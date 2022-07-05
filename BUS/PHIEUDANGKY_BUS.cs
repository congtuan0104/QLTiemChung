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

        public bool XoaPhieuDangKy(PHIEUDANGKY pdk_cu)
        {
            return pdk.xoaPhieuDangKy(pdk_cu);
        }

        public bool XoaPhieuDangKy_1NV(string manv)
        {
            return pdk.xoaPhieuDangKy_1NV(manv);
        }
        public bool XoaTatCaPhieuDangKy()
        {
            return pdk.xoaTatCaPhieuDangKy();
        }

        public bool ThemPhieuDangKy(PHIEUDANGKY pdk_moi)
        {
            return pdk.themPhieuDangKy(pdk_moi);
        }

        public List<PHIEUDANGKY> KiemTraTonTai(PHIEUDANGKY pdk_cu)
        {
            return pdk.kiemTraTonTai(pdk_cu);
        }
    }
}
