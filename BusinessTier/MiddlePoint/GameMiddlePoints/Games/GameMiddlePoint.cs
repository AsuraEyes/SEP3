using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.GameWebServices.GameLists;
using BusinessTier.Data.GameWebServices.Games;
using BusinessTier.Models;

namespace BusinessTier.MiddlePoint.GameMiddlePoints.Games
{
    public class GameMiddlePoint : IGameMiddlePoint
    {
        private readonly IGameWebService gameWebService;
        private readonly IGameListWebService gameListWebService;
        private readonly int resultsPerPage = 10;

        public GameMiddlePoint(IGameWebService gameWebService, IGameListWebService gameListWebService )
        {
            this.gameWebService = gameWebService;
            this.gameListWebService = gameListWebService;
        }

        public async Task<IList<Game>> GetLimitedSearchGglAsync(FilterRest filterRest)
        {
            filterRest.ResultsPerPage = resultsPerPage;
            var filter = new Filter();
            if (filterRest.Search != null)
            {
              filter.filter = filterRest.Search;   
            }
            else
            {
                filter.filter = "";
            }
            filter.limit = filterRest.ResultsPerPage;
            filter.offset = (filterRest.CurrentPage - 1) * filterRest.ResultsPerPage;
            var ggl = await gameWebService.GetLimitedSearchGamesAsync(filter);
            return ggl;
        }

        public async Task AddGameAsync(Game game)
        {
            game.approved = true;
            await gameWebService.SuggestGameAsync(game);
        }
        
        public async Task<IList<int>> GetUserGamesIdsAsync(string user)
        {
            var userGames = await gameListWebService.GetUserGameListAsync(user);
            return userGames.Select(g => g.id).ToList();
        }

        public async Task EditGameApprovalAsync(Game game)
        {
            game.approved = true;
            await gameWebService.EditGameAsync(game);
        }
    }
}