using System;

namespace Jobs
{
	public enum Sex
	{
		Male,
		Female,
		Unknown
	}

	public class Work
	{
		public Work(string position, TimeSpan experience)
		{
			Position = position;
			Experience = experience;
		}

		public string Company { get; private set; }
		public string Position { get; private set; }
		public TimeSpan Experience { get; private set; }
	}

	public sealed class Applicant
	{
		public decimal Salary { get; private set; }
		public string Position { get; private set; }
		public Sex Sex { get; private set; }
		public ushort Age { get; private set; }
		public int JobsCount { get; private set; }
		public TimeSpan SummaryExperience { get; private set; }
		public Work WorkBefore { get; private set; }
		public Work WorkNow { get; private set; }
		public DateTime PublichedDate { get; private set; }
	}
}
