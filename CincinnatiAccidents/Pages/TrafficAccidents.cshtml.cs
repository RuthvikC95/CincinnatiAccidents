using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CincinnatiAccidents.Pages
{
    public class TrafficAccidentsModel : PageModel
    {
        Accidents accidents = new Accidents();
        public void OnGet()
        {
                using (var webClient = new WebClient())
                {
                    ViewData["trafficAccidents"] = accidents.GetTrafficAccident();
                }
        }
    }
}
