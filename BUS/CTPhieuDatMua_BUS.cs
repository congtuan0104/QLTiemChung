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
    { CTPhieuDatMua_DAO CTPDM = new CTPhieuDatMua_DAO();
        public List<CTPhieuDatMua> XEMCHITIETPHIEU(int Maphieu)
        {
            return CTPDM.XEMCHITIETPHIEU(Maphieu);
        }
    }
}
