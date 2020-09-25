using HiperWebApp.Application.Interfaces;
using HiperWebApp.Application.Services.HttpClients;
using HiperWebApp.Domain.Models;
using HiperWebApp.Models;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Diagnostics;

namespace HiperWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IApplicationServiceProduct _applicationServiceProduct;

        public ProductController(IApplicationServiceProduct applicationServiceProduct)
        {
            _applicationServiceProduct = applicationServiceProduct;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel
            {
                Products = _applicationServiceProduct.GetAll()
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _applicationServiceProduct.Add(model);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    throw;
                }
                return RedirectToAction("Index", "Product");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Product product = _applicationServiceProduct.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _applicationServiceProduct.Update(model);
                }
                catch (InvalidOperationException ex) {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    throw;
                }
            }
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(int id)
        {
            _applicationServiceProduct.Remove(id);

            return RedirectToAction("Index", "Product");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
