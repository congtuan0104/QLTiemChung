using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class CTPhieuDatMua_BUS
    {
        CTPhieuDatMua_DAO CTPDM = new CTPhieuDatMua_DAO();
        public List<CTPhieuDatMua> XemChiTietPhieu(int Maphieu)
        {
            return CTPDM.XemChiTietPhieu_DB(Maphieu);
        }

        public bool ThemChiTietPhieuDatMuaVaccine(CTPhieuDatMua ct)
        {
            return CTPDM.ThemChiTietPhieuDatMuaVaccine_DB(ct);
        }

    }
}
