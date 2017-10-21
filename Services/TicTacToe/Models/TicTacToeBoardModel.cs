using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PersonalWebApi.Services.TicTacToe.Models
{
    public class TicTacToeBoardModel
    {
        public char[][] Grid { get; set; }
        public EState PlayerState { get; set; }
        public EState AiState { get; set; }
    }
}
