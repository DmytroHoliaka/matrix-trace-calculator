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

            if(strNum == string.Empty || !IsConvertibleToPositiveInt(strNum))
            {
                throw new ArgumentOutOfRangeException(nameof(strNum), "Input line is incorrect");
            }

            return Convert.ToInt32(strNum);
        }

        private static bool IsConvertibleToPositiveInt(string strNum)
        {
            int firstRealSymbolIndex = strNum.TakeWhile(c => char.IsWhiteSpace(c)).Count();
            int lastRealSymbolIndex = strNum.Length - strNum.Reverse().TakeWhile(c => char.IsWhiteSpace(c)).Count() - 1;

            if (lastRealSymbolIndex < 0)
            {
                return false;
            }

            string numWithoutEdgesSpaces = strNum.Substring(firstRealSymbolIndex, lastRealSymbolIndex - firstRealSymbolIndex + 1);
            int integerMaxLength = Convert.ToString(int.MaxValue).Length;

            if (numWithoutEdgesSpaces.Length > integerMaxLength || numWithoutEdgesSpaces.Length == 0)
            {
                return false;
            }

            char plusChar = '+';

            for (int i = (numWithoutEdgesSpaces[0] == plusChar) ? 1 : 0; i < numWithoutEdgesSpaces.Length; ++i)
            {
                if (!Char.IsDigit(numWithoutEdgesSpaces[i]))
                {
                    return false;
                }
            }

            long extendedNumber = Convert.ToInt64(strNum);

            if (extendedNumber > int.MaxValue || extendedNumber == 0)
            {
                return false;
            }

            return true;
        }
    }
}

