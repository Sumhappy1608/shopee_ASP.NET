using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using csdlnc_shopee.Models;

namespace csdlnc_shopee.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TAIKHOANDANGNHAP account)
        {
            shopeeEntities3 db = new shopeeEntities3();

            TAIKHOANDANGNHAP acc = (from TK in db.TAIKHOANDANGNHAPs where (TK.TENDANGNHAP == account.TENDANGNHAP && TK.MATKHAU == account.MATKHAU) select TK).SingleOrDefault();
            if(acc != null)
            {
                Session["account"] = acc;
            }
            else  //nếu không có tài khoản
            {
                return Redirect("/Login");
            }
            return Redirect("/");
        }

       public ActionResult Logout()
       {
            Session["account"] = null;
            return Redirect("/");
       }
    }
}