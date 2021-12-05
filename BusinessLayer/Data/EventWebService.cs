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

        private async Task<SOAPEventResponse1> getEventResponse(int id, Operation name, Event ev, Filter filter)
        {
            SOAPEventRequest soapEventRequest = new SOAPEventRequest();
            soapEventRequest.id = id;
            soapEventRequest.Operation = name;
            soapEventRequest.Event = ev;
            soapEventRequest.filter = filter;
            SOAPEventRequest1 soapEventRequest1 = new SOAPEventRequest1(soapEventRequest);
            SOAPEventResponse1 soapEventResponse1 = Port.SOAPEventAsync(soapEventRequest1).Result;
            return soapEventResponse1;
        }

        public async Task CreateEventAsync(Event Event)
        {
            Response = await getEventResponse(0, Operation.CREATE, Event, null);
        }

        public async Task<EventList> GetFilteredEventsAsync(Filter filter)
        {
            Response = await getEventResponse(0, Operation.GETALL, null, filter);
            return Response.SOAPEventResponse.eventList;
        }

        public async Task<Event> GetEventAsync(int id)
        {
            Response = await getEventResponse(id, Operation.GET, null, null);
            return Response.SOAPEventResponse.Event;
        }
        
        
        public async Task CancelEventAsync(int id)
        {
            Response = await getEventResponse(id, Operation.REMOVE, null, null);
        }

        public async Task EditEventAsync(Event Event)
        {
            Response = await getEventResponse(0, Operation.UPDATE, Event, null);
        }
    }
}