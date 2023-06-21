using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises
{
    public class ProductsResponseModel
    {
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
        [JsonProperty("data")]
        public List<Product> Products { get; set; }
        [JsonProperty("status")]
        public long Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

    }
    public class  Product
   {
    [JsonProperty("_id")]
    public string Id { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("price")]
    public long Price { get; set; }
    [JsonProperty("category")]
    public Category Category { get; set; }
    [JsonProperty("description")]
    public object Description { get; set; }
    [JsonProperty("createdBy")]
    public CreatedBy CreatedBy { get; set; }
    [JsonProperty("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }
    [JsonProperty("updatedAt")]
    public DateTimeOffset UpdatedAt { get; set; }
    [JsonProperty("slug")]
    public string Slug { get; set; }
    }
    public class Category
    {
    [JsonProperty("_id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("slug")]
    public string Slug { get; set; }
    }
     public class CreatedBy
    {
    [JsonProperty("role")]
    public string Role { get; set; }
    [JsonProperty("_id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    }
    public class Metadata
    {
    [JsonProperty("currentPage")]
    public long CurrentPage { get; set; }
    [JsonProperty("totalProducts")]
    public long TotalProducts { get; set; }
    [JsonProperty("nextPage")]
    public long NextPage { get; set; }
    [JsonProperty("prevPage")]
    public long PrevPage { get; set; }
    [JsonProperty("totalPages")]
    public long TotalPages { get; set; }
    }
}
