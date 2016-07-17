using System.Collections.Generic;
using System.Threading.Tasks;
using Jobs;

namespace JobLibraryTests.TestsStuff
{
	public class JobsProvider : IHtmlDataProvider
	{
		private readonly string _content;

		public JobsProvider(string content)
		{
			_content = content;
		}

		public string GetPage(string pageAddress)
		{
			var data = GetPageAsync(pageAddress);
			data.Wait();
			return data.Result;
		}

		public Task<string> GetPageAsync(string pageAddress)
		{
			return Task<string>.Factory.StartNew(() => _content);
		}
	}
}