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
    public class PhieuDatMua_DAO:DataAccess
    {
        List<PhieuDatMua> DS_DDH = new List<PhieuDatMua>();
        public List<PhieuDatMua> XEMDONDATHANG()
            {
                // Lấy danh sách hồ sơ tiêm chủng của một khách hàng
                MoKetNoi();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT MaPhieu,MaKH,NgayDat FROM PHIEUDATMUAVACCINE Where DaXoa IS NULL ";
                command.Connection = conec;
                SqlDataReader reader = command.ExecuteReader();

              DS_DDH.Clear();
            while (reader.Read())
                {
                PhieuDatMua PDM = new PhieuDatMua();
                    PDM.MaPhieu = reader.GetInt32(0);
                PDM.MaKH = reader.GetInt32(1);
               // PDM.TinhTrang = reader.GetInt32(2);
                PDM.NgayDat = reader.GetDateTime(2);
                  
                DS_DDH.Add(PDM);
                }
                reader.Close();
                return DS_DDH;
            }
        public List<PhieuDatMua> TraCuuKH(string MaKH)
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT MaPhieu,MaKH,NgayDat FROM PHIEUDATMUAVACCINE Where DaXoa IS NULL and MaKH = " +MaKH;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();


            DS_DDH.Clear();
            while (reader.Read())
            {
                PhieuDatMua PDM = new PhieuDatMua();
                PDM.MaPhieu = reader.GetInt32(0);
                PDM.MaKH = reader.GetInt32(1);
                // PDM.TinhTrang = reader.GetInt32(2);
                PDM.NgayDat = reader.GetDateTime(2);

                DS_DDH.Add(PDM);
            }
            reader.Close();
            return DS_DDH;
        }





    }
}
