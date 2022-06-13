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

        public int XemTinhTrangPhieu(string MaPhieu)
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT TinhTrang FROM PHIEUDATMUAVACCINE Where DaXoa IS NULL and MaPhieu = " + MaPhieu;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            PhieuDatMua PDM;

            //  DS_DDH.Clear();
            reader.Read();
            
                 PDM = new PhieuDatMua();
                
                PDM.TinhTrang = reader.GetInt32(0);
                if(PDM.TinhTrang ==-1)
                {
                    return -1;
                }
                if (PDM.TinhTrang == 1)
                {
                    return 1;
                }
                if (PDM.TinhTrang == 0)
                {
                    return 0;
                }


            
            reader.Close();
            return -1000;
           
           
        }


        //  ham update tinh trang của 1 phiếu sau khi ta nhan nut duyet hay ko duyet
        public void UpdateTinhTrangPhieu(string MaPhieu, int TT)
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE PHIEUDATMUAVACCINE SET TinhTrang= "+ TT.ToString()+" Where DaXoa IS NULL and MaPhieu = " + MaPhieu;
            
            command.Connection = conec;
            command.ExecuteNonQuery();

            


        }
        public void Insert_DonDatHang(DateTime NgayDat ,Decimal TongTien)
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO DONDATHANG(NgayDat,TongTien) VALUES  " + "(" + NgayDat + "," + TongTien + ")";

            command.Connection = conec;
            command.ExecuteNonQuery();
        }






    }
}
