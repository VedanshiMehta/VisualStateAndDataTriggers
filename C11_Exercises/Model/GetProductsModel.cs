using C11_Exercises.Endpoints;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.Model
{
    public class GetProductsModel
    {
        private readonly GetProductsEndpoint _endPoint;
        public int Page { get; set; }
        public int Size { get; set; }
        public long TotalProducts { get; set; }
        public long TotalPages { get; set; }
        public List<Product> ProductDetails { get; set; }
        public GetProductsModel()
        {
            _endPoint = new GetProductsEndpoint();
        }
        public async Task<Result> GetProductDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                _endPoint.Page = Page;
                _endPoint.Size = Size;
                var response = await _endPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<ProductsResponseModel>(data);
                    ProductDetails = products.Products;
                    
                    TotalProducts = products.Metadata.TotalProducts;
                    TotalPages = products.Metadata.TotalPages;
                    return new Result()
                    {
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new Result()
                    {
                        IsSuccess = false,
                        Message = "Something went wrong"
                    };
                }
            }
            else
            {
                return new Result()
                {
                    IsSuccess = false,
                    Message = "No Internet Connection"
                };
            }
        }

    }
}
