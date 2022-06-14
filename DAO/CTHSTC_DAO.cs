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
    public class CTHSTC_DAO: DataAccess
    {
        public List<CTHSTC> LayToanBoDVDK_DB(int MaHS)
        {
            MoKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;

            command.CommandText = "SELECT CD.MADV, CD.LOAIDV, CD.GIADV, CD.TENDV " +
                "FROM CT_HOSOTIEMCHUNG ch, CT_DV CD " +
                "WHERE CH.MaDV = CD.MADV AND MAHS = " + MaHS;
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();

            List<CTHSTC> DS_DVDK = new List<CTHSTC>();
            while (reader.Read())
            {
                CTHSTC dsdv = new CTHSTC();
                dsdv.MaDV = reader.GetInt32(0);
                dsdv.LoaiDV = reader.GetString(1);
                dsdv.GiaDV = reader.GetDecimal(2);
                dsdv.TenDV = reader.GetString(3);
                DS_DVDK.Add(dsdv);
            }
            reader.Close();
            return DS_DVDK;
        }
    }
}
