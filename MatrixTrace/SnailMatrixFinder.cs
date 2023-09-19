using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace
{
    public class SnailMatrixFinder
    {
        private enum Direction
        {
            Right,
            Left,
            Top,
            Bottom
        }

        public static string GetMatrixSnail(int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null");
            }

            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(matrix), "Incorrect matrix dimension");
            }

            int edgeSignal = -1;
            int initialRows = matrix.GetLength(0);
            int initialColumn = matrix.GetLength(1);
            int totalItemAmount = matrix.Length;

            int[,] limitedMatrix = new int[initialRows + 2, initialColumn + 2];
            Fill(limitedMatrix, edgeSignal);

            for (int r = 0; r < initialRows; r++)
            {
                for (int c = 0; c < initialColumn; c++)
                {
                    limitedMatrix[r + 1, c + 1] = matrix[r, c];
                }
            }

            Direction direction = Direction.Right;

            int i = 1;
            int j = 1;
            int itemCount = 1;
            string path = "";
            string separator = ", ";

            while (itemCount < totalItemAmount)
            {
                switch (direction)
                {
                    case Direction.Right:

                        while (limitedMatrix[i, j + 1] != edgeSignal)
                        {
                            path += limitedMatrix[i, j] + separator;
                            limitedMatrix[i, j] = edgeSignal;
                            ++itemCount;
                            ++j;
                        }

                        direction = Direction.Bottom;
                        break;


                    case Direction.Bottom:

                        while (limitedMatrix[i + 1, j] != edgeSignal)
                        {
                            path += limitedMatrix[i, j] + separator;
                            limitedMatrix[i, j] = edgeSignal;
                            ++itemCount;
                            ++i;
                        }

                        direction = Direction.Left;
                        break;


                    case Direction.Left:

                        while (limitedMatrix[i, j - 1] != edgeSignal)
                        {
                            path += limitedMatrix[i, j] + separator;
                            limitedMatrix[i, j] = edgeSignal;
                            ++itemCount;
                            --j;
                        }

                        direction = Direction.Top;
                        break;


                    case Direction.Top:

                        while (limitedMatrix[i - 1, j] != edgeSignal)
                        {
                            path += limitedMatrix[i, j] + separator;
                            limitedMatrix[i, j] = edgeSignal;
                            ++itemCount;
                            --i;
                        }

                        direction = Direction.Right;
                        break;


                    default:
                        break;
                }
            }

            path += limitedMatrix[i, j];
            return path;
        }

        private static void Fill(int[,] matrix, int value)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = value;
                }
            }
        }
    }
}
