using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasOop
{
    public class DataBarang
    {
        protected string kodeBarang;
        protected string namaBarang;
        protected double hargaBarang;
        protected int stokBarang;
        protected string jenisBarang;
        protected int qtyCart;

        public string KodeBarang { get => kodeBarang; set => kodeBarang = value; }
        public string NamaBarang { get => namaBarang; set => namaBarang = value; }
        public double HargaBarang { get => hargaBarang; set => hargaBarang = value; }
        public int StokBarang { get => stokBarang; set => stokBarang = value; }
        public string JenisBarang { get => jenisBarang; set => jenisBarang = value; }
        public int QtyCart { get => qtyCart; set => qtyCart = value; }
    }
}
