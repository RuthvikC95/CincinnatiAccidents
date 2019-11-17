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
            using (var webClient = new WebClient())
            {
                // pull in JSON stream for traffic accidents
                String trafficjsonString = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/rvmt-pkmq.json");
                var trafficAccidents = TrafficAccident.FromJson(trafficjsonString);
                ViewData["trafficAccidents"] = trafficAccidents;


                // pull in JSON stream for fire accidents
                String firejsonString = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/vnsz-a3wp.json");
                var fireAccidents = FireAccident.FromJson(firejsonString);
                ViewData["fireAccidents"] = fireAccidents;
            }
        }
    }
}
