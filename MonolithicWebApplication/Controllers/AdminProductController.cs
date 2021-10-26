using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MonolithicWebApplication.Infraestructure.Repositories;
using MonolithicWebApplication.Models;
using MonolithicWebApplication.Business.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace MonolithicWebApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminProductController : Controller
    {
        ProductRepository _productRepository; //= new ProductRepository();
        CategoriesRepository _categoriesRepository = new CategoriesRepository();

        public AdminProductController(ProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public IActionResult Products()
        {
            var products = _productRepository.Get();
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

            return View(productsList);
        }

        public IActionResult UpsertProduct(int? id)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.CategoryList = GetCategories();

            if (id != null)
            {
                Product foundProduct = _productRepository.Get().FirstOrDefault(p => p.CategoryId == id);

                ProductModel product = new ProductModel();
                product.IdProduct = foundProduct.IdProduct;
                product.NameProduct = foundProduct.NameProduct;
                product.DescriptionProduct = foundProduct.DescriptionProduct;
                product.ImageUrlProduct = foundProduct.ImageUrlProduct;
                product.MemoryProduct = foundProduct.MemoryProduct;
                product.StorageCapacityProduct = foundProduct.StorageCapacityProduct;
                product.ResolutionImageProduct = foundProduct.ResolutionImageProduct;
                product.PriceProduct = foundProduct.PriceProduct;
                product.CategoryId = foundProduct.CategoryId;

                newProduct.Product = product;

                return View(newProduct);
            }
            else
            {
                newProduct.Product = new ProductModel();
            }
            return View(newProduct);
        }

        [HttpPost]
        public IActionResult UpsertProduct(NewProduct productFormData)
        {

            if (ModelState.IsValid)
            {
                if (productFormData.Product.IdProduct != 0)
                {
                    Product existingProduct = _productRepository.Get().FirstOrDefault(p => p.IdProduct == productFormData.Product.IdProduct);
                    existingProduct.NameProduct = productFormData.Product.NameProduct;
                    existingProduct.DescriptionProduct = productFormData.Product.DescriptionProduct;
                    existingProduct.ImageUrlProduct = productFormData.Product.ImageUrlProduct;
                    existingProduct.MemoryProduct = productFormData.Product.MemoryProduct;
                    existingProduct.StorageCapacityProduct = productFormData.Product.StorageCapacityProduct;
                    existingProduct.ResolutionImageProduct = productFormData.Product.ResolutionImageProduct;
                    existingProduct.PriceProduct = productFormData.Product.PriceProduct;
                    existingProduct.CategoryId = productFormData.Product.CategoryId;

                    _productRepository.Update(productFormData.Product.IdProduct, existingProduct);

                }
                else
                {
                    Product newProduct = new Product();
                    newProduct.NameProduct = productFormData.Product.NameProduct;
                    newProduct.DescriptionProduct = productFormData.Product.DescriptionProduct;
                    newProduct.ImageUrlProduct = productFormData.Product.ImageUrlProduct;
                    newProduct.MemoryProduct = productFormData.Product.MemoryProduct;
                    newProduct.StorageCapacityProduct = productFormData.Product.StorageCapacityProduct;
                    newProduct.ResolutionImageProduct = productFormData.Product.ResolutionImageProduct;
                    newProduct.PriceProduct = productFormData.Product.PriceProduct;
                    newProduct.CategoryId = productFormData.Product.CategoryId;

                    _productRepository.Insert(newProduct);
                }

                return RedirectToAction(nameof(Products));
            }
            else
            {
                productFormData.CategoryList = GetCategories();
                if (productFormData.Product.IdProduct != 0)
                {
                    productFormData.Product = new ProductModel(); //_productRepository.Get().FirstOrDefault(p => p.IdProduct == productFormData.Product.IdProduct);
                }
            }

            return View(productFormData);
        }


        public IActionResult DeleteProduct(int? id)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.CategoryList = GetCategories(); 

            if (id != null)
            {
                Product foundProduct = _productRepository.Get().FirstOrDefault(p => p.CategoryId == id);

                ProductModel product = new ProductModel();
                product.IdProduct = foundProduct.IdProduct;
                product.NameProduct = foundProduct.NameProduct;
                product.DescriptionProduct = foundProduct.DescriptionProduct;
                product.ImageUrlProduct = foundProduct.ImageUrlProduct;
                product.MemoryProduct = foundProduct.MemoryProduct;
                product.StorageCapacityProduct = foundProduct.StorageCapacityProduct;
                product.ResolutionImageProduct = foundProduct.ResolutionImageProduct;
                product.PriceProduct = foundProduct.PriceProduct;
                product.CategoryId = foundProduct.CategoryId;

                newProduct.Product = product;

                return View(newProduct);
            }
            else
            {
                return RedirectToAction(nameof(Products));
            }
        }


        [HttpPost]
        public IActionResult DeleteProduct(NewProduct productFormData)
        {
            if (ModelState.IsValid)
            {
                if (productFormData.Product.IdProduct != 0)
                {
                    _productRepository.Delete(productFormData.Product.IdProduct);
                    return RedirectToAction(nameof(Products));
                }
            }
            return RedirectToAction(nameof(Products));
        }


        public List<SelectListItem> GetCategories()
        {
            return _categoriesRepository.Get().Select(c => new SelectListItem() { Value = c.IdCategory.ToString(), Text = c.NameCategory }).ToList();
        }
    }
}
