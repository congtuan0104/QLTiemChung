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
        HSTiemChung_DAO hstc_DAO = new HSTiemChung_DAO();

        public List<HSTiemChung> LayDSHS(int MaKH)
        {
            return hstc_DAO.LayTatCaHSTCCuaKH_DB(MaKH);
        }

        public bool XoaHS(int maHS)
        {
            return hstc_DAO.XoaHSTC_DB(maHS);
        }
    }
}
