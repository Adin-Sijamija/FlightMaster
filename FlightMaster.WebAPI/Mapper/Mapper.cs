using AutoMapper;
using FlightMaster.Model.WinUIModels;
using FlightMaster.WebAPI.Database.ClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Airfield, Model.Airfield>().ReverseMap();
            CreateMap<City, Model.City>().ReverseMap();
            CreateMap<Company, Model.Company>().ReverseMap();
            CreateMap<Country, Model.Country>().ReverseMap();
            CreateMap<User, Model.Customer>().ReverseMap();
            CreateMap<Journey, Model.Journey>().ReverseMap();
            CreateMap<Luxuries, Model.Luxuries>().ReverseMap();
            CreateMap<LuxuryPreferences, Model.LuxuryPreferences>().ReverseMap();
            CreateMap<Plane, Model.Plane>().ReverseMap();
            CreateMap<FlightTicketLuxuries, Model.FlightTicketLuxuries>().ReverseMap();


            CreateMap<FlightTicketType, Model.FlightTicketType>().ForMember(x=>x.TicketTypeName,s=>s.MapFrom(s=>s.TicketType.Name))
                .ReverseMap();
            CreateMap<Ticket, Model.Ticket>().ReverseMap();
            CreateMap<TicketPreferences, Model.TicketPreferences>().ReverseMap();
            CreateMap<TicketType, Model.TicketType>().ReverseMap();
           
            CreateMap<PlaneType, Model.PlaneType>().ReverseMap();

            CreateMap<Flight, Model.Flight>()
                .ReverseMap();

            CreateMap<Plane, CompanyPlaneInfoData>()
                .ForMember(dest => dest.PlaneName, src => src.MapFrom(s => s.Name))
                .ForMember(dest => dest.PlaneTypeName, src => src.MapFrom(s => s.PlaneType.Name))
                .ForMember(dest => dest.TotalPassangeres, src => src.MapFrom(s => s.PlaneType.TotalPassangeres))
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(s => s.Company.Name))
                .ForMember(dest => dest.Picture, src => src.MapFrom(s => s.Company.Picture));

            CreateMap<Flight, FlightInfoClass>()

                .ForMember(dest => dest.DepLocation, src => src.MapFrom(src => src.Airfield1.City.Country.Name + "-" + src.Airfield1.City.Name + "-" + src.Airfield1.Name))
                .ForMember(dest => dest.ArrLocation, src => src.MapFrom(src => src.Airfield2.City.Country.Name + "-" + src.Airfield2.City.Name + "-" + src.Airfield2.Name))
                .ForMember(dest => dest.FlightDate, src => src.MapFrom(x => x.StartDate.ToShortDateString()))
                .ForMember(dest => dest.ArrCountry, src => src.MapFrom(s => s.Airfield2.City.Country.Name))
                .ForMember(dest => dest.ArrCity, src => src.MapFrom(s => s.Airfield2.City.Name))
                .ForMember(dest => dest.ArrAirfield, src => src.MapFrom(s => s.Airfield2.Name))
                .ForMember(dest => dest.DepCountry, src => src.MapFrom(s => s.Airfield1.City.Country.Name))
                .ForMember(dest => dest.DepCity, src => src.MapFrom(s => s.Airfield1.City.Name))
                .ForMember(dest => dest.DepAirfield, src => src.MapFrom(s => s.Airfield1.Name))
                .ForMember(dest=>dest.Capacity,src=>src.MapFrom(s=>s.Plane.PlaneType.TotalPassangeres))
                .ForMember(dest=>dest.Company, src=>src.MapFrom(x=>x.Plane.Company.Name))
                .ForMember(dest=>dest.PlaneType, src=>src.MapFrom(x=>x.Plane.PlaneType.Name))
                .ForMember(dest => dest.Status,
                 opt => opt.MapFrom(source => Enum.GetName(typeof(Flight.FlightStatus), source.Status)))
                .ForMember(dest=>dest.TicketsSold,src=>src.MapFrom(s=>s.Tickets.Count))
                ;


            CreateMap<EmployeRegisterModel, Database.ClassModels.User>();
            CreateMap<User, Model.User>().ReverseMap();


            CreateMap<Airfield, AirfieldInfoDTO>()
                 .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                 .ForMember(dest => dest.CityName, src => src.MapFrom(src => src.City.Name))
                 .ForMember(dest => dest.CountryName, src => src.MapFrom(src => src.City.Country.Name));


        }
    }
}
