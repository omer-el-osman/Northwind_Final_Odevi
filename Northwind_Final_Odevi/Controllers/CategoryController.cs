using Class;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind_Final_Odevi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHelper<Categories> helper;
        private Categories categories;
        public CategoryController(IHelper<Categories> helper)
        {
            this.helper = helper;
        }


        // GET: CategoryController
        public ActionResult Index()
        {
            return View(helper.AllData());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            categories = helper.Find(id);
            return View(categories);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories collection)
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

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            categories = helper.Find(id);

            return View(categories);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categories collection)
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

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            categories = helper.Find(id);

            return View(categories);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Categories collection)
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
