using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Database.ClassModels
{
    public class PlaneType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int TotalPassangeres { get; set; }
  
    }
}
