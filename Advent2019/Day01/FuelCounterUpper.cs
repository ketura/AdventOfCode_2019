using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2019.Day01
{
	public class FuelCounterUpper
	{
		public int CalculateFuel(int moduleMass)
		{
			return (moduleMass / 3) - 2;
		}

		public int CalculateFuelSum(IEnumerable<int> moduleMasses)
		{
			return moduleMasses.Select(x => CalculateFuel(x)).Sum();
		}
	}
}
