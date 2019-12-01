using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CincinnatiAccidents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CincinnatiAccidents.Pages
{
    public class FireStationsDashboardModel : PageModel
    {
        IList<FireStations> fireStations { get; set; }
        public void OnGet()
        {
            fireStations = FireStationsList.allFireStations;
            ViewData["FireStationsList"] = fireStations;
        }
    }
}