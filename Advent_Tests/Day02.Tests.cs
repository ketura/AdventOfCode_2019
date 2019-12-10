using Advent2019.Day01;
using Advent2019.Day02;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Advent.Tests
{
	public class Day02_Tests
	{
		[Theory]
		[InlineData("1,0,0,0,99", "2,0,0,0,99")]
		[InlineData("2,3,0,3,99", "2,3,0,6,99")]
		[InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801")]
		[InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
		[InlineData("1,9,10,3,2,3,11,0,99,30,40,50", "3500,9,10,70,2,3,11,0,99,30,40,50")]
		public void IntcodeInterpreter_Execute_OutputMatchesExamples(string script, string expected)
		{
			//Arrange
			var program = new IntcodeProgram(script);
			var interpreter = new IntcodeInterpreter();

			//Act
			interpreter.Execute(program);

			//Assert
			Assert.Equal(expected, program.ToString());
		}




	}
}
