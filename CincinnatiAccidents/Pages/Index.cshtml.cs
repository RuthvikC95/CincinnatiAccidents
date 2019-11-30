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
                QuickTypeTraffic.TrafficAccident [] trafficAccidents2 = QuickTypeTraffic.TrafficAccident.FromJson(trafficjsonString);
               ViewData["trafficAccidents"] = trafficAccidents;

              

                IDictionary<string, QuickTypeTraffic.TrafficAccident> TrafficAccidentDictionary = new Dictionary<string, QuickTypeTraffic.TrafficAccident>();

                /* foreach (QuickTypeTraffic.TrafficAccident accident in trafficAccidents)
                 {
                     TrafficAccidentDictionary.Add(accident.CpdNeighborhood, accident);
                 } */ // Commenting this piece of code as there is an error while populating this "STRING" dictionary


                // pull in JSON stream for fire accidents
                String firejsonString = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/vnsz-a3wp.json");
                var fireAccidents = FireAccident.FromJson(firejsonString);
                QuickTypeFire.FireAccident[] fireAccidents2 = QuickTypeFire.FireAccident.FromJson(firejsonString);
                ViewData["fireAccidents"] = fireAccidents;

                IDictionary<string, QuickTypeFire.FireAccident> FireAccidentDictionary = new Dictionary<string, QuickTypeFire.FireAccident>();


                /* foreach (QuickTypeFire.FireAccident accident in fireAccidents)
                 {
                     FireAccidentDictionary.Add(accident.Neighborhood, accident);
                 } */ // Commenting this piece of code as there is an error while populating this "STRING" dictionary


                /*string neighborhoodjsonstring = webClient.DownloadString("https://cagisonline.hamilton-co.org/arcgis/rest/services/COUNTYWIDE/CagisCoreLayers/MapServer/11/query?where=1%3D1&outFields=*&outSR=4326&f=json");

                QuickType.Attributes[] neighborhood  = QuickType.Attributes.FromJson(neighborhoodjsonstring);
                
                List<QuickType.Attributes> allneighborhoods = neighborhood.Nbdname;

                List<string> Accidentproneneighborhoods = new List<string>();
                       
                foreach (QuickType.Attributes attribute in allneighborhoods)
                {
                    Console.WriteLine(attribute.nbdname);

                       if (TrafficAccidentDictionary.ContainsKey(attribute.nbdname) || FireAccidentDictionary.ContainsKey(attribute.nbdname))
                    {
                        Accidentproneneighborhoods.Add(nbdname); 
                    }
                }*/ //This piece of code is intended to check if a neighborhood is safe or not based on its presence in the traffic accidents dataset and fire accidents dataset. However, for this code to work the dictionaries should be populated, first.
            }
        }
    }
}
