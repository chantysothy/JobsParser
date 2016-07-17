using System.Threading.Tasks;

namespace Jobs
{
	public interface IHtmlDataProvider
	{
		string GetPage(string pageAddress);
		Task<string> GetPageAsync(string pageAddress);
	}
}
