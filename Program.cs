using System;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
			//SpeechSynthesizer synth = new SpeechSynthesizer();
			//synth.Speak("Hello, this is the grade book program.");
			//synth.Speak("Here are your current grade statistics.");

			
			GradeBook book = new GradeBook();
			book.Name = "Gabes Grade Book";
			book.Name = null; //Isn't applied because I have Property validation
			book.AddGrade(91);
			book.AddGrade(89.5f);
			book.AddGrade(75);

			GradeStatistics stats = book.ComputeStatistics();
			Console.WriteLine(book.Name);
			WriteResult("Average", stats.AverageGrade);
			WriteResult("Highest", (int)stats.HighestGrade);
			WriteResult("Lowest", stats.LowestGrade);

		}

		static void WriteResult(string description, int result) {
			Console.WriteLine(description + ": " + result);
		}
		static void WriteResult(string description, float result) {
			//Standard
			Console.WriteLine(description + ": " + result);
			/*
			//Formated
			Console.WriteLine("{0}: {1}", description, result);
			//Decimal Format
			Console.WriteLine("{0}: {1:F2}", description, result);
			//Currency Format
			Console.WriteLine("{0}: {1:C2}", description, result);
			//Newest Formating - note we don't need params
			Console.WriteLine($"{description}: {result:F2}");
			*/
        }
    }
}
