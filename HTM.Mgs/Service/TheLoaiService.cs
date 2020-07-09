using HTM.Mgs.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTM.Mgs.Service
{
    public class TheLoaiService : BaseService<TheLoai, HTMDb>
    {
        public IEnumerable<TheLoai> DSTheLoai()
        {
            var list = dbContext.TheLoais.Where(x=>x.DaXoa == false).AsQueryable();           
            return list.OrderBy(x => x.TheLoadId);
        }
        public IEnumerable<TheLoai> DSTheLoai1(int? SanPhamId)
        {
            var list = dbContext.TheLoais.Where(x => x.DaXoa == false).AsQueryable();
            if (SanPhamId.HasValue)
            {
                list = list.Where(m => m.SanPhamId == SanPhamId).AsQueryable();
            }
            return list.OrderBy(x => x.TheLoadId);
        }
        public IPagedList<TheLoai> GetDsTheLoai(string TenTheLoai, int PageCurrent, int PageSize)
        {

            var list = dbContext.TheLoais.AsEnumerable();
            if (!string.IsNullOrEmpty(TenTheLoai))
            {
                list = list.Where(x => x.TenTheLoai.Contains(TenTheLoai)).AsEnumerable();
            }
            
            return list.OrderByDescending(x => x.NgayTao).ToPagedList(PageCurrent, PageSize);
        }
        public TheLoai InsertOrUpdate(TheLoai theloai)
        {
            if (theloai == null) return null;
            try
            {

                if (theloai.TheLoadId > 0)
                {
                    var data = FindByKey(theloai.TheLoadId);
                    data.TenTheLoai = theloai.TenTheLoai;
                    data.TieuDe = theloai.TieuDe;
                    data.MoTa = theloai.MoTa;                   
                    Update(data);
                    return data;
                }
                else
                {
                    
                    Insert(theloai);
                    return theloai;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public TheLoai FindByKeys(object TheLoaiId)
        {
            TheLoai theloai = new TheLoai();
            if (TheLoaiId != null)
            {
                theloai = FindByKey(TheLoaiId);
            }
            return theloai;
        }
    }
}
