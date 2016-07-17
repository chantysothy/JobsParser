using System.Net;
using System.Text;
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
				var data = await client.DownloadDataTaskAsync(pageAddress);
				return Encoding.UTF8.GetString(data);
			}
		}
	}
}
