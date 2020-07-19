using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.MobileModel
{
    public class UserRegistrationModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Picture { get; set; }

    }
}
