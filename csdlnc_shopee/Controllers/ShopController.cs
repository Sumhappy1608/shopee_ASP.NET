using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using csdlnc_shopee.Models;

namespace csdlnc_shopee.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }
   
        public ActionResult Shop(string productID)
        {
            shopeeEntities3 db = new shopeeEntities3();

            string shopID = (from HH in db.HANGHOAs where HH.MAHANGHOA == productID select HH.MAGIANHANG).SingleOrDefault().ToString();

            List<HANGHOA> pList = (from H in db.HANGHOAs where H.MAGIANHANG == shopID select H).ToList();

            return View(pList);
        }
    }
}