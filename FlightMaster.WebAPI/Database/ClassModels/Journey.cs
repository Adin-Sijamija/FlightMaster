using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class Journey
    {
        [Key]
        public int Id { get; set; }
        
        public string StartCity { get; set; }
        public string EndCity { get; set; }
        
        public float TotalDuration { get; set; }
        public float TotalPrice { get; set; }

        public List<Ticket> Tickets { get; set; }

        public int CustomerId { get; set; }
        public User Customer { get; set; }

    }
}
