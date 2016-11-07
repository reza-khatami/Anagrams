using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(args[0]);
            }
            catch (Exception)
            {
                Console.WriteLine(args[0] + " NOT FOUND! ");
                Environment.Exit(0);
            }
            for (int i = 1; i < args.Count(); i++)
            {
                if (args[i] == null) continue;
                Console.WriteLine("Anagrams for \"" + args[i] + "\":");
                string InputWord = args[i].ToLower();
                string SortedInputWord = string.Concat(InputWord.OrderBy(c => c));
                sr.BaseStream.Position = 0;
                bool FoundAnagram = false;
                while (!sr.EndOfStream)
                {

                    var DictionaryWord = sr.ReadLine().ToLower();
                    if (string.IsNullOrEmpty(DictionaryWord)) continue;
                    if (InputWord.Length != DictionaryWord.Length) continue;
                    string SortedDictionaryWord = string.Concat(DictionaryWord.OrderBy(c => c));
                    if (SortedDictionaryWord.Equals(SortedInputWord, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine(DictionaryWord);
                        FoundAnagram = true;
                    }
                }
                if (!FoundAnagram) Console.WriteLine("No anagrams found for \"" + InputWord + "\"!");
                Console.WriteLine("");
            }
        }
    }
}
