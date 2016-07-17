using System;
using Jobs.Models;
using Jobs.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobLibraryTests
{
	[TestClass]
	public class ApplicantTests
	{
		[TestMethod]
		public void TheyAreEqual()
		{
			var first = new Applicant(
				null,
				30000,
				"Инженер-технолог",
				Sex.Female,
				45,
				2,
				new DateParser("20 лет и 3 месяца").ParseString(),
				new Job(
					"Инженер 1 кат",
					new DateParser("15 лет и 6 месяцев").ParseString()
					)
				{ Company = "Военное Представительство МО РФ" },
				new Job(
					"Директор",
					new DateParser("5 лет").ParseString()
					)
				{ Company = "Агентство недвижимости" },
				DateTime.Today.AddDays(-1),
				new Uri("https://job.ru/resume/3001906"),
				EducationType.HigherEducation,
				"г. Ярославль",
				"гр. Россия",
				true);

			var second = new Applicant(
				null,
				30000,
				"Инженер-технолог",
				Sex.Female,
				45,
				2,
				new DateParser("20 лет и 3 месяца").ParseString(),
				new Job(
					"Инженер 1 кат",
					new DateParser("15 лет и 6 месяцев").ParseString()
					)
				{ Company = "Военное Представительство МО РФ" },
				new Job(
					"Директор",
					new DateParser("5 лет").ParseString()
					)
				{ Company = "Агентство недвижимости" },
				DateTime.Today.AddDays(-1),
				new Uri("https://job.ru/resume/3001906"),
				EducationType.HigherEducation,
				"г. Ярославль",
				"гр. Россия",
				true);

			Assert.AreEqual(first, second);
		}

		[TestMethod]
		public void TheyAreNotEqual()
		{
			var first = new Applicant(
				null,
				30000,
				"Инженер-технолог1",
				Sex.Female,
				45,
				2,
				new DateParser("20 лет и 3 месяца").ParseString(),
				new Job(
					"Инженер 1 кат",
					new DateParser("15 лет и 6 месяцев").ParseString()
					)
				{ Company = "Военное Представительство МО РФ" },
				new Job(
					"Директор",
					new DateParser("5 лет").ParseString()
					)
				{ Company = "Агентство недвижимости" },
				DateTime.Today.AddDays(-1),
				new Uri("https://job.ru/resume/3001906"),
				EducationType.HigherEducation,
				"г. Ярославль",
				"гр. Россия",
				true);

			var second = new Applicant(
				null,
				30000,
				"Инженер-технолог",
				Sex.Female,
				45,
				2,
				new DateParser("20 лет и 3 месяца").ParseString(),
				new Job(
					"Инженер 1 кат",
					new DateParser("15 лет и 6 месяцев").ParseString()
					)
				{ Company = "Военное Представительство МО РФ" },
				new Job(
					"Директор",
					new DateParser("5 лет").ParseString()
					)
				{ Company = "Агентство недвижимости" },
				DateTime.Today.AddDays(-1),
				new Uri("https://job.ru/resume/3001906"),
				EducationType.HigherEducation,
				"г. Ярославль",
				"гр. Россия",
				true);

			Assert.AreNotEqual(first, second);
		}
	}
}