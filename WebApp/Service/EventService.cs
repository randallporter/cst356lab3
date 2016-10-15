using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Service
{
    public class EventService : IEventService
    {
        public bool CheckIfHoliday(Event anEvent)
        {
            DateTime holiday = new DateTime(anEvent.EventDate.Year, 7, 4);
            if (anEvent.EventDate.Date <= holiday && anEvent.EventDateEnd.Date >= holiday)
                return true;
            else
                return false;
        }
    }
}