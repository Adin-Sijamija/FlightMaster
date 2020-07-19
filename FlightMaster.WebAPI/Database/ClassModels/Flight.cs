using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

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
        public FlightStatus Status { get; set; }

        public int PlaneId { get; set; }
        [ForeignKey("PlaneId")]
        public Plane Plane { get; set; }

        public int Airfield1Id { get; set; }
        [ForeignKey("Airfield1Id")]
        public Airfield Airfield1 { get; set; }
        public int Airfield2Id { get; set; }
        [ForeignKey("Airfield2Id")]
        public Airfield Airfield2 { get; set; }

        public List<Ticket> Tickets { get; set; }
        public List<FlightTicketType> FlightTicketTypes { get; set; }


        public enum FlightStatus
        {
            OnTime=0,
            LateDeparture,
            LateArrival,
            DepartureDelayed,
            PostPoned,
            Rescheduled,
            Canceled,

        }
    }
}
