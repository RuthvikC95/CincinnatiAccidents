using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CincinnatiAccidents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CincinnatiAccidents.Pages
{
    public class AddFireStationModel : PageModel
    {
        private readonly ILogger<AddFireStationModel> _logger;
        [BindProperty]
        public FireStations fireStation { get; set; }
        public AddFireStationModel(ILogger<AddFireStationModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

        }

        public void onPost()
        {
            string stationList = fireStation.Neighbourhood + fireStation.FireStationNumber + fireStation.EngineCompany + fireStation.LadderCompany + fireStation.MedicUnit + fireStation.District + fireStation.Zip;
            FireStationsList.allFireStations.Add(fireStation);
            Console.WriteLine(fireStation);

        }
    }
}