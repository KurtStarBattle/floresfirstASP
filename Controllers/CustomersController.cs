using Microsoft.AspNetCore.Mvc;

using floresfirstASP.Data;

using floresfirstASP.Models;

 

namespace floresfirstASP.Controllers

{

    public class CustomersController : Controller

    {

        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext db) { _db = db; }

 

        // shows the list

        public IActionResult Index()

        {

            var customers = _db.Customers.ToList();

            return View(customers);

        }

 

        // shows the empty add-form

        public IActionResult Create()

        {

            return View();

        }

 

        // saves a new product

        [HttpPost]

        public IActionResult Create(Customer customer)

        {

            _db.Customers.Add(customer);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        // EDIT - show the edit form
        public IActionResult Edit(int id)
        {
            var product = _db.Customers.Find(id);
            if (product == null) return RedirectToAction("Index");
            return View(product);
        }

        // EDIT - save the changes
        [HttpPost]
        public IActionResult Edit(Customer product)
        {
            _db.Customers.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE - remove the product
        public IActionResult Delete(int id)
        {
            var product = _db.Customers.Find(id);
            if (product != null)
            {
                _db.Customers.Remove(product);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }

}