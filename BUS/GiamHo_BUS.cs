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

        public bool ThemNGH(GiamHo GH)
        {
            return gha.ThemNguoiGiamHo_DB(GH);
        }
    }
}
