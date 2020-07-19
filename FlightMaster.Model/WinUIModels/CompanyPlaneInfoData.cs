using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.WinUIModels
{
    public class CompanyPlaneInfoData
    {
        public int Id { get; set; }
        public string PlaneName { get; set; }
        public string PlaneTypeName { get; set; }
        public int TotalPassangeres { get; set; }

        public string CompanyName { get; set; }

        public byte[] Picture { get; set; }




        //public int Id { get; set; }
        //public string Name { get; set; }
        //public PlaneType planeType { get; set; }

        //public Company company { get; set; }

    }
}
