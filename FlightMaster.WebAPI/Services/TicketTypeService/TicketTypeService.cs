using AutoMapper;
using FlightMaster.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.TicketTypeService
{
    public class TicketTypeService:ITicketTypeService
    {

        private readonly FlightMasterContext db;
        private readonly IMapper mapper;

        public TicketTypeService(FlightMasterContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public bool Delete(int id)
        {
            var data = db.TicketTypes.Where(x => x.Id == id).SingleOrDefault();

            if (data != null)
            {
                db.TicketTypes.Remove(data);
                db.SaveChanges();

                return true;
            }

            return false;
        }

        public List<TicketType> Get()
        {
            var list = db.TicketTypes.ToList();
            return mapper.Map<List<Model.TicketType>>(list);
        }

        public object GetModel(TicketType ticketType)
        {
            return mapper.Map<Database.ClassModels.TicketType>(ticketType);
        }

        public TicketType Insert(TicketType ticketType)
        {
            Database.ClassModels.TicketType type = new Database.ClassModels.TicketType();
            type = mapper.Map<Database.ClassModels.TicketType>(ticketType);

            db.TicketTypes.Add(type);
            db.SaveChanges();
            return mapper.Map<Model.TicketType>(type);

        }

        public bool SetFlightTicketDiscount(FlightTicketType ticketType)
        {
            //update old
            Database.ClassModels.FlightTicketType oldFlightTicket = db.FlightTicketTypes
                .Include(x=>x.TicketType)
                .Include(x=>x.FlightTicketLuxuries)
                .SingleOrDefault(x => x.Id == ticketType.Id);
            oldFlightTicket.MaxTickets = oldFlightTicket.MaxTickets - ticketType.MaxTickets;
            db.FlightTicketTypes.Update(oldFlightTicket);
            db.SaveChanges();
            //create new discounted

            Database.ClassModels.FlightTicketType DiscountTicket = new Database.ClassModels.FlightTicketType();
            DiscountTicket.Price = ticketType.Price;
            DiscountTicket.MaxTickets = ticketType.MaxTickets;
            DiscountTicket.FlightId = oldFlightTicket.FlightId;

            //creat new ticket type (this ticket type plus discount in name)
            Database.ClassModels.TicketType ticketType1 = db.TicketTypes.SingleOrDefault(x => x.Name.Contains("Discount") && x.Name.Contains(ticketType.TicketTypeName));
            int TickTypeId = 0;
            if (ticketType1 == null)
            {
                Database.ClassModels.TicketType NewTicketType = new Database.ClassModels.TicketType();
                NewTicketType.Name = ticketType.TicketTypeName + " " + "Discount";
                NewTicketType.Icon = oldFlightTicket.TicketType.Icon;
                db.TicketTypes.Add(NewTicketType);
                db.SaveChanges();
                 TickTypeId = NewTicketType.Id;
            }
            else
            {
                TickTypeId = ticketType1.Id;

            }
            DiscountTicket.TicketTypeID = TickTypeId;
            db.FlightTicketTypes.Add(DiscountTicket);
            db.SaveChanges();


            //copy all luxuries
            List<Database.ClassModels.FlightTicketLuxuries> DiscountLux = new List<Database.ClassModels.FlightTicketLuxuries>();
            foreach (var item in oldFlightTicket.FlightTicketLuxuries)
            {
                DiscountLux.Add(new Database.ClassModels.FlightTicketLuxuries()
                {
                    LuxuriesID = item.LuxuriesID,
                    FlightTicketTypeID = DiscountTicket.Id
                });
            }

            db.FlightTicketLuxuries.AddRange(DiscountLux);
            db.SaveChanges();

            return true;
        }

        public bool ChangeTicketDiscount(FlightTicketType ticketType)
        {

            //find old ticket
            string TicketTypeName = ticketType.TicketTypeName;
            var firstWord = TicketTypeName.Substring(0, TicketTypeName.IndexOf(" "));

            Database.ClassModels.FlightTicketType OldOne = db.FlightTicketTypes
                .Include(x => x.TicketType)
                .Where(x => x.TicketType.Name.Contains(firstWord) && x.FlightId==ticketType.FlightId).OrderBy(x => x.TicketType.Name.Length).First();

            Database.ClassModels.FlightTicketType discountOne = db.FlightTicketTypes.SingleOrDefault(x => x.Id == ticketType.Id);

            int Diference = discountOne.MaxTickets - ticketType.MaxTickets;

            //add back the tickets
            OldOne.MaxTickets = OldOne.MaxTickets + Diference;
            db.FlightTicketTypes.Update(OldOne);
            db.SaveChanges();

            //update discount one
            discountOne.MaxTickets = ticketType.MaxTickets;
            db.FlightTicketTypes.Update(discountOne);
            db.SaveChanges();


            return true;
        }

        public TicketType Update(TicketType ticketType)
        {
            Database.ClassModels.TicketType type = mapper.Map<Database.ClassModels.TicketType>(ticketType);
            db.TicketTypes.Update(type);
            db.SaveChanges();
            return mapper.Map<Model.TicketType>(type);
        }
    }
}
