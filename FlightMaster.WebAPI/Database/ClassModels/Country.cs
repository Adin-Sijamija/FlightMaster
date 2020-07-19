using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(4)]
        public string ShortName { get; set; }
        public List<City> Cities { get; set; }
    }
}
