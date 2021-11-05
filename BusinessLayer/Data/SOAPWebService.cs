using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using MessageServerReference;

namespace BusinessLayer.Data
{
    public class SOAPWebService : ISOAPWebService
    {
        private MessagePort messagePort;

        public SOAPWebService()
        {
            messagePort = new MessagePortClient();
        }
        public async Task<String> GetMessageAsync()
        {
            getMessageRequest getMessageRequest = new getMessageRequest();
            getMessageRequest.name = " asd";
            getMessageRequest1 getMessageRequest1 = new getMessageRequest1(getMessageRequest);
            getMessageResponse1 getMessageResponse1 = new getMessageResponse1();
            getMessageResponse1 = messagePort.getMessageAsync(getMessageRequest1).Result;
            message message = getMessageResponse1.getMessageResponse.message;

            return  message.name + " " + message.body;
        }
        public async Task<string> HelloWorld()
        {
            //WebRequest answerXml = await GetWebRequest();
            //string answer = await deserializeXml(answerXml);
            return GetMessageAsync().Result;
        }

       
    }
}