using FlightMaster.Model;
using FlightMaster.Model.WinUIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.Companies
{
    public interface ICompanyService
    {
        List<Company> Get();

        Company Insert(Company company);
        List<Company> Search(int page, string search);
        Company Update(int id, Company company);

        bool Delete(int id);
        List<CompanyPlaneInfoData> getPlaneData(int id);
        TestClass test();
    }
}
