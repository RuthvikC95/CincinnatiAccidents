using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CincinnatiAccidents.Models
{
    public class FireStation
    {
        public int Id { get; set; }
        public string Neighbourhood { get; set; }
        [Display(Name = "Fire Station Number")]
        public string FireStationNumber { get; set; }
        [Display(Name = "Engine Company")]
        public string EngineCompany {get; set;}
        [Display(Name = "Ladder Company")]
        public string LadderCompany { get; set; }
        [Display(Name = "Medical Unit")]
        public string MedicUnit { get; set; }
        public string District { get; set; }
        public string Zip { get; set; }
    }
}
