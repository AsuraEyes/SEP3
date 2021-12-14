using System;
using System.ServiceModel;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier.Data.GameWebServices.Games;
using BusinessTier.MiddlePoint.GameMiddlePoints.Games;
using BusinessTier.Models;

namespace BusinessTierTests
{
    [TestClass]
    public class GameTest
    {
        private static readonly IGameWebService GameWebService = new GameWebService();
        private readonly IGameMiddlePoint gameMiddlePoint = new GameMiddlePoint(GameWebService, null);

        [TestMethod]
        public async Task ComplexityAndTimeEstimationInvalidAsync()
        {
            // The test fails, because the values of complexity and time estimation are not 1,2 or 3
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
        
        [TestMethod]
        public async Task ComplexityInvalidAsync()
        {
            // The test fails, because the value of complexity is not 1,2 or 3
            try
            {
                var newGame = new Game
                {
                    name = "Go",
                    complexity = 4,
                    timeEstimation = 2,
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
        
        [TestMethod]
        public async Task TimeEstimationInvalidAsync()
        {
            // The test fails, because the value of time estimation is not 1,2 or 3
            try
            {
                var newGame = new Game
                {
                    name = "Go",
                    complexity = 1,
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
        
        [TestMethod]
        public async Task AddGameAsync()
        {
            Game newGame;
            Game gameCheck;
            try
            {
                newGame = new Game
                {
                    name = "Go",
                    complexity = 2,
                    timeEstimation = 1,
                    minNumberOfPlayers = 12
                };
                await gameMiddlePoint.AddGameAsync(newGame);

                var filter = new FilterRest();
                var game = await gameMiddlePoint.GetLimitedSearchGglAsync(filter);
                gameCheck = await GameWebService.GetGameAsync(game.Count);
            }
            catch (AggregateException)
            {
                return;
            }
            catch (FaultException)
            {
                return;
            }
            Assert.AreEqual(newGame, gameCheck);
        }
    }
}