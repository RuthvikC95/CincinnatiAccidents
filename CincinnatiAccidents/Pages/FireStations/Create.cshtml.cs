using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CincinnatiAccidents.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CincinnatiAccidents.Pages.FireStations
{
    public class CreateModel : PageModel
    {
        private readonly IHostingEnvironment _environment;

        public CreateModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FireStation FireStation { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string station = FireStation.Neighbourhood + "," + FireStation.FireStationNumber + "," + FireStation.EngineCompany + "," + FireStation.LadderCompany + "," + FireStation.MedicUnit + "," + FireStation.District + "," + FireStation.Zip;
            string path = Path.Combine(_environment.ContentRootPath, "FireStations.txt");

            System.IO.File.AppendAllText(path, station + Environment.NewLine);

            return RedirectToPage("./Index");
        }
    }
}
