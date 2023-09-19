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
        private readonly int[,] _matrix;
        private readonly int _rows;
        private readonly int _columns;

        public int[,] Matrix => _matrix.Clone() as int[,];

        public MatrixHandler(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows), "Amount of rows and columns must be positive");
            }

            (_rows, _columns) = (rows, columns);
            _matrix = new int[_rows, _columns];
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

            _rows = matrix.GetLength(0);
            _columns = matrix.GetLength(1);
            _matrix = matrix.Clone() as int[,];
        }

        public void FillMatrix()
        {
            Random rand = new();

            for (int r = 0; r < _rows; ++r)
            {
                for (int c = 0; c < _columns; ++c)
                {
                    _matrix[r, c] = rand.Next(0, 101);
                }
            }
        }

        public void PrintMatrix()
        {
            for (int r = 0; r < _rows; ++r)
            {
                for (int c = 0; c < _columns; ++c)
                {
                    if (r == c)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(string.Format("{0, -5}", _matrix[r, c] + " "));
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(string.Format("{0, -5}", _matrix[r, c] + " "));
                    }
                }

                Console.WriteLine();
            }
        }

        public int GetMatrixTrace()
        {
            int smallerDimension = Math.Min(_rows, _columns);
            int matrixTrace = 0;

            for (int i = 0; i < smallerDimension; ++i)
            {
                matrixTrace += _matrix[i, i];
            }

            return matrixTrace;
        }
    }
}
