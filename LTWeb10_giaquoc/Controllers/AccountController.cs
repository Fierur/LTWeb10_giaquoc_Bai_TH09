using LTWeb10_giaquoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb10_giaquoc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        DuLieu data = new DuLieu();

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string tenDangNhap, string matKhau)
        {
            if(string.IsNullOrWhiteSpace(tenDangNhap))
            {
                ViewBag.ThongBao = "Tên đăng nhập không được để trống";
                return View();
            }
            if (string.IsNullOrEmpty(matKhau))
            {
                ViewBag.ThongBao = "Mật khẩu không được để trống";
                return View();
            }

            var khachHang = data.khachhangs.SingleOrDefault(kh => kh.taikhoan == tenDangNhap && kh.matkhau == matKhau);

            if(khachHang!=null)
            {
                ViewBag.ThongBao = "Đăng nhập không thành công";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                return View();
            }
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(string tenkh, string tendn, string mk, string retypemk, string email, string dc, string dt)
        {
            if(string.IsNullOrWhiteSpace(tendn))
            {
                ViewBag.ThongBao = "Tên đăng nhập không được để trống";
            }
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.ThongBao = "Email không được để trống";
            }
            if (string.IsNullOrEmpty(dt))
            {
                ViewBag.ThongBao = "Số điện thoại không được để trống";
            }
            if(mk != retypemk)
            {
                ViewBag.ThongBao = "Mật khẩu và nhập lại mật khẩu không đúng";
            }

            var checkEmail = data.khachhangs.SingleOrDefault(ce => ce.email == email);
            if(checkEmail != null)
            {
                ViewBag.ThongBao = "Email đã được sử dụng";
            }

            int maKHMoi = 1;
            if(data.khachhangs.Any())
            {
                maKHMoi = data.khachhangs.Max(kh => kh.makh) + 1;
            }

            khachhang khMoi = new khachhang
            {
                makh = maKHMoi,
                hoten = tenkh,
                taikhoan = tendn,
                matkhau =mk,
                email = email,
                dienthoai = dt,
                gioitinh = null,
                ngaysinh = null,
            };

            data.khachhangs.Add(khMoi);
            data.SaveChanges();

            ViewBag.ThongBao = "Đăng ký thành công! Vui lòng đăng nhập";
            return RedirectToAction("DangNhap");
        }

        public ActionResult DangXuat()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}