using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels
{
    public class Airfield
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }


    }
}
