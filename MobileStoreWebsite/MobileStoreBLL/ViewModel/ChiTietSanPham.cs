using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStoreBLL.ViewModel
{
    public class ChiTietSanPham
    {
        public SanPham SanPham { get; set; }
        public List<BinhLuan> DSBinhLuan { get; set; }
    }
}
