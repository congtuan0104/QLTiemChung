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
    public class GoiVaccine_DAO : DataAccess
    {
        public List<GoiVaccine> LayDSGoiVaccine_DB()
        {
            // Lấy danh sách tất cả gói vaccine
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select MaDV_GoiVaccine, TenGoi, MoTa, SoLuongTon, GiaDV" +
                " FROM goivaccine gv, dichvu d WHERE d.madv = gv.madv_goivaccine";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            List<GoiVaccine> dsGoiVaccine = new List<GoiVaccine>();
            while (reader.Read())
            {
                GoiVaccine gvc = new GoiVaccine();
                gvc.MaGoiVaccine = reader.GetInt32(0);
                gvc.TenGoiVaccine = reader.GetString(1);
                gvc.MoTa = reader.GetString(2);
                gvc.SoLuongTon = reader.GetInt32(3);
                gvc.Gia = reader.GetDecimal(4);
                dsGoiVaccine.Add(gvc);
            }
            reader.Close();
            return dsGoiVaccine;
        }
    }
}
