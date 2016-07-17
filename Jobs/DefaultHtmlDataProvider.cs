using System.Net;
using System.Threading.Tasks;

namespace Jobs
{
	public class DefaultHtmlDataProvider : IHtmlDataProvider
	{
		public string GetPage(string pageAddress)
		{
			var data = GetPageAsync(pageAddress);
			data.Wait();
			return data.Result;
		}

		public async Task<string> GetPageAsync(string pageAddress)
		{
			using (var client = new WebClient())
			{
				return await client.DownloadStringTaskAsync(pageAddress);
				;
			}
		}
	}
}
