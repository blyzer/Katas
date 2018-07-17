using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Katas.Wrap
{
    public static class Wrapper
    {
        public static void WrapWithRgex(string unWrappedText)
        {
            List<string> wrappedWords = new List<string>();
            wrappedWords = Regex.Matches(unWrappedText, "([a-zA-Z0-9]*\\S)").Cast<Match>().Select(m => m.Value).ToList();
            wrappedWords.ToString().Replace(" ", "");

            foreach (var item in wrappedWords)
            {
                Console.WriteLine(item);
            }
        }

        public static string Wrap(string unWrappedText, int wrappedZise)
        {

            if (unWrappedText.Length <= wrappedZise)
                return unWrappedText;

            if (unWrappedText[wrappedZise] == ' ')
                return unWrappedText.Substring(0, wrappedZise) + '\n' + Wrap(unWrappedText.Substring(wrappedZise + 1), wrappedZise);

            var previousSpace = unWrappedText.Substring(0, wrappedZise).LastIndexOf(' ');
            if (previousSpace != -1)
                return unWrappedText.Substring(0, previousSpace) + '\n' + Wrap(unWrappedText.Substring(previousSpace + 1), previousSpace);

            return unWrappedText.Substring(0, wrappedZise) + '\n' + Wrap(unWrappedText.Substring(wrappedZise + 0), wrappedZise);
        }
    }
}
