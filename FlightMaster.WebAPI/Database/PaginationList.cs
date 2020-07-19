using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Database
{
    public class PaginationList<T>
    {

        public List<T> data;
        public int PageSize;

        public PaginationList(List<T> data, int pageSize)
        {
            this.data = data;
            PageSize = pageSize;
        }

        public List<T> GetPage(int page)
        {
            List<T> PageData = new List<T>();
            if (data.Count == 0)
                return PageData;


            if (page < 1)
                return PageData;

            int startIndex = (page - 1) * PageSize;
           

            if (startIndex + PageSize > data.Count) {

                int lastpage = PageSize - ((startIndex + PageSize) - data.Count);

                PageData = data.GetRange(startIndex, lastpage);
                return PageData;
            }
            PageData = data.GetRange(startIndex, PageSize);
            return PageData;

        }
    }
}
