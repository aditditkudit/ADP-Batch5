using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasOop
{
    class Makanan : DataBarang
    {
        public Makanan(string kodeBarang, string namaBarang, double hargaBarang, int stokBarang)
        {
            this.KodeBarang = kodeBarang;
            this.NamaBarang = namaBarang;
            this.HargaBarang = hargaBarang;
            this.StokBarang = stokBarang;
            this.JenisBarang = getJenis();

        }

        public string getJenis()
        {
            return "Makanan";
        }
    }
}
