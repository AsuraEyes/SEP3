using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data
{
    public class EventWebService : IEventWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPEventResponse1 response;

        public EventWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPEventResponse1> getEventResponseAsync(int id, Operation name, Event ev, Filter filter)
        {
            SOAPEventRequest soapEventRequest = new SOAPEventRequest();
            soapEventRequest.id = id;
            soapEventRequest.Operation = name;
            soapEventRequest.Event = ev;
            soapEventRequest.filter = filter;
            SOAPEventRequest1 soapEventRequest1 = new SOAPEventRequest1(soapEventRequest);
            SOAPEventResponse1 soapEventResponse1 = port.SOAPEventAsync(soapEventRequest1).Result;
            return soapEventResponse1;
        }

        public async Task CreateEventAsync(Event newEvent)
        {
            response = await getEventResponseAsync(0, Operation.CREATE, newEvent, null);
        }

        public async Task<EventList> GetFilteredEventsAsync(Filter filter)
        {
            response = await getEventResponseAsync(0, Operation.GETALL, null, filter);
            return response.SOAPEventResponse.eventList;
        }

        public async Task<Event> GetEventAsync(int id)
        {
            response = await getEventResponseAsync(id, Operation.GET, null, null);
            return response.SOAPEventResponse.Event;
        }
        
        
        public async Task CancelEventAsync(int id)
        {
            response = await getEventResponseAsync(id, Operation.REMOVE, null, null);
        }

        public async Task EditEventAsync(Event eventToEdit)
        {
            response = await getEventResponseAsync(0, Operation.UPDATE, eventToEdit, null);
        }
    }
}