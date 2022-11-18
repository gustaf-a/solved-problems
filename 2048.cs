using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattisSolutions
{
    //https://open.kattis.com/problems/2048

    class _2048
    {
        static void Main()
        {
            int[,] board = GetBoardInput();
            switch (Console.ReadLine())
            {
                case "0":
                    MakeGameBoardMoveLeft(ref board);
                    break;
                case "1":
                    MakeGameBoardMoveUp(ref board);
                    break;
                case "2":
                    MakeGameBoardMoveRight(ref board);
                    break;
                case "3":
                    MakeGameBoardMoveDown(ref board);
                    break;
                default:
                    break;
            }
            PrintBoard(board);
        }

        private static void PrintBoard(int [,] board)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }

        private static void MakeGameBoardMoveDown(ref int[,] board)
        {
            for (int k = 3; k >= 0; k--)
            {
                for (int i = 3; i >= 0; i--)
                {
                    int currentTile = board[i, k];
                    if (i == 0)
                    {
                    }
                    else
                    {
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (currentTile == 0)
                            {
                                if (board[j, k] != 0)
                                {
                                    board[i, k] = board[j, k];
                                    board[j, k] = 0;
                                    currentTile = board[i, k];
                                }
                            }
                            else if (currentTile == board[j, k])
                            {
                                board[i, k] *= 2;
                                board[j, k] = 0;
                                break;
                            }
                            else if (board[j, k] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }


        private static void MakeGameBoardMoveUp(ref int[,] board)
        {
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int currentTile = board[i, k];
                    if (i == 3)
                    {
                    }
                    else
                    {
                        for (int j = i + 1; j < 4; j++)
                        {
                            if (currentTile == 0)
                            {
                                if (board[j, k] != 0)
                                {
                                    board[i, k] = board[j, k];
                                    board[j, k] = 0;
                                    currentTile = board[i, k];
                                }
                            }
                            else if (currentTile == board[j, k])
                            {
                                board[i, k] *= 2;
                                board[j, k] = 0;
                                break;
                            }
                            else if (board[j, k] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void MakeGameBoardMoveRight(ref int[,] board)
        {
            for (int k = 0; k < 4; k++)
            {
                for (int i = 3; i >= 0; i--)
                {
                    int currentTile = board[k, i];
                    if (i == 0)
                    {
                    }
                    else
                    {
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (currentTile == 0)
                            {
                                if (board[k, j] != 0)
                                {
                                    board[k, i] = board[k, j];
                                    board[k, j] = 0;
                                    currentTile = board[k, i];
                                }
                            }
                            else if (currentTile == board[k, j])
                            {
                                board[k, i] *= 2;
                                board[k, j] = 0;
                                break;
                            }
                            else if (board[k, j] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void MakeGameBoardMoveLeft(ref int[,] board)
        {
            //If move to the left, start in the left corner.
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int currentTile = board[k, i];
                    if (i == 3)
                    {
                    }
                    else
                    {
                        for (int j = i + 1; j < 4; j++)
                        {
                            if (currentTile == 0)
                            {
                                if (board[k, j] != 0)
                                {
                                    board[k, i] = board[k, j];
                                    board[k, j] = 0;
                                    currentTile = board[k, i];
                                }
                            } else if (currentTile == board[k, j])
                            {
                                board[k, i] *= 2;
                                board[k, j] = 0;
                                break;
                            }
                            else if (board[k, j] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }


        private static int[,] GetBoardInput()
        {
            int[,] board = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = Int32.Parse(line[j]);
                }
            }
            return board;
        }
    }
}
