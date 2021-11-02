using System.Collections.Generic;
using SEP3_Blazor.Models;

namespace SEP3_Blazor.Data
{
    public interface IGoldenGameListService
    {
        IList<GoldenGameList> GetAllAdults();
        void AddGoldenGameList(GoldenGameList goldenGameList);
        void RemoveGoldenGameList(int id);
        void UpdateGoldenGameList(GoldenGameList goldenGameList);
        GoldenGameList GetGoldenGameListById(int id);
        GoldenGameList GetAllGoldenGameLists(int id);
    }
}