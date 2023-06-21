using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.Endpoints
{
    public class GetProductsEndpoint
    {
        public int Size { get; set; }
        public int Page { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await
           RestService.For<IRefitApi>("https://api.storerestapi.com").GetProducts(Page, Size);
        }
    }
}
