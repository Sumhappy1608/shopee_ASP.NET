using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using csdlnc_shopee.Models;

namespace csdlnc_shopee.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            shopeeEntities3 db = new shopeeEntities3();
            List<HANGHOA> pList = db.HANGHOAs.Take(12).ToList();
            return View(pList);
            
        }

        //Best Seller
        public ActionResult BestSeller()
        {
            shopeeEntities3 db = new shopeeEntities3();
            List<HANGHOA> pList = (from HH in db.HANGHOAs
                                   orderby HH.SOLUONGDABAN descending
                                   select HH).Take(3).ToList();
            return PartialView("_BestSeller", pList);
        }

        //Hot Item

        public ActionResult HotItem()
        {
            shopeeEntities3 db = new shopeeEntities3();
            List<HANGHOA> pList = (from HH in db.HANGHOAs
                                   orderby HH.DANHGIA_HANGHOA descending
                                   select HH).Take(6).ToList();
            return PartialView("_HotItem", pList);
        }

        public ActionResult OnSale()
        {
            shopeeEntities3 db = new shopeeEntities3();
            List<HANGHOA> pList = (from HH in db.HANGHOAs
                                   orderby HH.GIATHANH 
                                   select HH).Take(3).ToList();
            return PartialView("_OnSale", pList);
        }

        //Lấy chi tiết sản phẩm

        public ActionResult ProductDetail(string productID)
        {
            shopeeEntities3 db = new shopeeEntities3();
            HANGHOA product = db.HANGHOAs.Where(x => x.MAHANGHOA == productID).SingleOrDefault();
            return View(product);
        }

        //Recent Post
        public ActionResult RecentPost()
        {
            shopeeEntities3 db = new shopeeEntities3();
            List<HANGHOA> pList = (from HH in db.HANGHOAs
                                   orderby HH.NGAYDANG descending
                                   select HH).Take(3).ToList();
            return PartialView("_RecentPost", pList);
        }

        public ActionResult Categories()
        {
            shopeeEntities3 db = new shopeeEntities3();
            List<DANHMUC> cList = db.DANHMUCs.Take(6).ToList();
            return PartialView("_Categories", cList);
        }

        public ActionResult CategoryItem(string categoryID)
        {
            shopeeEntities3 db = new shopeeEntities3();
            List<HANGHOA> pList = (from HH in db.HANGHOAs
                                   join DM in db.DANHMUCs on HH.LOAIHANGHOA equals DM.MALOAI
                                   where DM.MALOAI == categoryID
                                   select HH).ToList();
            return View(pList);
        }

        [HttpGet]
        public ActionResult search(string search)
        {
            shopeeEntities3 db = new shopeeEntities3();     
            List<HANGHOA> pList = db.HANGHOAs.Where(x => x.TENHANGHOA.Contains(search)).Take(12).ToList();
            return View(pList);
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