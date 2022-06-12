using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class GoiVaccine_BUS
    {
        GoiVaccine_DAO vca = new GoiVaccine_DAO();

        public List<GoiVaccine> LayDSGoiVaccine()
        {
            return vca.LayDSGoiVaccine_DB();
        }
    }
}
