using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api
{
    public class ProductsGet
    {
        private readonly IProductData productData;

        public ProductsGet(IProductData productData)
        {
            this.productData = productData;
        }

        [FunctionName("ProductsGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function ProductsGet processed a request.");

            var products = this.productData.GetProducts();
            return new ObjectResult(products);
        }
    }
}
