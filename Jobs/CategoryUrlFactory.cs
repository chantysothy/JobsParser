namespace Jobs
{
    public class CategoryUrlFactory
    {
        private readonly Category _category;

        public CategoryUrlFactory(Category category)
        {
            _category = category;
        }

        public CategoryUrl GetCategoryUrl()
        {
            const string url = "http://yaroslavl.job.ru/employer/search/";
            return new CategoryUrl(_category != Category.All ? url + $"?wrkfld={(int) _category}" : url);
        }
    }
}