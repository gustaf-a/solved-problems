using System;

namespace KattisSolutions
{
    class EightQueens
    {
        //invalid roinput
        //*.....*.
        //.*.....*
        //....*...
        //.....**.
        //.*.....*
        //.......*
        //.....*..
        //...*....
        //invalid input
        //*.......
        //..*.....
        //....*...
        //......*.
        //.*......
        //.......*
        //.....*..
        //...*....
        //valid input
        //*.......
        //......*.
        //....*...
        //.......*
        //.*......
        //...*....
        //.....*..
        //..*.....
        // https://open.kattis.com/problems/8queens
        static void Main()
        {
            int[,] gameBoard = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    if (line[j] == '.')
                    {
                        gameBoard[i, j] = 0;
                    }
                    else
                    {
                        gameBoard[i, j] = 1;
                    }

                }
            }
            if (GameBoardIsValid(gameBoard))
            {
                Console.WriteLine("valid");
            }
            else
            {
                Console.WriteLine("invalid");
            }
            Console.ReadKey();
        }

        private static bool GameBoardIsValid(int[,] gameBoard)
        {
            int rows = gameBoard.GetLength(0);
            int cols = gameBoard.GetLength(1);

            if (GetGameBoardSum(gameBoard, rows, cols) != 8) return false;

            int startRow = 0;
            int startCol = 0;

            //All rows
            int incrementRow = 0;
            int incrementCol = 1;
            for (startRow = 0; startRow < cols; startRow++)
            {
                if (!SumDirection(gameBoard, startRow, startCol, incrementRow, incrementCol)) return false;
            }
            //All cols
            startRow = 0;
            startCol = 0;
            incrementRow = 1;
            incrementCol = 0;
            for (startCol = 0; startCol < cols; startCol++)
            {
                if (!SumDirection(gameBoard, startRow, startCol, incrementRow, incrementCol)) return false;
            }
            //Check diagonally all top rows
            startRow = 0;
            incrementRow = 1;
            incrementCol = 1;
            //From toprow diagonally down
            for (startCol = 0; startCol < cols; startCol++)
            {
                if (!SumDirection(gameBoard, startRow, startCol, incrementRow, incrementCol)) return false;
            }
            //From left column diagonally down
            startCol = 0;
            for (startRow = 0; startRow < cols; startRow++)
            {
                if (!SumDirection(gameBoard, startRow, startCol, incrementRow, incrementCol)) return false;
            }
            incrementRow = -1;
            incrementCol = 1;
            startRow = rows - 1;
            //From bottomrow diagonally up
            for (startCol = 0; startCol < cols; startCol++)
            {
                if (!SumDirection(gameBoard, startRow, startCol, incrementRow, incrementCol)) return false;
            }
            //From left column diagonally up
            startCol = 0;
            for (startRow = 0; startRow < cols; startRow++)
            {
                if (!SumDirection(gameBoard, startRow, startCol, incrementRow, incrementCol)) return false;
            }
            return true;
        }

        private static int GetGameBoardSum(int[,] gameBoard, int rows, int cols)
        {
            int sumAll = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sumAll += gameBoard[i, j];
                }
            }
            return sumAll;
        }

        private static bool SumDirection(int[,] gameBoard, int startRow, int startCol, int dirRow, int dirCol)
        {
            int sum = 0;
            int i = startRow;
            int j = startCol;
            while (StepIsValid(gameBoard, i, j))
            {
                sum += gameBoard[i, j];
                i = i + dirRow;
                j = j + dirCol;
            }
            if (sum > 1) return false;
            return true;
        }

        private static bool StepIsValid(int[,] gameBoard, int i, int j)
        {
            if (gameBoard.GetLength(0) <= i || i < 0
                || gameBoard.GetLength(1) <= j || j < 0
                ) return false;
            return true;
        }

        private static bool SumAllColumns(int[,] gameBoard)
        {
            //Check sum all columns
            for (int i = 0; i < 8; i++)
            {
                int sum = 0;
                for (int j = 0; j < 8; j++)
                {
                    sum += gameBoard[j, i];
                }
                if (sum != 1) return false;
            }
            return true;
        }

        private static bool SumAllRows(int[,] gameBoard)
        {
            //Check sum all rows
            for (int i = 0; i < 8; i++)
            {
                int sum = 0;
                for (int j = 0; j < 8; j++)
                {
                    sum += gameBoard[i, j];
                }
                if (sum != 1) return false;
            }
            return true;
        }
    }
}
