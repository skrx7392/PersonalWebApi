using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonalWebApi.Models;
using PersonalWebApi.Services.TicTacToe.Interfaces;
using PersonalWebApi.Services.TicTacToe.Models;

namespace PersonalWebApi.Controllers.ApiControllers
{
    public class TicTacToeController : ApiController
    {
        private ITicTacToeService TicTacToeService { get; set; }

        public TicTacToeController(ITicTacToeService ticTacToeservice)
        {
            this.TicTacToeService = ticTacToeservice;
        }

        [HttpPost]
        public TicTacToeBoardModel MakeAiMove([FromBody]TicTacToeBoardViewModel viewModel)
        {
            var model = new TicTacToeBoardModel();
            model.AiState = (EState) viewModel.AiState;
            model.PlayerState = (EState) viewModel.PlayerState;
            model.Grid = viewModel.Grid;
            var move = this.TicTacToeService.FindBestMove(model);
            model.Grid[move.Row][move.Column] = (char)model.AiState;
            return model;
        }
    }
}
