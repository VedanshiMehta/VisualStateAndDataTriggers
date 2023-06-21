using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises
{
    public interface IRefitApi
    {
        [Get("/products")]
        Task<HttpResponseMessage> GetProducts(int page, int limit);
    }
}
