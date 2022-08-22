using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    internal static class SentencesParserTask
    {
        private static readonly char[] SentenceSeparators = { '.', '!', '?', ';', ':', '(', ')' };

        public static List<List<string>> ParseSentences(string text)
        {
            var parsedSentences = new List<List<string>>();

            var sentences = text.Split(SentenceSeparators);

            foreach (var sentence in sentences)
            {
                var wordsOfSentence = ParseSentenceOnWords(sentence.ToLower());

                if (wordsOfSentence.Count > 0)
                {
                    parsedSentences.Add(wordsOfSentence);
                }
            }

            return parsedSentences;
        }

        private static List<string> ParseSentenceOnWords(string sentence)
        {
            var wordsOfSentence = new List<string>();
            var wordToAddToSentence = new StringBuilder();

            foreach (var symbol in sentence)
            {
                var isWordSymbol = char.IsLetter(symbol) || symbol == '\'';

                if (isWordSymbol)
                {
                    wordToAddToSentence.Append(symbol);
                }
                else if (!string.IsNullOrWhiteSpace(wordToAddToSentence.ToString()))
                {
                    wordsOfSentence.Add(wordToAddToSentence.ToString());
                    wordToAddToSentence.Clear();
                }
            }

            if (!string.IsNullOrWhiteSpace(wordToAddToSentence.ToString()))
            {
                wordsOfSentence.Add(wordToAddToSentence.ToString());
            }

            return wordsOfSentence;
        }
    }
}