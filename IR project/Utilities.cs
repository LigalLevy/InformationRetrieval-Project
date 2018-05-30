using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning.Text.Stemmers;


namespace IR_project
{
    class Utilities
    {
        
        //convert all words to lower case
        public static List<string> ListToLower(string[] words)
        {
            List<string> new_words = new List<string>();

            foreach (string word in words)
            {
                if (word.CompareTo("") != 0)
                    new_words.Add(word.ToLower());
            }
            
            return new_words;
        }


        public static List<string> RemoveStopWords(List<string> words)
        {
            List<string> tmp = new List<string>();
            foreach (string word in words)
            {
                if (!StopWords.StopWordsList.Contains(word))
                    tmp.Add(word);
            }

            return tmp;
        }

        //stem all words - produces a base string in an attempt to represent related words
        public static List<string> StemmWords(List<string> words)
        {
            List<string> Stemmed = new List<string>();
            StemmerBase englishStemmer = new EnglishStemmer();

            foreach (string word in words)
            {
                Stemmed.Add(englishStemmer.Stem(word));
            }

            return Stemmed;
        }

        //steeming only one word
        public static string Stemming(string word)
        {
            StemmerBase englishStemmer = new EnglishStemmer();
            string stemWord = englishStemmer.Stem(word);

            return stemWord;
        }


        public static string[] ParseFiles(string path)
        {
            string[] words = null;

            if (File.Exists(path))
            {
                var file = File.ReadAllText(path);
                var punctuation = file.Where(Char.IsPunctuation).Distinct().ToArray();
                words = file.Split().Select(x => x.Trim(punctuation)).ToArray();
            }
                       
            return words;
        }


    }
}
