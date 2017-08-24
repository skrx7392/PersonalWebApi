using System;
using System.Collections.Generic;
using System.Text;
using PersonalWebApi.Services.TicTacToe.Models;

namespace PersonalWebApi.Services.TicTacToe
{
    public class TicTacToeService
    {
        public char? CheckForWin(TicTacToeBoardModel model, int[] inputLocation)
        {
            bool gameOver = true;
            for (int i = 0; i < model.Grid[inputLocation[0]].Length-1; i++)
            {
                if (model.Grid[inputLocation[0]][i] != model.Grid[inputLocation[0]][i + 1])
                {
                    gameOver = false;
                    break;
                }
            }
            if (gameOver)
                return model.Grid[inputLocation[0]][inputLocation[1]];
            gameOver = true;
            for (int i = 0; i < model.Grid.Length - 1; i++)
            {
                if (model.Grid[i][inputLocation[1]] != model.Grid[i + 1][inputLocation[1]])
                {
                    gameOver = false;
                    break;
                }
            }
            if(gameOver)
                return model.Grid[inputLocation[0]][inputLocation[1]];
            gameOver = true;
            if (model.Grid.Length % 2 == 0 || (inputLocation[0] != inputLocation[1] || inputLocation[0]+inputLocation[1]!=model.Grid.Length - 1))
                return null;
            for (int i = 0; i < model.Grid.Length; i++)
            {
                if (model.Grid[i][i] != model.Grid[i + 1][i + 1])
                {
                    gameOver = false;
                    break;
                }
            }
            if (gameOver)
                return model.Grid[inputLocation[0]][inputLocation[1]];
            gameOver = true;
            for (int i = 0; i < model.Grid.Length; i++)
            {
                if (model.Grid[i][model.Grid[i].Length - 1 - i] != model.Grid[i - 1][model.Grid[i - 1].Length - 1 - i - 1])
                {
                    gameOver = false;
                    break;
                }
            }
            if (gameOver)
                return model.Grid[inputLocation[0]][inputLocation[1]];
            return null;
        }
    }
}
