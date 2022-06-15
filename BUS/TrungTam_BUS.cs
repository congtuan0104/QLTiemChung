using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class TrungTam_BUS
    {
        TrungTam_DAO tta = new TrungTam_DAO();

        public List<TrungTam> LayDSTrungTam()
        {
            return tta.LayDSTrungTam_DB();
        }
    }
}
