using System;

namespace Jobs.Models
{
	public class Job : IEquatable<Job>
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

		public bool Equals(Job other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return string.Equals(Company, other.Company) && string.Equals(Position, other.Position) &&
			       ExperienceStart.Equals(other.ExperienceStart);
		}

		public override string ToString()
		{
			return $"Position: {Position}, Experience Start: {ExperienceStart}" +
			       (!string.IsNullOrWhiteSpace(Company) ? $", Company: {Company} " : "");
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != GetType())
				return false;
			return Equals((Job) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Company?.GetHashCode() ?? 0;
				hashCode = (hashCode*397) ^ (Position?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ ExperienceStart.GetHashCode();
				return hashCode;
			}
		}
	}
}
