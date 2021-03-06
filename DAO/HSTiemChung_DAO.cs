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
    public class HSTiemChung_DAO : DataAccess
    {
        public List<HSTiemChung> LayTatCaHSTCCuaKH_DB(int MaKH)
        {
            // Lấy danh sách hồ sơ tiêm chủng của một khách hàng
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select MaHS, MaTT, MaKH, MaNV, " +
                "NgayDangKy, NgayTiem, KQ_KhamTruocTiem, KQ_KhamSauTiem" +
                " from HOSOTIEMCHUNG WHERE DaXoa IS NULL AND MaKH = " + MaKH;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            List<HSTiemChung> DS_HSTC = new List<HSTiemChung>();
            while (reader.Read())
            {
                HSTiemChung hstc = new HSTiemChung();
                hstc.MaHS = reader.GetInt32(0);
                hstc.MaTT = reader.GetInt32(1);
                hstc.MaKH = reader.GetInt32(2);
                hstc.MaNV = reader.GetInt32(3);
                hstc.NgayLapHS = reader.GetDateTime(4);
                hstc.NgayHenTiem = reader.GetDateTime(5);
                hstc.KQ_KhamSangLoc = reader != null ? reader.GetString(6) : "";
                hstc.KQ_KhamSauTiem = reader != null ? reader.GetString(7) : "";
                DS_HSTC.Add(hstc);
            }
            reader.Close();
            return DS_HSTC;
        }
        
        public HSTiemChung XemHSTiemChung_DB(int MaHS)
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select MaHS, MaTT, MaKH, MaNV, " +
                "NgayDangKy, NgayTiem, KQ_KhamTruocTiem, KQ_KhamSauTiem" +
                " from HOSOTIEMCHUNG WHERE DaXoa IS NULL AND MaHS = " + MaHS;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            HSTiemChung hstc = new HSTiemChung();
            if (reader.Read())
            {                
                hstc.MaHS = reader.GetInt32(0);
                hstc.MaTT = reader.GetInt32(1);
                hstc.MaKH = reader.GetInt32(2);
                hstc.MaNV = reader.GetInt32(3);
                hstc.NgayLapHS = reader.GetDateTime(4);
                hstc.NgayHenTiem = reader.GetDateTime(5);
                hstc.KQ_KhamSangLoc = reader.GetString(6);
                hstc.KQ_KhamSauTiem = reader.GetString(7);
            }

            reader.Close();
            return hstc;
        }
        public bool CapNhatHoSoTiemChung_DB(HSTiemChung HS)
        {
            MoKetNoi();
            string sql = "update HOSOTIEMCHUNG " +
                "set NgayTiem = @ngayhen, KQ_KhamTruocTiem = @kq1, " +
                "KQ_KhamSauTiem = @kq2 WHERE MaHS = @mahs";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;

            command.Parameters.Add("@ngayhen", SqlDbType.Date).Value = HS.NgayHenTiem;
            command.Parameters.Add("@kq1", SqlDbType.NVarChar).Value = HS.KQ_KhamSangLoc;
            command.Parameters.Add("@kq2", SqlDbType.NVarChar).Value = HS.KQ_KhamSauTiem;
            command.Parameters.Add("@mahs", SqlDbType.Int).Value = HS.MaHS;
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
        public bool XoaHSTC_DB(int maHS)
        {
            MoKetNoi();
            string sql = "update HOSOTIEMCHUNG set DaXoa = GETDATE()" +
                " where MaHS = " + maHS;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
        public bool ThemHSTC_DB(HSTiemChung HSTC)
        {

            MoKetNoi();
            string sql = "insert into HOSOTIEMCHUNG(MATT, MAKH, MANV, NGAYDANGKY, NGAYTIEM, KQ_KhamTruocTiem, KQ_KhamSauTiem)" +
                " values(@matt, @makh, @tkID, @ngaydangky, @ngaytiem, N'', N'')";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;

            command.Parameters.Add("@matt", SqlDbType.Int).Value = HSTC.MaTT;
            command.Parameters.Add("@makh", SqlDbType.Int).Value = HSTC.MaKH;
            command.Parameters.Add("@tkID", SqlDbType.Int).Value = TaiKhoan.UserID ;
            command.Parameters.Add("@ngaydangky", SqlDbType.Date).Value = HSTC.NgayLapHS;
            command.Parameters.Add("@ngaytiem", SqlDbType.Date).Value = HSTC.NgayHenTiem;

            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
    }
}
