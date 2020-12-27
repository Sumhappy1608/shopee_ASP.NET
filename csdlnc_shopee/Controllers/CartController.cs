using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using csdlnc_shopee.Models;
namespace csdlnc_shopee.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart

        private shopeeEntities3 db = new shopeeEntities3();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart(string productID)
        {
            try
            {
                var account = Session["account"] as TAIKHOANDANGNHAP;
                if (account != null)
                {

                    GIOHANG toUpdate = db.GIOHANGs.FirstOrDefault(a => a.ID_NGUOIMUA == account.ID_THANHVIEN && a.MAHANGHOA == productID);
                    if (toUpdate == null)
                    {
                        GIOHANG giohang = new GIOHANG();
                        giohang.ID_NGUOIMUA = account.ID_THANHVIEN.Trim();
                        giohang.MAHANGHOA = productID.Trim();
                        giohang.NGAYTHEM = DateTime.Now;
                        giohang.SOLUONG = 1;
                        db.GIOHANGs.Add(giohang);
                        db.SaveChanges();
                    }
                    else
                    {
                        toUpdate.SOLUONG += 1;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return RedirectToAction("ProductDetail", "Home", new { @productID = productID });
        }

        [HttpPost]
        public ActionResult RemoveFromCart(string productID)
        {
            try
            {
                var account = Session["account"] as TAIKHOANDANGNHAP;
                if (account != null)
                {

                    GIOHANG toDelete = db.GIOHANGs.FirstOrDefault(a => a.ID_NGUOIMUA == account.ID_THANHVIEN && a.MAHANGHOA == productID);
                    db.GIOHANGs.Remove(toDelete);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}