using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.Model
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public byte[] Picture { get; set; }

    }
}
