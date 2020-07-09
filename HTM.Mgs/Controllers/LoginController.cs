using HTM.Mgs.Common;
using HTM.Mgs.Models;
using HTM.Mgs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HTM.Mgs.Controllers
{
   public class LoginController : Controller
    {
        public ActionResult Login(LoginModel loginModel)
        {
            //check validate
            if (ModelState.IsValid)
            {
                var _nguoiDung = new NguoiDungService();
                var result = _nguoiDung.Login(loginModel.UserName, Encryptor.MD5Hash(loginModel.Password), true);

                if (result == 1)
                {
                    var user = _nguoiDung.GetById(loginModel.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.TenDangNhap;
                    userSession.UserID = user.NguoiDungID;
                    userSession.NhomQuyenSuDungID = user.NhomQuyenSuDungID;
                    userSession.Image = user.AnhDaiDien;
                    userSession.Email = user.Email;
                    userSession.Name = user.HoVaTen;
                    userSession.GioiHan = user.GioiHan;
                    userSession.Gia = user.YeuCauNguoiDung.SanPham.Gia;
                    userSession.SoLuong = user.YeuCauNguoiDung.SoLuong;
                    var listCredentials = _nguoiDung.GetNhomNguoiDUng(loginModel.UserName);
                    Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "TrangChu"); //Action, controller
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");

                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị tạm khóa");

                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản không có quyền");

                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");

                }



            }

            return View("Login");   // index
        }
    }
}
