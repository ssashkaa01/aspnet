using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.DAL.Repositories;
using WebApplication.Entities;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ShopController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductCategory> _categoryRepository;
        public ShopController()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
        }
        // GET: Category
        public ActionResult Index(FilterModel search)
        {
            //ViewBag.Title = "Категорії --";
            IEnumerable<Product> list;
            if (search.Name != null)
                list = _productRepository.GetAll(x => x.Name.Contains(search.Name));
            else
            {
                list = _productRepository.GetAll();
            }
            var mapper = MyAutoMapperConfig.GetAutoMapper();
            // сопоставление
            var model = mapper.Map<List<ProductVM>>(list);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductAddVM model = new ProductAddVM();
            var categories = _categoryRepository.GetAll();
            var mapper = MyAutoMapperConfig.GetAutoMapper();
            // сопоставление
            var select = mapper.Map<List<SelectItemVM>>(categories);

            model.SetCategoriesSelect(select);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductAddVM model)
        {
            if (ModelState.IsValid)
            {
                Product animal = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    CategoryId = model.CategoryId,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    DeleteDate = DateTime.Now
                };
                _productRepository.Create(animal);
                _productRepository.Save();
                //context.Animals.Add(animal);
                //context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        // GET: Photo/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = _productRepository.Get(id);

            var mapper = MyAutoMapperConfig.GetAutoMapper();
            // сопоставление
            var model = mapper.Map<ProductAddVM>(product);

            return View(model);
        }

        // POST: Photo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductAddVM model)
        {
            Product product = _productRepository.Get(id);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Quantity = model.Quantity;
            product.CategoryId = model.CategoryId;
            product.ModifyDate = DateTime.Now;

            _productRepository.Save();

            return RedirectToAction("Index");

        }

        // GET: Photo/Delete/5
        public ActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();

            return RedirectToAction("Index");
        }

        // POST: Photo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            return View();
        }
    }
}