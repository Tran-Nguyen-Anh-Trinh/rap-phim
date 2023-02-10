using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRapPhim.DTO
{
    class CBBPhong
    {
        public string idGheNgoi { get; set; }
        public string TenPhong { get; set; }
        public string TrangThai { get; set; }
        public override string ToString()
        {
            return TenPhong + ": " + TrangThai + " (ghế đã mua)";
        }
    }
}
