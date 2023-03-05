using System;
using System.Collections.Generic;
using System.Text;

namespace JustifyClassLibrary
{
    public class StaticClass
    {
        public static string TextJustify3(string content, int maxWidth)
        {
            List<string> result = new List<string>();
            var sb = new StringBuilder();
            string[] words = content.Split(new char[0]);

            int i = 0;
            int n = words.Length;

            while (i < n)
            {
                int j = i + 1;
                int lineLength = words[i].Length;

                while (j < n && (lineLength + words[j].Length + (j - i - 1) < maxWidth))
                {
                    lineLength += words[j].Length;
                    ++j;
                }

                int diff = maxWidth - lineLength;
                int numberOfWords = j - i;
                if (numberOfWords == 1 || j >= n)
                {
                    sb.AppendLine(LeftJustify3(words, diff, i, j));
                }
                else
                {
                    sb.AppendLine(MiddleJustify3(words, diff, i, j));
                }

                i = j;
            }
            return sb.ToString();
        }

        public static string LeftJustify3(string[] words, int diff, int i, int j)
        {
            int spacesOnRight = diff - (j - i - 1);
            StringBuilder result = new StringBuilder(words[i]);
            for (int k = i + 1; k < j; ++k)
            {
                result.Append("&" + words[k]);
            }
            for(int _x = 0; _x < spacesOnRight; _x++)
            {
                result.Append("&");
            }
            return result.ToString();
        }

        public static string MiddleJustify3(string[] words, int diff, int i, int j)
        {
            int spacesNeeded = j - i - 1;
            int spaces = diff / spacesNeeded;
            int extraSpaces = diff % spacesNeeded;

            StringBuilder result = new StringBuilder(words[i]);
            for (int k = i + 1; k < j; ++k)
            {
                int spacesToApply = spaces + (extraSpaces-- > 0 ? 1 : 0);
                for (int _x = 0; _x < spacesToApply; _x++)
                {
                    result.Append("&");
                }
                result.Append(words[k]);
            }

            return result.ToString();

        }

        
        
        public static List<string> TextJustify2(string content, int maxWidth)
        {
            List<string> result = new List<string>();
            string[] words = content.Split(new char[0]);

            int i = 0;
            int n = words.Length;

            while (i < n)
            {
                int j = i + 1;
                int lineLength = words[i].Length;

                while (j < n && (lineLength + words[j].Length + (j - i - 1) < maxWidth))
                {
                    lineLength += words[j].Length;
                    ++j;
                }

                int diff = maxWidth - lineLength;
                int numberOfWords = j - i;
                if (numberOfWords == 1 || j >= n)
                {
                    result.Add(LeftJustify(words, diff, i, j));
                }
                else
                {
                    result.Add(MiddleJustify(words, diff, i, j));
                }

                i = j;
            }
            return result;
        }

        public static string MiddleJustify(string[] words, int diff, int i, int j)
        {
            int spacesNeeded = j - i - 1;
            int spaces = diff / spacesNeeded;
            int extraSpaces = diff % spacesNeeded;

            StringBuilder result = new StringBuilder(words[i]);
            for (int k = i + 1; k < j; ++k)
            {
                int spacesToApply = spaces + (extraSpaces-- > 0 ? 1 : 0);
                result.Append(' ', spacesToApply).Append(words[k]);

            }

            return result.ToString();

        }

        public static string LeftJustify(string[] words, int diff, int i, int j)
        {
            int spacesOnRight = diff - (j - i - 1);
            StringBuilder result = new StringBuilder(words[i]);
            for (int k = i + 1; k < j; ++k)
            {
                result.Append(" " + words[k]);
            }
            result.Append(' ', spacesOnRight);
            return result.ToString();
        }

        public static string TextJustify(string content, int maxWidth)
        {
            List<string> res = new List<string>();
            string[] words = content.Split(new char[0]);
            int size = words.Length;
            int index = 0;

            while (index < size)
            {
                int totalChars = words[index].Length;
                int lastIndex = index + 1;
                int gaps = 0;

                while (lastIndex < size)
                {
                    if (totalChars + 1 + words[lastIndex].Length > maxWidth)
                    {
                        break;
                    }
                    totalChars += 1 + words[lastIndex].Length;
                    gaps++;
                }

                StringBuilder sb = new StringBuilder();

                if (lastIndex == size || gaps == 0)
                {
                    for (int i = index; i < lastIndex; ++i)
                    {
                        sb.Append(words[i]).Append(' ');
                    }
                    sb.Remove(sb.Length - 1, 1);
                    while (sb.Length < maxWidth)
                    {
                        sb.Append(' ');
                    }
                }
                else
                {
                    int spaces = (maxWidth - totalChars) / gaps;
                    int restSpaces = (maxWidth - totalChars) % gaps;
                    for (int i = index; i < lastIndex - 1; ++i)
                    {
                        sb.Append(words[i]).Append(' ');
                        for (int j = 0; j < spaces + (i - index < restSpaces ? 1 : 0); ++j)
                        {
                            sb.Append(' ');
                        }
                    }
                    sb.Append(words[lastIndex - 1]);
                }

                res.Add(sb.ToString());
                index = lastIndex;
            }
            var finalString = String.Join(" ", res);
            return finalString;
        }
    }
}
