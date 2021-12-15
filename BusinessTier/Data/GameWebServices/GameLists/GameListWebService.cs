using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.GameWebServices.GameLists
{
    public class GameListWebService : IGameListWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPGameListResponse1 response;

        public GameListWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPGameListResponse1> GetGameListResponseAsync(string username, int gameId ,Operation operation)
        {
            var soapGameListRequest = new SOAPGameListRequest
            {
                Operation = operation,
                userName = username,
                gameId = gameId
            };
            var soapRequest1 = new SOAPGameListRequest1(soapGameListRequest);
            var soapResponse1 = await port.SOAPGameListAsync(soapRequest1);
            return soapResponse1;
        }
        
        public async Task<IList<Game>> GetUserGameListAsync(string user)
        {
            response = await GetGameListResponseAsync(user, 0, Operation.GET);
            return response.SOAPGameListResponse.gameList;
        }

        public async Task AddGameToUserGameListAsync(string username, int gameId)
        {
            await GetGameListResponseAsync(username, gameId, Operation.CREATE);
        }
        
        public async Task RemoveGameFromUserGameListAsync(string username, int gameId)
        {
            await GetGameListResponseAsync(username, gameId, Operation.REMOVE);
        }
    
        
    }
}