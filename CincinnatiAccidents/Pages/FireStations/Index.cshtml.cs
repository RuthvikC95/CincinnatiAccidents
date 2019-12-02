using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CincinnatiAccidents.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CincinnatiAccidents.Pages.FireStations
{
    public class IndexModel : PageModel
    {
        private readonly IHostingEnvironment _environment;

        public IndexModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IList<FireStation> FireStation = new List<FireStation>();

        public void OnGet()
        {
            string line;
            string path = Path.Combine(_environment.ContentRootPath, "FireStations.txt");
            StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                FireStation firSt = new FireStation();
                firSt.Neighbourhood = data[0];
                firSt.FireStationNumber = data[1];
                firSt.EngineCompany = data[2];
                firSt.LadderCompany = data[3];
                firSt.MedicUnit = data[4];
                firSt.District = data[5];
                firSt.Zip = data[6];
            }
        }

    }
}
