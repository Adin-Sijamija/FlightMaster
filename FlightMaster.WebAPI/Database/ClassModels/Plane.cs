using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class Plane
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int PlaneTypeId { get; set; }
        public PlaneType PlaneType { get; set; }


    }
}
