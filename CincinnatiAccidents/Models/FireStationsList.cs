using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CincinnatiAccidents.Models
{
    public static class FireStationsList
    {
        static FireStationsList()
        {
            allFireStations = new List<FireStations>();
        }

        public static IList<FireStations> allFireStations { get; set; }
    }
}
