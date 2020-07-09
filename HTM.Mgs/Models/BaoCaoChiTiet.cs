using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTM.Mgs.Models
{
     public class BaoCaoChiTiet : SanPham
    {

        public int? TenNguoiDung { get; set; }
        public int? NhapKhoId { get; set; }
        public int? BaoCaoId { get; set; }
        public string TenVanPhong { get; set; }
        public string TenPhieu { get; set; }
        public string DiaChiNhapHang { get; set; }      
        public double? DonGia { get; set; }      
        public double? TongTien { get; set; }      
    

    }
}
