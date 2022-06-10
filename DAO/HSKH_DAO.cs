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
            command.CommandText = "select MaKH, HoTen, SDT, DiaChi from KHACHHANG";
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

                DS_HSKH.Add(hskh);
            }
            reader.Close();
            return DS_HSKH;
        }

        public List<HSKH> TraCuuKH_DB(string TenKH, string Sdt)
        {
            MoKetNoi();
            string sql = "select MaKH, HoTen, SDT, DiaChi " +
                "from KHACHHANG WHERE HoTen LIKE '" + TenKH + "%' AND SDT LIKE '" + Sdt + "%'";
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

                DS_HSKH.Add(hskh);
            }
            reader.Close();
            return DS_HSKH;
        }

        public bool ThemKhachHang_DB(HSKH KH)
        {
            return true;
        }


        public bool XoaKhachHang_DB(string MaKH)
        {
            return true;
        }
    }


}

