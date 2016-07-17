using System;
using Jobs.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobLibraryTests
{
	[TestClass]
	public class DateParserTests
	{

		[TestMethod]
		public void FoundMonth_1()
		{
			var date = new DateParser("1 месяц").ParseString();

			var expected = DateTime.UtcNow.AddMonths(-1);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundMonth_2()
		{
			var date = new DateParser("2 месяца").ParseString();

			var expected = DateTime.UtcNow.AddMonths(-2);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundMonth_3()
		{
			var date = new DateParser("10 месяцев").ParseString();

			var expected = DateTime.UtcNow.AddMonths(-10);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundYear_1()
		{
			var date = new DateParser("1 год").ParseString();

			var now = DateTime.UtcNow.AddYears(-1);

			Assert.AreEqual(now.Year, date.Year);
			Assert.AreEqual(now.Month, date.Month);
		}

		[TestMethod]
		public void FoundYear_2()
		{
			var date = new DateParser("2 года").ParseString();

			var now = DateTime.UtcNow.AddYears(-2);

			Assert.AreEqual(now.Year, date.Year);
			Assert.AreEqual(now.Month, date.Month);
		}

		[TestMethod]
		public void FoundYear_3()
		{
			var date = new DateParser("10 лет").ParseString();

			var now = DateTime.UtcNow.AddYears(-10);

			Assert.AreEqual(now.Year, date.Year);
			Assert.AreEqual(now.Month, date.Month);
		}

		[TestMethod]
		public void ReturnNow_1()
		{
			var date = new DateParser("0 месяцев").ParseString();

			var expected = DateTime.UtcNow;

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void ReturnNow_2()
		{
			var date = new DateParser("фывафыафыа фыа фыа 123 фыва").ParseString();

			var expected = DateTime.UtcNow;

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundYearAndMonth_1()
		{
			var date = new DateParser("23 года и 1 месяц").ParseString();

			var expected = DateTime.UtcNow.AddYears(-23).AddMonths(-1);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundYearAndMonth_2()
		{
			var date = new DateParser("1 год и 9 месяцев").ParseString();

			var expected = DateTime.UtcNow.AddYears(-1).AddMonths(-9);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}

		[TestMethod]
		public void FoundYearAndMonth_3()
		{
			var date = new DateParser("20 лет и 2 месяца").ParseString();

			var expected = DateTime.UtcNow.AddYears(-20).AddMonths(-2);

			Assert.AreEqual(expected.Year, date.Year);
			Assert.AreEqual(expected.Month, date.Month);
		}
	}
}
