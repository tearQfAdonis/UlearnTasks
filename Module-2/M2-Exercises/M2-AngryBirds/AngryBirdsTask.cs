using System;

namespace AngryBirds
{
	public static class AngryBirdsTask
	{
        private const double g = 9.8;
		// Ниже — это XML документация, её использует ваша среда разработки, 
		// чтобы показывать подсказки по использованию методов. 
		// Но писать её естественно не обязательно.
		/// <param name="v">Начальная скорость</param>
		/// <param name="distance">Расстояние до цели</param>
		/// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
		public static double FindSightAngle(double v, double distance)
		{
			var sinus2SightAngle = (distance * g) / (v * v);
			var sightAngle = Math.Asin(sinus2SightAngle) / 2;

            if (sightAngle <= 0 && sightAngle >= Math.PI / 2)
            {
				return double.NaN;
            }

            return sightAngle;
        }
	}
}