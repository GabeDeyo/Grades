using System;
using System.Collections.Generic;
using System.IO;

namespace Grades {
	public class GradeBook {
		public GradeBook() {
			_name = "Empty";
			grades = new List<float>();
		}

		private List<float> grades = new List<float>();
		private string _name;

		public event NameChangedDelegate NameChanged;

		/* Provides no validation
		public string Name {
			get;
			set;
		}*/

		public string Name {
			get {
				return _name;
			}
			set {
				if (string.IsNullOrEmpty(value)) {
					throw new ArgumentException("Error");
				}

				if(_name != value) //Shows name IS changing
				{ 
					NameChangedEventArgs args = new NameChangedEventArgs();
					args.ExistingName = _name;
					args.NewName = value;

					NameChanged(this, args);
				}
				_name = value;
				
			}
		}

		public GradeStatistics ComputeStatistics() {
			GradeStatistics stats = new GradeStatistics();

			float sum = 0;
			foreach(float grade in grades) {
				stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
				stats.LowestGrade = Math.Min(grade, stats.LowestGrade);

				sum += grade;
			}
			
			//Careful for this line (in case grades.Count was 0)
			stats.AverageGrade = sum / grades.Count;

			return stats;
		}

		public void WriteGrades(TextWriter destination) {
			for (int i = 0; i < grades.Count; i++) {
				destination.WriteLine(grades[i]);
			}
		}

		public void AddGrade(float grade) {
			grades.Add(grade);
		}
    }
}
