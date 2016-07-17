using System;

namespace Jobs.Models
{
	public sealed class Applicant
	{
		internal Applicant()
		{
		}

		public Applicant(string imageUrl, decimal salary, string position, Sex sex, ushort? age, int jobsCount,
			DateTime summaryExperience, Job jobBefore, Job jobNow, DateTime publichedDate, Uri url, EducationType education,
			string city, string citizenship, bool readyToMove)
		{
			ImageUrl = imageUrl;
			Salary = salary;
			Position = position;
			Sex = sex;
			Age = age;
			JobsCount = jobsCount;
			SummaryExperience = summaryExperience;
			JobBefore = jobBefore;
			JobNow = jobNow;
			PublichedDate = publichedDate;
			Url = url;
			Education = education;
			City = city;
			Citizenship = citizenship;
			ReadyToMove = readyToMove;
		}

		public override string ToString()
		{
			return $"\n{new string('-', 70)}\n" +
			       $"Position: {Position} | Salary: {Salary} | Publiched Date: {PublichedDate}" +
			       $"\n\tSex: {Sex}, " +
			       $"\n\tAge: {Age}" +
			       $"\n\tEducation: {Education.GetDescription()}, " +
			       $"\n\tJobsCount: {JobsCount}" +
			       $"\n\tSummary Experience: {SummaryExperience}" +
				   $"\n\tWork Now: {JobNow}" +
				   $"\n\tWork Before: {JobBefore}" +
			       $"\n\tUrl: {Url}" +
			       $"\n\tCity: {City}" +
			       $"\n\tCitizenship: {Citizenship}" +
			       $"\n\tReady to move: " + (ReadyToMove ? "Yes" : "No") +
			       $"\n{new string('-', 70)}";
		}

		public string ImageUrl { get; internal set; }
		public decimal Salary { get; internal set; }
		public string Position { get; internal set; }
		public Sex Sex { get; internal set; }
		public ushort? Age { get; internal set; }
		public int JobsCount { get; internal set; }
		public DateTime SummaryExperience { get; internal set; }
		public Job JobBefore { get; internal set; }
		public Job JobNow { get; internal set; }
		public DateTime PublichedDate { get; internal set; }
		public Uri Url { get; internal set; }
		public EducationType Education { get; internal set; }
		public string City { get; internal set; }
		public string Citizenship { get; internal set; }
		public bool ReadyToMove { get; internal set; }
	}
}
