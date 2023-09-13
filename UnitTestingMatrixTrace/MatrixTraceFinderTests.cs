using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixTrace;

namespace MatrixTrace.Tests.UnitTesting.xUnit
{
    public class MatrixTraceFinderTests
    {
        [Fact]
        public void GetMatrixTrace_Null_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => MatrixTraceFinder.GetMatrixTrace(null));
        }

        [Theory]
        [ClassData(typeof(MatrixDataForArgumentException))]
        public void GetMatrixTrace_IncorrectMatrix_ThrowsArgumentOutOfRangeException(int[,] matrix)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => MatrixTraceFinder.GetMatrixTrace(matrix));
        }

        [Theory]
        [ClassData(typeof(MatrixDataForMatrixTrace))]
        public void GetMatrixTrace_CorrectMatrix_ReturnsMatrixTrace(int[,] matrix, int expected)
        {
            // Act
            int actual = MatrixTraceFinder.GetMatrixTrace(matrix);

            // Assert
            Assert.Equal(expected, actual);
        }

        private class MatrixDataForArgumentException : IEnumerable<object[]>
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

        private class MatrixDataForMatrixTrace : IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { CorrectMatrixExamples.matrix1, 1 };
                yield return new object[] { CorrectMatrixExamples.matrix2, 1 };
                yield return new object[] { CorrectMatrixExamples.matrix3, 1 };
                yield return new object[] { CorrectMatrixExamples.matrix4, 1 };
                yield return new object[] { CorrectMatrixExamples.matrix5, 1 };
                yield return new object[] { CorrectMatrixExamples.matrix6, 13 };
                yield return new object[] { CorrectMatrixExamples.matrix7, 37 };
                yield return new object[] { CorrectMatrixExamples.matrix8, 31 };
            }
        }
    }

    
}
