using Advent2019.Day01;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Day01.Tests
{
	public class Day01_Tests
	{
		[Theory]
		[InlineData(12, 2)]
		[InlineData(14, 2)]
		[InlineData(1969, 654)]
		[InlineData(100756, 33583)]
		public void FuelCounterUpper_CalculateFuel_TotalEqualsExamples(int testmass, int expected)
		{
			//Arrange
			var counter = new FuelCounterUpper();

			//Act
			int result = counter.CalculateFuel(testmass);

			//Assert
			Assert.Equal(expected, result);
		}


		public class DayOneATestData : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator()
			{
				yield return new object[] { new int[] { 12, 14, 1969, 100756 }, 34241 };
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		}

		[Theory]
		[ClassData(typeof(DayOneATestData))]
		public void FuelCounterUpper_CalculateFuelSum_TotalEqualsExpected(IEnumerable<int> testmasses, int expected)
		{
			//Arrange
			var counter = new FuelCounterUpper();

			//Act
			int result = counter.CalculateFuelSum(testmasses);

			//Assert
			Assert.Equal(expected, result);
		}


		[Theory]
		[InlineData(12, 2)]
		[InlineData(14, 2)]
		[InlineData(1969, 966)]
		[InlineData(100756, 50346)]
		public void RocketEquationDoubleChecker_CalculateRocketEquationFuel_TotalEqualsExamples(int testmass, int expected)
		{
			//Arrange
			var checker = new RocketEquationDoubleChecker();

			//Act
			int result = checker.CalculateRocketEquationFuel(testmass);

			//Assert
			Assert.Equal(expected, result);
		}


		public class DayOneBTestData : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator()
			{
				yield return new object[] { new int[] { 12, 14, 1969, 100756 }, 51316 };
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		}

		[Theory]
		[ClassData(typeof(DayOneBTestData))]
		public void RocketEquationDoubleChecker_CalculateRocketEquationFuelSum_TotalEqualsExpected(IEnumerable<int> testmasses, int expected)
		{
			//Arrange
			var checker = new RocketEquationDoubleChecker();

			//Act
			int result = checker.CalculateRocketEquationFuelSum(testmasses);

			//Assert
			Assert.Equal(expected, result);
		}


	}
}
