using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2019.Day01
{
	public class RocketEquationDoubleChecker
	{
		public int CalculateRocketEquationFuel(int moduleMass)
		{
			int fuel = moduleMass / 3 - 2;
			if (fuel <= 0)
				return 0;

			return fuel + CalculateRocketEquationFuel(fuel);
		}

		public int CalculateRocketEquationFuelSum(IEnumerable<int> moduleMasses)
		{
			return moduleMasses.Select(x => CalculateRocketEquationFuel(x)).Sum();
		}
	}
}
