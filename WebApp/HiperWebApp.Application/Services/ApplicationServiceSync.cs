using HiperWebApp.Application.Interfaces;
using HiperWebApp.Application.Services.HttpClients;
using HiperWebApp.Domain.Core.Interfaces.Services;
using HiperWebApp.Domain.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiperWebApp.Application.Services
{
    public class ApplicationServiceSync : IApplicationServiceSync
    {
        private readonly IProductService _serviceProduct;
        private readonly HiperApiClient _api;

        public ApplicationServiceSync(IProductService serviceProduct, HiperApiClient hiperApiClient)
        {
            _serviceProduct = serviceProduct;
            _api = hiperApiClient;
        }

        public ApplicationServiceSync()
        {

        }

        public async Task StartSync()
        {
            List<Product> productsLocal = _serviceProduct.GetAll().ToList();
            List<Product> productsApi = await _api.GetProductsAsync();

            GetProductsToSend(productsLocal, productsApi, out List<Product> productsAdd, out List<Product> productsEdit);

            if (productsAdd.Any())
                await _api.PostProductAsync(productsAdd);

            if (productsEdit.Any())
                await _api.PutProductAsync(productsEdit);

        }

        private static void GetProductsToSend(List<Product> productsLocal, List<Product> productsApi, out List<Product> productsAdd, out List<Product> productsEdit)
        {
            productsAdd = new List<Product>();
            productsEdit = new List<Product>();
            if (!productsLocal.Any())
            {
                return;
            }
            if (!productsApi.Any())
            {
                productsAdd.AddRange(productsLocal);
                return;
            }

            foreach ((Product productLocal, Product productApi) in from Product productLocal in productsLocal
                                                                   let productApi = productsApi.DefaultIfEmpty(null).FirstOrDefault(x => x.Id == productLocal.Id)
                                                                   select (productLocal, productApi))
            {
                if (productApi == null)
                {
                    productsAdd.Add(productLocal);
                }

                if (!productLocal.IsEquals(productApi))
                {
                    productsEdit.Add(productLocal);
                }
            }
        }
    }
}
