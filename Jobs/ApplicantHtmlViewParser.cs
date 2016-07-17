using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AngleSharp.Css.Values;
using AngleSharp.Dom;
using Jobs.Factories;
using Jobs.Models;

namespace Jobs
{
	public class ApplicantHtmlViewParser
	{
		private readonly string _siteUrl;
		private readonly IElement _view;

		public ApplicantHtmlViewParser(IElement view, string siteUrl)
		{
			_view = view;
			_siteUrl = siteUrl;
		}

		public Applicant Parse()
		{
			var applicant = new Applicant();

			var avatarCol = _view.GetElementsByClassName("avatar_col")[0];
			applicant.PublichedDate = GetPublishedDate(avatarCol);
			applicant.ImageUrl = GetImageUrl(avatarCol);

			var srDescription = _view.GetElementsByClassName("sr_descr")[0];
			applicant.Salary = GetSalary(srDescription);

			var nameElement = srDescription.GetElementsByClassName("sr_name")[0];
			applicant.Position = GetPosition(nameElement);
			applicant.Url = GetUrl(nameElement);

			var infoElement = srDescription.GetElementsByClassName("sr_seeker_info")[0];
			var sexField = infoElement.GetElementsByTagName("span");

			applicant.Sex = GetSex(sexField);

			var infoSections = new string[0];
			if (!string.IsNullOrWhiteSpace(infoElement.InnerHtml))
			{
				var info = new StringBuilder(infoElement.InnerHtml)
					.Replace(infoElement.Children[0].OuterHtml + ", ", "")
					.Replace("&nbsp", " ")
					.Replace("\n", "")
					.Replace("\t", "")
					.Replace(";", "")
					.ToString();
				infoSections = info.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
			}
			applicant.Age = GetAge(infoSections);
			applicant.Education = GetEducation(infoSections);
			applicant.City = GetCity(infoSections);
			applicant.Citizenship = GetCitizenship(infoSections);
			applicant.ReadyToMove = GetReadyToMoveStatus(infoSections);

			var infoBlocks = srDescription.GetElementsByTagName("dl");
			if (infoBlocks.Length > 0)
			{
				applicant.JobNow = GetJobNow(infoBlocks[0]);
				/*applicant.JobBefore = GetJobBefore(infoBlocks);
				applicant.JobsCount = GetJobsCount(infoBlocks);
				applicant.SummaryExperience = GetSummaryExperience(infoBlocks);*/
			}

			return applicant;
		}

		private Job GetJobNow(IElement infoBlock)
		{
			if (infoBlock.GetElementsByTagName("dt")[0].InnerHtml != "Сейчас")
				return null;

			var job = new Job();

			var jobContent = infoBlock.GetElementsByTagName("dd")[0];
			var jobDescription = jobContent.GetElementsByTagName("div");
			job.Position = jobDescription[0].GetElementsByTagName("b")[0].InnerHtml;
			if (job.Position.Contains("У соискателя нет опыта работы!"))
				return job;

			if (jobDescription.Length > 1)
			{
				var jobInfo = jobDescription[1].InnerHtml.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
				job.ExperienceStart = new DateParser().ParseString(jobInfo[0]);
				if(jobInfo.Length > 1)
					job.Company = jobInfo[1];
			}

			return job;
		}

		private static bool GetReadyToMoveStatus(IEnumerable<string> infoSections)
		{
			return infoSections.Any(section => section.Contains("готов к переезду"));
		}

		private static string GetCitizenship(IEnumerable<string> infoSections)
		{
			return infoSections.FirstOrDefault(section => new Regex("гр.\\s?[а-яА-Яa-zA-Z\\-0-9]+").IsMatch(section));
		}

		private static string GetCity(IEnumerable<string> infoSections)
		{
			return infoSections.FirstOrDefault(section => new Regex("г.\\s?[а-яА-Яa-zA-Z\\-0-9]+").IsMatch(section));
		}

		private static EducationType GetEducation(IEnumerable<string> infoSections)
		{
			var types = new[]
			{
				EducationType.IncompleteSecondaryEducation.GetDescription(),
				EducationType.SecondaryEducation.GetDescription(),
				EducationType.SecondarySpecialEducation.GetDescription(),
				EducationType.IncompleteHigherEducation.GetDescription(),
				EducationType.Student.GetDescription(),
				EducationType.HigherEducation.GetDescription(),
				EducationType.MBA.GetDescription(),
				EducationType.AcademicDegree.GetDescription()
			};

			var education = infoSections.FirstOrDefault(item => types.Any(item.ToLower().Contains));

			return new EducationTypeFactory(education).GetEducationType();
		}

		private static ushort? GetAge(IEnumerable<string> infoSections)
		{
			var ageString =
				infoSections.FirstOrDefault(
					section => section.Contains("года") || section.Contains("год") || section.Contains("лет"));
			if (string.IsNullOrWhiteSpace(ageString))
				return null;

			var ageMatch = Regex.Match(ageString, "[0-9]{1,3}").Value;

			ushort age;
			var parseResult = ushort.TryParse(ageMatch, out age);

			return parseResult ? (ushort?) age : null;
		}

		private static Sex GetSex(IHtmlCollection<IElement> sexField)
		{
			var source = sexField.Length > 0
				? sexField[0].InnerHtml
				: "";
			switch (source)
			{
				case "М":
					return Sex.Male;
				case "Ж":
					return Sex.Female;
				default:
					return Sex.Unknown;
			}
		}

		private Uri GetUrl(IElement nameElement)
		{
			return new Uri(_siteUrl + nameElement.GetAttribute("href"));
		}

		private static string GetPosition(IElement nameElement)
		{
			return nameElement.InnerHtml;
		}

		private static decimal GetSalary(IElement srDescription)
		{
			decimal salary = 0;

			var salaryElement = srDescription.GetElementsByClassName("sr_salary")[0];

			if (salaryElement.InnerHtml == "<span class=\"c_gray\">з/п не указана</span>")
				return salary;

			var salaryText = new StringBuilder(salaryElement.GetElementsByTagName("b")[0].InnerHtml.ToLower())
				.Replace("&nbsp;", "")
				.Replace("руб.", "")
				.ToString();
			decimal.TryParse(salaryText, out salary);

			return salary;
		}

		private static string GetImageUrl(IElement avatarCol)
		{
			var wrapTd = avatarCol.GetElementsByClassName("wrapTD")[0];
			return !wrapTd.ClassName.Contains("noimg")
				? wrapTd.GetElementsByTagName("img")[0].GetAttribute("src").Replace("thumbnew", "s150x150")
				: null;
		}

		private static DateTime GetPublishedDate(IElement avatarCol)
		{
			var dateString = avatarCol.GetElementsByClassName("sr_date")[0].InnerHtml;
			return DateTime.Parse(dateString);
		}
	}
}
