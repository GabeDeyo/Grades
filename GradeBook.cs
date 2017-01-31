using System;
using System.Collections.Generic;

namespace Grades {
	public class GradeBook {

		/* Provides no validation
		public string Name {
			get;
			set;
		}*/

		private string _name;

		public string Name {
			get {
				return _name;
			}
			set {
				if (!String.IsNullOrEmpty(value)) {
					_name = value;
				}
			}
		}

		public GradeBook() {
			grades = new List<float>();
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

		public void AddGrade(float grade) {
			grades.Add(grade);
		}

		private List<float> grades = new List<float>();
    }
}
