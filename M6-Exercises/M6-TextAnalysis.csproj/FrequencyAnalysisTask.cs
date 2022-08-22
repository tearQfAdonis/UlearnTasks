using System.Collections.Generic;

namespace TextAnalysis
{
    internal static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> sentences)
        {
            var bigramsFrequentModel = GetNGramsFrequentModel(sentences, 2);
            var trigramsFrequentModel = GetNGramsFrequentModel(sentences, 3);

            var bigramContinuationByBigramStart = GetMostFrequentNGramContinuationByNGramStart(bigramsFrequentModel);
            var trigramContinuationByTrigramStart = GetMostFrequentNGramContinuationByNGramStart(trigramsFrequentModel);

            var nGramContinuationByNGramStart =
                ConcatDictionaries(bigramContinuationByBigramStart, trigramContinuationByTrigramStart);

            return nGramContinuationByNGramStart;
        }

        private static Dictionary<string, string> ConcatDictionaries(
            Dictionary<string, string> firstDictionary,
            Dictionary<string, string> secondDictionary)
        {
            foreach (var keyValuePair in secondDictionary)
            {
                firstDictionary.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return firstDictionary;
        }

        private static Dictionary<string, Dictionary<string, int>> GetNGramsFrequentModel(
            List<List<string>> sentences, int nGramSize)
        {
            var nGramsFrequentModel = new Dictionary<string, Dictionary<string, int>>();

            foreach (var sentence in sentences)
            {
                if (sentence.Count < nGramSize)
                {
                    continue;
                }

                var nGramsCount = sentence.Count - nGramSize + 1;

                for (var i = 0; i < nGramsCount; i++)
                {
                    var nGramStart = string.Join(" ", sentence.GetRange(i, nGramSize - 1));
                    var nGramContinuation = string.Join(" ", sentence.GetRange(i + nGramSize - 1, 1));

                    if (!nGramsFrequentModel.ContainsKey(nGramStart))
                    {
                        nGramsFrequentModel[nGramStart] = new Dictionary<string, int>();
                    }

                    if (!nGramsFrequentModel[nGramStart].ContainsKey(nGramContinuation))
                    {
                        nGramsFrequentModel[nGramStart][nGramContinuation] = 1;
                    }
                    else
                    {
                        nGramsFrequentModel[nGramStart][nGramContinuation]++;
                    }
                }
            }

            return nGramsFrequentModel;
        }

        private static Dictionary<string, string> GetMostFrequentNGramContinuationByNGramStart(
            Dictionary<string, Dictionary<string, int>> nGrams)
        {
            var mostFrequentNGramContinuationByNGramStart = new Dictionary<string, string>();

            if (nGrams.Count == 0)
            {
                return mostFrequentNGramContinuationByNGramStart;
            }

            foreach (var nGramContinuationsByNGramStart in nGrams)
            {
                var nGramStart = nGramContinuationsByNGramStart.Key;
                var nGramsCountByNGramContinuation = nGramContinuationsByNGramStart.Value;

                var maxCountNGramContinuation = 0;
                var mostFrequentNGramContinuation = string.Empty;

                foreach (var nGramsCountByNGramContinuationPair in nGramsCountByNGramContinuation)
                {
                    var nGramContinuation = nGramsCountByNGramContinuationPair.Key;
                    var nGramsCount = nGramsCountByNGramContinuationPair.Value;

                    if (nGramsCount > maxCountNGramContinuation)
                    {
                        maxCountNGramContinuation = nGramsCount;
                        mostFrequentNGramContinuation = nGramContinuation;
                    }
                    else if (nGramsCount == maxCountNGramContinuation)
                    {
                        // nGramContinuation лексикографически меньше, чем mostFrequentNGramContinuation.
                        if (string.CompareOrdinal(mostFrequentNGramContinuation, nGramContinuation) > 0)
                        {
                            mostFrequentNGramContinuation = nGramContinuation;
                        }
                    }
                }

                mostFrequentNGramContinuationByNGramStart.Add(nGramStart, mostFrequentNGramContinuation);
            }

            return mostFrequentNGramContinuationByNGramStart;
        }
    }
}