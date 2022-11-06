using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Proj.Models;
using SalesProject_CourseTask.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject_CourseTask.Controllers
{
    public class CustomersController : Controller
    {
        //This is a field we call of the context insted of initalising a new instence of it everytime we call the controller
        private readonly ApplicationDBContext _context;

        //This is a constuctor that applies DI
        public CustomersController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            var customersList = _context.Customers.ToList();
            return View(customersList);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customers customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _context.Customers.Where(x => x.Customer_id == id).SingleOrDefault();
            return View(data);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customers customer)
        {
            var data = _context.Customers.FirstOrDefault(x => x.Customer_id == id);
            if (data != null)
            {
                data = customer;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.Customers.Find(id);
            return View(data);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customers customer)
        {
            var data = _context.Customers.FirstOrDefault(x => x.Customer_id == id);
            if (data != null)
            {
                _context.Customers.Remove(data);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag["Error"] = "Not Found"; 
                return View();
            }
        }
    }
}
