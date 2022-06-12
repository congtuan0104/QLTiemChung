using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    // Thực hiện kết nối, đóng kết nối với server
    public class DataAccess
    {
        public SqlConnection conec = null;

        string strconec = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=TIEMCHUNG;Integrated Security=True";

        public void MoKetNoi()
        {
            if (conec == null)
            {
                conec = new SqlConnection(strconec);
            }

            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
        }

        public void DongKetNoi()
        {
            if (conec != null && conec.State == ConnectionState.Open)
            {
                conec.Close();
            }
        }
    }
}

