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
    public class PHIEUDANGKY_DAO: DataAccess
    {
        List<PHIEUDANGKY> DS_PHIEUDANGKY = new List<PHIEUDANGKY>();
        public List<PHIEUDANGKY> layToanBoPhieuDangKy_DB()
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select MaNV, Ca, Ngay from PHIEUDANGKY ";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            DS_PHIEUDANGKY.Clear();
            while (reader.Read())
            {
                PHIEUDANGKY phieu = new PHIEUDANGKY();
                phieu.MaNV = reader.GetInt32(0);
                phieu.Ca = reader.GetString(1);
                phieu.Ngay = reader.GetDateTime(2);

                DS_PHIEUDANGKY.Add(phieu);
            }
            reader.Close();
            return DS_PHIEUDANGKY;
        }

        public List<PHIEUDANGKY> layPhieuDangKy_1_NhanVien_DB(string dieukien)
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select MaNV, Ca, Ngay from PHIEUDANGKY " + dieukien;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            DS_PHIEUDANGKY.Clear();
            while (reader.Read())
            {
                PHIEUDANGKY phieu = new PHIEUDANGKY();
                phieu.MaNV = reader.GetInt32(0);
                phieu.Ca = reader.GetString(1);
                phieu.Ngay = reader.GetDateTime(2);

                DS_PHIEUDANGKY.Add(phieu);
            }
            reader.Close();
            return DS_PHIEUDANGKY;
        }

        public bool xoaPhieuDangKy(PHIEUDANGKY pdk)
        {
            MoKetNoi();
            string sql = "delete from PHIEUDANGKY where MaNV = " + pdk.MaNV.ToString() +
                " and Ngay = '" + pdk.Ngay.ToString("yyyy-MM-dd") + "' and Ca = N'" + pdk.Ca + "';";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }

        public bool xoaPhieuDangKy_1NV(string manv)
        {
            MoKetNoi();
            string sql = "delete from PHIEUDANGKY where MaNV = " + manv;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }

        public bool xoaTatCaPhieuDangKy()
        {
            MoKetNoi();
            string sql = "delete from PHIEUDANGKY; ";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }

        public bool themPhieuDangKy(PHIEUDANGKY pdk)
        {

            MoKetNoi();
            string sql = "insert into PHIEUDANGKY(MaNV, Ca, Ngay)" +
                " values(@manv, @ca, '" + pdk.Ngay.ToString("yyyy-MM-dd") + "');";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            command.Parameters.Add("@manv", SqlDbType.Int).Value = pdk.MaNV;
            command.Parameters.Add("@ca", SqlDbType.NVarChar).Value = pdk.Ca;
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }

        public List<PHIEUDANGKY> kiemTraTonTai(PHIEUDANGKY pdk)
        {
            MoKetNoi();
            string sql = "select MaNV, Ca, Ngay from PHIEUDANGKY where MaNV = " + pdk.MaNV.ToString() +
                " and Ngay = '" + pdk.Ngay.ToString("yyyy-MM-dd") + "' and Ca = N'" + pdk.Ca + "';";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            DS_PHIEUDANGKY.Clear();
            while (reader.Read())
            {
                PHIEUDANGKY phieu = new PHIEUDANGKY();
                phieu.MaNV = reader.GetInt32(0);
                phieu.Ca = reader.GetString(1);
                phieu.Ngay = reader.GetDateTime(2);

                DS_PHIEUDANGKY.Add(phieu);
            }
            reader.Close();
            return DS_PHIEUDANGKY;
        }
    }
}
