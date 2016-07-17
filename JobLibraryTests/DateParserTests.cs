using System;
using Jobs.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobLibraryTests
{
	[TestClass]
	public class DateParserTests
	{
		private DateParser _dateParser;

		[TestInitialize]
		public void Init()
		{
			_dateParser = new DateParser();
		}

		[TestMethod]
		public void FoundMonth_1()
		{
			var date = _dateParser.ParseString("1 месяц");

			var expected = DateTime.UtcNow.AddMonths(-1);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundMonth_2()
		{
			var date = _dateParser.ParseString("2 месяца");

			var expected = DateTime.UtcNow.AddMonths(-2);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundMonth_3()
		{
			var date = _dateParser.ParseString("10 месяцев");

			var expected = DateTime.UtcNow.AddMonths(-10);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundYear_1()
		{
			var date = _dateParser.ParseString("1 год");

			var now = DateTime.UtcNow.AddYears(-1);

			Assert.AreEqual(now.Year, date.Year);
			Assert.AreEqual(now.Month, date.Month);
		}

		[TestMethod]
		public void FoundYear_2()
		{
			var date = _dateParser.ParseString("2 года");

			var now = DateTime.UtcNow.AddYears(-2);

			Assert.AreEqual(now.Year, date.Year);
			Assert.AreEqual(now.Month, date.Month);
		}

		[TestMethod]
		public void FoundYear_3()
		{
			var date = _dateParser.ParseString("10 лет");

			var now = DateTime.UtcNow.AddYears(-10);

			Assert.AreEqual(now.Year, date.Year);
			Assert.AreEqual(now.Month, date.Month);
		}

		[TestMethod]
		public void ReturnNow_1()
		{
			var date = _dateParser.ParseString("0 месяцев");

			var expected = DateTime.UtcNow;

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void ReturnNow_2()
		{
			var date = _dateParser.ParseString("фывафыафыа фыа фыа 123 фыва");

			var expected = DateTime.UtcNow;

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundYearAndMonth_1()
		{
			var date = _dateParser.ParseString("23 года и 1 месяц");

			var expected = DateTime.UtcNow.AddYears(-23).AddMonths(-1);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundYearAndMonth_2()
		{
			var date = _dateParser.ParseString("1 год и 9 месяцев");

			var expected = DateTime.UtcNow.AddYears(-1).AddMonths(-9);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundYearAndMonth_3()
		{
			var date = _dateParser.ParseString("20 лет и 2 месяца");

			var expected = DateTime.UtcNow.AddYears(-20).AddMonths(-2);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}
	}
}
