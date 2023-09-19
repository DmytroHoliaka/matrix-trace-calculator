using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace
{
    public static class DataParser
    {
        public static int GetPositiveInt(string strNum)
        {
            if (strNum is null)
            {
                throw new ArgumentNullException(nameof(strNum), "Null is incorrect value for input line");
            }

            if(strNum == string.Empty || !int.TryParse(strNum, out int _) || Convert.ToInt32(strNum) <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(strNum), "Input line is incorrect");
            }

            return Convert.ToInt32(strNum);
        }
    }
}

