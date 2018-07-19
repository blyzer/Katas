using System;
using System.Collections.Generic;

namespace Katas.ArabicToRoman
{
    public static class ArabicNumeralsToRomanNumerals
    {
        /// <summary>
        /// This Dictionary help to identify the roman number to be converted.
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

        public static string Of(int arabic)
        {
            if (arabic <= 0)
            {
                return "is emtpy the number";
            }


            string result = "";

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
