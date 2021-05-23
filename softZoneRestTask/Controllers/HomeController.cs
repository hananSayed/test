using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using softZoneRestTask.Models;
namespace softZoneRestTask.Controllers
{
    public class HomeController : Controller
    {
        
        RestaurantsRes db = new RestaurantsRes();
        // GET: Home
        public ActionResult Index(int? page,string filtration)
        {
            var rests = new List<RestInfo>();
            if (filtration != null && filtration != "")
            {
                int cityId = int.Parse(filtration.ToString());
                rests = db.RestInfos.Where(d => d.cityId == cityId).Take(10).ToList();
            }
            else
            {
                 rests = db.RestInfos.Take(10).ToList();

            }
            var cities = db.Cities.ToList();
            SelectList sl = new SelectList(cities, "cityId", "cityName");
            ViewBag.filtration = sl;
            const int pageSize = 3;//number of items in page
            int pageNumber = (page ?? 1);//page current
            return View(rests.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult getMenu(int? page, string id)
        {
            var meals = new List<Item>();
           if(id!=null&&id!="")
            {
                int restId = int.Parse(id);
                meals = db.Items.Where(d => d.restId == restId).Take(12).ToList();
            }
            const int pageSize = 6;//number of items in page
            int pageNumber = (page ?? 1);//page current
            TempData["display"] = "none";
            TempData["items"] = meals.ToPagedList(pageNumber, pageSize);
            return View(meals.ToPagedList(pageNumber, pageSize));
        }
        
        public ActionResult reserve(IEnumerable<int> ids)
        {
            if (ids!=null&& ids.Count() > 0)
            {
                TempData["ids"] = ids;
                return View();
            }
            else
            {
                TempData["display"] = "block";
               
                return View("getMenu", TempData["items"]);
            }
        }
        public ActionResult confirm(user us,int removeId=0)
        {
            if (removeId > 0) { }
            if (ModelState.IsValid||removeId>0)
            {
                TempData["userData"] = us;
                var ids = (List<int>)TempData["ids"];
                if (removeId > 0)
                {
                    ids.Remove(removeId);
                }
                List<Item> items = new List<Item>();
                foreach(var id in ids)
                {
                    items.Add(db.Items.SingleOrDefault(d => d.itemId == id));
                }
                userOrder userOrder = new userOrder()
                {
                    user = us,
                    items = items
                };
                return View(userOrder);
            }
            return View("reserve",us);
        }
        public ActionResult save(List<int> quantities)
        {

          user us=  (user)TempData["userData"];
            var ids = (List<int>)TempData["ids"];
            db.Users.Add(us);
           int res= db.SaveChanges();
            if (res > 0)
            {
                foreach (var id in ids)
                {
                    db.Orders.Add(new order() {
                    userId=us.userId,
                    itemId=id
                    
                    });
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult backToMenu()
        {
            return View("getMenu", TempData["items"]);

        }
        public ActionResult backToReserve()
        {
            user us = (user)TempData["userData"];

            return View("reserve", us);

        }
    }
}