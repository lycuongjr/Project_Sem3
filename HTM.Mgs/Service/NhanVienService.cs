using HTM.Mgs.Common;
using HTM.Mgs.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTM.Mgs.Service
{
   public class NhanVienService : BaseService<YeuCauNguoiDung, HTMDb>
    {
      
        public IPagedList<YeuCauNguoiDung> GetListYeuCauNguoiDung( int PageCurrent, int PageSize)
        {

            var list = dbContext.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == false && x.TrangThai == false).AsEnumerable();    
            return list.OrderByDescending(x => x.NgayTao).ToPagedList(PageCurrent, PageSize);
        }
        public IPagedList<YeuCauNguoiDung> GetListYeuCauNguoiDungQuanTri(int PageCurrent, int PageSize)
        {

            var list = dbContext.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == false && x.TrangThai == true).AsEnumerable();
            return list.OrderByDescending(x => x.NgayTao).ToPagedList(PageCurrent, PageSize);
        }
        public IPagedList<YeuCauNguoiDung> GetListYeuCauDaDuyet(int PageCurrent, int PageSize)
        {
           
            var list = dbContext.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == true && x.TrangThai == true ).AsEnumerable();
            return list.OrderByDescending(x => x.NgayTao).ToPagedList(PageCurrent, PageSize);
        }
        public YeuCauNguoiDung InsertOrUpdate(YeuCauNguoiDung yc)
        {
            if (yc == null) return null;
            try
            {

                if (yc.YeuCauNguoiDungId > 0)
                {
                    var data = FindByKey(yc.SanPhamId);
                    data.NoiDung = yc.NoiDung;
                    data.NguoiDungId = yc.NguoiDungId;
                    data.SanPhamId = yc.SanPhamId;
                    data.SoLuong = yc.SoLuong;
                    data.ThanhTien = yc.SoLuong * yc.SanPham.Gia;                     
                    Update(data);
                    return data;
                }
                else
                {
                    Insert(yc);
                    return yc;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public YeuCauNguoiDung FindByKeys(object Id)
        {
            YeuCauNguoiDung yc = new YeuCauNguoiDung();
            if (Id != null)
            {
                yc = FindByKey(Id);
            }
            return yc;
        }
    }
}
