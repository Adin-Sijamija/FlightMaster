using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Role { get; set; }
        public string Token { get; set; }

        public string Username { get; internal set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }



        public byte[] Picture  {get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public List<TicketPreferences> TicketPreferences { get; set; }
        public List<LuxuryPreferences> LuxuryPreferences { get; set; }
        public List<Journey> Journeys { get; set; }
    }
}
