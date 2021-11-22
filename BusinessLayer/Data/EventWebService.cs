using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class EventWebService : IEventWebService
    {
        private BookAndPlayPort Port;
        private SOAPEventResponse1 Response;

        public EventWebService()
        {
            Port = new BookAndPlayPortClient();
        }

        private async Task<SOAPEventResponse1> getEventResponse(int id, Operation name, Event ev, string filter)
        {
            SOAPEventRequest soapEventRequest = new SOAPEventRequest();
            soapEventRequest.id = id;
            soapEventRequest.Operation = name;
            soapEventRequest.Event = ev;
            soapEventRequest.filter = filter;
            Console.WriteLine("filter:"+filter);
            SOAPEventRequest1 soapEventRequest1 = new SOAPEventRequest1(soapEventRequest);
            SOAPEventResponse1 soapEventResponse1 = Port.SOAPEventAsync(soapEventRequest1).Result;
            return soapEventResponse1;
        }

        public async Task CreateEventAsync(Event Event)
        {
            Response = await getEventResponse(0, Operation.POST, Event, "");
        }

        public async Task<IList<Event>> GetEventsAsync()
        {
            Response = await getEventResponse(0, Operation.GETALL, null, "");
            return Response.SOAPEventResponse.eventList;
        }

        public async Task<IList<Event>> GetFilteredEventsAsync(string filter, int category, int currentPage, int resultsPerPage)
        {
            Response = await getEventResponse(category, Operation.GETALL, null, filter);
            return Response.SOAPEventResponse.eventList;
        }
    }
}