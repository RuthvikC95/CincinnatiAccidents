using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CincinnatiAccidents.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CincinnatiAccidents.Pages.CitizenSurveys
{
        public class CreateModel : PageModel
        {
            private readonly IWebHostEnvironment _environment;

            public CreateModel(IWebHostEnvironment environment)
            {
                _environment = environment;
            }

            public IActionResult OnGet()
            {
                return Page();
            }

            [BindProperty]
            public CitizenSurvey CitizenSurvey { get; set; }

            public IActionResult OnPost()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                string station = CitizenSurvey.Name + "," + CitizenSurvey.Neighbourhood + "," + CitizenSurvey.CarsOwned + "," + CitizenSurvey.RoadCondition + "," + CitizenSurvey.BuildingFireSafety;
                string path = Path.Combine(_environment.ContentRootPath, "CitizenSurvey.txt");

                System.IO.File.AppendAllText(path, station + Environment.NewLine);

                return RedirectToPage("./Index");
            }
        }
    }
