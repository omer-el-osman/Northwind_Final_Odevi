using Class;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind_Final_Odevi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHelper<Products> helper;
        private Products products;
        public ProductsController(IHelper<Products> helper)
        {
            this.helper = helper;
        }


        // GET: ProductsController
        public ActionResult Index()
        {
            return View(helper.AllData());
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            products = helper.Find(id);
            return View(products);
        }
       // [Authorize("Admin")]
        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }
       // [Authorize("Admin")]
        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products collection)
        {
            try
            {
                helper.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
      //  [Authorize("Admin")]
        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            products = helper.Find(id);
            return View(products);
        }
        //[Authorize("Admin")]
        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Products collection)
        {
            try
            {
                helper.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       // [Authorize("Admin")]
        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            products = helper.Find(id);
            return View(products);
        }
      //  [Authorize("Admin")]
        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Products collection)
        {
            try
            {
                helper.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
