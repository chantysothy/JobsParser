using System;
using System.Linq;
using JobLibraryTests.TestsStuff;
using Jobs;
using Jobs.Models;
using Jobs.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobLibraryTests
{
	[TestClass]
	public class JobsParserTests
	{
		[TestMethod]
		public void TestView_1_Female_WithoutProfileImage_WithExAndCurrentJobs_ReadyToMove_PostedYesterday()
		{
			const string view = "<div class=\"sr_list\">\r\n\t<div class=\"sr_row\">\r\n\t\t<div class=\"interval_2\"></div>\r\n\r\n\t\t<div class=\"avatar_col\">\r\n\t\t\t<span class=\"sr_date\">вчера</span>\r\n\t\t\t<div class=\"interval_2\"></div>\r\n\t\t\t<a class=\"wrapTD noimg\" href=\"/resume/3001906\"></a>\r\n\t\t</div>\r\n\r\n\t\t<div class=\"sr_descr\">\r\n\t\t\t<div class=\"row\">\r\n\t\t\t\t<div class=\"sr_salary\">от&nbsp;<b>30&nbsp;000 руб.</b></div>\r\n\r\n\t\t\t\t<a class=\"sr_name\" target=\"_blank\" href=\"/resume/3001906\">Инженер-технолог</a>\r\n\r\n\t\t\t\t<span class=\"nowrap\">\r\n\t\t\t\t\t\r\n\t\t\t\t</span>\r\n\t\t\t</div>\r\n\r\n\t\t\t<div class=\"interval_2\"></div>\r\n\r\n\t\t\t<div class=\"sr_seeker_info\">\r\n\t\t\t\t<span>Ж</span>, 45 лет, высшее образование, г.&nbsp;Ярославль, гр.&nbsp;Россия, готова к переезду\r\n\t\t\t</div>\r\n\r\n\t\t\t<div class=\"interval_2\"></div>\r\n\r\n\t\t\t<dl><dt>Сейчас</dt><dd><div><b>Директор</b></div><div>5 лет, Агентство недвижимости</div></dd></dl><div class=\"interval_3\"></div><dl><dt>Ранее</dt><dd><div><b>Инженер 1 кат</b></div><div>15 лет и 6 месяцев, Военное Представительство МО РФ</div></dd></dl><div class=\"interval_2\"></div><dl><dt>&nbsp;</dt><dd><div class=\"grey\"><i>Всего 2 места работы за 20 лет и 3 месяца</i></div></dd></dl>\r\n\r\n\t\t\t<div class=\"interval_2\"></div>\r\n\r\n\t\t\t<div class=\"sr_seeker_contact\">\r\n\t\t\t\t<span class=\"cv_id\" style=\"display: none;\">3001906</span>\r\n\t\t\t\t<span class=\"fio_switch\"><i class=\"ico-set ico-lock\"></i> <span class=\"a dotted\">ФИО и контактные данные</span></span>\r\n\t\t\t\t<div class=\"sr_seeker_contact_info\" style=\"display:none;\"></div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\r\n\t\t<div class=\"interval_2\"></div>\r\n\t</div>";
			var parser = new JobsParser(new JobsParserSettings(Category.Industry, new JobsProvider(view)));

			var actual = parser.Parse().First();

			var expected = new Applicant(
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
					) {Company = "Военное Представительство МО РФ" },
				new Job(
					"Директор", 
					new DateParser("5 лет").ParseString()
					) {Company = "Агентство недвижимости" },
				DateTime.Today.AddDays(-1),
				new Uri("https://job.ru/resume/3001906"),
				EducationType.HigherEducation,
				"г. Ярославль", 
				"гр. Россия", 
				true);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TestView_2()
		{
			const string view = "<div class=\"sr_list\">\r\n\t<div class=\"sr_row\">\r\n\t\t<div class=\"interval_2\"></div>\r\n\r\n\t\t<div class=\"avatar_col\">\r\n\t\t\t<span class=\"sr_date\">26.06.16</span>\r\n\t\t\t<div class=\"interval_2\"></div>\r\n\t\t\t<a class=\"wrapTD noimg\" href=\"/resume/1575489\"></a>\r\n\t\t</div>\r\n\r\n\t\t<div class=\"sr_descr\">\r\n\t\t\t<div class=\"row\">\r\n\t\t\t\t<div class=\"sr_salary\">от&nbsp;<b>70&nbsp;000 руб.</b></div>\r\n\r\n\t\t\t\t<a class=\"sr_name\" target=\"_blank\" href=\"/resume/1575489\">Главный инженер</a>\r\n\r\n\t\t\t\t<span class=\"nowrap\">\r\n\t                \r\n\t\t\t\t</span>\r\n\t\t\t</div>\r\n\r\n\t\t\t<div class=\"interval_2\"></div>\r\n\r\n\t\t\t<div class=\"sr_seeker_info\">\r\n\t\t\t\t\r\n\t\t\t</div>\r\n\r\n\t\t\t<div class=\"interval_2\"></div>\r\n\r\n\t\t\t<dl><dt>Сейчас</dt><dd><div><b>У соискателя нет опыта работы!</b></div></dd></dl>\r\n\r\n\t\t\t<div class=\"interval_2\"></div>\r\n\r\n\t\t\t<div class=\"sr_seeker_contact\">\r\n\t\t\t\t<span class=\"cv_id\" style=\"display: none;\">1575489</span>\r\n\t\t\t\t<span class=\"fio_switch\"><i class=\"ico-set ico-lock\"></i> <span class=\"a dotted\">ФИО и контактные данные</span></span>\r\n\t\t\t\t<div class=\"sr_seeker_contact_info\" style=\"display:none;\"></div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\r\n\t\t<div class=\"interval_2\"></div>\r\n\t</div>\r\n</div>";

			var parser = new JobsParser(new JobsParserSettings(Category.Industry, new JobsProvider(view)));

			var actual = parser.Parse().First();

			var expected = new Applicant(
				imageUrl:			null,
				salary:				30000,
				position:			"Инженер-технолог",
				sex:				Sex.Female,
				age:				45,
				jobsCount:			2,
				summaryExperience:	new DateParser("20 лет и 3 месяца").ParseString(),
				jobBefore:			new Job(
										"Инженер 1 кат",
										new DateParser("15 лет и 6 месяцев").ParseString()
									)
									{ Company = "Военное Представительство МО РФ" },
				jobNow:				new Job(
										"Директор",
										new DateParser("5 лет").ParseString()
									)
									{ Company = "Агентство недвижимости" },
				publichedDate:		DateTime.Today.AddDays(-1),
				url:				new Uri("https://job.ru/resume/3001906"),
				education:			EducationType.HigherEducation,
				city:				"г. Ярославль",
				citizenship:		"гр. Россия",
				readyToMove:		true);

			Assert.AreEqual(expected, actual);
		}
	}
}