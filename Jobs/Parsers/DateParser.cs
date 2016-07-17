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
				new StringBuilder(Regex.Match(_source, "[0-9]{1,3} год[а]?|[0-9]{1,3} лет").Groups[0].Value)
					.Replace(" года", "")
					.Replace(" год", "")
					.Replace(" лет", "")
					.ToString();
			var monthsString = new StringBuilder(Regex.Match(_source, "[0-9]{1,3} месяц(ев)?[а]?").Groups[0].Value)
				.Replace(" месяцев", "")
				.Replace(" месяца", "")
				.Replace(" месяц", "")
				.ToString();


			int years;
			int.TryParse(yearsString, out years);

			int months;
			int.TryParse(monthsString, out months);

			return DateTime.Today.AddYears(-years).AddMonths(-months);
		}
	}
}
