using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Magic8Ball
{
	class Program
	{
		/// <summary>
		/// Begin point for magic 8 ball
		/// </summary>

		static void Main(string[] args)
		{
			// Preserve current console text color
			ConsoleColor oldColor = Console.ForegroundColor;

			// Change console text color
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Magic 8 Ball (by: Reed)");

			// Create a randomizer object
			Random randomObject = new Random();


			while (true)
			{
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.Write("Ask a question?: ");
				Console.ForegroundColor = ConsoleColor.Gray;
				string questionString = Console.ReadLine();

				// Make the computer pause to think about the question 
				// before answering
				int numberOfSecondsToSleep = randomObject.Next(5) + 1;
				Console.WriteLine("Thinking about your answer, stand by....");
				Thread.Sleep(numberOfSecondsToSleep * 1000);


				if(questionString.Length == 0)
				{
					Console.WriteLine("Hey! You need to ask a question!");
					continue;
				}

				// See if the user types quit
				if(questionString.ToLower() == "quit")
				{
					break;
				}

				// If the user insults the Magic 8 Ball
				if(questionString.ToLower() == "you suck")
				{
					Console.WriteLine("You suck even more! Bye!!");
					break;
				}

				int randomNumber = randomObject.Next(8);

				// Use random number to determine response
				switch (randomNumber)
				{
					case 0:
						{
							Console.WriteLine("Oh you better believe it!");
							break;
						}
					case 1:
						{
							Console.WriteLine("I like to think I know something.");
							break;
						}
					case 2:
						{
							Console.WriteLine("HAHAH OK!");
							break;
						}
					case 3:
						{
							Console.WriteLine("YES!");
							break;
						}
					case 4:
						{
							Console.WriteLine("NO!");
							break;
						}
					case 5:
						{
							Console.WriteLine("Well, it's worth a shot.");
							break;
						}
					case 6:
						{
							Console.WriteLine("I dont know if that is a good idea!");
							break;
						}
					case 7:
						{
							Console.WriteLine("Fat chance in hell!");
							break;
						}
				}
			}
			// Cleaning up
			Console.ForegroundColor = oldColor;
		}
	}
}


