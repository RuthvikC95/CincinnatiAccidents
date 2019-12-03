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
    public class AccidentsController : ControllerBase
    {
        [Obsolete]
        private readonly IHostingEnvironment _environment;
        public string Search { get; set; }
        public bool SearchCompleted { get; set; }
        public ICollection<TrafficAccident> trafficAccidents { get; set; }
        public ICollection<FireAccident> fireAccidents { get; set; }

        HashSet<string> locationNames = new HashSet<string>();

        public AccidentsController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        // GET: api/Neighbourhoods
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Accident>> GetAccident (string  id)
        {
            List<Accident> Accidents = new List<Accident>();
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
                Accident nh = new Accident();
                nh.Address = traffic.AddressX;
                nh.AccidentDate = traffic.Crashdate;
                nh.Latitude = traffic.LatitudeX;
                nh.Longitude = traffic.LongitudeX;
                nh.Neighborhood = traffic.CommunityCouncilNeighborhood;
                nh.accidentType = "traffic";
                Accidents.Add(nh);
            }

            foreach (FireAccident fire in fireAccidents)
            {
                Accident nh = new Accident();
                nh.Address = fire.AddressX;
                nh.AccidentDate = fire.CreateTimeIncident;
                nh.Latitude = fire.LatitudeX;
                nh.Longitude = fire.LongitudeX;
                nh.Neighborhood = fire.CommunityCouncilNeighborhood;
                nh.accidentType = "fire";
                Accidents.Add(nh);
            }
            return Accidents;
        }
    }

 }

