using System;
using Lib.Common;
using NUnit.Framework;

namespace Unit.Tests.Common
{
	[TestFixture]
	public class PrimitiveExtensionsTester
	{
		[Test]
		public void should_wrap_arrays()
		{
			var strings = new[] {"one", "two", "three"};
			
			Assert.That(strings.WrapEachWith("before", "after", " ") == "beforeoneafter beforetwoafter beforethreeafter");
		}



		[Test]
		public void should_convert_to_bool()
		{
			bool? test = null;

			Assert.IsFalse(test.ToBool());

			test = false;
			Assert.IsFalse(test.ToBool());

			test = true;
			Assert.IsTrue(test.ToBool());
		}

		[Test]
		public void Should_properly_format_timespan_for_detention_history()
		{
			var timespan = new TimeSpan(0, 1, 0, 0);
			Assert.That(timespan.ToFormattedString(), Is.EqualTo("1 hour"));

			var timeSpan1 = new TimeSpan(0, 2, 0, 0);
			Assert.That(timeSpan1.ToFormattedString(), Is.EqualTo("2 hours"));

			var timeSpan2 = new TimeSpan(20, 0, 0, 0);
			Assert.That(timeSpan2.ToFormattedString(), Is.EqualTo("20 days"));

			var timeSpan3 = new TimeSpan(1, 0, 0, 0);
			Assert.That(timeSpan3.ToFormattedString(), Is.EqualTo("1 day"));

			var timeSpan4 = new TimeSpan(0, 0, 9, 0);
			Assert.That(timeSpan4.ToFormattedString(), Is.EqualTo("9 minutes"));

			var timeSpan5 = new TimeSpan(0, 0, 1, 0);
			Assert.That(timeSpan5.ToFormattedString(), Is.EqualTo("1 minute"));

			var timeSpan6 = new TimeSpan(1, 0, 24, 0);
			Assert.That(timeSpan6.ToFormattedString(), Is.EqualTo("1 day, 24 minutes"));

			var timeSpan7 = new TimeSpan(30, 10, 1, 0);
			Assert.That(timeSpan7.ToFormattedString(), Is.EqualTo("30 days, 10 hours, 1 minute"));

			var timeSpan8 = new TimeSpan(0, 48, 0, 0);
			Assert.That(timeSpan8.ToFormattedString(), Is.EqualTo("2 days"));

			var timeSpan9 = new TimeSpan(5000, 0, 360, 0);
			Assert.That(timeSpan9.ToFormattedString(), Is.EqualTo("5000 days, 6 hours"));
		}

		[Test]
		public void should_format_nullable_date_in_mmddyyyy_format()
		{
			DateTime? date = new DateTime(2008, 4, 5, 13, 10, 10);
			Assert.That(date.ToStandardDate(string.Empty), Is.EqualTo("04/05/2008"));

			DateTime? nulldate = null;
			Assert.That(nulldate.ToStandardDate(string.Empty), Is.EqualTo(string.Empty));
		}

		[Test]
		public void should_return_an_empty_string_when_null()
		{
			const string dummy = null;
			Assert.That(dummy.ToNullSafeString(), Is.EqualTo(string.Empty));
		}

		[Test]
		public void should_create_vaild_xhtml_link()
		{
			string dummy = "http://jeffreypalermo.com/&Id=1";
			string shouldEqual = "http://jeffreypalermo.com/&amp;Id=1";
			Assert.That(dummy.ToXhtmlLink(), Is.EqualTo(shouldEqual));

			string nullString = null;
			Assert.IsEmpty(nullString.ToXhtmlLink());
		}

		[Test]
		public void Should_convert_string_to_nullable_datetime()
		{
			Assert.That("2008/1/1".ToNullableDate().Value == new DateTime(2008, 1, 1));
			Assert.IsFalse("as".ToNullableDate().HasValue);
		}

		[Test]
		public void Should_split_string()
		{
			Assert.That("PascalCase".ToSeparatedWords() == "Pascal Case");
		}

		[Test]
		public void Should_convert_to_lower_camel_case()
		{
			Assert.That("PascalCase".ToLowerCamelCase() == "pascalCase");
		}
	}
}