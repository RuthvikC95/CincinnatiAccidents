using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Traffic;
using Fire;
using System.Net;

namespace CincinnatiAccidents.Pages
{
    public class SummaryModel : PageModel
    {
        public string Search { get; set; }
        public bool SearchCompleted { get; set; }
        public ICollection<TrafficAccident> trafficAccidents { get; set; }
        public ICollection<FireAccident> fireAccidents { get; set; }

        HashSet<string> locationNames = new HashSet<string>();

        public SummaryModel()
        {
            using (var webClient = new WebClient())
            {
                String trafficjsonString = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/rvmt-pkmq.json");
                trafficAccidents = TrafficAccident.FromJson(trafficjsonString);

                String firejsonString = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/vnsz-a3wp.json");
                fireAccidents = FireAccident.FromJson(firejsonString);
            }
        }
        public void OnGet()
        {
            SearchCompleted = false;
            foreach (Traffic.TrafficAccident traffic in trafficAccidents)
            {
                if (!traffic.CommunityCouncilNeighborhood.Equals("N/A"))
                {
                    locationNames.Add(traffic.CommunityCouncilNeighborhood.ToUpper());
                }
            }

            foreach (Fire.FireAccident fire in fireAccidents)
            {
                if (!fire.CommunityCouncilNeighborhood.Equals("N/A"))
                {
                    locationNames.Add(fire.CommunityCouncilNeighborhood.ToUpper());
                }
            }
            
            ViewData["LocationNames"] = locationNames;
            ViewData["trafficAccidents"] = trafficAccidents;
            ViewData["fireAccidents"] = fireAccidents;
        }
    }
}