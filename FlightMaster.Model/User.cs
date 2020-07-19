using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get;  set; }
        public string Password { get; set; }
        public byte[] Picture { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
