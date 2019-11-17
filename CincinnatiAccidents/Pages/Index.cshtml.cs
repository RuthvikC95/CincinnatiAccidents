using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickTypeFire;
using QuickTypeTraffic;

namespace CincinnatiAccidents.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            //Retrieving traffic accident data and passing it to View
            String trafficJsonString = getJsonFromURL("https://data.cincinnati-oh.gov/resource/rvmt-pkmq.json");
            var trafficAccidents = TrafficAccident.FromJson(trafficJsonString);
            ViewData["trafficAccidents"] = trafficAccidents;

            //Retrieving fire accident data and passing it to View
            String fireJsonString = getJsonFromURL("https://data.cincinnati-oh.gov/resource/vnsz-a3wp.json");
            var fireAccidents = FireAccident.FromJson(fireJsonString);
            ViewData["fireAccidents"] = fireAccidents;

            
        }

        //Download data from website
        public string getJsonFromURL(string url)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(url);
            }
        }
    }
}
