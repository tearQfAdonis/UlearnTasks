namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] nameDataCollection, string nameToFind)
        {
            const int minDay = 1;
            const int maxDay = 31;

            var days = GetDays(minDay, maxDay);

            var birthsCountByDay = DistributeNamesByDays(nameDataCollection, nameToFind, minDay, maxDay);

            return new HistogramData($"Рождаемость людей с именем '{nameToFind}'", days, birthsCountByDay);
        }

        private static int[] GetNumbersRange(int rangeStart, int rangeEnd)
        {
            var numbersRange = new int[rangeEnd - rangeStart + 1];
            for (var i = 0; i < numbersRange.Length; i++)
            {
                numbersRange[i] = rangeStart + i;
            }

            return numbersRange;
        }

        private static string[] ConvertNumbersToStrings(int[] numbers)
        {
            var numbersAsStrings = new string[numbers.Length];
            for (var i = 0; i < numbersAsStrings.Length; i++)
            {
                numbersAsStrings[i] = numbers[i].ToString();
            }

            return numbersAsStrings;
        }

        private static string[] GetDays(int minDay, int maxDay)
        {
            var days = ConvertNumbersToStrings(GetNumbersRange(minDay, maxDay));

            return days;
        }

        private static double[] DistributeNamesByDays(NameData[] nameDataCollection, string nameToFind,
                                                      int minDay, int maxDay)
        {
            var birthsCountByDay = new double[maxDay - minDay + 1];
            foreach (var nameData in nameDataCollection)
            {
                if (nameData.Name == nameToFind)
                {
                    birthsCountByDay[nameData.BirthDate.Day - minDay]++;
                }
            }

            // количество дней рождения в первый день месяца должно быть равно нулю по условию задачи,
            // т.к. первое число используется по умолчанию и для людей с неизвестной датой рождения.
            birthsCountByDay[0] = 0;

            return birthsCountByDay;
        }
    }
}