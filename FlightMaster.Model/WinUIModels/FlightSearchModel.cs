using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.WinUIModels
{
    public class FlightSearchModel
    {

        public int page { get; set; }

        public bool DateSearch { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int PlaneTypeId { get; set; }
        public int CompanyId { get; set; }

        public int StatusId { get; set; }

        public int DepCountryId { get; set; }
        public int DepCityId { get; set; }
        public int DepAirfieldId { get; set; }
        public int ArrCountryID { get; set; }
        public int ArrCityId { get; set; }
        public int ArrAirfieldID { get; set; }

        public int OrderBy { get; set; }


    
        public void SetDefaultData()
        {
            page = 1;
            DateSearch=false;

            PlaneTypeId = -1;
            CompanyId = -1;
            DepCountryId = -1;
            DepCityId = -1;
            DepAirfieldId = -1;
            ArrCountryID = -1;
            ArrCityId = -1;
            StatusId = -1;
            ArrAirfieldID = -1;
            StartDate = DateTime.UtcNow;
            EndDate= DateTime.UtcNow;
            OrderBy = 1;
        }

    }
}
