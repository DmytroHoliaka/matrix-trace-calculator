using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace
{
    public static class MatrixTraceFinder
    {
        public static int GetMatrixTrace(int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null");
            }

            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                throw new ArgumentOutOfRangeException("A matrix cannot have zero dimension");
            }

            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                return GetSquareMatrixTrace(matrix);
            }

            return GetRectangleMatrixTrace(matrix);
        }

        private static int GetSquareMatrixTrace(int[,] matrix)
        {
            int matrixTrace = 0;

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                matrixTrace += matrix[i, i];
            }

            return matrixTrace;
        }

        private static int GetRectangleMatrixTrace(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (rows > columns)
            {
                return GetBottomRectangleMatrixTrace(matrix);
            }

            return GetRightRectangleMatrixTrace(matrix);
        }

        private static int GetRightRectangleMatrixTrace(int[,] matrix)
        {
            if (matrix.GetLength(0) == 1)
            {
                return matrix[0, 0];
            }

            int matrixTrace = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0) - 1; ++i)
            {
                matrixTrace += matrix[i, i + 1] + matrix[i + 1, i + 1];
            }

            return matrixTrace;
        }

        private static int GetBottomRectangleMatrixTrace(int[,] matrix)
        {
            if (matrix.GetLength(1) == 1)
            {
                return matrix[0, 0];
            }

            int matrixTrace = 0;

            for (int i = 0; i < matrix.GetLength(1) - 1; ++i)
            {
                matrixTrace += matrix[i, i] + matrix[i, i + 1];
            }

            return matrixTrace;
        }
    }
}
