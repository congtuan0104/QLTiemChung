using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class LoginBUS
    {
        TaiKhoan_DAO tka = new TaiKhoan_DAO();

        public void DangNhap(string user, string pass)
        {
            if(tka.XacThucTaiKhoan_DB(user, pass))
            {
                if (TaiKhoan.Role == "Khách hàng")
                    tka.LayThongTinTKKH_DB(user.Substring(2));
                else
                    tka.LayThongTinTKNV_DB(user.Substring(2));
            }
        }
 
    }
}
