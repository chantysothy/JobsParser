namespace Jobs
{
	public class JobsParserSettings
	{
		public JobsParserSettings(Category category)
		{
			CategoryUrl = new CategoryUrlFactory(category).GetCategoryUrl();
		}

		public CategoryUrl CategoryUrl { get; }
	}
}
