using Class;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind_Final_Odevi.Controllers
{
    public class Order_Details_Controller : Controller
    {
        private readonly IHelper<Order_Details> helper;
        Order_Details order_Details;

        public Order_Details_Controller(IHelper<Order_Details> helper)
        {
            this.helper = helper;
            order_Details = new Order_Details();
        }
        // GET: Order_Details_Controller
        public ActionResult Index()
        {
            return View(helper.AllData());
        }

        // GET: Order_Details_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order_Details_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order_Details_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order_Details_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order_Details_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order_Details_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order_Details_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
