using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Haiku
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Please supply a string");
            }
            if (text.Length == 1)
            {
                return text.ToUpper();
            }
            return text[0].ToString().ToUpper() + text.Substring(1).ToLower();
        }

        public static string GetIndefiniteArticle(this string nounPhrase)
        {
            string word;
            Match m = Regex.Match(nounPhrase, @"\w+");
            if (m.Success)
            {
                word = m.Groups[0].Value;
            }
            else
            {
                return "an";
            }

            string wordi = word.ToLower();
            if (new[]
                    {
                        "euler",
                        "heir",
                        "honest",
                        "hono"
                    }.Any(anword => wordi.StartsWith(anword)))
            {
                return "an";
            }

            if (wordi.StartsWith("hour") && !wordi.StartsWith("houri"))
            {
                return "an";
            }

            char[] charList = {
                                  'a',
                                  'e',
                                  'd',
                                  'h',
                                  'i',
                                  'l',
                                  'm',
                                  'n',
                                  'o',
                                  'r',
                                  's',
                                  'x'
                              };
            if (wordi.Length == 1)
            {
                return wordi.IndexOfAny(charList) == 0 ? "an" : "a";
            }

            if (Regex.Match(word, "(?!FJO|[HLMNS]Y.|RY[EO]|SQU|(F[LR]?|[HL]|MN?|N|RH?|S[CHKLMNPTVW]?|X(YL)?)[AEIOU])[FHLMNRSX][A-Z]").Success)
            {
                return "an";
            }

            if (new[]
                    {
                        "^e[uw]",
                        "^onc?e\b",
                        "^uni([^nmd]|mo)",
                        "^u[bcfhjkqrst][aeiou]"
                    }.Any(regex => Regex.IsMatch(wordi, regex)))
            {
                return "a";
            }

            if (Regex.IsMatch(word, "^U[NK][AIEO]"))
            {
                return "a";
            }
            if (word == word.ToUpper())
            {
                return wordi.IndexOfAny(charList) == 0 ? "an" : "a";
            }

            if (wordi.IndexOfAny(new[]
                                     {
                                         'a',
                                         'e',
                                         'i',
                                         'o',
                                         'u'
                                     }) == 0)
            {
                return "an";
            }

            return Regex.IsMatch(wordi, "^y(b[lor]|cl[ea]|fere|gg|p[ios]|rou|tt)") ? "an" : "a";
        }
    }
}