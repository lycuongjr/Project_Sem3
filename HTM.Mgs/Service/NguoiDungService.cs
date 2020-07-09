using DataTables.AspNet.Core;
using HTM.Mgs.Common;
using HTM.Mgs.Models;
using HTM.Mgs.UI;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTM.Mgs.Service
{
    public class NguoiDungService : BaseService<NguoiDung, HTMDb>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StudentCode">Mã sinh viên </param>
        /// <param name="FullName">Họ tên</param>
        /// <param name="DepartmentID">Khoa đang theo học</param>
        /// <param name="PageCurrent">Trang hiện tại</param>
        /// <param name="PageSize">Số bản ghi hiện tại</param>
        /// <returns></returns>
        /// 
        #region Xem danh sách sinh viên
        public IEnumerable<NguoiDung> DSNguoiDung()
        {
            var list = dbContext.NguoiDungs.Where(x => x.TrangThai == true && x.DaXoa == false);
            return list;
        }
        public IPagedList<NguoiDung> GetStudents(string MaNhanVien, string HoVaTen, int PageCurrent, int PageSize)
        {

            var list = dbContext.NguoiDungs.Where(x => x.DaXoa == false).AsEnumerable();
            if (!string.IsNullOrEmpty(MaNhanVien))
            {
                list = list.Where(x => x.MaNhanVien.Contains(MaNhanVien)).AsEnumerable();
            }
            if (!string.IsNullOrEmpty(HoVaTen))
            {
                list = list.Where(x => x.HoVaTen.Contains(HoVaTen)).AsEnumerable();
            }
            return list.OrderByDescending(x => x.NgaySinh).ToPagedList(PageCurrent, PageSize);
        }

        public NguoiDung InsertOrUpdate(NguoiDung nguoiDung)
        {
            if (nguoiDung == null) return null;
            try
            {

                if (nguoiDung.NguoiDungID > 0)
                {
                    var data = FindByKey(nguoiDung.NguoiDungID);
                    data.HoVaTen = nguoiDung.HoVaTen;
                    data.TenDangNhap = nguoiDung.TenDangNhap;
                    data.ChucVuId = nguoiDung.ChucVuId;
                    data.VanPhongId = nguoiDung.VanPhongId;
                    data.DienThoai = nguoiDung.DienThoai;
                    data.ChucVu = nguoiDung.ChucVu;
                    data.Email = nguoiDung.Email;
                    data.TrangThai = nguoiDung.TrangThai;
                    Update(data);
                    return data;
                }
                else
                {
                    nguoiDung.MatKhau = EncryptHelper.EncryptMD5(nguoiDung.MatKhau);
                    Insert(nguoiDung);
                    return nguoiDung;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public NguoiDung FindByKeys(object NguoiDungId)
        {
            NguoiDung student = new NguoiDung();
            if (NguoiDungId != null)
            {
                student = FindByKey(NguoiDungId);
            }
            return student;
        }
        public List<string> GetNhomNguoiDUng(string tendangnhap)
        {
            var nguoiDung = dbContext.NguoiDungs.Single(x => x.TenDangNhap == tendangnhap);
            var data = (from a in dbContext.NhomNguoiDungs
                        join b in dbContext.ChucNangNguoiDungs on a.ChucNangNguoiDungID equals b.ChucNangNguoiDungID
                        join c in dbContext.NhomQuyenSuDungs on a.NhomQuyenSuDungID equals c.NhomQuyenSuDungID
                        where b.ChucNangNguoiDungID == nguoiDung.NhomQuyenSuDungID
                        select new
                        {
                            TenQuyenID = a.ChucNangNguoiDungID,
                            NhomQuyenID = a.NhomQuyenSuDungID
                        }).AsEnumerable().Select(x => new NhomNguoiDung()
                        {
                            ChucNangNguoiDungID = x.NhomQuyenID,
                            NhomQuyenSuDungID = x.NhomQuyenID
                        });

            return data.Select(x => x.NhomQuyenSuDungID).ToList();

        }
        public int Login(string username, string password, bool isLoginAdmin)
        {
            var result = dbContext.NguoiDungs.SingleOrDefault(x => x.TenDangNhap == username);
            if (result == null)
            {
                return 0;
            }
            if (isLoginAdmin == true)
            {

                if (result.NhomQuyenSuDungID == CommonConstants.ADMIN_GROUP
                || result.NhomQuyenSuDungID == CommonConstants.GIAM_DOC_GROUP)
                {
                    if (result.TrangThai == true)
                    {
                        return 1;
                    }
                    else
                    {
                        if (result.MatKhau == password)
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
                    }
                }
                else
             if (result.NhomQuyenSuDungID == CommonConstants.MOD_GROUP)
                    if (result.TrangThai == true)
                    {
                        return 1;
                    }
                    else
                    {
                        if (result.MatKhau == password)
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
                    }
                else if (result.NhomQuyenSuDungID == CommonConstants.EMPLOYEE)
                    if (result.TrangThai == true)
                    {
                        return 1;
                    }
                    else
                    {
                        if (result.MatKhau == password)
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
                    }
                else if (result.NhomQuyenSuDungID == CommonConstants.MEMBER_GROUP)
                    if (result.TrangThai == true)
                    {
                        return 1;
                    }
                    else
                    {
                        if (result.MatKhau == password)
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
                    }
            }
            

            return -3;
        }



        public NguoiDung GetById(string userName)
        {
            return dbContext.NguoiDungs.SingleOrDefault(x => x.TenDangNhap == userName);
        }
        #endregion
        #region Xem danh sách sinh viên đã xóa
        public IPagedList<NguoiDung> GetDanhSachSVDaXoa(string MaNhanVien, string HoVaTen, int PageCurrent, int PageSize)
        {

            var list = dbContext.NguoiDungs.Where(x => x.DaXoa == true).AsEnumerable();
            if (!string.IsNullOrEmpty(MaNhanVien))
            {
                list = list.Where(x => x.MaNhanVien.Contains(MaNhanVien)).AsEnumerable();
            }
            if (!string.IsNullOrEmpty(HoVaTen))
            {
                list = list.Where(x => x.HoVaTen.Contains(HoVaTen)).AsEnumerable();
            }
            return list.OrderByDescending(x => x.NgaySinh).ToPagedList(PageCurrent, PageSize);
        }
        public bool CheckTrungTenTaiKhoan(string TenTaiKhoan, int? ndID)
        {
            if (ndID == null)
            {
                var listND = dbContext.NguoiDungs.ToList();
                bool flag = true;
                foreach (var item in listND)
                {
                    if (item.TenDangNhap.ToLower().Equals(TenTaiKhoan.ToLower()))
                    {
                        flag = false;
                    }
                }
                return flag;
            }
            return true;
        }
        #endregion

    }
}
