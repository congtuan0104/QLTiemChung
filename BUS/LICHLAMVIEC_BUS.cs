using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class LICHLAMVIEC_BUS
    {
        LICHLAMVIEC_DAO llv = new LICHLAMVIEC_DAO();

        public List<LICHLAMVIEC> layLichLamViec()
        {
            return llv.layToanBoLichLamViec_DB();
        }

        public List<LICHLAMVIEC> layLichLamViec_1NhanVien(string dieukien)
        {
            return llv.layLichLamViec_1_NhanVien_DB(dieukien);
        }

        public bool ThemLichLamViec(LICHLAMVIEC llv_moi)
        {
            return llv.themLichLamViec(llv_moi);
        }

        public bool XoaLichLamViec(LICHLAMVIEC llv_cu)
        {
            return llv.xoaLichLamViec(llv_cu);
        }

        public List<LICHLAMVIEC> KiemTraTonTai(LICHLAMVIEC llv_chon)
        {
            return llv.kiemTraTonTai(llv_chon);
        }
    }
}
