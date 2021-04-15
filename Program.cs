using System;
using System.Linq;

namespace MarixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimension[0];
            int cols = dimension[1];

            if (rows <= 0 || cols <= 0)
            {
                Console.WriteLine("Invalid input!");                
            }

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (rowData.Length <= 0 || rowData.Length < cols || rowData.Length > cols)
                {
                    Console.WriteLine("Invalid input!");                    
                    continue;
                }

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] comandParts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (comandParts.Length != 5)  // numberIput Commands are not correcrt,less or more
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string comand = comandParts[0];

                if (comand != "swap")  //first element must be the comand -> swap /if not end !
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int rowIdx = int.Parse(comandParts[1]);
                int colIdx = int.Parse(comandParts[2]);
                int replaceRowIdx = int.Parse(comandParts[3]);
                int replaceColIdx = int.Parse(comandParts[4]);

                if (rowIdx >= 0 && rowIdx <= rows - 1 && colIdx >= 0 && colIdx <= cols - 1 && 
                    replaceColIdx >= 0 && replaceColIdx <= cols -1 && replaceRowIdx >= 0 && 
                    replaceRowIdx <= rows - 1)
                {
                    string currElement = matrix[rowIdx, colIdx];
                    matrix[rowIdx, colIdx] = matrix[replaceRowIdx, replaceColIdx];
                    matrix[replaceRowIdx, replaceColIdx] = currElement;
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
