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
    public class TrungTam_DAO : DataAccess
    {
        public List<TrungTam> LayDSTrungTam_DB()
        {
            // Lấy danh sách tất cả các trung tâm 
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT MaTT, TenTT, SDT_TT, DiaChi " +
                 "FROM TRUNGTAM";

            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            List<TrungTam> dsTrungTam = new List<TrungTam>();
            while (reader.Read())
            {
                TrungTam tt = new TrungTam();
                tt.MaTT = reader.GetInt32(0);
                tt.TenTT = reader.GetString(1);
                tt.SDT_TT = reader.GetString(2);
                tt.DiaChi = reader.GetString(3);
                dsTrungTam.Add(tt);
            }
            reader.Close();
            return dsTrungTam;
        }
    }
}
