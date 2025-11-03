using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTWeb10_giaquoc.Models;
using System.Data.Entity;
namespace LTWeb10_giaquoc.Controllers
{
    public class HomeController : Controller
    {
        DuLieu data = new DuLieu();
        public ActionResult Index()
        {
            List<sach> dsSach = data.saches.OrderByDescending(s => s.ngaycapnhat).Take(5).ToList();
            return View(dsSach);
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

        public ActionResult DSMenu_ChuDe()
        {
            List<chude> dsCD = data.chudes.Take(10).ToList();
            return PartialView(dsCD);
        }


        public ActionResult DSMenu_NXB()
        {
            var dsnxb = data.nhaxuatbans.ToList();
            return PartialView(dsnxb);
        }
        public ActionResult HTDanhSachTheoChuDe(int id)
        {
            var chude = data.chudes.SingleOrDefault(c => c.macd == id);
            if (chude == null)
            {
                return null;
            }

            var sachtheocd = data.saches.Where(s => s.macd == id).OrderBy(td => td.giaban).ToList();
            ViewBag.TenChuDe = chude.tencd;
            return View(sachtheocd);
        }
        public ActionResult HTDanhSachTheoNXB(int id)
        {
            var nxb = data.nhaxuatbans.SingleOrDefault(x => x.manxb == id);
            if (nxb == null) return HttpNotFound();

            var sachTheoNXB = data.saches.Where(s => s.manxb == id).ToList();
            ViewBag.TenNXB = nxb.tennxb;

            return View(sachTheoNXB);
        }

        public ActionResult Details(int id)
        {
            var sach = data.saches.Include("thamgias.tacgia").SingleOrDefault(s => s.masach == id);
            if (sach == null)
            {
                return null;
            }

            ViewBag.SachCungChuDe = data.saches.Where(s => s.macd == sach.macd && s.masach != id).Take(4).ToList();

            ViewBag.SachCungNXB = data.saches.Where(s => s.manxb == sach.manxb && s.masach != id).Take(4).ToList();

            return View(sach);
        }

        public ActionResult TimKiemNangCao()
        {
            ViewBag.DanhSachChuDe = data.chudes.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult TimKiemNangCao(string tensp, int? macd, string[] khoanggia)
        {
            var ketQua = data.saches.AsQueryable();
            if (!string.IsNullOrEmpty(tensp))
                ketQua = ketQua.Where(s => s.tensach.Contains(tensp));

            if (macd.HasValue && macd.Value > 0)
                ketQua = ketQua.Where(s => s.macd == macd.Value);

            if(khoanggia != null && khoanggia.Length>0)
            {
                var dsTheoGia = new List<sach>();
                foreach(var kg in khoanggia)
                {
                    switch (kg)
                    {
                        case "0-10000":
                            dsTheoGia.AddRange(ketQua.Where(s => s.giaban >= 0 && s.giaban <= 10000).ToList());
                            break;
                        case "11000-20000":
                            dsTheoGia.AddRange(ketQua.Where(s => s.giaban >= 11000 && s.giaban <= 20000).ToList());
                            break;
                        case "21000-40000":
                            dsTheoGia.AddRange(ketQua.Where(s => s.giaban >= 21000 && s.giaban <= 40000).ToList());
                            break;
                        case "40000+":
                            dsTheoGia.AddRange(ketQua.Where(s => s.giaban >= 40000).ToList());
                            break;
                    }
                }
                ketQua = dsTheoGia.AsQueryable().Distinct();
            }
            ViewBag.DanhSachChuDe = data.chudes.ToList();
            return View(ketQua.ToList());
        }
    }
}