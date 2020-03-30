using Exercise1.Facades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    public class AsyncApplication
    {
        private readonly IResourcesFacade _resourcesFacade;

        public AsyncApplication(IResourcesFacade resourcesFacade)
        {
            _resourcesFacade = resourcesFacade;
        }

        public void Run()
        {
           var total = _resourcesFacade.GetResourcesLength().GetAwaiter().GetResult();
           Console.WriteLine($"Aggregated string lengths: {total}");
        }
    }
}
