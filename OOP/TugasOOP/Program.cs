using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasOop
{
    class Program
    {
        static void Main(string[] args)
        {
            Etalase abc = new Etalase();
            //abc.tampilanEtalase();
            Console.WriteLine("==================");
            //abc.addToCart();
            int pilih;
            do
            {
                abc.tampilanEtalase();
                Console.WriteLine("==================");
                Console.WriteLine("Menu Keranjang Warung Aselole");
                Console.WriteLine("1. Tambah Barang ke Keranjang");
                Console.WriteLine("2. List barang di Keranjang");
                Console.WriteLine("3. Update Kuantity barang di Keranjang");
                Console.WriteLine("4. Delete barang di keranjang");
                Console.WriteLine("5. Cek Harga Semua yang di keranjang");
                Console.WriteLine("6. Keluar");
                Console.WriteLine("Pilih Menu: ");
                pilih = Convert.ToInt32(Console.ReadLine());

                if(pilih == 1)
                {
                    abc.addToCart();
                    Console.ReadKey();
                    Console.Clear();

                }
                else if(pilih == 2)
                {
                    abc.listCart();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if(pilih == 3)
                {
                    abc.updateCart();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (pilih == 4)
                {
                    abc.deleteCart();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (pilih == 5)
                {
                    abc.showTotal();
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Yang kamu input tidak ada menunya");
                }
            } while (pilih != 6);
            Console.ReadKey();

            
        }
    }
}
