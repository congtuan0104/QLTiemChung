using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class HSTiemChung_BUS
    {
        HSTiemChung_DAO hstc = new HSTiemChung_DAO();

        public List<HSTiemChung> LayDSHS(int MaKH)
        {
            return hstc.LayTatCaHSTCCuaKH_DB(MaKH);
        }

        public HSTiemChung LayThongTinTC(int MaHS)
        {
            return hstc.XemHSTiemChung_DB(MaHS);
        }

        public bool XoaHS(int maHS)
        {
            return hstc.XoaHSTC_DB(maHS);
        }
    }
}
