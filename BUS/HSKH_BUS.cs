using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class HSKH_BUS
    {
        HSKH_DAO hsa = new HSKH_DAO();      

        public List<HSKH> LayDSKH()
        {
            return hsa.LayToanBoHSKH_DB();
        }


        public List<HSKH> TraCuuKH(string TenKH, string Sdt)
        {
            return hsa.TraCuuKH_DB(TenKH, Sdt);
        }

    }
}

