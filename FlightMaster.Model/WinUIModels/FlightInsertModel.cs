using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.WinUIModels
{
    public class FlightInsertModel
    {

        public int Id { get;set;}
        public int PlaneId { get; set; }
        
        public int PassangerCapacity { get; set; }

        public List<Tickets> tickets { get; set; }
        public int DepartureAirfieldId { get; set; }
        public int ArrivalAirfieldId { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }

        public class Tickets
        {
            public FlightTicketType ticketType;

            public List<Luxuries> luxuries;
        }

        public void  RemoveTicket(int id)
        {

            foreach (var item in tickets)
            {
                if (item.ticketType.Id == id)
                {
                    tickets.Remove(item);
                    return;
                }
            }
        }

        public void Clear()
        {
            Id = 0;
            PlaneId = 0;
            PassangerCapacity = 0;
            if(tickets!=null) 
                tickets.Clear();
            DepartureAirfieldId = 0;
            ArrivalAirfieldId= 0;
        }
    }

}
