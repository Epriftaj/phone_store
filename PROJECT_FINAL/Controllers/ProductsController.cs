using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROJECT_FINAL.Models;

namespace PROJECT_FINAL.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Categorytbl);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(db.Categorytbls, "Category_Id", "Category_Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Title,ImgUrl,Description,Price,Quantity,isActive,Category_Id,File")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.File != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.File.FileName);
                    string extension = Path.GetExtension(product.File.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    product.ImgUrl = fileName;
                    product.File.SaveAs(Path.Combine(Server.MapPath("~/uploads"), fileName));
                    db.Products.Add(product);
                    db.SaveChanges();
                }

                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.Category_Id = new SelectList(db.Categorytbls, "Category_Id", "Category_Name", product.Category_Id);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.Categorytbls, "Category_Id", "Category_Name", product.Category_Id);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Title,ImgUrl,Description,Price,Quantity,isActive,Category_Id")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Id = new SelectList(db.Categorytbls, "Category_Id", "Category_Name", product.Category_Id);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Shto produktin ne shporte
        public ActionResult AddtoCart(int? id)
        {
            var p = db.Products.Where(x => x.ProductId == id).SingleOrDefault();
            return View(p);
        }
        List<Cart> li = new List<Cart>();


        [HttpPost]
        public ActionResult AddtoCart(Product product, string Quantity, int id)
        {
            var p = db.Products.Where(x => x.ProductId == id).SingleOrDefault();
            Cart c = new Cart();
            c.CartId = p.ProductId;
            c.Price = p.Price;
            c.Quantity = Convert.ToInt32(Quantity);
            c.ProductName = p.Title;
            c.Total = c.Quantity * p.Price;
            if (TempData["Cart"] == null)
            {
                li.Add(c);
                TempData["Cart"] = li;
            }
            else
            {
                List<Cart> li2 = TempData["Cart"] as List<Cart>;
                int flag = 0;
                foreach (var item in li2)
                {
                    if (item.ProductId == c.CartId)
                    {
                        item.Quantity += c.Quantity;
                        item.Total += c.Total;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    li2.Add(c);
                }
                TempData["Cart"] = li2;
                //List<Cart> li2 = TempData["Cart"] as List<Cart>;
                //li2.Add(c);
                //TempData["Cart"] = li2;
            }

            TempData.Keep();
            return RedirectToAction("Index");
        }



        public ActionResult remove(int? id)
        {
            List<Cart> li2 = TempData["Cart"] as List<Cart>;
            Cart c = li2.Where(x => x.ProductId == id).SingleOrDefault();
            li2.Remove(c);
            decimal h = 0;
            foreach (var item in li2)
            {
                h += item.Total;
            }
            TempData["total"] = h;
            return RedirectToAction("Checkout");
        }


        public ActionResult Checkout()
        {

            TempData.Keep();
            return View();
        }


        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            List<Cart> li = TempData["Cart"] as List<Cart>;

            foreach (var item in li)
            {
                Order od = new Order();
                od.OrderId = item.ProductId;
                od.OrderDate = System.DateTime.Now;
                od.Qty = item.Quantity;
                od.UnitPrice = item.Price;
                od.TotalAmount = item.Total;
               
                db.Orders.Add(od);
                //db.SaveChanges();
            }

            TempData.Remove("total");
            TempData.Remove("Cart");


            TempData["msg"] = "Order Completed.....Thanks for choosing Us!";
            TempData.Keep();
            return RedirectToAction("Index");
        }

    }
}
