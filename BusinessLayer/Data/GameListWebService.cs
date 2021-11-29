using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class GameListWebService : IGameListWebService
    {
        private BookAndPlayPort port;
        private SOAPGameListResponse1 response;

        public GameListWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPGameListResponse1> getGameListResponse(string username, int gameId ,Operation operation)
        {
            SOAPGameListRequest soapGameListRequest = new SOAPGameListRequest();
            soapGameListRequest.Operation = operation;
            soapGameListRequest.userName = username;
            soapGameListRequest.gameId = gameId;
            SOAPGameListRequest1 soapRequest1 = new SOAPGameListRequest1(soapGameListRequest);
            SOAPGameListResponse1 soapResponse1 = new SOAPGameListResponse1();
            soapResponse1 = await port.SOAPGameListAsync(soapRequest1);
            return soapResponse1;
        }
        
        public async Task<IList<Game>> GetUserGameListAsync(string user)
        {
            response = await getGameListResponse(user, 0, Operation.GET);
            return response.SOAPGameListResponse.gameList;
        }

        public async Task AddGameToUserGameListAsync(string username, int gameId)
        {
            await getGameListResponse(username, gameId, Operation.CREATE);
        }
        
        public async Task RemoveGameFromUserGameList(string username, int gameId)
        {
            await getGameListResponse(username, gameId, Operation.REMOVE);
        }
    
        
    }
}