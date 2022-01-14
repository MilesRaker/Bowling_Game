using Bowling_Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BowlingGameUnitTest
{
    [TestClass]
    public class BowlingGameUnitTest
    {
        [TestMethod]
        public void AllGuttersGameShouldBeZero()
        {
            int rolls = 20;
            int pins = 0;

            Game game = new Game();
            RollMany(game, rolls, pins);//helper function
            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void AllOnesGameShouldScoreTwenty()
        {
            int rolls = 20;
            int pins = 1;

            Game game = new Game();
            RollMany(game, rolls, pins);//helper function
            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void SpareShouldGetNextRollBonus()
        {
            Game game = new Game();
            game.Roll(5); //first roll
            game.Roll(5); //second roll, knocked them all down, SPARE
            game.Roll(3); //the value of this roll should be counted twice
            game.Roll(3);
            RollMany(game, 16, 0); //get 0 on the rest of the rolls
            Assert.AreEqual(19, game.Score());
        }

        [TestMethod]
        public void StrikeShouldGetTwoRollBonus()
        {
            Game game = new Game();
            game.Roll(10); //strike
            game.Roll(2);
            game.Roll(6);
            RollMany(game, 17, 0);
            Assert.AreEqual(26, game.Score());
        }

        [TestMethod]
        public void PerfectGameShouldGetPerfectScore()
        {
            Game game = new Game();
            RollMany(game, 12, 10);
            Assert.AreEqual(300, game.Score());
        }


        //helper function
        private void RollMany(Game game, int rolls, int pins)
        {
            for (int roll = 0; roll < rolls; roll++)
            {
                game.Roll(pins);
            }
        }
    }
}