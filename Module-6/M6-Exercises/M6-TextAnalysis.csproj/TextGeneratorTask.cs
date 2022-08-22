using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    internal static class TextGeneratorTask
    {
        public static string ContinuePhrase(Dictionary<string, string> nGramContinuationByNGramStart,
                                            string phraseBeginning,
                                            int countOfNGramContinuationToAppendToPhrase)
        {
            var phrase = new StringBuilder(phraseBeginning);

            for (var i = 0; i < countOfNGramContinuationToAppendToPhrase; i++)
            {
                var phraseWords = phrase.ToString().Split();
                var lastPhraseWord = phraseWords[phraseWords.Length - 1];

                var isPhraseKey = phraseWords.Length < 2 &&
                                  nGramContinuationByNGramStart.ContainsKey(phrase.ToString());
                var areTwoLastWordsKey = phraseWords.Length > 1 &&
                                         nGramContinuationByNGramStart.ContainsKey(
                                             $"{phraseWords[phraseWords.Length - 2]} {lastPhraseWord}");
                var isLastWordKey = phraseWords.Length > 1 &&
                                    nGramContinuationByNGramStart.ContainsKey(lastPhraseWord);

                if (isPhraseKey)
                {
                    phrase.Append($" {nGramContinuationByNGramStart[phraseBeginning]}");
                }

                if (areTwoLastWordsKey)
                {
                    phrase.Append(
                        $" {nGramContinuationByNGramStart[$"{phraseWords[phraseWords.Length - 2]} {lastPhraseWord}"]}");
                }
                else if (isLastWordKey)
                {
                    phrase.Append($" {nGramContinuationByNGramStart[lastPhraseWord]}");
                }
            }

            return phrase.ToString();
        }
    }
}