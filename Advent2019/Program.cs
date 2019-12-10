using Advent2019.Day01;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2019
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please enter day to execute:");
			string input = Console.ReadLine().ToUpper();

			Dictionary<string, Func<string>> days = new Dictionary<string, Func<string>>()
			{
				["1A"] = () =>
				{
					var ints = File.ReadAllText("files/day01/input_day01.txt").Split('\n').Select(x => int.Parse(x));
					var counter = new FuelCounterUpper();
					int result = counter.CalculateFuelSum(ints);
					return $"Total fuel is: {result}";
				},
				["1B"] = () =>
				{
					var ints = File.ReadAllText("files/day01/input_day01.txt").Split('\n').Select(x => int.Parse(x));
					var checker = new RocketEquationDoubleChecker();
					int result = checker.CalculateRocketEquationFuelSum(ints);
					return $"Total fuel is: {result}";
				},
			};

			if(!days.ContainsKey(input))
			{
				Console.WriteLine("Invalid input! Must be a supported day of advent. Aborting.");
				Console.ReadKey();
				return;
			}

			string output = days[input]();

			Console.WriteLine(output);
			Console.ReadLine();

		}
	}
}
