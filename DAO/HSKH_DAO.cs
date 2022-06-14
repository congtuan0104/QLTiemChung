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
    public class HSKH_DAO : DataAccess
    {
        List<HSKH> DS_HSKH = new List<HSKH>();
        
        public List<HSKH> LayToanBoHSKH_DB()
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select MaKH, HoTen, SDT, DiaChi, GioiTinh " +
                "from KHACHHANG WHERE DaXoa IS NULL";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            DS_HSKH.Clear();
            while (reader.Read())
            {
                HSKH hskh = new HSKH();
                hskh.MaKH = reader.GetInt32(0);
                hskh.TenKH = reader.GetString(1);
                hskh.SDT = reader.GetString(2);
                hskh.DiaChi = reader.GetString(3);
                hskh.GioiTinh = reader.GetString(4);
                DS_HSKH.Add(hskh);
            }
            reader.Close();
            return DS_HSKH;
        }

        public List<HSKH> TraCuuKH_DB(string TenKH, string Sdt)
        {
            MoKetNoi();
            string sql = "select MaKH, HoTen, SDT, DiaChi, GioiTinh " +
                "from KHACHHANG WHERE DaXoa IS NULL AND" +
                " HoTen LIKE '" + TenKH + "%' AND SDT LIKE '" + Sdt + "%'";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            DS_HSKH.Clear();
            while (reader.Read())
            {
                HSKH hskh = new HSKH();
                hskh.MaKH = reader.GetInt32(0);
                hskh.TenKH = reader.GetString(1);
                hskh.SDT = reader.GetString(2);
                hskh.DiaChi = reader.GetString(3);
                hskh.GioiTinh = reader.GetString(4);
                DS_HSKH.Add(hskh);
            }
            reader.Close();
            return DS_HSKH;
        }

        public HSKH XemKhachHang_DB(int makh)
        {          
            MoKetNoi();
            string sql = "select MaKH, HoTen, SDT, DiaChi, GioiTinh, NgaySinh" +
                " from KHACHHANG WHERE DaXoa IS NULL AND MaKH = " + makh;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            HSKH kh = new HSKH();
            if (reader.Read())
            {                
                kh.MaKH = reader.GetInt32(0);
                kh.TenKH = reader.GetString(1);
                kh.SDT = reader.GetString(2);
                kh.DiaChi = reader.GetString(3);
                kh.GioiTinh = reader.GetString(4);
                kh.NgaySinh = reader.GetDateTime(5);
                reader.Close();
                return kh;
            }

            reader.Close();
            return null;
        }

        public bool ThemKhachHang_DB(HSKH KH)
        {

            MoKetNoi();
            string sql = "insert into KHACHHANG(HoTen, DiaChi, NgaySinh, GioiTinh, SDT)" +
                " values(@tenkh, @diachi, @ngaysinh, @gioitinh, @sdt)";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;

            command.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = KH.TenKH;
            command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = KH.DiaChi;
            command.Parameters.Add("@ngaysinh", SqlDbType.Date).Value = KH.NgaySinh;
            command.Parameters.Add("@gioitinh", SqlDbType.NVarChar).Value = KH.GioiTinh;
            command.Parameters.Add("@sdt", SqlDbType.Char).Value = KH.SDT;

            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }


        public bool XoaKhachHang_DB(int MaKH)
        {
            MoKetNoi();
            string sql = "update KHACHHANG set DaXoa = GETDATE()" +
                " where MaKH = " + MaKH;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
    }


}

