using System;

namespace Jobs.Models
{
	public class Job
	{
		internal Job()
		{
		}

		public Job(string position, DateTime experienceStart)
		{
			Position = position;
			ExperienceStart = experienceStart;
		}

		public string Company { get; set; }
		public string Position { get; internal set; }
		public DateTime ExperienceStart { get; internal set; }

		public override string ToString()
		{
			return $"Position: {Position}, Experience Start: {ExperienceStart}" + (!string.IsNullOrWhiteSpace(Company) ? $", Company: {Company} " : "");
		}
	}
}
