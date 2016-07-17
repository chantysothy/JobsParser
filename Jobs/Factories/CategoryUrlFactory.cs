namespace Jobs.Factories
{
	public class CategoryUrlFactory
	{
		private const string BaseUrl = "http://yaroslavl.job.ru/employer/search/?ncv=0";
		private readonly Category _category;

		public CategoryUrlFactory(Category category)
		{
			_category = category;
		}

		public string GetCategoryUrl()
		{
			var categoryId = (int) _category;

			return categoryId < 0 ? BaseUrl : $"{BaseUrl}&wrkfld={categoryId}";
		}
	}
}
