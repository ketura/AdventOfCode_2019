using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Advent2019.Day02
{
	public class IntcodeProgram
	{
		public List<int> Program = new List<int>();


		public IntcodeProgram(string script)
		{
			Program = script.Split(',').Select(x => int.Parse(x)).ToList();
		}

		public override string ToString()
		{
			return String.Join(',', Program);
		}
	}

	public delegate (bool Continue, int newIndex) IntcodeOperation(IntcodeProgram program, int index);

	public class IntcodeOpcode
	{
		public int Opcode;
		public string Name;
		public IntcodeOperation Operation;
	}

	public class IntcodeInterpreter
	{

		protected Dictionary<int, IntcodeOpcode> Opcodes = new Dictionary<int, IntcodeOpcode>()
		{
			[1] = new IntcodeOpcode()
			{
				Opcode = 1,
				Name = "ADD",
				Operation = (program, index) => 
				{
					var args = program.Program.Skip(index).Take(4).ToList();
					int lhs = program.Program[args[1]];
					int rhs = program.Program[args[2]];
					int dest = args[3];

					program.Program[dest] = lhs + rhs;
					return (true, index + 4);
				}
			},

			[2] = new IntcodeOpcode()
			{
				Opcode = 2,
				Name = "MULTIPLY",
				Operation = (program, index) =>
				{
					var args = program.Program.Skip(index).Take(4).ToList();
					int lhs = program.Program[args[1]];
					int rhs = program.Program[args[2]];
					int dest = args[3];

					program.Program[dest] = lhs * rhs;
					return (true, index + 4);
				}
			},

			[99] = new IntcodeOpcode()
			{
				Opcode = 99,
				Name = "EXIT",
				Operation = (program, index) =>
				{
					return (false, index);
				}
			},
		};

		public void Execute(IntcodeProgram program, bool debugOutput=false)
		{
			int opCount = 0;
			int maxOps = 100;
			Dictionary<int, string> history = new Dictionary<int, string>();
			history[-1] = program.ToString();

			int index = 0;
			while(opCount < maxOps)
			{
				int code = program.Program[index];

				if(!Opcodes.ContainsKey(code))
				{
					Console.WriteLine($"Encountered unknown code '{code}' at operation #{opCount}.  Aborting.");
					return;
				}

				var opcode = Opcodes[code];
				var (result, newIndex) = opcode.Operation(program, index);

				history[opCount] = program.ToString();
				if (debugOutput)
				{
					Console.WriteLine($"Ran opcode '{opcode.Name}({opcode.Opcode})' at operation #{opCount}.  Result:\n\t{history[opCount]}\n\n");
				}


				if (!result)
				{
					if (debugOutput)
					{
						Console.WriteLine($"Encountered exit command from opcode '{code}' at operation #{opCount}.  Exiting.");
					}
					
					return;
				}

				index = newIndex;

				opCount++;
			}

			Console.WriteLine($"Program exceeded max operations ({maxOps}).  Aborting.");
		}


	}
}
