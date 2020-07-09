using DataTables.AspNet.Core;
using HTM.Mgs.Models;
using HTM.Mgs.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HTM.Mgs.Controllers
{
    public class ThongKeController : Controller
    {
        public ActionResult Index()
        {
            HTMDb db = new HTMDb();
            var DSYeuCauTuNguoiDung = db.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == false && x.TrangThai == false).Count();
            var DSYeuCauDaDuyetTuNguoiDung = db.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == true && x.TrangThai == true).Count();
            var SanPhamChoDuyet = db.SanPhams.Where(x => x.DaXoa == false && x.DaPheDuyet == false && x.TrangThai == true && x.DaNhapKho == true).Count();
            var SanPhamChoDuyetTrongKho = db.SanPhams.Where(x => x.DaXoa == false && x.DaNhapKho == false && x.TrangThai == false).Count();
            ViewBag.DSYeuCauTuNguoiDung = DSYeuCauTuNguoiDung.ToString();
            ViewBag.DSYeuCauDaDuyetTuNguoiDung = DSYeuCauDaDuyetTuNguoiDung.ToString();
            ViewBag.SanPhamChoDuyet = SanPhamChoDuyet.ToString();
            ViewBag.SanPhamChoDuyetTrongKho = SanPhamChoDuyetTrongKho.ToString();
            return View();
        }
        public JsonResult _ThongTinBaoCao(int? NhapKhoId, int? SanPhamId, IDataTablesRequest request)
        {
            var pageNum = request.Start / request.Length + 1;          
            ThongKeService _thongke = new ThongKeService();
            var danhsach = _thongke.ListBaoCao(NhapKhoId, SanPhamId, request);
            var result = danhsach.ToPagedList(pageNum, request.Length);
            return Json(new
            {
                draw = request.Draw,
                data = result.Select(m => new
                {
                    m.BaoCaoId,
                    m.TenSanPham,
                    m.DiaChiNhapHang,
                    m.NgayTao,
                    m.SoLuong,
                    m.TongTien,                    
                }).ToList(),
                recordsTotal = result.TotalItemCount,
                recordsFiltered = result.TotalItemCount
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
