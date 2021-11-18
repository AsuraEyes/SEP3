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

        private async Task<SOAPEventResponse1> getEventResponse(int id, Operation name, Event ev)
        {
            SOAPEventRequest soapEventRequest = new SOAPEventRequest();
            soapEventRequest.id = id;
            soapEventRequest.Operation = name;
            soapEventRequest.Event = ev;
            SOAPEventRequest1 soapEventRequest1 = new SOAPEventRequest1(soapEventRequest);
            SOAPEventResponse1 soapEventResponse1 = new SOAPEventResponse1();
            soapEventResponse1 = Port.SOAPEventAsync(soapEventRequest1).Result;
            return soapEventResponse1;
        }

        public async Task<IList<Event>> GetEventsAsync()
        {
            Response = await getEventResponse(0, Operation.GETALL, null);
            return Response.SOAPEventResponse.eventList;
        }
    }
}