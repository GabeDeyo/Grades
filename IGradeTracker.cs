using System.IO;
using System.Collections;

namespace Grades
{
	internal interface IGradeTracker : IEnumerable
	{
		void AddGrade(float grade);
		GradeStatistics ComputeStatistics();
		void WriteGrades(TextWriter description);
		string Name { get; set; }
	}
}