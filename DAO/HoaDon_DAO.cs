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
    public class HoaDon_DAO : DataAccess
    {
        List<HoaDon> DS_HoaDon = new List<HoaDon>();

        public List<HoaDon> LayToanBoHoaDon_DB()
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select MaHD,SoDotThanhToan,TienTra_1Dot,TongTien, ConLai,MaHS " +
                "from HOADON";  
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            DS_HoaDon.Clear();
            while (reader.Read())
            {
                HoaDon hoadon = new HoaDon();
                hoadon.MaHD = reader.GetInt32(0);
                hoadon.SoDotThanhToan = reader.GetInt32(1);
                hoadon.TienTra_1Dot = reader.GetDecimal(2);              
                hoadon.TongTien = reader.GetDecimal(3);
                hoadon.ConLai = reader.GetDecimal(4);
                hoadon.MaHS= reader.GetInt32(5);
                DS_HoaDon.Add(hoadon);
            }
            reader.Close();
            return DS_HoaDon;
        }
        public bool ThemHoaDon_DB(HoaDon Hdon,int MaHS)
        {

            MoKetNoi();
            string sql = "insert into HOADON(SoDotThanhToan, TienTra_1Dot, TongTien,ConLai,MaHS)" +
                " values(@SoDotThanhToan, @TienTra_1Dot, @TongTien, @ConLai, @MaHS)";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;

            command.Parameters.Add("@SoDotThanhToan", SqlDbType.Int).Value = Hdon.SoDotThanhToan;
            command.Parameters.Add("@TienTra_1Dot", SqlDbType.Money).Value = Hdon.TienTra_1Dot;
            command.Parameters.Add("@TongTien", SqlDbType.Money).Value = Hdon.TongTien;
            command.Parameters.Add("@ConLai", SqlDbType.Money).Value = Hdon.ConLai;
            command.Parameters.Add("@MaHS", SqlDbType.Int).Value = MaHS;

            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
        public HoaDon XemHoaDon_DB(int MaHS)
        {
            MoKetNoi();
            string sql = "select MaHD,SoDotThanhToan,TienTra_1Dot,TongTien, ConLai,MaHS" +
                " from HOADON WHERE MaHS = " + MaHS;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            HoaDon hoadon = new HoaDon();
            if (reader.Read())
            {
                hoadon.MaHD = reader.GetInt32(0);
                hoadon.SoDotThanhToan = reader.GetInt32(1);
                hoadon.TienTra_1Dot = reader.GetDecimal(2);
                hoadon.TongTien = reader.GetDecimal(3);
                hoadon.ConLai = reader.GetDecimal(4);
                hoadon.MaHS = reader.GetInt32(5);
                reader.Close();
                return hoadon;
            }
            else
            {
                return null;
            }    
            
        }
        public bool CapNhatHoaDon(int MaHD)
        {
            MoKetNoi();
            string sql = "update HOADON set ConLai=ConLai-TienTra_1Dot" +
                " where MaHD = " + MaHD;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conec;
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
    }
}
