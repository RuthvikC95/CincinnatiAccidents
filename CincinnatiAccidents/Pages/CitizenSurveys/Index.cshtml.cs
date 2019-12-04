using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CincinnatiAccidents.Models;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace CincinnatiAccidents.Pages.CitizenSurveys
{
    public class IndexModel : PageModel
    {
        private readonly IHostingEnvironment _environment;

        public IndexModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IList<CitizenSurvey> CitizenSurvey = new List<CitizenSurvey>();

        public void OnGet()
        {
            string line;
            string path = Path.Combine(_environment.ContentRootPath, "CitizenSurvey.txt");
            StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                CitizenSurvey survey = new CitizenSurvey();
                survey.Name = data[0];
                survey.Neighbourhood = data[1];
                survey.CarsOwned = Int32.Parse(data[2]);
                survey.RoadCondition = data[3];
                survey.BuildingFireSafety = data[4];
               

                CitizenSurvey.Add(survey);
            }
            file.Close();
        }
    }
}
