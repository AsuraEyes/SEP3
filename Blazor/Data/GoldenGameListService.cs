using System.Collections.Generic;
using System.Linq;
using SEP3_Blazor.Models;
using SEP3_Blazor.Persistence;

namespace SEP3_Blazor.Data
{
    public class GoldenGameListServiceJson : IGoldenGameListService
        {
            private readonly FileContext FileContext = new();

            public IList<GoldenGameList> GetAllGoldenGameLists()
            {
                IList<GoldenGameList> tmp = new List<GoldenGameList>(FileContext.GoldenGameLists);
                return tmp;
            }

            public IList<GoldenGameList> GetAllAdults()
            {
                throw new System.NotImplementedException();
            }

            public void AddGoldenGameList(GoldenGameList goldenGameList)
            {
                var max = FileContext.GoldenGameLists.Max(goldenGameList => goldenGameList.Id);
                goldenGameList.Id = ++max;
                FileContext.GoldenGameLists.Add(goldenGameList);
                FileContext.SaveChanges();
            }

            public IList<Event> GetAllEvents()
            {
                IList<Event> events = new List<Event>();
                var goldenGameLists = GetAllGoldenGameLists();
                foreach (var goldenGameList in goldenGameLists) events.Add(goldenGameList.EventName);

                return events;
            }

            public void RemoveGoldenGameList(int id)
            {
                FileContext.GoldenGameLists.Remove(FileContext.GoldenGameLists.First(a => a.Id == id));
                FileContext.SaveChanges();
            }

            public void UpdateGoldenGameList(GoldenGameList goldenGameList)
            {
                var editGoldenGameList = FileContext.GoldenGameLists.First(a => a.Id == goldenGameList.Id);
                editGoldenGameList.Id = goldenGameList.Id;
                editGoldenGameList.ComplexityLevel = goldenGameList.ComplexityLevel;
                editGoldenGameList.TimeEstimation = goldenGameList.TimeEstimation;
                editGoldenGameList.NoPlayers = goldenGameList.NoPlayers;
                editGoldenGameList.Description = goldenGameList.Description;
                editGoldenGameList.AgeTarget = goldenGameList.AgeTarget;
                editGoldenGameList.LinkTutorialGame = goldenGameList.LinkTutorialGame;
                editGoldenGameList.NeededEquipment = goldenGameList.NeededEquipment;
                FileContext.SaveChanges();
            }

            public GoldenGameList GetGoldenGameListById(int id)
            {
                return FileContext.GoldenGameLists.FirstOrDefault(a => a.Id == id);
            }

            public GoldenGameList GetAllGoldenGameLists(int id)
            {
                throw new System.NotImplementedException();
            }
        }
    }
    
