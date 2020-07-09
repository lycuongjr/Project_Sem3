using DataTables.AspNet.Core;
using HTM.Mgs.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTM.Mgs.Service
{
    public class ThongKeService : BaseService<BaoCao, HTMDb>
    {
        public IQueryable<BaoCao> DanhSach()
        {
            var ds = dbContext.BaoCaos.Where(x => x.TrangThai == true);
            return ds;
        }
        public IQueryable<BaoCao>DanhSachBaoCao(IDataTablesRequest request)
        {
            var danhsach = DanhSach();
            var order = request.Columns?.Where(x => x.Sort != null).FirstOrDefault();
            return danhsach.OrderByDescending(x => x.NgayTao);
        }
        public IPagedList<BaoCao> DanhSachPhanTrang(int pageNumber = 1, int pageSize = 10)
        {
            var danhsach = DanhSach();
            return danhsach.ToPagedList(pageNumber, pageSize);
        }
        public IQueryable<BaoCaoChiTiet> DSBaoCao()
        {
            var result = (from bc in dbContext.BaoCaos
                          join nk in dbContext.NhapKhoes on bc.NhapKhoId equals nk.NhapKhoId
                          join sp in dbContext.SanPhams on nk.SanPhamId equals sp.SanPhamId
                          where (bc.DaXoa != true)
                          select new BaoCaoChiTiet
                          {
                              TenSanPham = nk.TenSanPham,
                              DiaChiNhapHang = nk.DiaChiNhapHang,
                              MaSanPham = nk.MaNhapKho,
                              SoLuong = nk.SoLuong,
                              NgayTao = nk.NgayTao,
                              TongTien = nk.SoLuong * nk.DonGia,
                              SanPhamId = sp.SanPhamId,
                              NhapKhoId = nk.NhapKhoId,
                              BaoCaoId = bc.BaoCaoId
                          }).Distinct().AsQueryable<BaoCaoChiTiet>();
            return result;
        }
        public IQueryable<BaoCaoChiTiet> ListBaoCao(int? NhapKhoId, int? SanPhamId, IDataTablesRequest request)
        {

            var DSThongTinChiTiet = DSBaoCao().ToList();
            if (NhapKhoId.HasValue)
            {
                DSThongTinChiTiet = DSThongTinChiTiet.Where(x => x.NhapKhoId == NhapKhoId).ToList();
            }
            if (SanPhamId.HasValue)
            {
                DSThongTinChiTiet = DSThongTinChiTiet.Where(x => x.SanPhamId == SanPhamId).ToList();

            }
            var orderColumn = request.Columns?.Where(m => m.Sort != null).FirstOrDefault();
            return DSThongTinChiTiet.AsQueryable().OrderBy(m => m.BaoCaoId);
        }
      
    }
}
