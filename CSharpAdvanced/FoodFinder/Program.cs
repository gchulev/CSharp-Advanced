using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main()
        {
            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            var foods = new Dictionary<string, bool>()
            {
                {"pear", false },
                {"flour", false },
                {"pork", false},
                {"olive", false }
            };

            var vowels = new Queue<char>(Console.ReadLine().Split(' ').Select(char.Parse));
            var consonants = new Stack<char>(Console.ReadLine().Split(' ').Select(char.Parse));

            while (consonants.Count > 0)
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();

                if (pear.Contains(currentVowel))
                {
                    pear = pear.Replace(currentVowel.ToString(), "");
                }
                if (pear.Contains(currentConsonant))
                {
                    pear = pear.Replace(currentConsonant.ToString(), "");
                }
                if (flour.Contains(currentVowel))
                {
                    flour = flour.Replace(currentVowel.ToString(), "");
                }
                if (flour.Contains(currentConsonant))
                {
                    flour = flour.Replace(currentConsonant.ToString(), "");
                }
                if (pork.Contains(currentVowel))
                {
                    pork = pork.Replace(currentVowel.ToString(), "");
                }
                if (pork.Contains(currentConsonant))
                {
                    pork = pork.Replace(currentConsonant.ToString(), "");
                }
                if (olive.Contains(currentVowel))
                {
                    olive = olive.Replace(currentVowel.ToString(), "");
                }
                if (olive.Contains(currentConsonant))
                {
                    olive = olive.Replace(currentConsonant.ToString(), "");
                }

                vowels.Enqueue(currentVowel);

                if (string.IsNullOrWhiteSpace(pear))
                {
                    foods["pear"] = true;
                }
                if (string.IsNullOrWhiteSpace(flour))
                {
                    foods["flour"] = true;
                }
                if (string.IsNullOrWhiteSpace(pork))
                {
                    foods["pork"] = true;
                }
                if (string.IsNullOrWhiteSpace(olive))
                {
                    foods["olive"] = true;
                }
               
            }

            var foundWords = foods.Where(x => x.Value == true).ToDictionary(x => x.Key, x => x.Value);
            int wordsFoundCount = foods.Where(x => x.Value == true).Count();

            Console.WriteLine($"Words found: {wordsFoundCount}{Environment.NewLine}{string.Join(Environment.NewLine, foundWords.Keys)}");
        }
    }
}
