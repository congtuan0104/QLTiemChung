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
    public class GiamHo_DAO : DataAccess
    {
        public GiamHo XemNguoiGiamHo_DB(int makh)
        {
            // Truy vấn thông tin người giám hộ của một khách hàng
            MoKetNoi();
            string sql = "select MaKH, HoTen_NGH, MoiQuanHe" +
                " from NGUOIGIAMHO WHERE MaKH = " + makh;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            GiamHo GH = new GiamHo();
            if (reader.Read())
            {
                GH.MaKH = reader.GetInt32(0);
                GH.TenNGH = reader.GetString(1);
                GH.QuanHe = reader.GetString(2);
                reader.Close();
                return GH;
            }
            return null;
            
        }

        public bool ThemNguoiGiamHo_DB(GiamHo GH)
        {
            MoKetNoi();
            string sql = "insert into NGUOIGIAMHO(MaKH, HoTen_NGH, MoiQuanHe)" +
                " values(@makh, @ten, @quanhe)";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;

            command.Parameters.Add("@makh", SqlDbType.Int).Value = GH.MaKH;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = GH.TenNGH;
            command.Parameters.Add("@quanhe", SqlDbType.NVarChar).Value = GH.QuanHe;

            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }

        public bool XoaNguoiGiamHo_DB(int maKH)
        {
            MoKetNoi();
            string sql = "DELETE NGUOIGIAMHO where MaKH = " + maKH;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
    }
}
