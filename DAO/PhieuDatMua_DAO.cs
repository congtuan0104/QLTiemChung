using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;


namespace DAO
{
    public class PhieuDatMua_DAO : DataAccess
    { List<CTPhieuDatMua> CT_PDM = new List<CTPhieuDatMua>();
        List<PhieuDatMua> DS_DDH = new List<PhieuDatMua>();
        public List<PhieuDatMua> LayDSDonDatHang_DB()
        {
            // Lấy danh sách hồ sơ tiêm chủng của một khách hàng
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT MaPhieu,MaKH,NgayDat, TinhTrang " +
                "FROM PHIEUDATMUAVACCINE Where DaXoa IS NULL ";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            DS_DDH.Clear();
            while (reader.Read())
            {
                PhieuDatMua PDM = new PhieuDatMua();
                PDM.MaPhieu = reader.GetInt32(0);
                PDM.MaKH = reader.GetInt32(1);
                PDM.NgayDat = reader.GetDateTime(2);
                PDM.TinhTrang = reader.GetInt32(3);
                DS_DDH.Add(PDM);
            }
            reader.Close();
            return DS_DDH;
        }


        public List<PhieuDatMua> TraCuuDDHCuaKH_DB(int MaKH, int TinhTrang)
        {
            MoKetNoi();
            string sql = "SELECT MaPhieu,MaKH,NgayDat, TinhTrang FROM PHIEUDATMUAVACCINE " +
                "Where DaXoa IS NULL and MaKH = " + MaKH;
            if (TinhTrang >= -1)
                sql = sql + " AND TinhTrang = "+ TinhTrang;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            DS_DDH.Clear();
            while (reader.Read())
            {
                PhieuDatMua PDM = new PhieuDatMua();
                PDM.MaPhieu = reader.GetInt32(0);
                PDM.MaKH = reader.GetInt32(1);
                PDM.NgayDat = reader.GetDateTime(2);
                PDM.TinhTrang = reader.GetInt32(3);

                DS_DDH.Add(PDM);
            }
            reader.Close();
            return DS_DDH;
        }

        public PhieuDatMua XemPhieuDatMua_DB(int MaPhieu)
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT MaPhieu,MaKH,NgayDat, TinhTrang " +
                "FROM PHIEUDATMUAVACCINE Where MaPhieu = " + MaPhieu;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                PhieuDatMua PDM = new PhieuDatMua();
                PDM.MaPhieu = reader.GetInt32(0);
                PDM.MaKH = reader.GetInt32(1);
                PDM.NgayDat = reader.GetDateTime(2);
                PDM.TinhTrang = reader.GetInt32(3);
                reader.Close();
                return PDM;
            }
            reader.Close();
            return null;

        }


        //  ham update tinh trang của 1 phiếu sau khi ta nhan nut duyet hay ko duyet
        public bool CapNhatTinhTrangPhieu_DB(int MaPhieu, int TinhTrang)
        {
            MoKetNoi();
            string sql = "update PHIEUDATMUAVACCINE set TinhTrang = " + TinhTrang +
                " where MaPhieu = " + MaPhieu;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }

        public bool ThemDonDatHang_DB(DonDatHang ddh)
        {
            MoKetNoi();
            
        
            string sql = "insert into DonDatHang(TongTien,NgayDat)" +
               " values(@tongtien,'" + ddh.Ngaydat.ToString("yyyy-MM-dd") + "')";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            
           
          
            command.Parameters.Add("@tongtien", SqlDbType.Decimal).Value = ddh.TongTien;

            int kq = command.ExecuteNonQuery();
            
                return kq > 0;

        }


        public bool XoaDonDatHang_DB(int maPhieu)
        {
            MoKetNoi();
            string sql = "update PHIEUDATMUAVACCINE set DaXoa = GETDATE()" +
                " where MaPhieu = " + maPhieu;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
        public bool ThemPhieuDatMuaVaccine_DB(PhieuDatMua pdm)
        {

            MoKetNoi();
            string sql = "insert into PHIEUDATMUAVACCINE(MaKH,TinhTrang,NgayDat) values" +
                " (@Makh,0,@Ngaydat)";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;

            command.Parameters.Add("@Makh", SqlDbType.Int).Value = pdm.MaKH;
            command.Parameters.Add("@Ngaydat", SqlDbType.Date).Value = pdm.NgayDat;


            int kq = command.ExecuteNonQuery();

            return kq > 0;
        }

        public List<PhieuDatMua> LayDSDonDatHangTheoTinhTrang_DB(int TinhTrang)
        {
            
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT MaPhieu,MaKH,NgayDat, TinhTrang " +
                "FROM PHIEUDATMUAVACCINE Where DaXoa IS NULL  and TinhTrang="+TinhTrang;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            DS_DDH.Clear();
            while (reader.Read())
            {
                PhieuDatMua PDM = new PhieuDatMua();
                PDM.MaPhieu = reader.GetInt32(0);
                PDM.MaKH = reader.GetInt32(1);
                PDM.NgayDat = reader.GetDateTime(2);
                PDM.TinhTrang = reader.GetInt32(3);
                DS_DDH.Add(PDM);
            }
            reader.Close();
            return DS_DDH;
        }
        

    }
}
