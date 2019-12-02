using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CincinnatiAccidents.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net;
using Traffic;
using Fire;

namespace CincinnatiAccidents.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighbourhoodsController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;
        public string Search { get; set; }
        public bool SearchCompleted { get; set; }
        public ICollection<TrafficAccident> trafficAccidents { get; set; }
        public ICollection<FireAccident> fireAccidents { get; set; }

        HashSet<string> locationNames = new HashSet<string>();

        public NeighbourhoodsController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        // GET: api/Neighbourhoods
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Neighbourhood>> GetNeighbourhood(string  id)
        {
            List<Neighbourhood> Neighbourhood = new List<Neighbourhood>();
            string location = id;

            using (var webClient = new WebClient())
            {
                String trafficjsonString = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/rvmt-pkmq.json");
                trafficAccidents = TrafficAccident.FromJson(trafficjsonString);
                trafficAccidents = trafficAccidents.Where(x => x.CommunityCouncilNeighborhood.ToUpper().Equals(location.ToUpper())).ToArray();
                String firejsonString = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/vnsz-a3wp.json");
                fireAccidents = FireAccident.FromJson(firejsonString);
                fireAccidents = fireAccidents.Where(x => x.CommunityCouncilNeighborhood.ToUpper().Equals(location.ToUpper())).ToArray();

            }

            foreach (TrafficAccident traffic in trafficAccidents)
            {
                Neighbourhood nh = new Neighbourhood();
                nh.Address = traffic.AddressX;
                nh.AccidentDate = traffic.Crashdate;
                nh.Latitude = traffic.LatitudeX;
                nh.Longitude = traffic.LongitudeX;
                nh.Neighborhood = traffic.CommunityCouncilNeighborhood;
                nh.accidentType = "traffic";
                Neighbourhood.Add(nh);
            }

            foreach (FireAccident fire in fireAccidents)
            {
                Neighbourhood nh = new Neighbourhood();
                nh.Address = fire.AddressX;
                nh.AccidentDate = fire.CreateTimeIncident;
                nh.Latitude = fire.LatitudeX;
                nh.Longitude = fire.LongitudeX;
                nh.Neighborhood = fire.CommunityCouncilNeighborhood;
                nh.accidentType = "fire";
                Neighbourhood.Add(nh);
            }
            return Neighbourhood;
        }
    }

 }

