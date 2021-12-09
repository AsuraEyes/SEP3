using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier.Data.GameWebServices.Games;
using BusinessTier.MiddlePoint.GameMiddlePoints.Games;

namespace BusinessTierTests
{
    [TestClass]
    public class GameTest
    {
        private static readonly IGameWebService GameWebService = new GameWebService();
        private readonly IGameMiddlePoint gameMiddlePoint = new GameMiddlePoint(GameWebService, null);

        [TestMethod]
        public async Task AddGameAsync()
        {
            try
            {
                var newGame = new Game
                {
                    name = "Go",
                    complexity = 4,
                    timeEstimation = 9,
                    minNumberOfPlayers = 12
                };
                await gameMiddlePoint.AddGameAsync(newGame);
            }
            catch (AggregateException)
            {
                return;
            }
            Assert.Fail();
        }
    }
}