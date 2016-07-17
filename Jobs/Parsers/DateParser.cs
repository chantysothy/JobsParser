using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Jobs.Parsers
{
	public class DateParser
	{
		public DateTime ParseString(string source)
		{
			var yearsString =
				new StringBuilder(Regex.Match(source, "[0-9]{1,3} ���[�]?|[0-9]{1,3} ���").Groups[0].Value)
					.Replace(" ����", "")
					.Replace(" ���", "")
					.Replace(" ���", "")
					.ToString();
			var monthsString = new StringBuilder(Regex.Match(source, "[0-9]{1,3} �����(��)?[�]?").Groups[0].Value)
				.Replace(" �������", "")
				.Replace(" ������", "")
				.Replace(" �����", "")
				.ToString();


			int years;
			int.TryParse(yearsString, out years);

			int months;
			int.TryParse(monthsString, out months);

			return DateTime.UtcNow.AddYears(-years).AddMonths(-months);
		}
	}
}
