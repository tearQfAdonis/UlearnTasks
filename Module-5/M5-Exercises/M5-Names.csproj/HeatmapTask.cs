namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] nameDataCollection)
        {
            const int minDay = 2;
            const int maxDay = 31;
            const int minMonth = 1;
            const int maxMonth = 12;

            var days = GetDays(minDay, maxDay);
            var months = GetMonths(minMonth, maxMonth);
            var birthsCountByDayAndMonth = DistributeBirthsCountByDayAndMonth(
                nameDataCollection, days.Length, months.Length, minDay, minMonth);

            return new HeatmapData("Пример карты интенсивностей", birthsCountByDayAndMonth, days, months);
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

        private static string[] GetMonths(int minMonth, int maxMonth)
        {
            var months = ConvertNumbersToStrings(GetNumbersRange(minMonth, maxMonth));

            return months;
        }

        private static double[,] DistributeBirthsCountByDayAndMonth(NameData[] nameDataCollection,
                                                                    int daysCount,
                                                                    int monthsCount,
                                                                    int minDay,
                                                                    int minMonth)
        {
            var birthsCountByDayAndMonth = new double[daysCount, monthsCount];
            foreach (var nameData in nameDataCollection)
            {
                if (nameData.BirthDate.Day != 1)
                {
                    birthsCountByDayAndMonth[nameData.BirthDate.Day - minDay, nameData.BirthDate.Month - minMonth]++;
                }
            }

            return birthsCountByDayAndMonth;
        }
    }
}