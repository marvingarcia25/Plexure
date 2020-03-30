using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Facades
{
    public interface IResourcesFacade
    {
        Task<int> GetResourcesLength();
    }
}
