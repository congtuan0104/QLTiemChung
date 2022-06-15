using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HSTiemChung
    {
        public int MaHS { get; set; }
        public int MaTT { get; set; }
        public int MaKH { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayLapHS { get; set; }
        public DateTime NgayHenTiem { get; set; }
        public string KQ_KhamSangLoc { get; set; }
        public string KQ_KhamSauTiem { get; set; }

        public bool CapNhatHSTC_DB(HSTiemChung hstc)
        {
            throw new NotImplementedException();
        }
    }
}
