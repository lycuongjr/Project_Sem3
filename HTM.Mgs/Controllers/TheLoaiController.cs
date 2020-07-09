using HTM.Mgs.Common;
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
    public class TheLoaiController : BaseController
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
        public PartialViewResult LoadDsTheLoai(string TenTheLoai, int? PageCurrent)
        {
            TheLoaiService service = new TheLoaiService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.TheLoai> theloai = service.GetDsTheLoai(TenTheLoai
                , pageNumber
                , 10
                );
            ViewBag.TenTheLoai = TenTheLoai;
            ViewBag.PageCurrent = PageCurrent;
            return PartialView("_DanhSachTheLoai", theloai);
        }
        public PartialViewResult _Form(int? Id)
        {
            var tl = new Models.TheLoai();
            if (Id.HasValue && Id != null)
            {
                var theloai = new TheLoaiService();
                tl = theloai.FindByKeys(Id);
            }
            return PartialView(tl);
        }
        [HttpPost]
        public ActionResult _Form(int? Id
           , string TenTheLoai
           , string TieuDe
           , string MoTa         
           )
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            TheLoaiService _tl = new TheLoaiService();
            Models.TheLoai tl = _tl.FindByKeys(Id);
            tl.TenTheLoai = TenTheLoai;
            tl.TieuDe = TieuDe;
            tl.MoTa = MoTa;
            if (Id.HasValue)
            {
                tl.NguoiSua = session.Name;
                tl.NgaySua = DateTime.Now;
                _tl.Update(tl);
                setAlert("Thông tin sản phẩm đã được cập nhập", "success");
            }
            else
            {
                tl.NgayTao = DateTime.Now;
                _tl.Insert(tl);
                setAlert("Thêm sản phẩm thành công", "success");
            }
            return RedirectToAction("Index");
        }
    }
}
