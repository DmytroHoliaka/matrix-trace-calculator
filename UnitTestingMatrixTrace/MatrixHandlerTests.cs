using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace.Tests.UnitTesting.xUnit
{
    public class MatrixHandlerTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public void MatrixHandlerCtor_IncorrectDimension_ThrowsArgumentOutOfRangeException(int rows, int columns)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new MatrixHandler(rows, columns));
        }

        [Fact]
        public void MatrixHandlerCtor_Null_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new MatrixHandler(null));
        }

        [Theory]
        [ClassData(typeof(IncorrectMartrix))]
        public void MatrixHandlerCtor_IncorrectMatrix_ThrowsArgumentOutOfRangeException(int[,] matrix)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new MatrixHandler(matrix));
        }

        [Theory]
        [ClassData(typeof(CorrectInstancesOfMatrixHandler))]
        public void GetMatrixTrace_CorrectMatrix_ReturnsMatrixTrace(MatrixHandler matrix, int expected)
        {
            // Arrange
            int actual = matrix.GetMatrixTrace();

            // Assert
            Assert.Equal(expected, actual);
        }


        private class IncorrectMartrix : IEnumerable<object[]>
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

        private class CorrectInstancesOfMatrixHandler : IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new MatrixHandler(CorrectMatrixExamples.matrix1), 1 };
                yield return new object[] { new MatrixHandler(CorrectMatrixExamples.matrix2), 1 };
                yield return new object[] { new MatrixHandler(CorrectMatrixExamples.matrix3), 1 };
                yield return new object[] { new MatrixHandler(CorrectMatrixExamples.matrix4), 1 };
                yield return new object[] { new MatrixHandler(CorrectMatrixExamples.matrix5), 1 };
                yield return new object[] { new MatrixHandler(CorrectMatrixExamples.matrix6), 13 };
                yield return new object[] { new MatrixHandler(CorrectMatrixExamples.matrix7), 20 };
                yield return new object[] { new MatrixHandler(CorrectMatrixExamples.matrix8), 16 };
            }
        }
    }


}
