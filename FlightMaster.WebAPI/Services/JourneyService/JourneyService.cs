using AutoMapper;
using FlightMaster.Model.MobileModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.JourneyService
{
    public class JourneyService:IJourneyService
    {

        private readonly FlightMasterContext db;
        private readonly IMapper mapper;

        public JourneyService(FlightMasterContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public bool AddJourney(JourneyInsertModel model)
        {

            try
            {
                Database.ClassModels.Journey NewJourney = new Database.ClassModels.Journey();

                int totalTickets = 0; double TotalPrice = 0;

                foreach (var item in model.ticketsTobeAddeds)
                {
                    totalTickets += item.TicketCount;
                    TotalPrice += item.TicketCount * item.Price;
                }

                NewJourney.CustomerId = model.UserId;
                NewJourney.TotalPrice =(float) TotalPrice;

                db.Journeys.Add(NewJourney);
                db.SaveChanges();

                int count = 1;
                string StartCity = "";
                string EndCity = "";

                foreach (var item in model.ticketsTobeAddeds)
                {
                    for (int i = 0; i < item.TicketCount; i++)
                    {

                        Database.ClassModels.Ticket ticket = new Database.ClassModels.Ticket();
                        ticket.JourneyId = NewJourney.Id;
                        ticket.FlightTicketTypeId = item.FlightTicketTypeID;
                        ticket.FlightId= item.FlightId;
                        ticket.TicketStatus = "Not Checked In";

                        Database.ClassModels.Flight flight = db.Flights
                            .Include(x=>x.Airfield1).ThenInclude(x=>x.City).ThenInclude(x=>x.Country)
                            .Include(x=>x.Airfield2).ThenInclude(x=>x.City).ThenInclude(x => x.Country)
                            .SingleOrDefault(x => x.Id == item.FlightId);

                        if (count == 1)
                        {
                            StartCity = flight.Airfield1.City.Name;

                        }

                        if(count== model.ticketsTobeAddeds.Count)
                        {
                          EndCity = flight.Airfield2.City.Name;
                        }

                        bool NameExsists = true;
                        do
                        {

                            Random rand = new Random();
                            int tickNumber = rand.Next(100, 39999);
                            ticket.Name = flight.Airfield1.City.Country.ShortName+":"+ flight.Airfield1.City.ShortName
                                + flight.Airfield2.City.Country.ShortName + ":" + flight.Airfield2.City.ShortName
                                + tickNumber.ToString();

                            Database.ClassModels.Ticket ticket1 = db.Tickets.SingleOrDefault(x => x.Name == ticket.Name);

                            if (ticket1 == null)
                                NameExsists = false;


                        } while (NameExsists);


                        db.Tickets.Add(ticket);
                        db.SaveChanges();

                        Database.ClassModels.FlightTicketType flightTicketType = db.FlightTicketTypes.SingleOrDefault(x => x.FlightId == flight.Id && x.Id == ticket.FlightTicketTypeId);
                        ++flightTicketType.CurrentTickets;
                        db.FlightTicketTypes.Update(flightTicketType);
                        db.SaveChanges();

                    }

                    ++count;

                }


                NewJourney.StartCity = StartCity;
                NewJourney.EndCity= EndCity;

                db.Journeys.Update(NewJourney);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        
        }

        public List<UserJourneyInfoModel> GetFutureUserJourneys(int userId)
        {

            List<Database.ClassModels.Journey> journeys = db.Journeys.Where(x => x.CustomerId == userId).ToList();
            List<UserJourneyInfoModel> userJourneyInfoModels = new List<UserJourneyInfoModel>();


            foreach (var item in journeys)
            {
                bool IsOldJourney = true;

                UserJourneyInfoModel newlyCreated = new UserJourneyInfoModel();
                newlyCreated.ticketsInfos = new List<UserJourneyTicketsInfo>();
                newlyCreated.Journey = mapper.Map<Model.Journey>(item);

                List<Database.ClassModels.Ticket> JoourneyTickets = db.Tickets
                    .Include(x=>x.Flight)
                    .Include(x=>x.FlightTicketType)
                        .ThenInclude(x=>x.TicketType)
                    .Where(x => x.JourneyId == item.Id).ToList();

                foreach (var ticket in JoourneyTickets)
                {

                    if (ticket.Flight.StartDate > DateTime.Now)
                        IsOldJourney = false; 

                    UserJourneyTicketsInfo userJourneyTicketsInfo = new UserJourneyTicketsInfo();
                    userJourneyTicketsInfo.TicketId = ticket.Id;
                    userJourneyTicketsInfo.FlightName = ticket.Flight.Name;
                    userJourneyTicketsInfo.FlightStatus = ticket.Flight.Status.ToString();
                    userJourneyTicketsInfo.FlightDate = ticket.Flight.StartDate.ToShortDateString()+" "+ticket.Flight.StartDate.ToShortTimeString()+":"+ticket.Flight.EndDate.ToShortTimeString();
                    userJourneyTicketsInfo.Name = ticket.Name;
                    userJourneyTicketsInfo.Price = ticket.FlightTicketType.Price;
                    userJourneyTicketsInfo.TicketType = ticket.FlightTicketType.TicketType.Name;
                    userJourneyTicketsInfo.TicketStatus = ticket.TicketStatus;

                    newlyCreated.ticketsInfos.Add(userJourneyTicketsInfo);

                }



                if (!IsOldJourney)
                    userJourneyInfoModels.Add(newlyCreated);
            }


            return userJourneyInfoModels;
        }


        public List<UserJourneyInfoModel> GetUserPastJourneys(int userId)
        {
            List<Database.ClassModels.Journey> journeys = db.Journeys.Where(x => x.CustomerId == userId).ToList();
            List<UserJourneyInfoModel> userJourneyInfoModels = new List<UserJourneyInfoModel>();


            foreach (var item in journeys)
            {
                bool IsOldJourney = false;

                UserJourneyInfoModel newlyCreated = new UserJourneyInfoModel();
                newlyCreated.ticketsInfos = new List<UserJourneyTicketsInfo>();
                newlyCreated.Journey = mapper.Map<Model.Journey>(item);

                List<Database.ClassModels.Ticket> JoourneyTickets = db.Tickets
                    .Include(x => x.Flight)
                    .Include(x => x.FlightTicketType)
                        .ThenInclude(x => x.TicketType)
                    .Where(x => x.JourneyId == item.Id).ToList();

                foreach (var ticket in JoourneyTickets)
                {

                    if (ticket.Flight.EndDate < DateTime.Now)
                        IsOldJourney = true;

                    UserJourneyTicketsInfo userJourneyTicketsInfo = new UserJourneyTicketsInfo();
                    userJourneyTicketsInfo.TicketId = ticket.Id;
                    userJourneyTicketsInfo.FlightName = ticket.Flight.Name;
                    userJourneyTicketsInfo.FlightStatus = ticket.Flight.Status.ToString();
                    userJourneyTicketsInfo.FlightDate = ticket.Flight.StartDate.ToShortDateString()+" "+ticket.Flight.StartDate.ToShortTimeString()+":"+ticket.Flight.EndDate.ToShortTimeString();
                    userJourneyTicketsInfo.Name = ticket.Name;
                    userJourneyTicketsInfo.Price = ticket.FlightTicketType.Price;
                    userJourneyTicketsInfo.TicketType = ticket.FlightTicketType.TicketType.Name;
                    userJourneyTicketsInfo.TicketStatus = ticket.TicketStatus;

                    newlyCreated.ticketsInfos.Add(userJourneyTicketsInfo);

                }



                if(IsOldJourney)
                    userJourneyInfoModels.Add(newlyCreated);
            }

          

            return userJourneyInfoModels;

        }

        public List<UserJourneyTicketsInfo> GetJourneyDataCheck(int journeyId)
        {
            List<UserJourneyTicketsInfo> data = new List<UserJourneyTicketsInfo>();



            List<Database.ClassModels.Ticket> JoourneyTickets = db.Tickets
                  .Include(x => x.Flight)
                  .Include(x => x.FlightTicketType)
                      .ThenInclude(x => x.TicketType)
                  .Where(x => x.JourneyId == journeyId).ToList();

            foreach (var ticket in JoourneyTickets)
            {

                UserJourneyTicketsInfo userJourneyTicketsInfo = new UserJourneyTicketsInfo();
                userJourneyTicketsInfo.TicketId = ticket.Id;
                userJourneyTicketsInfo.FlightName = ticket.Flight.Name;
                userJourneyTicketsInfo.FlightStatus = ticket.Flight.Status.ToString();
                userJourneyTicketsInfo.Name = ticket.Name;
                userJourneyTicketsInfo.Price = ticket.FlightTicketType.Price;
                userJourneyTicketsInfo.TicketType = ticket.FlightTicketType.TicketType.Name;
                userJourneyTicketsInfo.TicketStatus = ticket.TicketStatus;

                data.Add(userJourneyTicketsInfo);
            }


            return data;

        }

        public List<UserFutureJourneysData> GetFutureJourneysData(int userId)
        {

            List<UserFutureJourneysData> data = new List<UserFutureJourneysData>();

            List<Database.ClassModels.Journey> journeys = db.Journeys
                .Include(x=>x.Tickets)
                .ThenInclude(x=>x.Flight)
                .Where(x => x.CustomerId == userId).ToList();

            foreach (var journey in journeys)
            {
                bool IsOldJourney = false;
                UserFutureJourneysData data1 = new UserFutureJourneysData();
                data1.Journey = mapper.Map<Model.Journey>(journey);
                data1.Flights = new List<Model.Flight>();
                foreach (var ticket in journey.Tickets)
                {

                    var added = data1.Flights.SingleOrDefault(x => x.Id == ticket.FlightId);
                    if (added == null)
                    {
                        Model.Flight flight = mapper.Map<Model.Flight>(ticket.Flight);
                        data1.Flights.Add(flight);
                    }

                }
                data1.TotalTickets=journey.Tickets.Count;
               IsOldJourney= data1.Flights.Last().EndDate < DateTime.Now;

                if (!IsOldJourney)
                    data.Add(data1);

            }

            return data;
        }

        public List<UserJourneyTicketsInfo> GetUserFlightTickets(int flightId, int userId)
        {
            List<UserJourneyTicketsInfo> data = new List<UserJourneyTicketsInfo>();
            List<Database.ClassModels.Ticket> tickets = db.Tickets
                .Include(x=>x.Flight)
                .Include(x=>x.Journey)
                .Include(x=>x.FlightTicketType)
                .ThenInclude(x=>x.TicketType)
                .Where(x => x.Journey.CustomerId == userId && x.FlightId == flightId).ToList();

            foreach (var item in tickets)
            {
                UserJourneyTicketsInfo data1 = new UserJourneyTicketsInfo();
                data1.TicketId = item.Id;
                data1.FlightName = item.Flight.Name;
                data1.FlightDate = item.Flight.StartDate.ToShortDateString();
                data1.FlightStatus = item.Flight.Status.ToString();
                data1.Name = item.Name;
                data1.Price = item.FlightTicketType.Price;
                data1.TicketType = item.FlightTicketType.TicketType.Name;
                data1.TicketStatus = item.TicketStatus;
                data.Add(data1);
            }


            return data;
        }

        public UserFlightLocationsDTO GetUserFlightLocations(int flightId)
        {

            Database.ClassModels.Flight flight = db.Flights
                .Include(x => x.Airfield1)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Country)
                .Include(x => x.Airfield2)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Country)
                .SingleOrDefault(x => x.Id == flightId);

            UserFlightLocationsDTO userFlightLocationsDTO = new UserFlightLocationsDTO();
            userFlightLocationsDTO.DepartureLocation = flight.Airfield1.City.Country.Name + ":" + flight.Airfield1.City.Name + ":" + flight.Airfield1.Name;
            userFlightLocationsDTO.ArrivalLocation = flight.Airfield2.City.Country.Name + ":" + flight.Airfield2.City.Name + ":" + flight.Airfield2.Name;

            return userFlightLocationsDTO;
        }
    }
}
