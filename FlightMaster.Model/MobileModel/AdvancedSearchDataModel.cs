using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.MobileModel
{
    public class AdvancedSearchDataModel
    {
        public int page;
        public string luxuiresId;
        public DateTime Mindate;
        public DateTime MaxDate;
        public int depCityId;
        public int arrCityId;

        public AdvancedSearchDataModel(int page, string luxuriesIds, DateTime mindate, DateTime maxDate, int depCityId, int arrCityId)
        {
            this.page = page;
            luxuiresId = luxuriesIds;
            Mindate = mindate;
            MaxDate = maxDate;
            this.depCityId = depCityId;
            this.arrCityId = arrCityId;
        }
    }
}
