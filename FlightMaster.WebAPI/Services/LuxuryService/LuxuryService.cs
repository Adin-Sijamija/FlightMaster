using AutoMapper;
using FlightMaster.Model;
using FlightMaster.Model.WinUIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.LuxuryService
{
    public class LuxuryService : ILuxuryService
    {
        private readonly FlightMasterContext db;
        private readonly IMapper mapper;

        public LuxuryService(FlightMasterContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public FlightTicketLuxuries AddTicketLuxuries(FlightTicketLuxuries flightTicketLuxuries)
        {

            Database.ClassModels.FlightTicketLuxuries DbTicket = mapper.Map<Database.ClassModels.FlightTicketLuxuries>(flightTicketLuxuries);
            db.FlightTicketLuxuries.Add(DbTicket);
            db.SaveChanges();

            flightTicketLuxuries.Id = DbTicket.Id;
            return flightTicketLuxuries;
        }

        public bool RemoveTicketLuxuries(Model.FlightTicketLuxuries flightTicketLuxuries)
        {
            Database.ClassModels.FlightTicketLuxuries DbTicket = db.FlightTicketLuxuries.SingleOrDefault(x => x.FlightTicketTypeID ==flightTicketLuxuries.FlightTicketTypeID && x.LuxuriesID==flightTicketLuxuries.LuxuriesID); 
            db.FlightTicketLuxuries.Remove(DbTicket);
            db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            Database.ClassModels.Luxuries luxuries = db.Luxuries.SingleOrDefault(x => x.Id == id);

            if (luxuries == null)
                return false;

            List<Database.ClassModels.FlightTicketLuxuries> ticketLuxuries = db.FlightTicketLuxuries.Where(x => x.LuxuriesID == id).ToList();

            db.FlightTicketLuxuries.RemoveRange(ticketLuxuries);
            db.SaveChanges();

            if (luxuries != null)
            {
                db.Luxuries.Remove(luxuries);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Luxuries> GetAll()
        {
            List<Database.ClassModels.Luxuries> luxuries = db.Luxuries.ToList();
            return mapper.Map<List<Luxuries>>(luxuries);
        }

        public TicketLuxuriesDTF GetTicketLuxuries(int id)
        {
            List<Database.ClassModels.Luxuries> luxuries = db.Luxuries.ToList();
            List<Database.ClassModels.Luxuries> Takenlux = new List<Database.ClassModels.Luxuries>();

            List<Database.ClassModels.FlightTicketLuxuries> ticketLuxuries = db.FlightTicketLuxuries.Where(x => x.FlightTicketTypeID == id).ToList();

            foreach (var TickLux in ticketLuxuries)
            {
                foreach (var lux in luxuries)
                {
                    if (TickLux.LuxuriesID == lux.Id)
                        Takenlux.Add(lux);


                }
            }

            luxuries = luxuries.Except(Takenlux).ToList();

            TicketLuxuriesDTF dtf = new TicketLuxuriesDTF();
            dtf.id = id;
            dtf.TakenLuxuries = mapper.Map<List<Model.Luxuries>>(Takenlux);
            dtf.AvailabelLuxuries = mapper.Map<List<Model.Luxuries>>(luxuries);

            return dtf;
        }

        public Luxuries Insert(Luxuries luxuries)
        {
            Database.ClassModels.Luxuries DbLux = mapper.Map<Database.ClassModels.Luxuries>(luxuries);
            db.Luxuries.Add(DbLux);
            db.SaveChanges();

            luxuries.Id = DbLux.Id;
            return luxuries;
        }

     

        public Luxuries Update(Luxuries luxuries)
        {
            Database.ClassModels.Luxuries DbLux = mapper.Map<Database.ClassModels.Luxuries>(luxuries);
            db.Luxuries.Update(DbLux);
            db.SaveChanges();

            return mapper.Map<Model.Luxuries>(DbLux);

        }
    }
}
