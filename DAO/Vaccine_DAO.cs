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
    public class Vaccine_DAO:DataAccess
    {
        public List<Vaccine> LayDSVaccine_DB()
        {
            // Lấy danh sách tất cả vaccine
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select MaDV_Vaccine, TenVaccine, NhaSX, MoTa, SoLuongTon, GiaDV" +
                " FROM vaccine v, dichvu d WHERE d.madv = v.madv_vaccine";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            List<Vaccine> dsVaccine = new List<Vaccine>(); 
            while (reader.Read())
            {
                Vaccine vc = new Vaccine();
                vc.MaVaccine = reader.GetInt32(0);
                vc.TenVaccine = reader.GetString(1);
                vc.NhaSanXuat = reader.GetString(2);
                vc.MoTa = reader.GetString(3);
                vc.SoLuongTon = reader.GetInt32(4);
                vc.Gia = reader.GetDecimal(5);
                dsVaccine.Add(vc);
            }
            reader.Close();
            return dsVaccine;
        }
    }
}
