using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FreqDictionary
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void FileExistTest()
        {
            Assert.AreEqual(true, File.Exists(@"C:\Users\setup\Desktop\north.sql"));
        }
        [Test]
        public void FileContentIsNullTest()
        {
            int count = File.ReadAllLines(@"C:\Users\setup\Desktop\north.sql").Count();
            bool test = false;
            if (count > 0)
                test = true;
            Assert.AreEqual(true, test);
        }
        [Test]
        public void CountOfWordsTest()
        {
            Dictionary<string, int> keys = freqDict(@"C:\Users\setup\Desktop\north.sql");
            bool a = false;
            if (keys.ContainsKey("Table") && keys["Table"] > 2)
                a = true;
            Assert.AreEqual(true,a);
        }
        [Test]
        public void DictionarySimilarTest()
        {
            Dictionary<string, int> keys = freqDict(@"C:\Users\setup\Desktop\north.sql");
            bool a = true;
            foreach (var item in keys)
            {
                if(item.Key == "")
                {
                    a = false;
                    break;
                }
            }
            Assert.AreEqual(true, a);
        }
        [Test]
        public void WordTest()
        {

            Dictionary<string, int> keys = freqDict(@"C:\Users\setup\Desktop\north.sql");
            bool a = true;
            foreach (var item in keys)
            {
                if(item.Key.Contains('.') || item.Key.Contains(',') || item.Key.Contains(':') || item.Key.Contains(';') || item.Key.Contains('?') || item.Key.Contains('!') || item.Key.Contains(' ') || item.Key.Contains('0') || item.Key.Contains('1') || item.Key.Contains('2') || item.Key.Contains('3') || item.Key.Contains('4') || item.Key.Contains('5') || item.Key.Contains('6') || item.Key.Contains('7') || item.Key.Contains('8') || item.Key.Contains('9'))
                {
                    a = false;
                }
            }
            Assert.AreEqual(true, a);
            
        }
        static Dictionary<string, int> freqDict(string path)
        {
            char[] separators = { '.', ',', ':', ';', '?', '!', '\n', '\t', ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var wordCount = new Dictionary<string, int>();
            foreach (var line in File.ReadAllLines(path))
            {
                var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (!wordCount.ContainsKey(word))
                    {
                        wordCount.Add(word, 1);
                    }
                    else
                    {
                        wordCount[word] += 1;
                    }
                }
            }

            return wordCount;
        }
    }
}
