using Class;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind_Final_Odevi.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IHelper<Orders> helper;
        private Orders orders;
        public OrdersController(IHelper<Orders> helper)
        {
            this.helper = helper;
            orders = new Orders();
        }

        // GET: OrdersController
        public ActionResult Index()
        {
            return View(helper.AllData());
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            orders = helper.Find(id);
            return View(orders);
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Orders collection)
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

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            orders = helper.Find(id);
            return View(orders);
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Orders collection)
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

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {

            orders = helper.Find(id);
            return View(orders);
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
