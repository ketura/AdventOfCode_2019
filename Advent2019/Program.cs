using Advent2019.Day01;
using Advent2019.Day02;
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

				["2A"] = () =>
				{
					var program = new IntcodeProgram(File.ReadAllText("files/day02/input_day02_modified.txt"));
					var interpreter = new IntcodeInterpreter();
					interpreter.Execute(program, true);
					return $"Position 0: {program.Program[0]}";
				},

				["2B"] = () =>
				{
					string defaultInput = File.ReadAllText("files/day02/input_day02.txt");
					var interpreter = new IntcodeInterpreter();
					int output = -1;
					for(int noun = 0; noun <= 99; noun++)
					{
						for(int verb = 0; verb <=99; verb++)
						{
							var program = new IntcodeProgram(defaultInput);
							program.Program[1] = noun;
							program.Program[2] = verb;

							interpreter.Execute(program, false);

							if(program.Program[0] == 19690720)
							{
								output = 100 * noun + verb;
							}
						}
						
					}
					
					return $"Output : {output}";
				},
			};

			if(!days.ContainsKey(input))
			{
				Console.WriteLine("Invalid input! Must be a supported day of advent. Aborting.");
				Console.ReadKey();
				return;
			}

			string finalOutput = days[input]();

			Console.WriteLine(finalOutput);
			Console.ReadLine();

		}
	}
}
