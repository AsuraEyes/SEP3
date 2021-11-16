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
    public class GameWebService : IGameWebService
    {
        private BookAndPlayPort port;
        private SOAPGameResponse1 response;

        public GameWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPGameResponse1> getGameResponse(int id, Operation name, Game game, String username)
        {
            SOAPGameRequest soapGameRequest = new SOAPGameRequest();
            soapGameRequest.id = id;
            soapGameRequest.Operation = name;
            soapGameRequest.Game = game;
            soapGameRequest.userName = username;
            SOAPGameRequest1 soapRequest1 = new SOAPGameRequest1(soapGameRequest);
            SOAPGameResponse1 soapResponse1 = new SOAPGameResponse1();
            soapResponse1 = port.SOAPGameAsync(soapRequest1).Result;
            return soapResponse1;
        }
        public async Task<Game> GetGameAsync(int id)
        {
            response = await getGameResponse(id, Operation.GET, null, "");
            Game game = response.SOAPGameResponse.game;

            return  game;
        }

        public async Task  AddGameAsync(Game game)
        {
            response = await getGameResponse(0, Operation.POST, game, "");
            //return response.getMessageResponse.Notification;
        }

        public async Task<IList<Game>> GetGamesAsync()
        {
            response = await getGameResponse(0, Operation.GETALL, null, "");
            return response.SOAPGameResponse.gameList;
        }

        public async Task<IList<Game>> GetUserGamesAsync(string user)
        {
            response = await getGameResponse(0, Operation.GETALL, null, user);
            return response.SOAPGameResponse.gameList;
        }

        public async Task RemoveGameAsync(int id)
        {
            response = await getGameResponse(id, Operation.DELETE, null, "");
        }

        public async Task EditGameAsync(Game game)
        {
            response = await getGameResponse(0, Operation.PATCH, game, "");
        }
    }
}