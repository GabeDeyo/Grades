using System;
using System.Speech.Synthesis;

namespace Grades
{
	class Program {
		static void Main(string[] args) {
			//SpeechSynthesizer synth = new SpeechSynthesizer();
			//synth.Speak("Hello, this is the grade book program.");
			//synth.Speak("Here are your current grade statistics.");


			GradeBook book = new GradeBook();

			// Don't set equal, simply add reference to the method with another delegate
			book.NameChanged += OnNameChanged;
			/*book.NameChanged += OnNameChanged2;
			book.NameChanged += OnNameChanged2;
			book.NameChanged -= OnNameChanged2;*/

			book.Name = "Gabes Grade Book";
			book.Name = null; //Isn't applied because I have Property validation
			book.Name = "Grade Book";
			book.AddGrade(91);
			book.AddGrade(89.5f);
			book.AddGrade(75);
			book.WriteGrades(Console.Out);

			GradeStatistics stats = book.ComputeStatistics();
			Console.WriteLine(book.Name);
			WriteResult("Average", stats.AverageGrade);
			WriteResult("Highest", stats.HighestGrade);
			WriteResult("Lowest", stats.LowestGrade);
			WriteResult(stats.Description, stats.LetterGrade);
		}

		static void OnNameChanged(object sender, NameChangedEventArgs args) {
			Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}.");
		}

		/*static void OnNameChanged2(object sender, NameChangedEventArgs args) {
			Console.WriteLine("***");
		}*/


		static void WriteResult(string description, float result) {
			/*
			Standard
			//Console.WriteLine(description + ": " + result);
			//Formated
			Console.WriteLine("{0}: {1}", description, result);
			//Decimal Format
			Console.WriteLine("{0}: {1:F2}", description, result);
			//Currency Format
			Console.WriteLine("{0}: {1:C2}", description, result);
			*/
			//Newest Formating - note we don't need params
			Console.WriteLine($"{description}: {result}");
		}

		static void WriteResult(string description, string result) {
			Console.WriteLine(description + ": " + result);
		}

		
	}
}
