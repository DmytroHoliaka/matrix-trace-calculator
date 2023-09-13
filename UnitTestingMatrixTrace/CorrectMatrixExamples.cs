using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace.Tests.UnitTesting.xUnit
{
    public class CorrectMatrixExamples
    {
        public readonly static int[,] matrix1 =    // 1 x 1
        {
            { 1 }
        };

        public readonly static int[,] matrix2 =    // 1 x 2 
        {
            { 1, 2 }
        };

        public readonly static int[,] matrix3 =    // 2 x 1
        {
            { 1 },
            { 2 }
        };

        public readonly static int[,] matrix4 =    // 1 x 10
        {
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
        };

        public readonly static int[,] matrix5 =    // 10 x 1
        {
            { 1 }, { 2 }, { 3 }, { 4 }, { 5 }, { 6 }, { 7 }, { 8 }, { 9 }, { 10 }
        };

        public readonly static int[,] matrix6 =    // 3 x 3
        {
            { 3, 5, 1 },
            { 6, 1, 0 },
            { 4, 7, 9 }
        };

        public readonly static int[,] matrix7 =    // 4 x 5
        {
            { 3, 7, 4, 2, 9},
            { 1, 6, 2, 0, 3},
            { 4, 7, 5, 8, 2},
            { 3, 1, 5, 6, 2}
        };

        public readonly static int[,] matrix8 =    // 5 x 4
        {
            { 2, 6, 3, 1 },
            { 7, 8, 4, 6 },
            { 1, 0, 4, 7 },
            { 3, 5, 8, 2 },
            { 0, 3, 5, 1 }
        };
    }
}
