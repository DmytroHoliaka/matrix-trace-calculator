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
        private int[,] _matrix;
        private int Rows { get; }      
        private int Columns { get; } 
        
        public int[,] Matrix                
        {
            get => this._matrix.Clone() as int[,];
            private set => this._matrix = value;
        }

        public MatrixHandler(int rows, int columns)
        {
            (this.Rows, this.Columns) = (rows, columns);
            this._matrix = new int[this.Rows, this.Columns];
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
            this._matrix = matrix.Clone() as int[,];
        }

        public void FillMatrix()
        {
            Random rand = new();

            for (int r = 0; r < this.Rows; ++r)
            {
                for (int c = 0; c < this.Columns; ++c)
                {
                    this._matrix[r, c] = rand.Next(0, 101);
                }
            }
        }

        public void PrintMatrix()
        {
            for (int r = 0; r < this.Rows; ++r)
            {
                for (int c = 0; c < this.Columns; ++c)
                {
                    if (r == c)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(string.Format("{0, -5}", this._matrix[r, c] + " "));
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(string.Format("{0, -5}", this._matrix[r, c] + " "));
                    }
                }

                Console.WriteLine();
            }
        }

        public int GetMatrixTrace()
        {
            if (this._matrix.GetLength(0) == this._matrix.GetLength(1))
            {
                return GetSquareMatrixTrace();
            }

            return GetRectangleMatrixTrace();
        }

        private int GetSquareMatrixTrace()
        {
            int matrixTrace = 0;

            for (int i = 0; i < this._matrix.GetLength(0); ++i)
            {
                matrixTrace += this._matrix[i, i];
            }

            return matrixTrace;
        }

        private int GetRectangleMatrixTrace()
        {
            int rows = this._matrix.GetLength(0);
            int columns = this._matrix.GetLength(1);

            if (rows > columns)
            {
                return GetBottomRectangleMatrixTrace();
            }

            return this.GetRightRectangleMatrixTrace();
        }

        private int GetRightRectangleMatrixTrace()
        {
            if (this._matrix.GetLength(0) == 1)
            {
                return this._matrix[0, 0];
            }

            int matrixTrace = this._matrix[0, 0];

            for (int i = 0; i < this._matrix.GetLength(0) - 1; ++i)
            {
                matrixTrace += this._matrix[i, i + 1] + this._matrix[i + 1, i + 1];
            }

            return matrixTrace;
        }

        private int GetBottomRectangleMatrixTrace()
        {
            if (this._matrix.GetLength(1) == 1)
            {
                return this._matrix[0, 0];
            }

            int matrixTrace = 0;

            for (int i = 0; i < this._matrix.GetLength(1) - 1; ++i)
            {
                matrixTrace += this._matrix[i, i] + this._matrix[i, i + 1];
            }

            return matrixTrace;
        }

    }
}
