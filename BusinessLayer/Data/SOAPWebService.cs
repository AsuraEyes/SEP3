using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;
using MessageServerReference;

namespace BusinessLayer.Data
{
    public class SOAPWebService : ISOAPWebService
    {
        private MessagePort messagePort;
        private getMessageResponse1 response;

        public SOAPWebService()
        {
            messagePort = new MessagePortClient();
        }

        private async Task<getMessageResponse1> getResponse(int id, operation name, message message)
        {
            getMessageRequest getMessageRequest = new getMessageRequest();
            getMessageRequest.id = id;
            getMessageRequest.operation = name;
            getMessageRequest.message = message;
            getMessageRequest1 getMessageRequest1 = new getMessageRequest1(getMessageRequest);
            getMessageResponse1 getMessageResponse1 = new getMessageResponse1();
            getMessageResponse1 = messagePort.getMessageAsync(getMessageRequest1).Result;
            return getMessageResponse1;
        }
        public async Task<message> GetMessageAsync(int id)
        {
            response = await getResponse(id, operation.GET, null);
            message message = response.getMessageResponse.message;

            return  message;
        }

        public async Task  AddMessageAsync(message message)
        {
            response = await getResponse(0, operation.POST, message);
            //return response.getMessageResponse.Notification;
        }

        public async Task<IList<message>> GetMessagesAsync()
        {
            response = await getResponse(0, operation.GETALL, null);
            return response.getMessageResponse.messagesList;
        }

        public async Task RemoveMessageAsync(int id)
        {
            response = await getResponse(id, operation.DELETE, null);
        }

        public async Task EditMessageAsync(message message)
        {
            response = await getResponse(0, operation.PATCH, message);
        }

        public async Task<string> HelloWorld()
        {
            //WebRequest answerXml = await GetWebRequest();
            //string answer = await deserializeXml(answerXml);
            return "GetMessageAsync().Result";
        }

       
    }
}