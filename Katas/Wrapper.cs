using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Katas.Wrap
{
    public static class Wrapper
    {
        public static string Wrap(string unWrappedText, int wrappedZise)
        {
            var actualCount = 0;
            var wrappedword = string.Empty;
            char previousCharOfWord = '\0';
            
            if (unWrappedText == "\n")
            {
                return unWrappedText;
            }

            if ((string.IsNullOrEmpty(unWrappedText)) || (string.IsNullOrWhiteSpace(unWrappedText)))
            {
                return string.Empty;
            }

            foreach (var charOfWord in unWrappedText)
            {
                if (char.IsWhiteSpace(charOfWord) && previousCharOfWord != '\n')
                {
                    wrappedword += "\n";
                    actualCount = 0;
                    continue;
                }
                else if (char.IsWhiteSpace(charOfWord) && previousCharOfWord == '\n')
                {
                    actualCount = 0;
                    continue;
                }

                wrappedword += charOfWord.ToString();
                previousCharOfWord = charOfWord;
                actualCount++;

                if (actualCount == wrappedZise)
                {
                    previousCharOfWord = '\n';
                    wrappedword += "\n";
                    actualCount = 0;
                }
            }
            
            return wrappedword;
        }
    }
}
