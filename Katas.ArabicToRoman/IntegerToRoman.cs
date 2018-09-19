using System.Collections.Generic;

namespace Katas.IntegerToRoman
{
    public static class IntegerToRoman
    {
        /// <summary>
        ///     This Dictionary help to identify the roman number to be converted.
        /// </summary>
        static readonly Dictionary<string, int> romanToArabics = new Dictionary<string, int>()
        {
            { "ↈ" , 100000 },
            { "ↇ" , 50000  },
            { "ↂ", 10000  },
            { "ↁ" , 5000   },
            { "Z" , 2000   },
            { "M" , 1000   },
            { "CM", 900    },
            { "D" , 500    },
            { "CD", 400    },
            { "C" , 100    },
            { "XC", 90     },
            { "L" , 50     },
            { "XL", 40     },
            { "X" , 10     },
            { "IX", 9      },
            { "V" , 5      },
            { "IV", 4      },
            { "I" , 1      }
        };

        /// <summary>
        ///     Convert arabic number to roman number
        /// </summary>
        /// <param name="arabic"> 
        ///     Integer parameter to convert to roman number string
        /// </param>/>
        ///  <returns>
        ///     Return the arabic number converted to roman number string, by the parameter <paramref name="arabic"/>
        ///  </returns>
        public static string Converter(int arabic)
        {
            /// <summary>
            ///     verifying if minor or equal to zero.
            /// </summary>
            if (arabic <= 0)
            {
                return "is emtpy the number";
            }
            
            string result = "";

            /// <summary>
            /// Iterating the arabic number comparying to roman dictionary string.
            /// </summary>
            foreach (var romanToArabic in romanToArabics)
            {
                while (arabic >= romanToArabic.Value)
                {
                    result += romanToArabic.Key;
                    arabic -= romanToArabic.Value;
                }
            }

            return result;
        }
    }
}
