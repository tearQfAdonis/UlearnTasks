namespace Pluralize
{
    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            var firstDigit = count % 10;
            var secondDigit = count % 100 / 10;

            if (secondDigit != 1 && (firstDigit == 2 || firstDigit == 3 || firstDigit == 4))
            {
                return "рубля";
            }

            if (secondDigit != 1 && firstDigit == 1)
            {
                return "рубль";
            }

            return "рублей";
        }
    }
}