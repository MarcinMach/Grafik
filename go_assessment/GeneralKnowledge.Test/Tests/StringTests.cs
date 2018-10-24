using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            // TODO:
            // Complete the methods below

            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };
                
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }

        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";
            var dictionary = new Dictionary<char, int>();
            foreach(var ch in word)
            {
                if (!char.IsLetter(ch))
                {
                    continue;
                }
                if(dictionary.ContainsKey(ch))
                {
                    dictionary[ch]++;
                }
                else
                {
                    dictionary.Add(ch, 1);
                }
                
            }
            var showDictionary = dictionary;
             
            // TODO:
            // Write an algoritm that gets the unique characters of the word below 
            // and counts the number of occurences for each character found
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // TODO: 


             return String.Concat(a.OrderByDescending(x => x)).Equals(String.Concat(b.OrderByDescending(x => x)));
            // Write logic to determine whether a is an anagram of b

        }
    }
}
