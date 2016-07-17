using Jobs.Factories;
using Jobs.Models;

namespace Jobs
{
	public class JobsParserSettings
	{
		public JobsParserSettings(Category category, IHtmlDataProvider htmlDataProvider)
		{
			HtmlDataProvider = htmlDataProvider;
			CategoryUri = new CategoryUrlFactory(category).GetCategoryUrl();
		}

		public IHtmlDataProvider HtmlDataProvider { get; }

		public string CategoryUri { get; }
	}
}
