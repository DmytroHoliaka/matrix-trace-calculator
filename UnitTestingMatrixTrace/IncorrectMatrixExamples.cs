using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace.Tests.UnitTesting.xUnit
{
    public static class IncorrectMatrixExamples
    {
        public readonly static int[,] matrix1 = new int[0, 0];
        public readonly static int[,] matrix2 = new int[0, 1];
        public readonly static int[,] matrix3 = new int[1, 0];
    }
}
