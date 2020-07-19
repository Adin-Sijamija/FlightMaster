using FlightMaster.MobileApp.Services;
using FlightMaster.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.ViewModels.AdvancedSearchModels
{
    public class LuxuriesViewModel:BaseViewModel
    {
        ApiCaller api;

        private List<Luxuries> luxuries;
        public List<LuxuriesBinding> LuxuriesData;
        public List<int> LuxuryIds;

        public LuxuriesViewModel()
        {
            this.api =new ApiCaller();
            this.luxuries = new List<Luxuries>();
            LuxuriesData = new List<LuxuriesBinding>();
            LuxuryIds = new List<int>();
        }

        public async Task<bool> LoadData()
        {
            luxuries = await api.GetAll<List<Luxuries>>("Luxuries", "GetAll");

            foreach (var item in luxuries)
            {
                LuxuriesData.Add(new LuxuriesBinding(item));
            }

            return true;
        }

        public void SetIds(int id)
        {
            if (LuxuryIds.Count == 0) { LuxuryIds.Add(id); return; }

            bool Exsists = LuxuryIds.Contains(id);
            if (Exsists) { LuxuryIds.Remove(id); return; }

            LuxuryIds.Add(id);
            return;


        }




        public class LuxuriesBinding
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ImageSource Icon;
            public bool IsSelected { get; set; }

            public LuxuriesBinding(Luxuries lux)
            {
                Name = lux.Name;
                Id = lux.Id;
                Icon= ImageSource.FromStream(() => new MemoryStream(lux.Icon));
                IsSelected = false;
            }
        }


    }
}
