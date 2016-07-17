using Jobs.Factories;

namespace Jobs
{
	public class JobsParserSettings
	{
		public JobsParserSettings(Category category)
		{
			CategoryUri = new CategoryUrlFactory(category).GetCategoryUrl();
		}

		public string CategoryUri { get; }
	}
}
