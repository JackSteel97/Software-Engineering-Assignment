using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;

namespace SE_Project.NewsApi
{
    /// <summary>
    /// Class for extracting keywords from strings.
    /// </summary>
    public class KeywordHelper
    {
        /// <summary>
        /// A collection of words loaded from the text file to be used as stop words.
        /// </summary>
        private string[] StopWords { get; set; }

        /// <summary>
        /// The file path to the stop words file.
        /// </summary>
        private const string StopWordsFileName = "Data/StopWords.txt";

        /// <summary>
        /// Constructor, loads the stop word data from disk.
        /// </summary>
        public KeywordHelper()
        {
            LoadStopWords();
        }

        /// <summary>
        /// Get keywords from a string.
        /// </summary>
        /// <param name="content">String to extract keywords from</param>
        /// <returns>List of keywords</returns>
        public List<string> GetKeyWords(string content)
        {
            string[] words = GetWords(content);

            return words.Except(StopWords, StringComparer.OrdinalIgnoreCase).ToList();
        }

        /// <summary>
        /// Get words from a string.
        /// <br/>
        /// Clean an input string then split it into non-empty words.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>An array of non-empty words.</returns>
        private string[] GetWords(string input)
        {
            // Remove punctuation and digits.
            string noPunc = RemoveExtras(input);

            // Split into words and remove any empty results.
            return noPunc.Split(' ').Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();
        }

        /// <summary>
        /// Removes punctuation and digits from a string.
        /// </summary>
        /// <param name="input">String to remove.</param>
        /// <returns>The cleaned string.</returns>
        private string RemoveExtras(string input)
        {
            return new string(input.Trim().Where(c => !char.IsPunctuation(c) && !char.IsDigit(c)).ToArray());
        }

        /// <summary>
        /// Load the stop words from file into memory.
        /// </summary>
        private void LoadStopWords()
        {
            string[] lines = Properties.Resources.StopWords.Split('\n');

            List<string> formattedLines = new List<string>(lines.Length);

            for (int i = 0; i < lines.Length; i++)
            {
                // Check it isn't a comment.
                if (!lines[i].StartsWith("#"))
                {
                    // Add to formatted lines after removing punctuation and numbers.
                    formattedLines.Add(RemoveExtras(lines[i]));
                }
            }
            StopWords = formattedLines.ToArray();
        }
    }
}