﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class HSTiemChung_DAO : DataAccess
    {
        public List<HSTiemChung> LayTatCaHSTCCuaKH_DB(int MaKH)
        {
            // Lấy danh sách hồ sơ tiêm chủng của một khách hàng
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select MaHS, MaTT, MaKH, MaNV, " +
                "NgayDangKy, NgayTiem, KQ_KhamTruocTiem, KQ_KhamSauTiem" +
                " from HOSOTIEMCHUNG WHERE DaXoa IS NULL AND MaKH = " + MaKH;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            List<HSTiemChung> DS_HSTC = new List<HSTiemChung>();
            while (reader.Read())
            {
                HSTiemChung hstc = new HSTiemChung();
                hstc.MaHS = reader.GetInt32(0);
                hstc.MaTT = reader.GetInt32(1);
                hstc.MaKH = reader.GetInt32(2);
                hstc.MaNV = reader.GetInt32(3);
                hstc.NgayLapHS = reader.GetDateTime(4);
                hstc.NgayHenTiem = reader.GetDateTime(5);
                hstc.KQ_KhamSangLoc = reader.GetString(6);
                hstc.KQ_KhamSauTiem = reader.GetString(7);

                DS_HSTC.Add(hstc);
            }
            reader.Close();
            return DS_HSTC;
        }
    }
}