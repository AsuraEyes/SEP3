using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.EventWebServices.Events
{
    public class EventWebService : IEventWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPEventResponse1 response;

        public EventWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPEventResponse1> GetEventResponseAsync(int id, Operation name, Event ev, Filter filter)
        {
            SOAPEventRequest soapEventRequest = new SOAPEventRequest
            {
                id = id,
                Operation = name,
                Event = ev,
                filter = filter
            };
            SOAPEventRequest1 soapEventRequest1 = new SOAPEventRequest1(soapEventRequest);
            SOAPEventResponse1 soapEventResponse1 = await port.SOAPEventAsync(soapEventRequest1);
            return soapEventResponse1;
        }

        public async Task CreateEventAsync(Event newEvent)
        {
            response = await GetEventResponseAsync(0, Operation.CREATE, newEvent, null);
        }

        public async Task<EventList> GetFilteredEventsAsync(Filter filter)
        {
            response = await GetEventResponseAsync(0, Operation.GETALL, null, filter);
            return response.SOAPEventResponse.eventList;
        }

        public async Task<Event> GetEventAsync(int id)
        {
            response = await GetEventResponseAsync(id, Operation.GET, null, null);
            return response.SOAPEventResponse.Event;
        }
        
        
        public async Task CancelEventAsync(int id)
        {
            response = await GetEventResponseAsync(id, Operation.REMOVE, null, null);
        }

        public async Task EditEventAsync(Event eventToEdit)
        {
            response = await GetEventResponseAsync(0, Operation.UPDATE, eventToEdit, null);
        }
    }
}