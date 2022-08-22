using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            //Truyen du lieu tu controller sang cho view
            //Cach 1 su dung view data
            ViewData["Message"] = "Day la cach su dung view data";
            ViewData["Data"] = new Customer
            {
                Code = "HE153654",
                Name = "Tran Xuan Quang",
                Age = 21
            };


            //Cach 2 su dung view bag
            ViewBag.Mess = "Day la cach su dung view bag";
            ViewBag.Customer = new Customer
            {
                Code = "HE153654-SE",
                Name = "Tran Xuan Quang-DZ",
                Age = 21
            };

            //Cach 3 truyen model
            Customer customer = new Customer
            {
                Code = "123456",
                Name = "Nguyen Van DZ",
                Age = 22
            };
            return View(customer);
        }

        public IActionResult Show()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Add(string code, string name, int age)
        //{
        //    Customer customer = new Customer
        //    {
        //        Code = code,
        //        Name = name,
        //        Age = age
        //    };
        //    return View();
        //}
        static List<Customer> list = new List<Customer>();
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {             
                list.Add(customer);
                //Di chuyen den trang hien thi default
                return View(list);

                //Di chuyen den trang view duoc tao ra
                //
                //
                //return View("ListCustomer");
            }
            else
            {
                //Loi => Di chuyen tro ve trang Show
                return View("Show");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(list);
        }


        public IActionResult Detail(string id)
        {
            Customer customer = find(list, id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            Customer customer = find(list, id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                updateCus(customer);
                return RedirectToAction("Add");
            }
            else
            {
                //Loi => Di chuyen tro ve trang Show
                return View("Show");
            }
        }

        public IActionResult Delete(string id)
        {
            deleteCus(id);
            return RedirectToAction("Add");
        }

        private void deleteCus(string id)
        {
            foreach (var c in list)
            {
                if(c.Code == id)
                {
                    list.Remove(c);
                    break;
                }
            }
        }

        private void updateCus(Customer customer)
        {
            foreach (var c in list)
            {
                if(c.Code == customer.Code)
                {
                    c.Name = customer.Name;
                    c.Age = customer.Age;
                    break;
                }
            }
        }

        Customer find(List<Customer> list, string id)
        {
            foreach (Customer customer in list)
            {
                if(customer.Code == id)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
