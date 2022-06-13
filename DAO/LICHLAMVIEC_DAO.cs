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
    public class LICHLAMVIEC_DAO : DataAccess
    {
        List<LICHLAMVIEC> DS_LICHLAMVIEC = new List<LICHLAMVIEC>();
        public List<LICHLAMVIEC> layToanBoLichLamViec_DB()
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select MaNV, Ca, Ngay from LICHLAMVIEC ";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            DS_LICHLAMVIEC.Clear();
            while (reader.Read())
            {
                LICHLAMVIEC lich = new LICHLAMVIEC();
                lich.MaNV = reader.GetInt32(0);
                lich.Ca = reader.GetString(1);
                lich.Ngay = reader.GetDateTime(2);
                
                DS_LICHLAMVIEC.Add(lich);
            }
            reader.Close();
            return DS_LICHLAMVIEC;
        }

        public List<LICHLAMVIEC> layLichLamViec_1_NhanVien_DB(string dieukien)
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select MaNV, Ca, Ngay from LICHLAMVIEC "+dieukien;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            DS_LICHLAMVIEC.Clear();
            while (reader.Read())
            {
                LICHLAMVIEC lich = new LICHLAMVIEC();
                lich.MaNV = reader.GetInt32(0);
                lich.Ca = reader.GetString(1);
                lich.Ngay = reader.GetDateTime(2);

                DS_LICHLAMVIEC.Add(lich);
            }
            reader.Close();
            return DS_LICHLAMVIEC;
        }

        public bool themLichLamViec(LICHLAMVIEC llv)
        {

            MoKetNoi();
            string sql = "insert into LICHLAMVIEC(MaNV, Ca, Ngay)" +
                " values(@manv, @ca, '" + llv.Ngay.ToString("yyyy-MM-dd") + "');";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;

            command.Parameters.Add("@manv", SqlDbType.Int).Value = llv.MaNV;
            
            command.Parameters.Add("@ca", SqlDbType.NVarChar).Value = llv.Ca;
            

            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
    }
}
