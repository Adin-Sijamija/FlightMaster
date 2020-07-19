using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.Model
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }

        public string Duration { get; set; }
        public int Status { get; set; }

        public int PlaneId { get; set; }

       
    }
}
