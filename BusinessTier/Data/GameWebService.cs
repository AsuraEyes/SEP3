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
        private readonly BookAndPlayPort port;
        private SOAPGameResponse1 response;
        private SOAPGGLResponse1 gglResponse;

        public GameWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPGameResponse1> GetGameResponseAsync(int id, Operation name, Game game)
        {
            SOAPGameRequest soapGameRequest = new SOAPGameRequest();
            soapGameRequest.id = id;
            soapGameRequest.Operation = name;
            soapGameRequest.Game = game;
            SOAPGameRequest1 soapRequest1 = new SOAPGameRequest1(soapGameRequest);
            SOAPGameResponse1 soapResponse1 = new SOAPGameResponse1();
            soapResponse1 = port.SOAPGameAsync(soapRequest1).Result;
            return soapResponse1;
        }
        
        private async Task<SOAPGGLResponse1> GetGGLResponseAsync(Operation name,Filter filter)
        {
            SOAPGGLRequest soapGGLRequest = new SOAPGGLRequest();
            soapGGLRequest.Operation = name;
            soapGGLRequest.Filter = filter;
            SOAPGGLRequest1 soapRequest1 = new SOAPGGLRequest1(soapGGLRequest);
            SOAPGGLResponse1 soapResponse1 = new SOAPGGLResponse1();
            soapResponse1 = port.SOAPGGLAsync(soapRequest1).Result;
            return soapResponse1;
        }
        public async Task<Game> GetGameAsync(int id)
        {
            response = await GetGameResponseAsync(id, Operation.GET, null);
            Game game = response.SOAPGameResponse.game;

            return  game;
        }

        public async Task  SuggestGameAsync(Game game)
        {
            response = await GetGameResponseAsync(0, Operation.CREATE, game);
        }

        public async Task<IList<Game>> GetSuggestedGamesAsync()
        {
            response = await GetGameResponseAsync(0, Operation.GETALL, null);
            return response.SOAPGameResponse.gameList;
        }
        
        public async Task RemoveGameAsync(int id)
        {
            response = await GetGameResponseAsync(id, Operation.REMOVE, null);
        }

        public async Task EditGameAsync(Game game)
        {
            response = await GetGameResponseAsync(0, Operation.UPDATE, game);
        }
        
        public async Task<IList<Game>> GetLimitedSearchGamesAsync(Filter filter)
        {
            gglResponse = await GetGGLResponseAsync(Operation.GETALL, filter);
            return gglResponse.SOAPGGLResponse.gameList;
        }
    }
}