using System;
using System.Collections.Generic;
using System.Text;
using PersonalWebApi.Services.TicTacToe.Models;

namespace PersonalWebApi.Services.TicTacToe.Interfaces
{
    public interface ITicTacToeService
    {
        Move FindBestMove(TicTacToeBoardModel model);
    }
}
