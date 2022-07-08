using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class Vaccine_BUS
    {
        Vaccine_DAO vca = new Vaccine_DAO();

        public List<Vaccine> LayDSVaccine()
        {
            return vca.LayDSVaccine_DB();
        }
        public bool KiemTraSLVaccine(int MaVaccine, int sl)
        {
            Vaccine v = vca.XemThongTinVaccine(MaVaccine);
            if (v.SoLuongTon >= sl)
                return true;
            return false;
        }
    }
}
