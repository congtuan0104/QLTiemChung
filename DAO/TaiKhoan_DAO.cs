using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class TaiKhoan_DAO : DataAccess
    {

        public bool XacThucTaiKhoan_DB(string username, string password)
        {
            MoKetNoi();
            string sql = "select TenTaiKhoan, VaiTro" +
                " from TaiKhoan WHERE TenTaiKhoan = '" + username + "' AND MatKhau = '" + password + "'";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            
            if (reader.Read())
            {
                TaiKhoan.Username = reader.GetString(0);
                TaiKhoan.Role = reader.GetString(1);
                reader.Close();
                return true;
            }
            return false;
        }

        public void LayThongTinTKNV_DB(string sdt)
        {
            MoKetNoi();
            string sql = "select MaNV, TenNV" +
                " from NHANVIEN WHERE SDT_NV = '" + sdt + "'";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();


            if (reader.Read())
            {
                TaiKhoan.UserID = reader.GetInt32(0);
                TaiKhoan.Name = reader.GetString(1);
                reader.Close();
            }
            return;
        }

        public void LayThongTinTKKH_DB(string sdt)
        {
            MoKetNoi();
            string sql = "select MaKH, HoTen" +
                " from KHACHHANG WHERE SDT = '" + sdt + "'";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();


            if (reader.Read())
            {
                TaiKhoan.UserID = reader.GetInt32(0);
                TaiKhoan.Name = reader.GetString(1);
                reader.Close();
            }
            return;
        }
    }
}
