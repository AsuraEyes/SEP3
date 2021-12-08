using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier.Data;
using BusinessTier.Middlepoint;
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
                var allEvents = new FilterREST
                {
                    ByDate = false,
                    ByAvailability = false,
                    CategoryId = 0
                };
                var filterRest = new FilterREST
                {
                    ByDate = true,
                    ByAvailability = false,
                    CategoryId = 1
                };
            
                expectedEvents = await eventMiddlePoint.EventFilterAsync(filterRest);
                actualEvents = await eventMiddlePoint.EventFilterAsync(allEvents);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            Assert.AreNotEqual(expectedEvents, actualEvents);
        }
    }
}