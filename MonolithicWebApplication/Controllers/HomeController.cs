using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonolithicWebApplication.Infraestructure.API;
using MonolithicWebApplication.Infraestructure.API.Models;
using MonolithicWebApplication.Infraestructure.Repositories;
using MonolithicWebApplication.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MonolithicWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private IExternalProductProviderClient _externalProductProvider;
        ProductRepository _productRepository; //= new ProductRepository();
        private readonly ILogger<HomeController> _logger;
        /*
        public HomeController(ILogger<HomeController> logger, IExternalProductProviderClient externalProductProviderClient)
        {
            _logger = logger;
            _externalProductProvider = externalProductProviderClient;
        }
        */
        public HomeController(IExternalProductProviderClient externalProductProvider, ProductRepository productRepository)
        {
            _productRepository = productRepository;
            _externalProductProvider = externalProductProvider;
        }

        public async Task<IActionResult> Index()
        {
            var products = _productRepository.Get();
            var externalProducts = _externalProductProvider.GetProducts();
            List<ProductModel> productsList = new List<ProductModel>();

            foreach (var product in products)
            {
                var tmpProduct = new ProductModel();
                tmpProduct.IdProduct = product.IdProduct;
                tmpProduct.NameProduct = product.NameProduct;
                tmpProduct.DescriptionProduct = product.DescriptionProduct;
                tmpProduct.ImageUrlProduct = product.ImageUrlProduct;
                tmpProduct.MemoryProduct = product.MemoryProduct;
                tmpProduct.StorageCapacityProduct = product.StorageCapacityProduct;
                tmpProduct.ResolutionImageProduct = product.ResolutionImageProduct;
                tmpProduct.PriceProduct = product.PriceProduct;
                tmpProduct.CategoryId = product.CategoryId;

                productsList.Add(tmpProduct);
            }
            
            foreach (ExternalProduct externalProduct in await externalProducts)
            {
                var tmpProduct = new ProductModel();
                tmpProduct.IdProduct = externalProduct.IdProduct;
                tmpProduct.NameProduct = externalProduct.NameProduct;
                tmpProduct.DescriptionProduct = externalProduct.DescriptionProduct;
                tmpProduct.ImageUrlProduct = externalProduct.ImageUrlProduct;
                productsList.Add(tmpProduct);
            }
            
            return View(productsList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
