using System;

namespace Jobs.Models
{
	public sealed class Applicant
	{
		internal Applicant()
		{
		}

		public Applicant(string imageUrl, decimal salary, string position, Sex sex, ushort age, int jobsCount,
			TimeSpan summaryExperience, Work workBefore, Work workNow, DateTime publichedDate)
		{
			ImageUrl = imageUrl;
			Salary = salary;
			Position = position;
			Sex = sex;
			Age = age;
			JobsCount = jobsCount;
			SummaryExperience = summaryExperience;
			WorkBefore = workBefore;
			WorkNow = workNow;
			PublichedDate = publichedDate;
		}

		public string ImageUrl { get; internal set; }
		public decimal Salary { get; internal set; }
		public string Position { get; internal set; }
		public Sex Sex { get; internal set; }
		public ushort Age { get; internal set; }
		public int JobsCount { get; internal set; }
		public TimeSpan SummaryExperience { get; internal set; }
		public Work WorkBefore { get; internal set; }
		public Work WorkNow { get; internal set; }
		public DateTime PublichedDate { get; internal set; }
		public Uri Url { get; internal set; }
		public string Education { get; internal set; }

		public override string ToString()
		{
			return
				$"Salary: {Salary}, Position: {Position}, Sex: {Sex}, Age: {Age}, JobsCount: {JobsCount}, SummaryExperience: {SummaryExperience}, WorkBefore: {WorkBefore}, WorkNow: {WorkNow}, PublichedDate: {PublichedDate}";
		}
	}
}
