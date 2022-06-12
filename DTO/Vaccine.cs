using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Vaccine
    {
        public int MaVaccine { get; set; }
        public string TenVaccine { get; set; }
        public string NhaSanXuat { get; set; }
        public string MoTa { get; set; }
        public int SoLuongTon { get; set; }
        public decimal Gia { get; set; }
        public bool DuocChon { get; set; }
    }
}
