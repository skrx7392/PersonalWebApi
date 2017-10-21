using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalWebApi.Controllers.ApiControllers;
using PersonalWebApi.Models;
using PersonalWebApi.Services.TicTacToe;
using PersonalWebApi.Services.TicTacToe.Interfaces;
using PersonalWebApi.Services.TicTacToe.Models;

namespace PersonalWebApi.Tests.Controllers.ApiControllers
{
    [TestClass]
    public class TicTacToeControllerTest
    {
        [TestMethod]
        public void MakeAiMoveTest()
        {
            ITicTacToeService service = new TicTacToeService();
            TicTacToeController controller = new TicTacToeController(service);
            
            TicTacToeBoardViewModel model = new TicTacToeBoardViewModel()
            {
                Grid = new char[][]
                {
                    new [] {'X', 'O', 'X'},
                    new [] {'O', 'O', 'X'},
                    new [] {'-', '-', '-'}
                },
                AiState = 'X',
                PlayerState = 'O'
            };

            Move move = service.FindBestMove(
                new TicTacToeBoardModel() { Grid = model.Grid, AiState = EState.X, PlayerState = EState.O });

            TicTacToeBoardModel board = controller.MakeAiMove(model);

            Move bestMove = new Move() { Row = 2, Column = 2 };
            Assert.IsNotNull(move);
            Assert.IsNotNull(board);
            Assert.AreEqual(board.Grid[move.Row][move.Column], board.Grid[bestMove.Row][bestMove.Column]);
            //Assert.AreEqual(bestMove.Column, move.Column);
        }
    }
}
