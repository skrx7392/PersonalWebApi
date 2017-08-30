using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using PersonalWebApi.Services.TicTacToe.Interfaces;
using PersonalWebApi.Services.TicTacToe.Models;

namespace PersonalWebApi.Services.TicTacToe
{
    public class TicTacToeService : ITicTacToeService
    {
        private int Evaluate(TicTacToeBoardModel model, Move currentMove)
        {
            bool gameOver = true;
            for (int i = 0; i < model.Grid[currentMove.Row].Length-1; i++)
            {
                if (model.Grid[currentMove.Row][i] != model.Grid[currentMove.Row][i + 1])
                {
                    gameOver = false;
                    break;
                }
            }

            if (gameOver)
                return GiveEvaluationScore(model, currentMove);
            gameOver = true;
            for (int i = 0; i < model.Grid.Length - 1; i++)
            {
                if (model.Grid[i][currentMove.Column] != model.Grid[i + 1][currentMove.Column])
                {
                    gameOver = false;
                    break;
                }
            }
            if(gameOver)
                return GiveEvaluationScore(model, currentMove);
            gameOver = true;
            if (model.Grid.Length % 2 == 0 || (currentMove.Row != currentMove.Column || currentMove.Row + currentMove.Column !=model.Grid.Length - 1))
                return 0;
            for (int i = 0; i < model.Grid.Length; i++)
            {
                if (model.Grid[i][i] != model.Grid[i + 1][i + 1])
                {
                    gameOver = false;
                    break;
                }
            }
            if (gameOver)
                return GiveEvaluationScore(model, currentMove);
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
                return GiveEvaluationScore(model, currentMove);
            return 0;
        }

        private int GiveEvaluationScore(TicTacToeBoardModel model, Move currentMove)
        {
            if ((EState) model.Grid[currentMove.Row][currentMove.Column] == model.AiState)
                return 10;
            if ((EState)model.Grid[currentMove.Row][currentMove.Column] == model.PlayerState)
                return -10;
            return 0;
        }

        private bool IsGameOver(TicTacToeBoardModel model)
        {
            for (int i = 0; i < model.Grid.Length; i++)
            {
                for (int j = 0; j < model.Grid[i].Length; j++)
                {
                    if ((EState) model.Grid[i][j] == EState.Blank)
                        return false;
                }
            }
            return true;
        }

        private int Minimax(TicTacToeBoardModel model, int depth, bool isMax, Move currentMove)
        {
            int score = Evaluate(model, currentMove);
            if (score == 10 || score == -10)
                return score;
            if (IsGameOver(model))
                return 0;

            if (isMax)
            {
                int best = -1000;
                for (int i = 0; i < model.Grid.Length; i++)
                {
                    for (int j = 0; j < model.Grid[i].Length; j++)
                    {
                        if ((EState) model.Grid[i][j] == EState.Blank)
                        {
                            model.Grid[i][j] = (char) model.AiState;
                            best = Math.Max(best,
                                Minimax(model, depth + 1, !isMax, new Move() {Row = i, Column = j}));
                            model.Grid[i][j] = (char) EState.Blank;
                        }
                    }
                }
                return best;
            }
            else
            {
                int best = 1000;
                for (int i = 0; i < model.Grid.Length; i++)
                {
                    for (int j = 0; j < model.Grid[i].Length; j++)
                    {
                        if ((EState) model.Grid[i][j] == EState.Blank)
                        {
                            model.Grid[i][j] = (char)model.PlayerState;
                            best = Math.Min(best,
                                Minimax(model, depth + 1, !isMax, new Move() {Row = i, Column = j}));
                            model.Grid[i][j] = (char) EState.Blank;
                        }
                    }
                }
                return best;
            }
        }

        public Move FindBestMove(TicTacToeBoardModel model)
        {
            int bestVal = -1000;
            Move bestMove = new Move()
            {
                Row = -1,
                Column = -1
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((EState) model.Grid[i][j] == EState.Blank)
                    {
                        var currentMove = new Move() {Row = i, Column = j};
                        model.Grid[i][j] = (char) model.AiState;
                        int moveVal = Minimax(model, 0, false, currentMove);
                        model.Grid[i][j] = (char) EState.Blank;
                        if (moveVal > bestVal)
                        {
                            bestMove.Row = i;
                            bestMove.Column = j;
                            bestVal = moveVal;
                        }
                    }
                }
            }
            return bestMove;
        }
    }
}
