using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class PhieuDatMua_BUS
    {
        PhieuDatMua_DAO DDH = new PhieuDatMua_DAO();
        
        public List<PhieuDatMua> LayDSDonDatHang()
        {
            return DDH.LayDSDonDatHang_DB();

        }
        public List<PhieuDatMua> TraCuuDDHCuaKH(int makh, int tinhtrang)
        {
            return DDH.TraCuuDDHCuaKH_DB(makh, tinhtrang);

        }

        public PhieuDatMua XemPhieuDatMua(int MaPhieu)
        { 
            return DDH.XemPhieuDatMua_DB(MaPhieu);

        }

        public bool CapNhatTinhTrangPhieu(int Maphieu, int TinhTrang)
        {
            return DDH.CapNhatTinhTrangPhieu_DB(Maphieu, TinhTrang);
        }

        public void ThemDonDatHang(DonDatHang DD)
        {
            DDH.ThemDonDatHang_DB(DD);
        }

        public bool XoaDonDatHang(int MaPhieu)
        {
            return DDH.XoaDonDatHang_DB(MaPhieu);
        }
        public List<PhieuDatMua> LayDSDonDatHangTheoTinhTrang(int TinhTrang)
        {
           return DDH.LayDSDonDatHangTheoTinhTrang_DB(TinhTrang);
        }
        public bool ThemPhieuDatMuaVaccine(PhieuDatMua pdm)
        {
            return DDH.ThemPhieuDatMuaVaccine_DB(pdm);
        }
        public bool ThemChiTietPhieuDatMuaVaccine(CTPhieuDatMua CT)
        {
            return DDH.ThemChiTietPhieuDatMuaVaccine_DB(CT);
        }















    }
}
