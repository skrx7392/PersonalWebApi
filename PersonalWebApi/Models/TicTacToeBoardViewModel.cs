using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalWebApi.Models
{
    public class TicTacToeBoardViewModel
    {
        public char[][] Grid { get; set; }
        public char PlayerState { get; set; }
        public char AiState { get; set; }
    }
}