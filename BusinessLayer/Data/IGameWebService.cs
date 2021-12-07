using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BookAndPlaySOAP;


namespace BusinessLayer.Data
{
    public interface IGameWebService
    {
        Task<Game> GetGameAsync(int id);
        Task SuggestGameAsync(Game game);
        Task<IList<Game>> GetGamesAsync(bool approved);

        Task<IList<Game>> GetLimitedSearchGamesAsync(bool approved, Filter filter);
        //Task<IList<Game>> GetUserGamesAsync(string user);
        Task RemoveGameAsync(int id);
        Task EditGameAsync(Game game);
    }
}