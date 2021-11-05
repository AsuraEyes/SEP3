using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace BusinessLayer.Data
{
    public class SOAPWebService : ISOAPWebService
    {
        /// <summary>
         /// Execute a Soap WebService call
         /// </summary>
         public async Task Execute()
         {
             HttpWebRequest request = await GetWebRequest();
             XmlDocument soapEnvelopeXml = new XmlDocument();
             soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
             <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
               <soap:Body>
                 <HelloWorld xmlns=""http://tempuri.org/"" />
               </soap:Body>
             </soap:Envelope>");

             using (Stream stream = request.GetRequestStream())
             {
                 soapEnvelopeXml.Save(stream);
             }

             using (WebResponse response = request.GetResponse())
             {
                 using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                 {
                     string soapResult = rd.ReadToEnd();
                     Console.WriteLine(soapResult);
                 }
             }
         }


        /// <summary>
         /// Create a soap webrequest to [Url]
         /// </summary>
         /// <returns></returns>
         public async Task<HttpWebRequest> GetWebRequest()
         {
             HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:8080/ws");
             webRequest.Headers.Add(@"SOAP:Action");
             webRequest.ContentType = "text/xml;charset=\"utf-8\"";
             webRequest.Accept = "text/xml";
             webRequest.Method = "GET";
             return webRequest;
         }
        public async Task<string> HelloWorld(string param)
        {
            //WebRequest answerXml = await GetWebRequest();
            //string answer = await deserializeXml(answerXml);
            return param + " - " + "answer";
        }

        private async Task<string> deserializeXml(string xml)
        {
            XmlTextReader reader = null;

            string stringToReturn = "";

            try
            {
                //Load the reader with the XML file.
                reader = new XmlTextReader(xml);

                //Parse the XML and display the text content of each of the elements.
                while (reader.Read()){
                    if (reader.IsStartElement()){
                        if (reader.IsEmptyElement)
                        {
                            stringToReturn += ("<{0}/>", reader.Name);
                        }
                        else
                        {
                            stringToReturn += ("<{0}> ", reader.Name);
                            reader.Read(); //Read the start tag.
                            if (reader.IsStartElement())  //Handle nested elements.
                                stringToReturn += ("\r\n<{0}>", reader.Name);
                            stringToReturn += (reader.ReadString());  //Read the text content of the element.
                        }
                    }
                }
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return stringToReturn;
        }
    }
}