using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace
{
    public class MatrixHandler
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int[,] Matrix { get; private set; }

        public MatrixHandler()
        {
            (this.Rows, this.Columns) = GetMatrixDemention();
            this.Matrix = new int[Rows, Columns];
        }

        public MatrixHandler(int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null");
            }

            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(matrix), "A matrix cannot have zero dimension");
            }

            this.Rows = matrix.GetLength(0);
            this.Columns = matrix.GetLength(1);
            this.Matrix = new int[this.Rows, this.Columns];

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    this.Matrix[i, j] = matrix[i, j];
                }
            }
        }

        public void FillMatrix()
        {
            Random rand = new();

            for (int r = 0; r < this.Rows; ++r)
            {
                for (int c = 0; c < this.Columns; ++c)
                {
                    this.Matrix[r, c] = rand.Next(0, 101);
                }
            }
        }

        public void PrintMatrix()
        {
            if (this.Rows == this.Columns)
            {
                this.PrintSquareMatrix();
            }
            else if (this.Rows > this.Columns)
            {
                this.PrintRectangleBottomMatrix();
            }
            else
            {
                this.PrintRectangleRightMatrix();
            }
        }

        private void PrintRectangleRightMatrix()
        {
            for (int r = 0; r < this.Rows; ++r)
            {
                for (int c = 0; c < this.Columns; c++)
                {
                    if (c == r || (c == r + 1 && c != this.Rows))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(string.Format("{0, -5}", this.Matrix[r, c]) + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(string.Format("{0, -5}", this.Matrix[r, c]) + " ");
                    }
                }

                Console.WriteLine();
            }
        }

        private void PrintRectangleBottomMatrix()
        {
            for (int r = 0; r < this.Rows; r++)
            {
                for (int c = 0; c < this.Columns; c++)
                {
                    if ((r, c) == (0, 0) || (c == r && c != this.Columns - 1) || c == r + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(string.Format("{0, -5}", this.Matrix[r, c]) + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(string.Format("{0, -5}", this.Matrix[r, c]) + " ");
                    }
                }

                Console.WriteLine();
            }
        }

        private void PrintSquareMatrix()
        {
            for (int r = 0; r < this.Rows; ++r)
            {
                for (int c = 0; c < this.Columns; ++c)
                {
                    if (r == c)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(string.Format("{0, -5}", this.Matrix[r, c]) + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(string.Format("{0, -5}", this.Matrix[r, c]) + " ");
                    }
                }

                Console.WriteLine();
            }
        }

        private static (int, int) GetMatrixDemention()
        {
            Console.Write("Enter amount of rows: ");
            int rows = DataParser.GetPositiveInt(Console.ReadLine());

            Console.Write("Enter amount of columns: ");
            int columns = DataParser.GetPositiveInt(Console.ReadLine());

            return (rows, columns);
        }
    }
}
