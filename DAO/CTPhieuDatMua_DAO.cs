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
    public class CTPhieuDatMua_DAO : DataAccess
    {

        List<CTPhieuDatMua> CT = new List<CTPhieuDatMua>();
        public List<CTPhieuDatMua> XemChiTietPhieu_DB(int MaPhieu)
        {

            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT cp.MaDV_Vaccine, " +
                "cd.TenDV,cd.GiaDV, cp.SoLuong, cp.ThanhTien " +
                "FROM ct_dv cd, CT_PHIEUDATMUAVACCINE cp " +
                "WHERE cd.MaDV = cp.MaDV_Vaccine AND cp.MaPhieu =" + MaPhieu;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            CT.Clear();
            while (reader.Read())
            {
                CTPhieuDatMua CTM = new CTPhieuDatMua();
                CTM.MaVaccine = reader.GetInt32(0);
                CTM.TenVaccine = reader.GetString(1);
                CTM.Gia = reader.GetDecimal(2);
                CTM.SoLuong = reader.GetInt32(3);
                CTM.ThanhTien = reader.GetDecimal(4);
                CT.Add(CTM);
            }
            reader.Close();
            return CT;

        }
       
    }
}
