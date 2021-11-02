using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SEP3_Blazor.Models;

namespace SEP3_Blazor.Persistence
{
    public class FileContext
    {
        private readonly string goldenGameListsFile = "goldenGameLists.json";

        public FileContext()
        {
            GoldenGameLists = File.Exists(goldenGameListsFile) ? ReadData<GoldenGameList>(goldenGameListsFile) : new List<GoldenGameList>();
        }

        public IList<GoldenGameList> GoldenGameLists { get; }

        private IList<T> ReadData<T>(string fileName)
        {
            using (var jsonReader = File.OpenText(fileName))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            var jsonAdults = JsonSerializer.Serialize(GoldenGameLists, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (var outputFile = new StreamWriter(goldenGameListsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }
    }
}