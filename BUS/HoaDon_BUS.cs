using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class HoaDon_BUS
    {
        HoaDon_DAO hdDSA = new HoaDon_DAO();
        public List<HoaDon> LayDSHoaDon()
        {
            return hdDSA.LayToanBoHoaDon_DB();
        }
        public HoaDon LayThongTinHoaDon(int MaHS)
        {
            return hdDSA.XemHoaDon_DB(MaHS);
        }
        public bool CapNhatHoaDon(int MaHS)
        {
            return hdDSA.CapNhatHoaDon(MaHS);
        }
        public bool ThemHoaDon(HoaDon Hdon,int MaHS)
        {
            return hdDSA.ThemHoaDon_DB(Hdon, MaHS);
        }
    }
}
