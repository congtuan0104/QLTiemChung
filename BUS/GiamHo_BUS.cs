using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class GiamHo_BUS
    {
        GiamHo_DAO gha = new GiamHo_DAO();

        public GiamHo LayThongTinNGHCuaKH(int MaKH)
        {
            return gha.XemNguoiGiamHo_DB(MaKH);
        }

        public bool KiemTraKHCoNGH(int MaKH)
        {
            if (gha.XemNguoiGiamHo_DB(MaKH) == null)
                return false;
            return true;
        }

        public bool ThemNGH(GiamHo GH)
        {
            return gha.ThemNguoiGiamHo_DB(GH);
        }

        public bool XoaNGH(int MaKH)
        {
            return gha.XoaNguoiGiamHo_DB(MaKH);
        }
    }
}
