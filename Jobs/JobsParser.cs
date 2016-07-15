using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;

namespace Jobs
{
	public class JobsParser
	{
		private const string Selector = "div.sr_row";

		private readonly CategoryUrl _categoryUrl;

		public JobsParser(JobsParserSettings settings)
		{
			_categoryUrl = settings.CategoryUrl;
		}

		public async Task<IReadOnlyCollection<Applicant>> ParseAsync()
		{
			// Setup the configuration to support document loading
			var config = Configuration.Default.WithDefaultLoader();

			// Load the names of all The Big Bang Theory episodes from Wikipedia
			var address = _categoryUrl.Url;

			// Asynchronously get the document in a new context using the configuration
			var document = await BrowsingContext.New(config).OpenAsync(address);

			// Perform the query to get all applicant's views
			var views = document.QuerySelectorAll(Selector);

			// We are only interested in the text - select it with LINQ
			var titles = views.Select(m => m.TextContent);

			throw new NotImplementedException();
		}
	}
}
