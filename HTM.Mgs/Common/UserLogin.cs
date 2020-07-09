using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTM.Mgs.Common
{
    [Serializable]
    public class UserLogin
    {
        public int? UserID { set; get; }
        public string UserName { set; get; }
        public string NhomQuyenSuDungID { set; get; }
        public string Image { set; get; }
        public string Email { set; get; }
        public string Name { set; get; }
        public double? GioiHan { get; set; }
        public int? SoLuong { get; set; }
        public double? Gia { get; set; }

    }
}
