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
        public List<PhieuDatMua> XEMDONDATHANG()
        {
            return DDH.XEMDONDATHANG();

        }
        public List<PhieuDatMua> TraCuuKH(string makh)
        {
            return DDH.TraCuuKH(makh);

        }

        public int XemTinhTrangPhieu(string MaPhieu)
        { 
            return DDH.XemTinhTrangPhieu(MaPhieu);

        }
        public void UpdateTinhTrangPhieu(string Maphieu, int TT)
        {
            DDH.UpdateTinhTrangPhieu(Maphieu, TT);
        }
        public void Insert_DonDatHang(DateTime NgayDat, Decimal TongTien)
        {
            DDH.Insert_DonDatHang(NgayDat, TongTien);
        }















    }
}
