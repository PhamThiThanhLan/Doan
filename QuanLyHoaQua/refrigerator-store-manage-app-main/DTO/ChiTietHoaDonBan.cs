using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ChiTietHoaDonBan
    {
        public string MaHDB { get; set; }
        public string MaSanPham { get; set; }
        public float DonGia { get; set; }
        public float GiamGia { get; set; }
        public float ThanhTien { get; set; }
        public int SoLuongBan { get; set; }
    }
}
