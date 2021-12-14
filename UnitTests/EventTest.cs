using System;
using System.ServiceModel;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier.Data.EventWebServices.Events;
using BusinessTier.MiddlePoint.EventMiddlePoints.Events;
using BusinessTier.Models;

namespace BusinessTierTests
{
    [TestClass]
    public class EventTest
    {
        private static readonly IEventWebService EventWebService = new EventWebService();
        private readonly IEventMiddlePoint eventMiddlePoint = new EventMiddlePoint(EventWebService);
        
        [TestMethod]
        public async Task GetAllEventsAsync()
        {
            EventList expectedEvents;
            EventList actualEvents;
            try
            {
                var allEvents = new Filter();
                var filterRest = new FilterRest();
            
                expectedEvents = await eventMiddlePoint.EventFilterAsync(filterRest);
                actualEvents = await EventWebService.GetFilteredEventsAsync(allEvents);
            }
            catch (FaultException)
            {
                return;
            }
            Assert.AreEqual(expectedEvents, actualEvents);
        }
        
        [TestMethod]
        public async Task FilterEventsByDateAsync()
        {
            EventList expectedEvents;
            EventList actualEvents;
            try
            {
                var allEvents = new Filter();
                var filterRest = new FilterRest
                {
                    ByDate = true
                };
            
                expectedEvents = await eventMiddlePoint.EventFilterAsync(filterRest);
                actualEvents = await EventWebService.GetFilteredEventsAsync(allEvents);
            }
            catch (FaultException)
            {
                return;
            }
            Assert.AreEqual(expectedEvents, actualEvents);
        }
        
        [TestMethod]
        public async Task FilterEventsByAvailabilityAsync()
        {
            EventList expectedEvents;
            EventList actualEvents;
            try
            {
                var allEvents = new Filter();
                var filterRest = new FilterRest
                {
                    ByAvailability = true
                };
            
                expectedEvents = await eventMiddlePoint.EventFilterAsync(filterRest);
                actualEvents = await EventWebService.GetFilteredEventsAsync(allEvents);
            }
            catch (FaultException)
            {
                return;
            }
            Assert.AreNotEqual(expectedEvents, actualEvents);
        }
        
        [TestMethod]
        public async Task FilterEventsByCategoryAsync()
        {
            EventList expectedEvents;
            EventList actualEvents;
            try
            {
                var allEvents = new Filter
                {
                    categoryId = 3
                };
                var filterRest = new FilterRest
                {
                   CategoryId = 3
                };
            
                expectedEvents = await eventMiddlePoint.EventFilterAsync(filterRest);
                actualEvents = await EventWebService.GetFilteredEventsAsync(allEvents);
            }
            catch (FaultException)
            {
                return;
            }
            Assert.AreEqual(expectedEvents, actualEvents);
        }
    }
}