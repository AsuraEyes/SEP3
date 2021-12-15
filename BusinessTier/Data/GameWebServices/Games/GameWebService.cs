using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.GameWebServices.Games
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
            var soapGameRequest = new SOAPGameRequest
            {
                id = id,
                Operation = name,
                Game = game
            };
            var soapRequest1 = new SOAPGameRequest1(soapGameRequest);
            var soapResponse1 = new SOAPGameResponse1();
            soapResponse1 = port.SOAPGameAsync(soapRequest1).Result;
            return soapResponse1;
        }
        
        private async Task<SOAPGGLResponse1> GetGglResponseAsync(Operation name,Filter filter)
        {
            var soapGglRequest = new SOAPGGLRequest
            {
                Operation = name,
                Filter = filter
            };
            var soapRequest1 = new SOAPGGLRequest1(soapGglRequest);
            var soapResponse1 = await port.SOAPGGLAsync(soapRequest1);
            return soapResponse1;
        }
        public async Task<Game> GetGameAsync(int id)
        {
            response = await GetGameResponseAsync(id, Operation.GET, null);
            var game = response.SOAPGameResponse.game;

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
            gglResponse = await GetGglResponseAsync(Operation.GETALL, filter);
            return gglResponse.SOAPGGLResponse.gameList;
        }
    }
}