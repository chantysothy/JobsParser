using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Jobs.Parsers
{
	public class DateParser
	{
		private readonly string _source;

		public DateParser(string source)
		{
			_source = source;
		}

		public DateTime ParseString()
		{
			var yearsString =
				new StringBuilder(Regex.Match(_source, "[0-9]{1,3} ���[�]?|[0-9]{1,3} ���").Groups[0].Value)
					.Replace(" ����", "")
					.Replace(" ���", "")
					.Replace(" ���", "")
					.ToString();
			var monthsString = new StringBuilder(Regex.Match(_source, "[0-9]{1,3} �����(��)?[�]?").Groups[0].Value)
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
