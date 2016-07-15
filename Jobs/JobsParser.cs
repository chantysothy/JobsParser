using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;

namespace Jobs
{
    public interface ICategoryUrl
    {
        string Url { get; }
    }

    public class JobsParser
    {
        private readonly ICategoryUrl _categoryUrl;

        public JobsParser(ICategoryUrl categoryUrl)
        {
            _categoryUrl = categoryUrl;
        }

        public async Task<IReadOnlyCollection<Applicant>> Parse()
        {
            // Setup the configuration to support document loading
            var config = Configuration.Default.WithDefaultLoader();
            
            // Load the names of all The Big Bang Theory episodes from Wikipedia
            var address = _categoryUrl.Url;
            
            // Asynchronously get the document in a new context using the configuration
            var document = await BrowsingContext.New(config).OpenAsync(address);
            
            //Applicant view
            const string selector = "div.sr_row";
            
            // Perform the query to get all applicant's views
            var cells = document.QuerySelectorAll(selector);
            
            // We are only interested in the text - select it with LINQ
            var titles = cells.Select(m => m.TextContent);

            throw new NotImplementedException();
        }
    }
}