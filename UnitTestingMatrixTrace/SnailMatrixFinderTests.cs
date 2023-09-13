using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace.Tests.UnitTesting.xUnit
{
    public class SnailMatrixFinderTests
    {
        [Fact]
        public void GetMatrixSnail_Null_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => SnailMatrixFinder.GetMatrixSnail(null));
        }

        [Theory]
        [ClassData(typeof(MatrixDataForArgumentOutOfRangeException))]
        public void GetMatrixSnail_IncorrectMatrix_ThrowsArgumentException(int[,] matrix)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SnailMatrixFinder.GetMatrixSnail(matrix));
        }

        [Theory]
        [ClassData(typeof(MatrixDataForSnailPath))]
        public void GetMatrixSnail_CorrectMatrix_ReturnSnailPath(int[,] matrix, string expected)
        {
            // Act
            string actual = SnailMatrixFinder.GetMatrixSnail(matrix);

            // Assert
            Assert.Equal(expected, actual);
        }


        private class MatrixDataForArgumentOutOfRangeException : IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { IncorrectMatrixExamples.matrix1 };
                yield return new object[] { IncorrectMatrixExamples.matrix2 };
                yield return new object[] { IncorrectMatrixExamples.matrix3 };
            }
        }

        private class MatrixDataForSnailPath : IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                    { CorrectMatrixExamples.matrix1, "1" };

                yield return new object[]
                    { CorrectMatrixExamples.matrix2, "1, 2" };

                yield return new object[]
                    { CorrectMatrixExamples.matrix3, "1, 2" };

                yield return new object[]
                    { CorrectMatrixExamples.matrix4, "1, 2, 3, 4, 5, 6, 7, 8, 9, 10" };

                yield return new object[]
                    { CorrectMatrixExamples.matrix5, "1, 2, 3, 4, 5, 6, 7, 8, 9, 10" };

                yield return new object[]
                    { CorrectMatrixExamples.matrix6, "3, 5, 1, 0, 9, 7, 4, 6, 1" };

                yield return new object[]
                    { CorrectMatrixExamples.matrix7, "3, 7, 4, 2, 9, 3, 2, 2, 6, 5, 1, 3, 4, 1, 6, 2, 0, 8, 5, 7" };

                yield return new object[]
                    { CorrectMatrixExamples.matrix8, "2, 6, 3, 1, 6, 7, 2, 1, 5, 3, 0, 3, 1, 7, 8, 4, 4, 8, 5, 0" };
            }
        }
    }
}
