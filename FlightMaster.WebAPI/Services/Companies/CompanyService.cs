using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlightMaster.Model;
using FlightMaster.Model.WinUIModels;
using FlightMaster.WebAPI.Database.ClassModels;
using Microsoft.EntityFrameworkCore;

namespace FlightMaster.WebAPI.Services.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly FlightMasterContext db;
        private readonly IMapper mapper;

        public CompanyService(FlightMasterContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public bool Delete(int id)
        {
            Database.ClassModels.Company comp = db.Companies.Where(x => x.Id == id).SingleOrDefault();
            if (comp==null)
            {
                return false;
            }

            db.Companies.Remove(comp);
            db.SaveChanges();
            return true;

        }

        public List<Model.Company> Get()
        {
            var list = db.Companies.ToList();
            return mapper.Map<List<Model.Company>>(list); 
        }

        public TestClass test()
        {
            Database.ClassModels.Plane plane = db.Planes.First();
            Database.ClassModels.PlaneType planetype = db.PlaneType.First();
            Database.ClassModels.Country country = db.Countries.First();
                
            TestClass test = new TestClass();

            mapper.Map<Database.ClassModels.Plane, TestClass>(plane,test);
            mapper.Map<Database.ClassModels.PlaneType, TestClass>(planetype, test);
            mapper.Map<Database.ClassModels.Country, TestClass>(country,test);


            return test;
        }

        public List<CompanyPlaneInfoData> getPlaneData(int id)
        {

            List<CompanyPlaneInfoData> data = new List<CompanyPlaneInfoData>();
            List<Database.ClassModels.Plane> planes = db.Planes.Where(x => x.CompanyId == id).Include(x => x.PlaneType).Include(x=>x.Company).ToList();

            data = mapper.Map<List<CompanyPlaneInfoData>>(planes);


            return data;


        }

        public Model.Company Insert(Model.Company company)
        {
            Database.ClassModels.Company dbcompany = mapper.Map<Database.ClassModels.Company>(company);
            db.Companies.Add(dbcompany);
            db.SaveChanges();

            
            return mapper.Map<Model.Company>(dbcompany);
        }
        public List<Model.Company> Search(int page, string search)
        {



            if (search.Trim() == "")
            {
                List<Database.ClassModels.Company> companies = db.Companies.ToList();
                List<Database.ClassModels.Company> pagedata = new List<Database.ClassModels.Company>();

                List<Model.Company> paged = new List<Model.Company>();

                int beginingIndex = 0;
                if (page == 1)
                    beginingIndex = 0;
                if (page > 1)
                    beginingIndex = page * 20;

                if (companies.Count < beginingIndex)
                {
                    return paged;
                }
                if (companies.Count > beginingIndex && companies.Count < (beginingIndex + 20))
                {
                    pagedata.AddRange(companies.GetRange(beginingIndex, companies.Count));

                    return paged = mapper.Map<List<Model.Company>>(pagedata);
                }


                pagedata.AddRange(companies.GetRange(beginingIndex, beginingIndex + 20));
                return paged = mapper.Map<List<Model.Company>>(pagedata);


            }
            else {

                List<Database.ClassModels.Company> companies = db.Companies.Where(x=>x.Name.Contains(search)).ToList();
                List<Database.ClassModels.Company> pagedata = new List<Database.ClassModels.Company>();

                List<Model.Company> paged = new List<Model.Company>();

                if (companies.Count > 0)
                {
                    int beginingIndex = 0;
                    if (page == 1)
                        beginingIndex = 0;
                    if (page > 1)
                        beginingIndex = page * 20;

                    if (companies.Count < beginingIndex)
                    {
                        return paged;
                    }
                    if (companies.Count > beginingIndex && companies.Count < (beginingIndex + 20))
                    {
                        pagedata.AddRange(companies.GetRange(beginingIndex, companies.Count));

                        return paged = mapper.Map<List<Model.Company>>(pagedata);
                    }

                    pagedata.AddRange(companies.GetRange(beginingIndex, beginingIndex + 20));
                    return paged = mapper.Map<List<Model.Company>>(pagedata);

                }
                return paged;

              

            }




        }

    
        public Model.Company Update(int id, Model.Company company)
        {
            Database.ClassModels.Company edited = db.Companies.Where(x => x.Id == id).SingleOrDefault();
            edited.Name = company.Name;
            edited.Picture = company.Picture;
            db.Companies.Update(edited);
            db.SaveChanges();

            return mapper.Map<Model.Company>(edited);

        }
    }
}
