using System;

// Given a n x n board and 2 players
// check if there are 'm' consecutive values in the 
// board in any row, column or any of the diagonals
namespace Gomuku
{
    class Program
    {
        static void Main(string[] args)
        {
            Piece[,] input = {
                        {Piece.Empty,   Piece.Player1, Piece.Empty,     Piece.Empty},
                        {Piece.Empty,   Piece.Empty,   Piece.Player1,   Piece.Empty},
                        {Piece.Empty,   Piece.Player1, Piece.Empty,     Piece.Empty},
                        {Piece.Empty,   Piece.Empty,   Piece.Empty,     Piece.Empty}
                     };

            Piece winner = GetWinner(input);

            Console.WriteLine("Winner is {0}", winner);
        }

        enum Piece
        {
            Empty,
            Player1,
            Player2
        };

        static Piece GetWinner(Piece[,] board)
        {
            int wins = 2;

            int countOfValuesInRow = 0;
            Piece winner = Piece.Empty;

            // Check row
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1) - 1; j++)
                {
                    if ((board[i, j] != Piece.Empty) &&
                        (board[i, j] == board[i, j + 1])) 
                    {
                        winner = board[i, j];
                        countOfValuesInRow++;
              
                        if (countOfValuesInRow + 1 == wins)
                        {
                            return winner; 
                        }             
                    }
                    else
                    {
                        countOfValuesInRow = 0;   
                    }
                }       
            }

            int countOfValuesInColumn = 0;
            // Check column
            for (int j = 0; j < board.GetLength(1); j++)
            {
                for (int i = 0; i < board.GetLength(0) - 1; i++)
                {
                    if ((board[i, j] != Piece.Empty) &&
                        (board[i, j] == board[i + 1, j]))
                    {
                        winner = board[i, j];
                        countOfValuesInColumn++;

                        if (countOfValuesInColumn + 1 == wins)
                        {
                            return winner;
                        }
                    }
                    else
                    {
                        countOfValuesInColumn = 0;
                    }
                }
            }
    
            // Lower half of board - left of diagonal 1 - top left to bottom right
            int countOfValuesInLowerDiagonal1 = 0;        
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int row = i, column = 0; 
                    row < (board.GetLength(0) - 1) &&
                    column < (board.GetLength(1) - 1); 
                    row++,
                    column++)
                {
                    if (board[row, column] != Piece.Empty &&
                        board[row, column] == board[row + 1, column + 1])
                    {
                        winner = board[row, column];
                        countOfValuesInLowerDiagonal1++;
             
                        if (countOfValuesInLowerDiagonal1 + 1 == wins)
                        {
                            return winner;
                        }              
                    }
                    else
                    {
                        countOfValuesInLowerDiagonal1 = 0;  
                    }
                }
            }
    
            // Upper half of board - Right of diagonal 1 - top left to bottom right    
            int countOfValuesInUpperDiagonal1 = 0;       
            for(int i = 1; i < board.GetLength(1); i++)
            {
                for(int row = 0, column = i; 
                    row < (board.GetLength(0) - 1) && (column < board.GetLength(1) - 1); 
                    row++, column++)
                {
                    if (board[row, column] != Piece.Empty &&
                        board[row, column] == board[row + 1, column + 1])
                    {
                        winner = board[row, column];
                        countOfValuesInUpperDiagonal1++;
             
                        if (countOfValuesInUpperDiagonal1 + 1 == wins)
                        {
                            return winner;
                        }              
                    }
                    else
                    {
                        countOfValuesInUpperDiagonal1 = 0;  
                    }     
                }
            }
    
            // Upper  half of board - left of diagonal 2 - bottom left to top right
            int countOfValuesInUpperDiagonal2 = 0;
    
            for(int i = board.GetLength(0) - 1; i >= 0; i--)
            {
                for(int row = i, column = 0; row >= 1 && column < board.GetLength(1) - 1; row--, column++)
                {
                    if ((board[row, column] != Piece.Empty) && (board[row, column] == board[row - 1, column + 1]))
                    {
                        winner = board[row, column];
                        countOfValuesInUpperDiagonal2++;
              
                        if (countOfValuesInUpperDiagonal2 + 1 == wins)
                        {
                            return winner;  
                        } 
                    }
                    else
                    {
                        countOfValuesInUpperDiagonal2 = 0;   
                    }
                }
            }
    
    
            // Lower half of board - Right of diagonal 2 - bottom left to top right
            int countOfValuesInLowerDiagonal2 = 0;
            for(int i = 1; i < board.GetLength(1); i++)
            {
                for(int row = board.GetLength(0) - 1, column = i;
                    row >= 1 && column < board.GetLength(1) - 1;
                    row--, column++)
                {
                    if ((board[row, column] != Piece.Empty) && (board[row, column] == board[row - 1, column + 1]))
                    {
                        winner = board[row, column];
                        countOfValuesInLowerDiagonal2++;
             
                        if (countOfValuesInLowerDiagonal2 + 1 == wins)
                        {
                            return winner;  
                        } 
                    }
                    else
                    {
                        countOfValuesInLowerDiagonal2 = 0;   
                    }              
                }
            }
     
            return Piece.Empty; 
        }
    }
}
