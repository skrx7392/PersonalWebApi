using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalWebApi.Services.TicTacToe;
using PersonalWebApi.Services.TicTacToe.Models;

namespace PersonalWebApi.Tests.Services
{
    [TestClass]
    public class TicTacToeServiceTest
    {
        [TestMethod]
        public void FindBestMoveTest()
        {
            TicTacToeService service = new TicTacToeService();

            TicTacToeBoardModel model = new TicTacToeBoardModel()
            {
                Grid = new char[][]
                {
                    new [] {'X', 'O', 'X'},
                    new [] {'O', 'O', 'X'},
                    new [] {'-', '-', '-'}
                },
                AiState = EState.X,
                PlayerState = EState.O
            };
            
            Move move = service.FindBestMove(model);

            Move bestMove = new Move() {Row = 2, Column = 2};
            Assert.IsNotNull(move);
            Assert.AreEqual(bestMove.Row, move.Row);
            Assert.AreEqual(bestMove.Column, move.Column);
        }
    }
}
