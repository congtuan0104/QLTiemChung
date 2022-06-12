using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GoiVaccine
    {
            public int MaGoiVaccine { get; set; }
            public string TenGoiVaccine { get; set; }
            public string MoTa { get; set; }
            public int SoLuongTon { get; set; }
            public decimal Gia { get; set; }
            public bool DuocChon { get; set; }
    }
}
