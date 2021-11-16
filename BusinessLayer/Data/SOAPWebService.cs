using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class SOAPWebService : ISOAPWebService
    {
        private BookAndPlayPort port;
        private SOAPResponse1 response;

        public SOAPWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPResponse1> getResponse(int id, Operation name, Game game, User user)
        {
            SOAPRequest soapRequest = new SOAPRequest();
            soapRequest.id = id;
            soapRequest.Operation = name;
            soapRequest.Game = game;
            soapRequest.User = user;
            SOAPRequest1 soapRequest1 = new SOAPRequest1(soapRequest);
            SOAPResponse1 soapResponse1 = new SOAPResponse1();
            soapResponse1 = port.SOAPAsync(soapRequest1).Result;
            return soapResponse1;
        }
        public async Task<Game> GetGameAsync(int id)
        {
            response = await getResponse(id, Operation.GET, null, null);
            Game game = response.SOAPResponse.Game;

            return  game;
        }

        public async Task  AddGameAsync(Game game)
        {
            response = await getResponse(0, Operation.POST, game, null);
            //return response.getMessageResponse.Notification;
        }

        public async Task<IList<Game>> GetGamesAsync()
        {
            response = await getResponse(0, Operation.GETALL, null, null);
            return response.SOAPResponse.GameList.gameList;
        }

        public async Task<IList<Game>> GetUserGamesAsync(User user)
        {
            response = await getResponse(0, Operation.GETALL, null, user);
            return response.SOAPResponse.GameList.gameList;
        }

        public async Task RemoveGameAsync(int id)
        {
            response = await getResponse(id, Operation.DELETE, null, null);
        }

        public async Task EditGameAsync(Game game)
        {
            response = await getResponse(0, Operation.PATCH, game, null);
        }
    }
}