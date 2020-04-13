using ASP.NET_CarsAuction.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace ASP.NET_CarsAuction.Controllers
{
    public class HomeController : Controller
    {
        AuctionContext db = new AuctionContext();
        public string GetUserName()
        {
            string result = "";
            if (User.Identity.IsAuthenticated)
            {
                result = User.Identity.Name;
            }
            return result;
        }
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var cars = db.Cars.Where(item => item.IsCheck == true).ToList();
            return View(cars.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "manager")]
        public ActionResult UnchecktedCars()
        {
            var cars = db.Cars.Where(item => item.IsCheck == false);
            return View(cars);
        }

        [Authorize(Roles = "manager")]
        public ActionResult IsCheckCars(int id)
        {
            var car = db.Cars.Find(id);
            if (car != null)
            {
                car.IsCheck = true;
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UnchecktedCars");
            }
            return HttpNotFound();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var car = db.Cars.Find(id);
            if (car != null)
            {
                return View(car);
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "admin,manager")]
        public ActionResult ShowList()
        {
            var cars = db.Cars.ToList();
            return View(cars);
        }

        [Authorize(Roles = "admin,manager")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var car = db.Cars.Find(id);
            if (car != null)
            {
                return View(car);
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "admin,manager")]
        [HttpPost]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowList");
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "admin,manager")]
        public ActionResult Delete(int id)
        {
            var car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
                return RedirectToAction("ShowList");
            }
            return HttpNotFound();
        }

        public ActionResult AutoSedan(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var autoSedan = db.Cars.Where(item => item.CategoryId == 1 && item.IsCheck == true).ToList();
            return View("Index",autoSedan.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AutoCupe(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var autoCupe = db.Cars.Where(item => item.CategoryId == 2 && item.IsCheck == true).ToList();
            return View("Index", autoCupe.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AutoUniversal(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var autoUniversal = db.Cars.Where(item => item.CategoryId == 3 && item.IsCheck == true).ToList();
            return View("Index", autoUniversal.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        [HttpGet]
        public ActionResult RateForm(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var car = db.Cars.Find(id);
            if (car != null)
            {
                return View(car);
            }
            return HttpNotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult RateForm(int id,Car car)
        {
            var _car = db.Cars.Find(id);
            if ((car.Price - _car.Price) > 999)
            {
                _car.DateTimeLot = DateTime.Now;
                _car.UserName = GetUserName();
                _car.Price = car.Price;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("RateForm");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}