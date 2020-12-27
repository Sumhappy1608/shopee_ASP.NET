using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using csdlnc_shopee.Models;
namespace csdlnc_shopee.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        private shopeeEntities3 db = new shopeeEntities3();

        public ActionResult Index()
        {
            var account = Session["account"] as TAIKHOANDANGNHAP;
            List<DATHANG> dList = (from DATHANG in db.DATHANGs
                                   where DATHANG.NGUOIMUA == account.ID_THANHVIEN
                                   join DONHANG in db.DONHANGs on DATHANG.ID_DONHANG equals DONHANG.ID_DONHANG
                                   select DATHANG).ToList();
            return View(dList);
        }
        public ActionResult CheckoutOne(string productID)
        {
            List<DONVIVANCHUYEN> dvvc = db.DONVIVANCHUYENs.ToList();
            var account = Session["account"] as TAIKHOANDANGNHAP;
            List<VOUCHER_NGUOIDUNG> voucher = (from user_voucher in db.VOUCHER_NGUOIDUNG
                                               where user_voucher.ID_NGUOIMUA == account.ID_THANHVIEN && user_voucher.TRANGTHAIDUNG == 0
                                               select user_voucher).ToList();
            SelectList dvvcList = new SelectList(dvvc, "MADONVI", "TENDONVI");
            SelectList voucherList = new SelectList(voucher, "MAVOUCHER", "MAVOUCHER");
            ViewBag.DVVCLIST = dvvcList;
            ViewBag.VOUCHERLIST = voucherList;
            HANGHOA product = db.HANGHOAs.Find(productID);
            return View(product);
        }
        [HttpPost]
        public ActionResult CheckoutProduct(string productID, string shipping, string voucherID)
        {
            var account = Session["account"] as TAIKHOANDANGNHAP;
            var newCheckout = "";
            try
            {
                const string chars = "0123456789";
                DATHANG toAdd = new DATHANG();
                DONHANG toAddDonHang = new DONHANG();

                var voucherInfo = (from system_voucher in db.VOUCHERs
                                   where system_voucher.MACODE == voucherID
                                   join loai_voucher in db.LOAIVOUCHERs
                                   on system_voucher.LOAIVOUCHER equals loai_voucher.MALOAIVOUCHER
                                   select new
                                   {
                                       mucgia = loai_voucher.MUCGIA,
                                       giamtoida = loai_voucher.GIAMTOIDA,
                                       uudai = loai_voucher.UUDAI
                                   }).SingleOrDefault();

                List<DATHANG> found;
                Random random = new Random();
                toAdd.NGUOIMUA = account.ID_THANHVIEN;
                do
                {
                    toAdd.ID_DONHANG = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
                    toAddDonHang.ID_DONHANG = toAdd.ID_DONHANG;
                    found = db.DATHANGs.Where(x => x.ID_DONHANG == toAdd.ID_DONHANG).ToList();
                    if (found.Count == 0) break;
                } while (toAdd.ID_DONHANG != "");
                toAdd.NGAYDAT = DateTime.Now;

                var currentItem = (from GH in db.GIOHANGs
                                   where GH.ID_NGUOIMUA == account.ID_THANHVIEN && GH.MAHANGHOA == productID
                                   join HH in db.HANGHOAs on GH.MAHANGHOA equals HH.MAHANGHOA
                                   select new
                                   {
                                       id_hh = HH.MAHANGHOA,
                                       gianhang = HH.MAGIANHANG,
                                       ten = HH.TENHANGHOA,
                                       giathanh = HH.GIATHANH,
                                       soluong = GH.SOLUONG
                                   }).SingleOrDefault();
                toAdd.TONGTIEN = currentItem.giathanh * currentItem.soluong;
                toAdd.GIANHANG = currentItem.gianhang;
                toAdd.MADVVC = shipping;
                toAddDonHang.MASANPHAM = currentItem.id_hh;
                toAddDonHang.SOLUONG = currentItem.soluong;
                toAddDonHang.DONGIA = currentItem.giathanh;
                db.DATHANGs.Add(toAdd);
                db.DONHANGs.Add(toAddDonHang);
                db.SaveChanges();
                newCheckout = toAdd.ID_DONHANG;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return RedirectToAction("Payment", "Checkout", new { billID = newCheckout, voucher = voucherID });
        }
        public ActionResult Payment(string billID, string voucherID)
        {

            DATHANG billInfo = (from bill in db.DATHANGs
                                where bill.ID_DONHANG == billID
                                select bill).SingleOrDefault();
            var voucherInfo = (from system_voucher in db.VOUCHERs
                               where system_voucher.MACODE == voucherID
                               join loai_voucher in db.LOAIVOUCHERs
                               on system_voucher.LOAIVOUCHER equals loai_voucher.MALOAIVOUCHER
                               select new
                               {
                                   mavoucher = system_voucher.MACODE,
                                   mucgia = loai_voucher.MUCGIA,
                                   giamtoida = loai_voucher.GIAMTOIDA,
                                   uudai = loai_voucher.UUDAI
                               }).SingleOrDefault();
            ViewBag.BILLINFO = billInfo;
            ViewBag.VOUCHERINFO = voucherInfo;
            return View();
        }
        [HttpPost]
        public ActionResult PaymentConfirm(string billID, string voucherID, string paymentMethod)
        {

            DATHANG dathang = db.DATHANGs.Find(billID);
            THANHTOAN found;
            DATHANG billInfo = (from bill in db.DATHANGs
                                where bill.ID_DONHANG == billID
                                select bill).SingleOrDefault();
            var voucherInfo = (from system_voucher in db.VOUCHERs
                               where system_voucher.MACODE == voucherID
                               join loai_voucher in db.LOAIVOUCHERs
                               on system_voucher.LOAIVOUCHER equals loai_voucher.MALOAIVOUCHER
                               select new
                               {
                                   mavoucher = system_voucher.MACODE,
                                   mucgia = loai_voucher.MUCGIA,
                                   giamtoida = loai_voucher.GIAMTOIDA,
                                   uudai = loai_voucher.UUDAI
                               }).SingleOrDefault();
            if (billInfo != null)
            {
                try
                {
                    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    Random random = new Random();
                    THANHTOAN toAdd = new THANHTOAN();
                    DONMUA toAddDonMua = new DONMUA();
                    THONGTINDONHANG toAddThongTinDonHang = new THONGTINDONHANG();
                    THONGTINVANCHUYEN toAddThongTinVanChuyen = new THONGTINVANCHUYEN();
                    toAdd.ID_DONHANG = billID;
                    toAddDonMua.MADVVC = dathang.MADVVC;
                    toAddDonMua.ID_DONHANG = dathang.ID_DONHANG;
                    toAddThongTinDonHang.ID_DONHANG = dathang.ID_DONHANG;
                    toAddThongTinDonHang.THOIGIAN = DateTime.Now;
                    toAddThongTinDonHang.TINHTRANG_DH = "Chờ xác nhận";
                    toAddThongTinVanChuyen.TINHTRANG_VC = "Người bán đang chuẩn bị đơn hàng";
                    toAddThongTinVanChuyen.THOIGIAN = DateTime.Now;
                    var total = billInfo.TONGTIEN;
                    toAdd.SOTIENTT = (voucherInfo != null && total - voucherInfo.mucgia > 0) ? total - Math.Min(total * voucherInfo.uudai, voucherInfo.giamtoida) : total;
                    toAdd.NGAYTHANHTOAN = DateTime.Now;
                    do
                    {
                        toAdd.SO_THANHTOAN = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
                        toAddThongTinVanChuyen.MADONVAN = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
                        found = db.THANHTOANs.Where(x => x.SO_THANHTOAN == toAdd.SO_THANHTOAN).SingleOrDefault();
                    } while (toAdd.SO_THANHTOAN == "" || toAddThongTinVanChuyen.MADONVAN == "" || found != null);
                    toAdd.UUDAI = voucherInfo.mavoucher;
                    toAdd.HOANTIEN = billInfo.TONGTIEN - toAdd.SOTIENTT;
                    toAdd.LOAITHANHTOAN = paymentMethod != "Thanh toán khi nhận hàng" ? "ONL" : "COD";
                    toAdd.LOAITTONLINE = toAdd.LOAITHANHTOAN == "COD" ? null : paymentMethod == "Ví Airpay" ? "VDT" : paymentMethod == "Thẻ tín dụng" ? "ATM" : "DEBIT";
                    db.THANHTOANs.Add(toAdd);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Success", "Checkout");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}