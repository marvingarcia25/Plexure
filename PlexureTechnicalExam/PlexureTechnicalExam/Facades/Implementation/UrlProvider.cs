using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1.Facades.Implementation
{
    public class UrlProvider : IUrlProvider
    {
        //Default implementation of the URL provider.
        public List<string> GetUrls()
        {
            List<string> urls = new List<string>
            {
                "https://postman-echo.com/get?foo1=bar1&foo2=bar2",
                "https://postman-echo.com/get?foo1=bar1&foo2=bar22",
                "https://postman-echo.com/get?foo1=bar1&foo2=bar223"
            };
            return urls;
        }
    }
}
