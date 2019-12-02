using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CincinnatiAccidents.Models
{
    public class FireStation
    {
        public int Id { get; set; }
        public string Neighbourhood { get; set; }
        public string FireStationNumber { get; set; }
        public string EngineCompany {get; set;}
        public string LadderCompany { get; set; }
        public string MedicUnit { get; set; }
        public string District { get; set; }
        public string Zip { get; set; }
    }
}
