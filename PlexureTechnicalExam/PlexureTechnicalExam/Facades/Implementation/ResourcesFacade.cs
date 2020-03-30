using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Facades.Implementation
{
    public class ResourcesFacade : IResourcesFacade
    {
        private readonly IUrlProvider _urlProvider;
        public ResourcesFacade(IUrlProvider urlProvider)
        {
            _urlProvider = urlProvider;
        }

        public async Task<int> GetResourcesLength()
        { 
            // Make a list of web addresses.
            List<string> urlList = _urlProvider.GetUrls();

            // Create a query.
            IEnumerable<Task<int>> downloadTasksQuery =
                from url in urlList select ProcessURLAsync(url);

            // Use ToArray to execute the query and start the download tasks.
            Task<int>[] downloadTasks = downloadTasksQuery.ToArray();

            // Await the completion of all the running tasks.
            int[] lengths = await Task.WhenAll(downloadTasks);

            //Sum up the total lengths
            int total = lengths.Sum();

            return total;
        }

        private async Task<int> ProcessURLAsync(string url)
        {
            var byteArray = await GetURLContentsAsync(url);
            return byteArray.Length;
        }

        private async Task<string> GetURLContentsAsync(string url)
        {
            string responseText = string.Empty;

            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);

            // Send the request to the Internet resource and wait for
            // the response.
            using (WebResponse response = await webReq.GetResponseAsync())
            {  
                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                {
                    responseText = reader.ReadToEnd();
                }
            }

            // Return the result as a string.
            return responseText;
        }
    }
}
