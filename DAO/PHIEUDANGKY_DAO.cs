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
    }
}
