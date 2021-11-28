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

        private async Task<SOAPGameResponse1> getGameResponse(int id, Operation name, Game game, bool approved)
        {
            SOAPGameRequest soapGameRequest = new SOAPGameRequest();
            soapGameRequest.id = id;
            soapGameRequest.Operation = name;
            soapGameRequest.Game = game;
            soapGameRequest.approved = approved;
            SOAPGameRequest1 soapRequest1 = new SOAPGameRequest1(soapGameRequest);
            SOAPGameResponse1 soapResponse1 = new SOAPGameResponse1();
            soapResponse1 = port.SOAPGameAsync(soapRequest1).Result;
            return soapResponse1;
        }
        public async Task<Game> GetGameAsync(int id)
        {
            response = await getGameResponse(id, Operation.GET, null, false);
            Game game = response.SOAPGameResponse.game;

            return  game;
        }

        public async Task  AddGameAsync(Game game)
        {
            response = await getGameResponse(0, Operation.CREATE, game, false);
            //return response.getMessageResponse.Notification;
        }

        public async Task<IList<Game>> GetGamesAsync(bool approved)
        {
            response = await getGameResponse(0, Operation.GETALL, null, approved);
            return response.SOAPGameResponse.gameList;
        }
        
        // public async Task<IList<Game>> GetGGLAsync()
        // {
        //     response = await getGameResponse(0, Operation.GETALL, null, true);
        //     return response.SOAPGameResponse.gameList;
        // }
        //
        // public async Task<IList<Game>> GetSuggestedGamesAsync()
        // {
        //     response = await getGameResponse(0, Operation.GETALL, null, false);
        //     return response.SOAPGameResponse.gameList;
        // }

        // public async Task<IList<Game>> GetUserGamesAsync(string user)
        // {
        //     response = await getGameResponse(0, Operation.GETALL, null);
        //     return response.SOAPGameResponse.gameList;
        // }

        public async Task RemoveGameAsync(int id)
        {
            response = await getGameResponse(id, Operation.REMOVE, null, false);
        }

        public async Task EditGameAsync(Game game)
        {
            response = await getGameResponse(0, Operation.UPDATE, game, false);
        }
    }
}