using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FreqDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keys = freqDict(@"C:\Users\setup\Desktop\north.sql");
            foreach (var item in keys)
            {
                Console.WriteLine("Word: " + item.Key + " Count: " + item.Value);
            }
        }

        static Dictionary<string, int>freqDict(string path)
        {
            char[] separators = { '.', ',', ':', ';', '?', '!', '\n', '\t', ' ' };
            var wordCount = new Dictionary<string, int>();
            var uniqueWords = new HashSet<string>();

            foreach (var line in File.ReadAllLines(path))
            {
                var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (uniqueWords.Add(word))
                    {
                        wordCount.Add(word, 1);
                    }
                    else
                    {
                        wordCount[word] = wordCount[word]++;
                    }
                }
            }

            return wordCount;
        }
    }
}
