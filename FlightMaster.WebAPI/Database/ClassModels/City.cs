using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<Airfield> Airfields { get; set; }

    }
}
