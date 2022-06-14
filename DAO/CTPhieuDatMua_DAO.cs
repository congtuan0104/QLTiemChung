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
        public List<CTPhieuDatMua> XEMCHITIETPHIEU(int MaPhieu)
        {
            
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT MaDV_Vaccine,SoLuong,ThanhTien FROM CT_PHIEUDATMUAVACCINE where MaPhieu= "+MaPhieu;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            decimal TinhTongTien = 0;
            CT.Clear();
            while (reader.Read())
            {
                CTPhieuDatMua CTM = new CTPhieuDatMua();
                CTM.MaDV_Vaccine = reader.GetInt32(0);
                CTM.SoLuong = reader.GetInt32(1);
                CTM.ThanhTien = reader.GetDecimal(2);
              //  TinhTongTien = TinhTongTien + CTM.ThanhTien;
                
                CT.Add(CTM);
              //  CTM.TongTien=TinhTongTien;
                
               



            }
            reader.Close();
            return CT;

        }
    }
}
