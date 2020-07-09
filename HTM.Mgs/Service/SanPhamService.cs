using HTM.Mgs.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTM.Mgs.Service
{
    public class SanPhamService : BaseService<SanPham, HTMDb>
    {
        public IEnumerable<SanPham> DSSanPham()
        {
            var list = dbContext.SanPhams.Where(x => x.DaXoa == false && x.DaNhapKho == true && x.TrangThai == true).AsQueryable();
            return list.OrderBy(x => x.SanPhamId);
        }
        public IPagedList<SanPham> GetListSanPham(string MaSanPham, string TenSanPham, int PageCurrent, int PageSize, int? TheLoaiId)
        {

            var list = dbContext.SanPhams.Where(x => x.DaXoa == false && x.DaNhapKho == true).AsEnumerable();
            if (TheLoaiId.HasValue)
            {
                list = list.Where(x => x.TheLoaiId == TheLoaiId);
            }
            if (!string.IsNullOrEmpty(TenSanPham))
            {
                list = list.Where(x => x.TenSanPham.Contains(TenSanPham)).AsEnumerable();
            }
            if (!string.IsNullOrEmpty(MaSanPham))
            {
                list = list.Where(x => x.MaSanPham.Contains(MaSanPham)).AsEnumerable();
            }
            return list.OrderByDescending(x => x.NgayTao).ToPagedList(PageCurrent, PageSize);
        }
        public IPagedList<SanPham> GetListSanPhamChoDuyet(string MaSanPham, string TenSanPham, int PageCurrent, int PageSize)
        {

            var list = dbContext.SanPhams.Where(x => x.DaXoa == false && x.DaPheDuyet == false && x.TrangThai == true && x.DaNhapKho == true).AsEnumerable();
            if (!string.IsNullOrEmpty(TenSanPham))
            {
                list = list.Where(x => x.TenSanPham.Contains(TenSanPham)).AsEnumerable();
            }
            if (!string.IsNullOrEmpty(MaSanPham))
            {
                list = list.Where(x => x.MaSanPham.Contains(MaSanPham)).AsEnumerable();
            }
            return list.OrderByDescending(x => x.NgayTao).ToPagedList(PageCurrent, PageSize);
        }
        public IPagedList<SanPham> GetListSanPhamChoNhapKho(string MaSanPham, string TenSanPham, int PageCurrent, int PageSize)
        {

            var list = dbContext.SanPhams.Where(x => x.DaXoa == false  && x.DaNhapKho == true && x.DaPheDuyet == false && x.SoLuong >= 0).AsEnumerable();
            if (!string.IsNullOrEmpty(TenSanPham))
            {
                list = list.Where(x => x.TenSanPham.Contains(TenSanPham)).AsEnumerable();
            }
            if (!string.IsNullOrEmpty(MaSanPham))
            {
                list = list.Where(x => x.MaSanPham.Contains(MaSanPham)).AsEnumerable();
            }
            return list.OrderByDescending(x => x.NgayTao).ToPagedList(PageCurrent, PageSize);
        }
 
        public IPagedList<SanPham> GetListSanPhamHetHang(string MaSanPham, string TenSanPham, int PageCurrent, int PageSize)
        {

            var list = dbContext.SanPhams.Where(x => x.DaXoa == false && x.DaNhapKho == true && x.SoLuong <= 0).AsEnumerable();
            if (!string.IsNullOrEmpty(TenSanPham))
            {
                list = list.Where(x => x.TenSanPham.Contains(TenSanPham)).AsEnumerable();
            }
            if (!string.IsNullOrEmpty(MaSanPham))
            {
                list = list.Where(x => x.MaSanPham.Contains(MaSanPham)).AsEnumerable();
            }
            return list.OrderByDescending(x => x.NgayTao).ToPagedList(PageCurrent, PageSize);
        }
        public SanPham InsertOrUpdate(SanPham sanPham)
        {
            if (sanPham == null) return null;
            try
            {

                if (sanPham.SanPhamId > 0)
                {
                    var data = FindByKey(sanPham.SanPhamId);
                    data.TenSanPham = sanPham.TenSanPham;
                    data.TieuDe = sanPham.TieuDe;
                    data.MoTa = sanPham.MoTa;
                    data.Anh = sanPham.Anh;
                    data.Gia = sanPham.Gia;
                    data.SoLuong = sanPham.SoLuong;
                    data.TheLoaiId = sanPham.TheLoaiId;
                    data.ChiTiet = sanPham.ChiTiet;
                    data.DaPheDuyet = false;
                    Update(data);
                    return data;
                }
                else
                {
                  
                    Insert(sanPham);
                    return sanPham;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public SanPham FindByKeys(object SanPhamId)
        {
            SanPham sp = new SanPham();
            if (SanPhamId != null)
            {
                sp = FindByKey(SanPhamId);
            }
            return sp;
        }
        public IPagedList<SanPham> GetListSanPhamDaXoa(string TenSanPham, string MaSanPham, int PageCurrent, int PageSize)
        {

            var list = dbContext.SanPhams.Where(x => x.DaXoa == true).AsEnumerable();
            if (!string.IsNullOrEmpty(TenSanPham))
            {
                list = list.Where(x => x.TenSanPham.Contains(TenSanPham)).AsEnumerable();
            }
            if (!string.IsNullOrEmpty(MaSanPham))
            {
                list = list.Where(x => x.MaSanPham.Contains(MaSanPham)).AsEnumerable();
            }
            return list.OrderByDescending(x => x.NgayTao).ToPagedList(PageCurrent, PageSize);
        }
        
        
        
    }
}
