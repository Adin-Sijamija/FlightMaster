using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.Model
{
    public class Airfield
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int CityId { get; set; }


    }
}
