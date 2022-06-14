using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class PHIEUDANGKY_BUS
    {
        PHIEUDANGKY_DAO pdk = new PHIEUDANGKY_DAO();

        public List<PHIEUDANGKY> layPhieuDangKy()
        {
            return pdk.layToanBoPhieuDangKy_DB();
        }

        public List<PHIEUDANGKY> layPhieuDangKy_1NhanVien(string dieukien)
        {
            return pdk.layPhieuDangKy_1_NhanVien_DB(dieukien);
        }
    }
}
