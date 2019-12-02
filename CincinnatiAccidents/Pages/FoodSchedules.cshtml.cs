using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CincinnatiAccidents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CincinnatiAccidents.Pages
{
    public class FoodSchedulesModel : PageModel
    {
        public ICollection<FoodSchedule> foodSchedules { get; set; }
        public void OnGet()
        {
            foreach (FoodSchedule schedule in foodSchedules)
            { 
                using (var webClient = new WebClient())
                {
                    String trafficjsonString = webClient.DownloadString("https://mobilefoodschedules.azurewebsites.net/api/saapprovedfoodschedules");
                    foodSchedules = FoodSchedule.FromJson(trafficjsonString);
                }
                ViewData["FoodSchedules"] = foodSchedules;
            }


        }
    }
}