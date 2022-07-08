using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class CTHSTC_BUS
    {
        CTHSTC_DAO cths = new CTHSTC_DAO();

        public List<CTHSTC> LayDSDV(int MaHS)
        {
            return cths.LayToanBoDVDK_DB(MaHS);
        }
        public bool ThemChiTietHSTC(int MaDV)
        {
            return cths.ThemChiTietHSTC_DB(MaDV);
        }
    }
}
