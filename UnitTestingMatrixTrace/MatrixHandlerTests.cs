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
        [Fact]
        public void MatrixHandlerCtor_Null_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new MatrixHandler(null));
        }

        [Theory]
        [ClassData(typeof(MatrixDataForArgumentException))]
        public void MatrixHandlerCtor_IncorrectMatrix_ThrowsArgumentOutOfRangeException(int[,] matrix)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new MatrixHandler(matrix));
        }

        private class MatrixDataForArgumentException : IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {IncorrectMatrixExamples.matrix1};
                yield return new object[] {IncorrectMatrixExamples.matrix2};
                yield return new object[] {IncorrectMatrixExamples.matrix3};
            }
        }
    }
}
