using AutoMapper;
using FlightMaster.Model;
using FlightMaster.Model.MobileModel;
using FlightMaster.Model.WinUIModels;
using FlightMaster.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.Flight
{
    public class FlightService : IFlightService
    {
        private readonly FlightMasterContext db;
        private readonly IMapper mapper;

        public FlightService(FlightMasterContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }



        public bool DeleteAll()
        {
            List<Database.ClassModels.Flight> flights = db.Flights.ToList();
            db.Flights.RemoveRange(flights);
            db.SaveChanges();
            return true;
        }

        public bool DeleteFlight(int id)
        {

            Database.ClassModels.Flight flight = db.Flights
                .Include(x => x.FlightTicketTypes)
                .ThenInclude(x => x.FlightTicketLuxuries)
                .SingleOrDefault(x => x.Id == id);

            foreach (var item in flight.FlightTicketTypes)
            {
                if (item.FlightTicketLuxuries.Count > 0)
                {
                    db.FlightTicketLuxuries.RemoveRange(item.FlightTicketLuxuries);
                    db.SaveChanges();
                }
            }
            db.FlightTicketTypes.RemoveRange(flight.FlightTicketTypes);
            db.SaveChanges();

            db.Flights.Remove(flight);
            db.SaveChanges();
            return true;
        }

        public bool DeleteTicketType(int id)
        {

            Database.ClassModels.FlightTicketType flightTicketType = db.FlightTicketTypes.SingleOrDefault(x => x.Id == id);

            if (flightTicketType == null)
                return false;

            db.FlightTicketTypes.Remove(flightTicketType);


            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }


            return true;



        }

        public bool GenerateData(int number, DateTime min, DateTime max)
        {

            List<Database.ClassModels.Airfield> airfields = db.Airfields
                .Include(x => x.City)
                .ThenInclude(x => x.Country)
                .ToList();
            List<Database.ClassModels.Plane> planes = db.Planes.Include(x => x.PlaneType).ToList();
            List<Database.ClassModels.TicketType> tickets = db.TicketTypes.Where(x => !x.Name.Contains("Discount")).ToList();


            for (int i = 0; i < number; i++)
            {

                Database.ClassModels.Flight flight = new Database.ClassModels.Flight();

                int range = airfields.Count;

                int Dep = -1;
                int Arr = -1;

                Random random = new Random();
                while (Dep == Arr && Dep == -1 && Arr == -1)
                {

                    Dep = random.Next(0, range);
                    Arr = random.Next(0, range);

                }
                flight.Airfield1Id = airfields.ElementAt(Dep).Id;
                flight.Airfield2Id = airfields.ElementAt(Arr).Id;

                flight.PlaneId = planes.ElementAt(random.Next(0, planes.Count)).Id;


                TimeSpan timeSpan = max - min;
                var randomTest = new Random();
                TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
                DateTime newDate = min + newSpan;

                flight.StartDate = newDate;
                flight.EndDate = newDate;
                double extarH = (double)random.Next(1, 8);
                flight.EndDate = flight.EndDate.AddHours(extarH);
                flight.EndDate = flight.EndDate.AddMinutes(random.Next(0, 60));
                TimeSpan flightduration = (flight.EndDate - flight.StartDate);
                flight.Duration = string.Format("{0:00}:{1:00}", (int)flightduration.TotalHours, flightduration.Minutes);

                flight.Name = airfields.ElementAt(Dep).City.Country.ShortName + ":" + airfields.ElementAt(Dep).City.ShortName + "--" + airfields.ElementAt(Arr).City.Country.ShortName + ':' + airfields.ElementAt(Arr).City.ShortName + ' ' + flight.StartDate.ToShortDateString();


                db.Flights.Add(flight);
                db.SaveChanges();

                //Generate random flight Tickets
                List<Database.ClassModels.FlightTicketType> flightTicketTypes = new List<Database.ClassModels.FlightTicketType>();


                int PlaneCapacity = planes.Where(x => x.Id == flight.PlaneId).Select(x => x.PlaneType.TotalPassangeres).SingleOrDefault();
                int TicketCount = random.Next(1, tickets.Count);
                int currentTickets = 0;


                for (int z = 0; z < TicketCount; z++)
                {

                    int randomprice = random.Next(100, 800);
                    int randomTicketsNumber = random.Next(50, 150);

                    if (TicketCount == 1)
                    {
                        Database.ClassModels.FlightTicketType NewOneTicket = new Database.ClassModels.FlightTicketType();
                        NewOneTicket.FlightId = flight.Id;
                        NewOneTicket.MaxTickets = PlaneCapacity;
                        NewOneTicket.CurrentTickets = 0;
                        NewOneTicket.Price = randomprice;
                        int randTicket = random.Next(tickets.Count);
                        NewOneTicket.TicketTypeID = tickets[randTicket].Id;

                        flightTicketTypes.Add(NewOneTicket);
                        break;
                    }

                    bool FlightTicketExsists = true;
                    do
                    {
                        Database.ClassModels.FlightTicketType newTicket = new Database.ClassModels.FlightTicketType();
                        newTicket.FlightId = flight.Id;
                        newTicket.CurrentTickets = 0;
                        newTicket.Price = randomprice;
                        int randTicket = random.Next(tickets.Count);
                        newTicket.TicketTypeID = tickets[randTicket].Id;

                        newTicket.MaxTickets = randomTicketsNumber;
                        currentTickets += randomTicketsNumber;

                        if (PlaneCapacity < currentTickets)
                        {
                            newTicket.MaxTickets = currentTickets - PlaneCapacity;
                        }


                        Database.ClassModels.FlightTicketType exsists = flightTicketTypes.Where(x => x.FlightId == flight.Id && x.TicketTypeID == newTicket.TicketTypeID).SingleOrDefault();

                        if (exsists == null)
                        {
                            flightTicketTypes.Add(newTicket);
                            FlightTicketExsists = false;
                        }



                    } while (FlightTicketExsists = false);



                }


                db.FlightTicketTypes.AddRange(flightTicketTypes);
                db.SaveChanges();


                // Add Ticket Luxuries randomly
                List<Database.ClassModels.Luxuries> luxuries = db.Luxuries.ToList();
                int maxlux = luxuries.Count;

                foreach (var ticket in flightTicketTypes)
                {

                    int IntRandomTimes = random.Next(0, maxlux);

                    for (int j = 0; j < IntRandomTimes; j++)
                    {


                        bool Exsists = true;
                        do
                        {
                            int RandLux = random.Next(0, maxlux - 1);

                            Database.ClassModels.FlightTicketLuxuries newlyCreated = new Database.ClassModels.FlightTicketLuxuries()
                            {
                                LuxuriesID = luxuries[RandLux].Id,
                                FlightTicketTypeID = ticket.Id,


                            };

                            Database.ClassModels.FlightTicketLuxuries exsists = db.FlightTicketLuxuries.SingleOrDefault(x => x.FlightTicketTypeID == newlyCreated.FlightTicketTypeID && x.LuxuriesID == newlyCreated.LuxuriesID);

                            if (exsists == null)
                            {
                                db.FlightTicketLuxuries.Add(newlyCreated);
                                db.SaveChanges();
                                Exsists = false;
                            }


                        } while (Exsists);





                    }


                }


            }

            return true;

        }

        public List<Model.Flight> GetAll()
        {
            return mapper.Map<List<FlightMaster.Model.Flight>>(db.Flights.ToList());
        }

        public List<FlightInfoClass> GetFlightInfo(FlightSearchModel flightSearchModel)
        {
            List<Database.ClassModels.Flight> flights = db.Flights
                .Include(x => x.Airfield1)
                    .ThenInclude(x => x.City)
                        .ThenInclude(x => x.Country)
                .Include(x => x.Airfield2)
                    .ThenInclude(x => x.City)
                        .ThenInclude(x => x.Country)
                .Include(x => x.Plane)
                    .ThenInclude(x => x.PlaneType)
                .Include(x => x.Plane)
                    .ThenInclude(x => x.Company)
                .Include(x => x.FlightTicketTypes)
                .Include(x => x.Tickets)
                .ToList();


            List<Database.ClassModels.Flight> flights1 = new List<Database.ClassModels.Flight>();


            if (flightSearchModel.StartDate.Date == flightSearchModel.EndDate.Date)
            {
                flights1.AddRange(flights.Where(x => x.StartDate < DateTime.Now.AddDays(-1)).ToList());

                flights = flights.Except(flights1).ToList();
                flights1.Clear();
            }
            else
            {
                foreach (var item in flights)
                {

                    if (flightSearchModel.StartDate.Year != 2000)
                    {
                        if (item.StartDate < flightSearchModel.StartDate)
                            flights1.Add(item);
                        continue;
                    }

                    if (flightSearchModel.EndDate.Year != 2000)
                    {
                        if (item.StartDate > flightSearchModel.StartDate)
                            flights1.Add(item);
                    }

                }

                flights = flights.Except(flights1).ToList();
                flights1.Clear();
            }






            if (flightSearchModel.StatusId != -1)
            {
                flights1.AddRange(flights.Where(x => (int)x.Status != flightSearchModel.StatusId).ToList());
                flights = flights.Except(flights1).ToList();
                flights1.Clear();
            }



            if (flightSearchModel.DepAirfieldId != -1)
            {
                flights1.AddRange(flights.Where(x => x.Airfield1.Id != flightSearchModel.DepAirfieldId).ToList());
                flights = flights.Except(flights1).ToList();
                flights1.Clear();
            }

            if (flightSearchModel.DepCityId != -1)
            {
                flights1.AddRange(flights.Where(x => x.Airfield1.City.Id != flightSearchModel.DepCityId).ToList());
                flights = flights.Except(flights1).ToList();
                flights1.Clear();
            }

            if (flightSearchModel.DepCountryId != -1)
            {
                flights1.AddRange(flights.Where(x => x.Airfield1.City.CountryId != flightSearchModel.DepCountryId).ToList());
                flights = flights.Except(flights1).ToList();
                flights1.Clear();
            }



            if (flightSearchModel.ArrAirfieldID != -1)
            {
                flights1.AddRange(flights.Where(x => x.Airfield2.Id != flightSearchModel.ArrAirfieldID).ToList());
                flights = flights.Except(flights1).ToList();
                flights1.Clear();
            }

            if (flightSearchModel.ArrCityId != -1)
            {
                flights1.AddRange(flights.Where(x => x.Airfield2.City.Id != flightSearchModel.ArrCityId).ToList());
                flights = flights.Except(flights1).ToList();
                flights1.Clear();
            }

            if (flightSearchModel.ArrCountryID != -1)
            {
                flights1.AddRange(flights.Where(x => x.Airfield2.City.CountryId != flightSearchModel.ArrCountryID).ToList());
                flights = flights.Except(flights1).ToList();
                flights1.Clear();
            }


            if (flightSearchModel.CompanyId != -1)
            {
                flights1.AddRange(flights.Where(x => x.Plane.CompanyId != flightSearchModel.CompanyId).ToList());
                flights = flights.Except(flights1).ToList();
                flights1.Clear();
            }


            if (flightSearchModel.PlaneTypeId != -1)
            {
                flights1.AddRange(flights.Where(x => x.Plane.PlaneTypeId != flightSearchModel.PlaneTypeId).ToList());
                flights = flights.Except(flights1).ToList();
                flights1.Clear();
            }

            List<FlightOrderClass> flightOrders = new List<FlightOrderClass>();
            foreach (var item in flights)
            {
                FlightOrderClass orderClass = new FlightOrderClass();
                orderClass.flight = item;
                orderClass.TicketsSold = 0;
                orderClass.TotalTickets = 0;
                foreach (var flightTicketTypes in item.FlightTicketTypes)
                {
                    orderClass.TotalTickets += flightTicketTypes.MaxTickets;
                    orderClass.TicketsSold += flightTicketTypes.CurrentTickets;
                }
                flightOrders.Add(orderClass);
            }

            switch (flightSearchModel.OrderBy)
            {
                case 1:
                    flightOrders = flightOrders.OrderBy(x => x.flight.StartDate).ToList();
                    break;
                case 2:
                    flightOrders = flightOrders.OrderByDescending(x => x.flight.StartDate).ToList();
                    break;
                case 3:
                    flightOrders = flightOrders.OrderByDescending(x => x.TotalTickets).ToList();
                    break;
                case 4:
                    flightOrders = flightOrders.OrderBy(x => x.TotalTickets).ToList();
                    break;
                case 5:
                    flightOrders = flightOrders.OrderByDescending(x => x.TicketsSold).ToList();
                    break;
                case 6:
                    flightOrders = flightOrders.OrderBy(x => x.TicketsSold).ToList();
                    break;
                default:
                    break;
            }

            PaginationList<Database.ClassModels.Flight> pagenation = new Database.PaginationList<Database.ClassModels.Flight>(flightOrders.Select(x => x.flight).ToList(), 20);

            List<Database.ClassModels.Flight> PageFlights = pagenation.GetPage(flightSearchModel.page);


            return mapper.Map<List<FlightInfoClass>>(PageFlights);


        }

        public List<Model.FlightTicketType> GetFlightTicketTypes(int id)
        {
            return mapper.Map<List<Model.FlightTicketType>>(db.FlightTicketTypes.Include(x => x.TicketType).Where(x => x.FlightId == id).ToList());
        }

        public FlightInsertModel InsertFlight(FlightInsertModel flightInsertModel)
        {
            Database.ClassModels.Flight flight = new Database.ClassModels.Flight();
            flight.Airfield1Id = flightInsertModel.DepartureAirfieldId;
            flight.Airfield2Id = flightInsertModel.ArrivalAirfieldId;
            flight.StartDate = flightInsertModel.DepartureDateTime;
            flight.EndDate = flightInsertModel.ArrivalDateTime;
            flight.PlaneId = flightInsertModel.PlaneId;

            Database.ClassModels.Airfield ArrAirFld = db.Airfields.Where(x => x.Id == flightInsertModel.ArrivalAirfieldId).Include(x => x.City).ThenInclude(x => x.Country).SingleOrDefault();
            Database.ClassModels.Airfield DepAirFld = db.Airfields.Where(x => x.Id == flightInsertModel.DepartureAirfieldId).Include(x => x.City).ThenInclude(x => x.Country).SingleOrDefault();
            flight.Name = DepAirFld.City.Country.ShortName + ":" + DepAirFld.City.ShortName + "--" + ArrAirFld.City.Country.ShortName + ':' + ArrAirFld.City.ShortName + ' ' + flight.StartDate.ToShortDateString();



            TimeSpan flightduration = (flightInsertModel.ArrivalDateTime - flightInsertModel.DepartureDateTime);
            flight.Duration = string.Format("{0:00}:{1:00}", (int)flightduration.TotalHours, flightduration.Minutes);


            db.Flights.Add(flight);
            db.SaveChanges();

            flightInsertModel.Id = flight.Id;

            return flightInsertModel;
        }

        public Model.FlightTicketType InsertFlightTicket(Model.FlightTicketType flightTikcetType)
        {
            Database.ClassModels.FlightTicketType DbTicket = mapper.Map<Database.ClassModels.FlightTicketType>(flightTikcetType);


            DbTicket.TicketTypeID = flightTikcetType.TicketTypeID;
            DbTicket.TicketType = null;
            db.Add(DbTicket);
            db.SaveChanges();

            flightTikcetType.Id = DbTicket.Id;
            return flightTikcetType;

        }


        public List<JourneyFlighsDTO> AdvancedUserSearch(AdvancedSearchDataModel data)
        {
            List<Database.ClassModels.Flight> flights = db.Flights
                .Include(x => x.Airfield1)
                    .ThenInclude(x => x.City)
                        .ThenInclude(x => x.Country)
                .Include(x => x.Airfield2)
                    .ThenInclude(x => x.City)
                        .ThenInclude(x => x.Country)
                       .Where(x => x.StartDate > data.Mindate && x.EndDate < data.MaxDate)
                .ToList();

            List<int> desiredluxuries = new List<int>();
            desiredluxuries.AddRange(data.luxuiresId.Split(";").Select(Int32.Parse).ToList());



            List<Database.ClassModels.Flight> startflights = flights.Where(x => x.Airfield1.CityId == data.depCityId).ToList();


            if (startflights.Count == 0)
            {
                return null;
            }


            List<JourneyFlighsDTO> journeydata = new List<JourneyFlighsDTO>();


            List<Database.ClassModels.Flight> directflights = flights.Where(x => x.Airfield1.CityId == data.depCityId && x.Airfield2.CityId == data.arrCityId && x.StartDate > data.Mindate && x.EndDate < data.MaxDate).ToList();

            foreach (var item in directflights)
            {

                JourneyFlighsDTO journey = new JourneyFlighsDTO();
                journey.AvarageCost = 0;
                journey.EndDate = item.EndDate;
                journey.StartDate = item.StartDate;
                journey.TotalFlights = 1;
                journey.Journeyflights = new List<Model.Flight>();
                journey.Journeyflights.Add(mapper.Map<Model.Flight>(item));

                journeydata.Add(journey);
            }


            startflights = startflights.Except(directflights).ToList();



            List<Database.ClassModels.Flight> flightssearch1 = flights.Except(startflights).ToList();

            List<Database.ClassModels.Flight> ToBeRemovedFlights = new List<Database.ClassModels.Flight>();

            foreach (var startflight in startflights)
            {
                List<Database.ClassModels.Flight> flights2 = flightssearch1.Where(x => x.Airfield1.CityId == startflight.Airfield2.CityId && x.StartDate>startflight.EndDate).ToList();

                foreach (var flight2 in flights2)
                {


                    if (flight2.Airfield2.CityId == data.arrCityId)
                    {

                        JourneyFlighsDTO journey = new JourneyFlighsDTO();
                        journey.AvarageCost = 0;
                        journey.EndDate = startflight.EndDate;
                        journey.StartDate = flight2.EndDate;
                        journey.TotalFlights = 2;
                        journey.Journeyflights = new List<Model.Flight>();
                        journey.Journeyflights.Add(mapper.Map<Model.Flight>(startflight));
                        journey.Journeyflights.Add(mapper.Map<Model.Flight>(flight2));
                        journeydata.Add(journey);

                        ToBeRemovedFlights.Add(flight2);
                        continue;
                    }
                }

            }

            flightssearch1 = flightssearch1.Except(ToBeRemovedFlights).ToList();
            ToBeRemovedFlights.Clear();


            foreach (var startflight in startflights)
            {
                List<Database.ClassModels.Flight> flights2 = flightssearch1.Where(x => x.Airfield1.CityId == startflight.Airfield2.CityId && x.StartDate > startflight.EndDate).ToList();

                foreach (var flight2 in flights2)
                {


                    if (flight2.Airfield2.CityId == data.arrCityId)
                    {

                        JourneyFlighsDTO journey = new JourneyFlighsDTO();
                        journey.AvarageCost = 0;
                        journey.EndDate = startflight.EndDate;
                        journey.StartDate = flight2.EndDate;
                        journey.TotalFlights = 2;
                        journey.Journeyflights = new List<Model.Flight>();
                        journey.Journeyflights.Add(mapper.Map<Model.Flight>(startflight));
                        journey.Journeyflights.Add(mapper.Map<Model.Flight>(flight2));
                        journeydata.Add(journey);

                        ToBeRemovedFlights.Add(flight2);
                        continue;
                    }

                    List<Database.ClassModels.Flight> flights3 = flightssearch1.Where(x => x.Airfield1.CityId == flight2.Airfield2.CityId && x.StartDate > flight2.EndDate).ToList();

                    foreach (var flight3 in flights3)
                    {

                        if (flight3.Airfield2.CityId == data.arrCityId)
                        {

                            JourneyFlighsDTO journey = new JourneyFlighsDTO();
                            journey.AvarageCost = 0;
                            journey.EndDate = startflight.EndDate;
                            journey.StartDate = flight3.EndDate;
                            journey.TotalFlights = 3;
                            journey.Journeyflights = new List<Model.Flight>();
                            journey.Journeyflights.Add(mapper.Map<Model.Flight>(startflight));
                            journey.Journeyflights.Add(mapper.Map<Model.Flight>(flight2));
                            journey.Journeyflights.Add(mapper.Map<Model.Flight>(flight3));
                            journeydata.Add(journey);

                            ToBeRemovedFlights.Add(flight2);
                            ToBeRemovedFlights.Add(flight3);
                            continue;
                        }
                    }

                }

            }

            flightssearch1 = flightssearch1.Except(ToBeRemovedFlights).ToList();
            ToBeRemovedFlights.Clear();



            foreach (var startflight in startflights)
            {
                List<Database.ClassModels.Flight> flights2 = flightssearch1.Where(x => x.Airfield1.CityId == startflight.Airfield2.CityId && x.StartDate > startflight.EndDate).ToList();

                foreach (var flight2 in flights2)
                {


                    if (flight2.Airfield2.CityId == data.arrCityId)
                    {

                        JourneyFlighsDTO journey = new JourneyFlighsDTO();
                        journey.AvarageCost = 0;
                        journey.EndDate = startflight.EndDate;
                        journey.StartDate = flight2.EndDate;
                        journey.TotalFlights = 2;
                        journey.Journeyflights = new List<Model.Flight>();
                        journey.Journeyflights.Add(mapper.Map<Model.Flight>(startflight));
                        journey.Journeyflights.Add(mapper.Map<Model.Flight>(flight2));
                        journeydata.Add(journey);

                        ToBeRemovedFlights.Add(flight2);
                        continue;
                    }

                    List<Database.ClassModels.Flight> flights3 = flightssearch1.Where(x => x.Airfield1.CityId == flight2.Airfield2.CityId && x.StartDate > flight2.EndDate).ToList();

                    foreach (var flight3 in flights3)
                    {

                        if (flight3.Airfield2.CityId == data.arrCityId)
                        {

                            JourneyFlighsDTO journey = new JourneyFlighsDTO();
                            journey.AvarageCost = 0;
                            journey.EndDate = startflight.EndDate;
                            journey.StartDate = flight3.EndDate;
                            journey.TotalFlights = 3;
                            journey.Journeyflights = new List<Model.Flight>();
                            journey.Journeyflights.Add(mapper.Map<Model.Flight>(startflight));
                            journey.Journeyflights.Add(mapper.Map<Model.Flight>(flight2));
                            journey.Journeyflights.Add(mapper.Map<Model.Flight>(flight3));
                            journeydata.Add(journey);

                            ToBeRemovedFlights.Add(flight2);
                            ToBeRemovedFlights.Add(flight3);
                            continue;
                        }
                        List<Database.ClassModels.Flight> flights4 = flightssearch1.Where(x => x.Airfield1.CityId == flight3.Airfield2.CityId && x.StartDate > flight3.EndDate).ToList();
                        foreach (var flight4 in flights4)
                        {
                            if (flight4.Airfield2.CityId == data.arrCityId)
                            {

                                JourneyFlighsDTO journey = new JourneyFlighsDTO();
                                journey.AvarageCost = 0;
                                journey.EndDate = startflight.EndDate;
                                journey.StartDate = flight4.EndDate;
                                journey.TotalFlights = 3;
                                journey.Journeyflights = new List<Model.Flight>();
                                journey.Journeyflights.Add(mapper.Map<Model.Flight>(startflight));
                                journey.Journeyflights.Add(mapper.Map<Model.Flight>(flight2));
                                journey.Journeyflights.Add(mapper.Map<Model.Flight>(flight3));
                                journey.Journeyflights.Add(mapper.Map<Model.Flight>(flight4));
                                journeydata.Add(journey);

                                ToBeRemovedFlights.Add(flight2);
                                ToBeRemovedFlights.Add(flight3);
                                ToBeRemovedFlights.Add(flight4);
                                continue;
                            }
                        }
                    }

                }

            }

            flightssearch1 = flightssearch1.Except(ToBeRemovedFlights).ToList();
            ToBeRemovedFlights.Clear();




            foreach (var item in journeydata)
            {
                SetExtraData(item, desiredluxuries);
            }

            journeydata.OrderBy(x => x.TotalFlights).ThenBy(x => x.LuxuriesAvailabel).ThenBy(x => x.TravelTime);

            PaginationList<JourneyFlighsDTO> PageData = new PaginationList<JourneyFlighsDTO>(journeydata, 20);

            return PageData.GetPage(data.page);

        }

        private void SetExtraData(JourneyFlighsDTO item, List<int> desiredluxuries = null)
        {
            TimeSpan TotalTime = new TimeSpan();



            int HasLuxurys = 0;
            int TotalCount = 0;
            double Total = 0;

            int Flightcount = 1;

            foreach (var ModelFlight in item.Journeyflights)
            {
                Database.ClassModels.Flight flight = db.Flights
                    .Include(x => x.FlightTicketTypes)
                    .ThenInclude(x => x.FlightTicketLuxuries)
                    .ThenInclude(x => x.Luxuries)
                    .Include(x => x.Airfield1)
                        .ThenInclude(x => x.City)
                    .Include(x => x.Airfield2)
                        .ThenInclude(x => x.City)
                    .SingleOrDefault(x => x.Id == ModelFlight.Id);

                int count = flight.FlightTicketTypes.Count;
                double avarage = 0;

                foreach (var ticket in flight.FlightTicketTypes)
                {
                    avarage += ticket.Price;
                    ++count;

                    if (desiredluxuries != null)
                    {
                        foreach (var luxuries in ticket.FlightTicketLuxuries)
                        {
                            //todo find
                            if (desiredluxuries.Contains(luxuries.LuxuriesID))
                                ++HasLuxurys;
                        }
                    }



                }
                avarage = avarage / count;

                TotalCount++;
                Total += avarage;

                if (Flightcount == 1)
                    item.StartAirfield = flight.Airfield1.City.Name + ":" + flight.Airfield1.Name;

                if (Flightcount == item.Journeyflights.Count)
                    item.EndAirfield = flight.Airfield2.City.Name + ":" + flight.Airfield2.Name;

                ++Flightcount;
                TimeSpan time = new TimeSpan((ModelFlight.EndDate - ModelFlight.StartDate).Ticks);
                TotalTime = TotalTime.Add(time);
            }

            item.AvarageCost = Total / TotalCount;
            item.TravelTime = string.Format("{0:00}:{1:00}", (int)TotalTime.TotalHours, TotalTime.Minutes);

            item.LuxuriesAvailabel = HasLuxurys;


        }

        public MobileFlightInfoDTO GetMobileFlightInfo(int flightId)
        {

            Database.ClassModels.Flight flight = db.Flights.
                Include(x => x.Plane).ThenInclude(x => x.Company)
                .Include(x => x.Plane).ThenInclude(x => x.PlaneType)
                .Include(x => x.FlightTicketTypes)
                    .ThenInclude(x => x.TicketType)
                .Include(x => x.FlightTicketTypes)
                    .ThenInclude(x => x.FlightTicketLuxuries)
                .ThenInclude(x => x.Luxuries)
                .SingleOrDefault(x => x.Id == flightId);


            MobileFlightInfoDTO data = new MobileFlightInfoDTO();
            data.tickets = new List<MobileFlightTicketLuxuriesInfo>();
            data.AirplaneName = flight.Plane.Name;
            data.AirplaneType = flight.Plane.PlaneType.Name;
            data.CompanyName = flight.Plane.Company.Name;
            data.CompanyLogo = flight.Plane.Company.Picture;

            foreach (var TicketType in flight.FlightTicketTypes)
            {
                MobileFlightTicketLuxuriesInfo ticketdata = new MobileFlightTicketLuxuriesInfo();
                ticketdata.Price = TicketType.Price;
                ticketdata.MaxTickets = TicketType.MaxTickets;
                ticketdata.CurrentTickets = TicketType.CurrentTickets;
                ticketdata.Name = TicketType.TicketType.Name;
                ticketdata.Icon = TicketType.TicketType.Icon;
                ticketdata.Id = TicketType.Id;



                List<Database.ClassModels.Luxuries> luxuries =
                    db.FlightTicketLuxuries
                    .Include(x => x.Luxuries).Where(x => x.FlightTicketTypeID == TicketType.Id)
                    .Select(x => x.Luxuries)
                    .ToList();
                ticketdata.TicketLuxuries = mapper.Map<List<Model.Luxuries>>(luxuries);
                data.tickets.Add(ticketdata);
            }


            return data;




        }

        public List<JourneyFlighsDTO> GetUserRecommendedFlights(int userId, int page)
        {

            try
            {



                //Koristeni sistem je Content based filtering (tjt filtering prema atributima)
                //Koristeni sistem jeste "Weighted" sistem u kojem se atributi leta porede sa 
                //ukusima (preferencama) postavljenim korisnikom pri registraciji
                // primjer Ako let ima "Economy" kartu koju je korisnik ocjenuo sa 5 bodova
                // Svi letovi dobijaju 5 bodova  koji imaju ekonomi clasu
                //isti princim je koristen i za luksuze unutar leta
                //također se gleda lokacija korisnika tako da letovi pocinju u istom gradu i/ili drzavi



                //GetUser 

                Database.ClassModels.User user = db.Users
                    .Include(x => x.TicketPreferences)
                    .Include(x => x.LuxuryPreferences)
                    .Include(x => x.Journeys)
                        .ThenInclude(x => x.Tickets)
                            .ThenInclude(x => x.Flight)
                    .SingleOrDefault(x => x.Id == userId);


                //Get future0 flights

                List<Database.ClassModels.Flight> flights = db.Flights
                    .Include(x => x.Airfield1)
                        .ThenInclude(x => x.City)
                            .ThenInclude(x => x.Country)
                    .Include(x => x.Airfield2)
                        .ThenInclude(x => x.City)
                            .ThenInclude(x => x.Country)
                    .Include(x => x.FlightTicketTypes)
                        .ThenInclude(x => x.TicketType)
                    .Include(x => x.FlightTicketTypes)
                        .ThenInclude(x => x.FlightTicketLuxuries)
                            .ThenInclude(x => x.Luxuries)
                    .Where(x => x.StartDate > DateTime.Now && (int)x.Status != 6)
                    .ToList();


                //Step One Point Addition Based On User Preferences

                List<FLightReccomenderData> filterData = new List<FLightReccomenderData>();


                foreach (var flight in flights)
                {
                    int TicketPoints = 0;
                    int LuxuryPoints = 0;


                    //set TicketPoints
                    foreach (var flightTicketType in flight.FlightTicketTypes)
                    {
                        Database.ClassModels.TicketPreferences ticketprefrences = user.TicketPreferences.SingleOrDefault(x => x.TicketTypeId == flightTicketType.TicketTypeID);

                        if (ticketprefrences != null)
                        {
                            TicketPoints += ticketprefrences.Rating;
                        }

                        List<Database.ClassModels.Luxuries> ticketLuxuries = flightTicketType.FlightTicketLuxuries.Select(x => x.Luxuries).ToList();

                        foreach (var luxury in ticketLuxuries)
                        {
                            Database.ClassModels.LuxuryPreferences luxuryPreferences = user.LuxuryPreferences.SingleOrDefault(x => x.LuxuriesId == luxury.Id);

                            if (luxuryPreferences != null)
                            {
                                LuxuryPoints += luxuryPreferences.Rating;
                            }


                        }

                    }

                    filterData.Add(new FLightReccomenderData()
                    {

                        flight = flight,
                        LuxuriesPoints = LuxuryPoints,
                        TicketPoints = TicketPoints,
                        PopularUserCountryPoints = 0,
                        TotalPoints = LuxuryPoints + TicketPoints

                    });
                }






                List<FLightReccomenderData> SameStartCityAsUser = new List<FLightReccomenderData>();
                List<FLightReccomenderData> SameStartCountryAsUser = new List<FLightReccomenderData>();

                SameStartCityAsUser = filterData.Where(x => x.flight.Airfield1.CityId == user.CityId).ToList();
                SameStartCityAsUser.OrderBy(x => x.TotalPoints).ThenBy(x => x.flight.StartDate);

                SameStartCountryAsUser = filterData.Where(x => x.flight.Airfield1.City.CountryId == user.City.CountryId).ToList();
                SameStartCountryAsUser.OrderBy(x => x.TotalPoints).ThenBy(x => x.flight.StartDate);

                filterData = filterData.Except(SameStartCityAsUser).ToList();
                filterData = filterData.Except(SameStartCountryAsUser).ToList();
                filterData.OrderBy(x => x.TotalPoints).ThenBy(x => x.flight.StartDate);

                filterData.OrderBy(x => x.TotalPoints);
                List<FLightReccomenderData> TotalData = new List<FLightReccomenderData>();
                TotalData.AddRange(SameStartCityAsUser);
                TotalData.AddRange(SameStartCountryAsUser);
                TotalData.AddRange(filterData);

                PaginationList<FLightReccomenderData> PageData = new PaginationList<FLightReccomenderData>(TotalData, 20);
                List<FLightReccomenderData> pagedata = PageData.GetPage(page);


                List<JourneyFlighsDTO> journeyInfos = new List<JourneyFlighsDTO>();
                foreach (var item in pagedata)
                {

                    TimeSpan flightduration = (item.flight.EndDate - item.flight.StartDate);
                    string Duration = string.Format("{0:00}:{1:00}", (int)flightduration.TotalHours, flightduration.Minutes);

                    JourneyFlighsDTO journey = new JourneyFlighsDTO();
                    journey.AvarageCost = 0;
                    journey.EndDate = item.flight.EndDate;
                    journey.StartDate = item.flight.StartDate;
                    journey.EndAirfield = item.flight.Airfield2.City.Name + ":" + item.flight.Airfield2.Name;
                    journey.StartAirfield = item.flight.Airfield1.City.Name + ":" + item.flight.Airfield1.Name;
                    journey.TotalFlights = 1;
                    journey.AvarageCost = 0;
                    journey.LuxuriesAvailabel = 0;
                    journey.TravelTime = Duration;
                    journey.Journeyflights = new List<Model.Flight>();
                    journey.Journeyflights.Add(mapper.Map<Model.Flight>(item.flight));

                    SetExtraData(journey);

                    journeyInfos.Add(journey);
                }



                return journeyInfos;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public Model.Flight GetFlightInfo(int flightId)
        {
            Database.ClassModels.Flight flight = db.Flights.SingleOrDefault(x => x.Id == flightId);

            return mapper.Map<Model.Flight>(flight);

        }

        public TicketInfoModel GetTicketInfo(string ticketCode)
        {

            TicketInfoModel data = new TicketInfoModel();

            Database.ClassModels.Ticket ticket = db.Tickets
                .Include(x => x.Journey).ThenInclude(x => x.Customer)
                .Include(x => x.FlightTicketType)
                .ThenInclude(x => x.TicketType)
                .SingleOrDefault(x => x.Name.ToLower() == ticketCode.ToLower());
            if (ticket == null)
                return null;


            Database.ClassModels.Flight flight = db.Flights
                .Include(x => x.Airfield1)
                    .ThenInclude(x => x.City)
                        .ThenInclude(x => x.Country)
                .Include(x => x.Airfield2)
                    .ThenInclude(x => x.City)
                        .ThenInclude(x => x.Country)
                .Include(x => x.Plane)
                .ThenInclude(x => x.Company)
                .SingleOrDefault(x => x.Id == ticket.FlightId);


            data.TicketId = ticket.Id;
            data.TicketStatus = ticket.TicketStatus;
            data.FlightTicketType = ticket.FlightTicketType.TicketType.Name;
            data.UserName = ticket.Journey.Customer.FirstName + " " + ticket.Journey.Customer.LastName;
            data.UserIcon = ticket.Journey.Customer.Picture;
            data.FlightproviderIcon = flight.Plane.Company.Picture;
            data.FlightProvider = flight.Plane.Company.Name;
            data.FlightStatus = flight.Status.ToString();
            data.Duration = flight.Duration;
            data.Departure = flight.Airfield1.City.Country.Name + ":" + flight.Airfield1.City.Name + ":" + flight.Airfield1.Name;
            data.Destination = flight.Airfield2.City.Country.Name + ":" + flight.Airfield2.City.Name + ":" + flight.Airfield2.Name;
            data.DepartureTime = flight.StartDate.ToShortTimeString();

            return data;
        }

        public bool CheckInTicket(Ticket ticket)
        {
            Database.ClassModels.Ticket ticket1 = db.Tickets.SingleOrDefault(x => x.Id == ticket.Id);

            if (ticket1 == null) { return false; }
            else
            {
                ticket1.TicketStatus = "Checked In";
                db.Tickets.Update(ticket1);
                db.SaveChanges();

                return true;
            }

        }



        Model.Flight IFlightService.UpdateFlightStatus(Model.Flight flight)
        {
            Database.ClassModels.Flight flight1 = db.Flights.SingleOrDefault(x => x.Id == flight.Id);

            if (flight1 != null)
            {
                flight1.StartDate = flight.StartDate;
                flight1.EndDate = flight.EndDate;
                flight1.Status = (Database.ClassModels.Flight.FlightStatus)flight.Status;

                TimeSpan flightduration = (flight.EndDate - flight.StartDate);
                string Duration = string.Format("{0:00}:{1:00}", (int)flightduration.TotalHours, flightduration.Minutes);
                flight1.Duration = Duration;

                db.Flights.Update(flight1);
                db.SaveChanges();

                return mapper.Map<Model.Flight>(flight1);
            }
            else
            {
                return null;
            }
        }

        class FLightReccomenderData
        {
            public Database.ClassModels.Flight flight { get; set; }
            public int TicketPoints { get; set; }
            public int LuxuriesPoints { get; set; }
            public int TotalPoints { get; set; }
            public int PopularUserCountryPoints { get; set; }
        }

        class FlightOrderClass
        {
            public Database.ClassModels.Flight flight { get; set; }
            public int TotalTickets { get; set; }
            public int TicketsSold { get; set; }


        }
    }
}
