
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Tests
{
    [TestFixture]
    public class TicTacToeTests
    {
        [Test]
        public void CreateGame_GameIsInCorrectState()
        {
            Game game = new Game();

            Assert.That(game.MovesCounter, Is.EqualTo(0));
            Assert.That(game.GetState(1), Is.EqualTo(State.Unset));
        }

        [Test]
        public void MakeMove_CounterShifts()
        {
            Game game = new Game();
            game.MakeMove(1);

            Assert.That(game.MovesCounter, Is.EqualTo(1));
        }

        [Test]
        public void MakeInvalidMove_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var game = new Game();
                game.MakeMove(0);
            });
        }

        [Test]
        public void MoveOnTheSameSquare_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var game = new Game();
                game.MakeMove(1);
                game.MakeMove(1);
            });
        }

        [Test]
        public void MakingMoves_SetStateCorrectly()
        {
            Game game = new Game();
            MakeMoves(game, 1,2,3,4);

            Assert.That(game.GetState(1), Is.EqualTo(State.Cross));
            Assert.That(game.GetState(2), Is.EqualTo(State.Circle));
            Assert.That(game.GetState(3), Is.EqualTo(State.Cross));
            Assert.That(game.GetState(4), Is.EqualTo(State.Circle));
           
        }

        [Test]
        public void GetWinner_CirclesWinertically_ReturnsCircles()
        {
            Game game = new Game();

            // 2,5,8 - circles win
            MakeMoves(game, 1, 2, 3, 5, 7, 8);

            Assert.That(game.GetWinner(), Is.EqualTo(Winner.Circles));
        }

        [Test]
        public void GetWinner_CrossesWinDiagonal_ReturnCrosses()
        {
            Game game = new Game();

            //1,5,9 - crosses win
            MakeMoves(game, 1, 4, 5, 2, 9);

            Assert.That(game.GetWinner(), Is.EqualTo(Winner.Crosses));
        }

        [Test]
        public void GetWinner_GameIsUnfinished_ReturnsGameIsUnfinished()
        {
            Game game = new Game();

            MakeMoves(game, 1, 2,4);

            Assert.That(game.GetWinner(), Is.EqualTo(Winner.GameIsUnfinished));
        }

        private void MakeMoves(Game game, params int[] indexes)
        {
            foreach (var index in indexes)
            {
                game.MakeMove(index);
            }

        }
    }
}
