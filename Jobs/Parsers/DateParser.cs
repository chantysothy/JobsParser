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
				new StringBuilder(Regex.Match(source, "[0-9]{1,3} год[а]?|[0-9]{1,3} лет").Groups[0].Value)
					.Replace(" года", "")
					.Replace(" год", "")
					.Replace(" лет", "")
					.ToString();
			var monthsString = new StringBuilder(Regex.Match(source, "[0-9]{1,3} мес€ц(ев)?[а]?").Groups[0].Value)
				.Replace(" мес€цев", "")
				.Replace(" мес€ца", "")
				.Replace(" мес€ц", "")
				.ToString();


			int years;
			int.TryParse(yearsString, out years);

			int months;
			int.TryParse(monthsString, out months);

			return DateTime.UtcNow.AddYears(-years).AddMonths(-months);
		}
	}
}
