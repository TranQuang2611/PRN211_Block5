using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebMVC_EF.Models;

namespace WebMVC_EF.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>();
            List<Product> products = new List<Product>();
            using (var context = new MySaleDBContext())
            {
                products = context.Products.Include(x => x.Category).ToList();
                categories = context.Categories.ToList();
                ViewBag.cat = categories;
                return View(products);
            }

        }

        [HttpPost]
        public IActionResult Index(int cid)
        {
            List<Category> categories = new List<Category>();
            List<Product> products = new List<Product>();
            using (var context = new MySaleDBContext())
            {
                if (cid != 0)
                {
                    products = context.Products.Include(x => x.Category).Where(x => x.CategoryId == cid).ToList();
                }
                else
                {
                    products = context.Products.Include(x => x.Category).ToList();
                }
                categories = context.Categories.ToList();
                ViewBag.cat = categories;
                ViewBag.cid = cid;
                return View(products);
            }

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            List<Category> categories = new List<Category>();
            Product product = new Product();
            using (var context = new MySaleDBContext())
            {
                categories = context.Categories.ToList();
                product = context.Products.FirstOrDefault(x => x.ProductId == id);
            }
            ViewBag.cate = categories;
            return View(product);
        }

        public IActionResult Information(int id)
        {
            Product product = new Product();
            using (var context = new MySaleDBContext())
            {
                product = context.Products.FirstOrDefault(x => x.ProductId == id);
                
            }
            return View(product);
        }

        public IActionResult Update(Product p)
        {
            List<Category> categories = new List<Category>();
            if (ModelState.IsValid)
            {
                using (var context = new MySaleDBContext())
                {
                    categories = context.Categories.ToList();
                    context.Products.Update(p);
                    if (context.SaveChanges() > 0)
                    {
                        ViewBag.mess = "Update thành công";
                    }
                    else
                    {
                        ViewBag.mess = "Update không thành công";
                    }
                    
                }
            }
            ViewBag.cate = categories;
            return View(p);
        }

        public IActionResult Delete(int id)
        {
            using (var context = new MySaleDBContext())
            {
                Product product = context.Products.FirstOrDefault(x => x.ProductId == id);
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Category> categories = new List<Category>();
            using (var context = new MySaleDBContext())
            {
                categories = context.Categories.ToList();
                ViewBag.cat = categories;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, decimal price, int stock, int cid)
        {
            Product product = new Product
            {
                ProductName = name,
                UnitPrice = price,
                UnitsInStock = stock,
                CategoryId = cid
            };
            using (var context = new MySaleDBContext())
            {
                context.Products.Add(product);
                if (context.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    List<Category> categories = new List<Category>();
                    categories = context.Categories.ToList();
                    ViewBag.cat = categories;
                    return View();
                }
            }
        }
    }
}
