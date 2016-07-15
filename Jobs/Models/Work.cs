using System;

namespace Jobs.Models
{
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

		public override string ToString()
		{
			return $"Position: {Position}, Experience: {Experience}" + (!string.IsNullOrWhiteSpace(Company) ? $", Company: {Company} " : "");
		}
	}
}
