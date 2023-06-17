using Class;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind_Final_Odevi.Controllers
{
    public class CustomersController : Controller
    {


        private readonly IHelperCustomers<Customers> helper;
        private Customers customers;
        public CustomersController(IHelperCustomers<Customers> helper)
        {
            this.helper = helper;
        }


        // GET: CategoryController
        public ActionResult Index()
        {
            return View(helper.AllData());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(string id)
        {
            customers = helper.Find(id);
            return View(customers);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customers collection)
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
        public ActionResult Edit(string id)
        {
            customers = helper.Find(id);

            return View(customers);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Customers collection)
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
        public ActionResult Delete(string id)
        {
            customers = helper.Find(id);

            return View(customers);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Customers collection)
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
