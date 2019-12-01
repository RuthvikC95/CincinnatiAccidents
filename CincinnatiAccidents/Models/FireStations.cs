using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CincinnatiAccidents.Models
{
    public class FireStations
    {
        public string Neighbourhood { get; set; }
        public string FireStationNumber { get; set; }
        public string EngineCompany {get; set;}
        public int LadderCompany { get; set; }
        public string MedicUnit { get; set; }
        public int District { get; set; }
        public int Zip { get; set; }
    }
}
