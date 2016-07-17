using System;
using System.Text;
using Jobs.Helpers;

namespace Jobs.Models
{
	public sealed class Applicant : IEquatable<Applicant>
	{
		internal Applicant()
		{
		}

		public Applicant(string imageUrl, decimal salary, string position, Sex sex, ushort? age, int? jobsCount,
			DateTime? summaryExperience, Job jobBefore, Job jobNow, DateTime publichedDate, Uri url, EducationType education,
			string city, string citizenship, bool? readyToMove)
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

		public string ImageUrl { get; internal set; }
		public decimal Salary { get; internal set; }
		public string Position { get; internal set; }
		public Sex Sex { get; internal set; }
		public ushort? Age { get; internal set; }
		public int? JobsCount { get; internal set; }
		public DateTime? SummaryExperience { get; internal set; }
		public Job JobBefore { get; internal set; }
		public Job JobNow { get; internal set; }
		public DateTime PublichedDate { get; internal set; }
		public Uri Url { get; internal set; }
		public EducationType Education { get; internal set; }
		public string City { get; internal set; }
		public string Citizenship { get; internal set; }
		public bool? ReadyToMove { get; internal set; }

		public bool Equals(Applicant other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return string.Equals(ImageUrl, other.ImageUrl) && Salary == other.Salary && string.Equals(Position, other.Position) && Sex == other.Sex && Age == other.Age && JobsCount == other.JobsCount && SummaryExperience.Equals(other.SummaryExperience) && Equals(JobBefore, other.JobBefore) && Equals(JobNow, other.JobNow) && PublichedDate.Equals(other.PublichedDate) && Equals(Url, other.Url) && Education == other.Education && string.Equals(City, other.City) && string.Equals(Citizenship, other.Citizenship) && ReadyToMove == other.ReadyToMove;
		}

		public override string ToString()
		{
			var representation = new StringBuilder($"{new string('-', 70)}\n");

			representation.AppendLine($"Position: {Position} | Salary: {Salary} | Publiched Date: {PublichedDate}");
			if(Sex != Sex.Unknown)
				representation.AppendLine($"\tSex: {Sex}, ");
			if(Age != null)
				representation.AppendLine($"\tAge: {Age}");
			if(Education != EducationType.Unknown)
				representation.AppendLine($"\tEducation: {Education.GetDescription()}, ");
			if(JobsCount != null)
				representation.AppendLine($"\tJobsCount: {JobsCount}");
			if(SummaryExperience != null)
				representation.AppendLine($"\tSummary Experience: {SummaryExperience}");
			if(JobNow != null)
				representation.AppendLine($"\tJob Now: {JobNow}");
			if(JobBefore != null)
				representation.AppendLine($"\tJob Before: {JobBefore}");

			representation.AppendLine($"\tUrl: {Url}");

			if (ImageUrl != null)
				representation.AppendLine($"\tImage Url: {ImageUrl}");
			if (City != null)
				representation.AppendLine($"\tCity: {City}");
			if (Citizenship != null)
				representation.AppendLine($"\tCitizenship: {Citizenship}");
			if (ReadyToMove != null)
				representation.AppendLine("\tReady to move: " + (ReadyToMove == true ? "Yes" : "No"));

			representation.AppendLine($"{new string('-', 70)}");
			return representation.ToString();
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			return obj is Applicant && Equals((Applicant) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = ImageUrl?.GetHashCode() ?? 0;
				hashCode = (hashCode*397) ^ Salary.GetHashCode();
				hashCode = (hashCode*397) ^ (Position?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ (int) Sex;
				hashCode = (hashCode*397) ^ Age.GetHashCode();
				hashCode = (hashCode*397) ^ JobsCount.GetHashCode();
				hashCode = (hashCode*397) ^ SummaryExperience.GetHashCode();
				hashCode = (hashCode*397) ^ (JobBefore?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ (JobNow?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ PublichedDate.GetHashCode();
				hashCode = (hashCode*397) ^ (Url?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ (int) Education;
				hashCode = (hashCode*397) ^ (City?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ (Citizenship?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ ReadyToMove.GetHashCode();
				return hashCode;
			}
		}
	}
}
