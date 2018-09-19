namespace Katas.Wrap
{
    public static class Wrapper
    {
        /// <summary>
        ///  This single static function named wrap that takes two arguments, a string, and a column number.        
        /// </summary>
        /// <param name="unWrappedText"> Text without the newline according to the column length size. </param> 
        /// <param name="wrappedZise"> Column length to be wrap the text. </param>/>
        ///  <returns>
        ///  String wrapped by new line accordin to the number on the <paramref name="wrappedZise"/>
        ///  </returns>
        public static string Wrap(string unWrappedText, int wrappedZise)
        {
            /// <summary>Count of chars and previous char of the wrapped word</summary>
            int actualCount = 0;
            string wrappedword = string.Empty;
            char previousCharOfWord = '\0';

            /// <summary>Comparing the character of new line or the length has reached</summary>
            if (unWrappedText == "\n" || unWrappedText.Length <= wrappedZise)
            {
                return unWrappedText;
            }

            /// <summary>Verifying if is null or have a space. </summary>
            if ((string.IsNullOrEmpty(unWrappedText)) || (string.IsNullOrWhiteSpace(unWrappedText)))
            {
                return string.Empty;
            }

            /// <summary>Iterating over unwrapped text.</summary>
            foreach (char charOfWord in unWrappedText)
            {
                /// <summary>Checking white space and the previous char is new line to define if need it add new line character or set actual conut to 0.</summary>
                if (char.IsWhiteSpace(charOfWord) && previousCharOfWord != '\n')
                {
                    wrappedword += "\n";
                    actualCount = 0;
                    continue;
                }

                wrappedword += charOfWord.ToString();
                previousCharOfWord = charOfWord;
                actualCount++;

                /// <summary>has reached the length column.</summary>
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
