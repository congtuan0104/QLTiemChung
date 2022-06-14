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

        public HSKH LayThongTinKH(int MaKH)
        {
            return hsa.XemKhachHang_DB(MaKH);
        }

        public bool ThemKH(HSKH KH)
        {
            return hsa.ThemKhachHang_DB(KH);
        }

        public bool XoaKH(int MaKH)
        {
            return hsa.XoaKhachHang_DB(MaKH);
        }

        public bool KiemTraKHTonTai(string TenKH, string SDT)
        {
            if((hsa.TraCuuKH_DB(TenKH, SDT).Count == 0))
            {
                return false;
            }
            return true;
        }

    }
}

