using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Service;
using WebApp.Models;

namespace WebApp.Tests
{
    [TestFixture]
    class EventServiceTests
    {
        private IEventService _eventService;

        [SetUp]
        public void Setup()
        {
            _eventService = new EventService();
        }

        [Test]
        public void IfNotHolidayBefore()
        {
            Event anEvent = new Event();
            anEvent.EventDate = new DateTime(2016, 07, 03);
            anEvent.EventDateEnd = new DateTime(2016, 07, 03);
            Assert.IsFalse(_eventService.CheckIfHoliday(anEvent));
        }

        [Test]
        public void IfNotHolidayAfter()
        {
            Event anEvent = new Event();
            anEvent.EventDate = new DateTime(2016, 07, 05);
            anEvent.EventDateEnd = new DateTime(2016, 07, 05);
            Assert.IsFalse(_eventService.CheckIfHoliday(anEvent));
        }

        [Test]
        public void IfHoliday()
        {
            Event anEvent = new Event();
            anEvent.EventDate = new DateTime(2016, 07, 04);
            anEvent.EventDateEnd = new DateTime(2016, 07, 04);

            Assert.IsTrue(_eventService.CheckIfHoliday(anEvent));
        }

        [Test]
        public void IfHolidayInRange()
        {
            Event anEvent = new Event();
            anEvent.EventDate = new DateTime(2016, 07, 03);
            anEvent.EventDateEnd = new DateTime(2016, 07, 05);

            Assert.IsTrue(_eventService.CheckIfHoliday(anEvent));
        }
    }
}
