using QuickTypeFire;
using QuickTypeTraffic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CincinnatiAccidents
{
    public class Accidents
    {
        public TrafficAccident[] GetTrafficAccident()
        {
            String trafficjsonString = GetData("https://data.cincinnati-oh.gov/resource/rvmt-pkmq.json");
            var trafficAccidents = TrafficAccident.FromJson(trafficjsonString);
            return trafficAccidents;
        }

        public FireAccident[] GetFireAccident()
        {
            String firejsonString = GetData("https://data.cincinnati-oh.gov/resource/vnsz-a3wp.json");
            var fireAccidents = FireAccident.FromJson(firejsonString);
            return fireAccidents;
        }

        private string GetData(string endpoint)
        {
            string downloadedData = "";
            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString(endpoint);

            }
            return downloadedData;
        }
    }
}
