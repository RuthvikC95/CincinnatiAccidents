using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CincinnatiAccidents.Models
{
    public class CitizenSurvey
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Please enter your name")]
        [Display (Name="Name")]
        public String Name { get; set; }

        [Display(Name="Neighbourhood")]
        [Required (ErrorMessage = "Neighbourhood is mandatory")]
        public String Neighbourhood { get; set; }

        [Display(Name="Road Condition")]
        [Required (ErrorMessage ="Road condition field is mandatory")]
        public String RoadCondition { get; set; }

        [Display(Name = "Cars Owned")]
        [Required(ErrorMessage = "Please enter no of cars owned. If you does not own a car, then please enter 0")]
        public int CarsOwned { get; set; }

        [Display (Name="Fire Safety")]
        [Required (ErrorMessage ="Fire Safety field is mandatory")]
        public String BuildingFireSafety { get; set; }

    }
}
