using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasOop
{
    class Etalase
    {
        public List<DataBarang> dummies;
        public List<DataBarang> cart;
        public Etalase()
        {
            dummies = new List<DataBarang>
            {
                new Makanan("ASW", "Ciki", 1000.0, 20),
                new Makanan("Hirhi", "Cuka", 5000.0, 10),
                new Makanan("cok", "Ciki", 1000.0, 20),
                new Minuman("Cik", "Amer", 75000.0, 2100),
                new Minuman("sad", "Vodka", 750000.0, 2100),
                new Minuman("123", "Gingseng", 25000.0, 2100),
            };
            cart = new List<DataBarang>();

        }

        public void tampilanEtalase()
        {
            int i = 1;
            Console.WriteLine("--NO--|--KODE--|--NAMA BARANG--|--HARGA BARANG--|--STOK BARANG--|--JENIS BARANG--|");
            foreach (var dummy in dummies)
            {                                
                Console.WriteLine("--{5}--|--{0}--|--{1}--|--{2}--|--{3}--|--{4}--|", dummy.KodeBarang, dummy.NamaBarang, dummy.HargaBarang, dummy.StokBarang, dummy.JenisBarang, i);
                i++;
            }
        }

        public void addToCart()
        {
            tampilanEtalase();
            Console.WriteLine("================================");
            Console.WriteLine("Masukkan No Barang untuk dimasukkan kedalam keranjang: ");
            int select = Convert.ToInt32(Console.ReadLine());
            int index = select - 1;
            Console.WriteLine("Masukkan Berapa banyak Barang untuk dimasukkan kedalam keranjang: ");
            int qty = Convert.ToInt32(Console.ReadLine());
            DataBarang dataBarang = new DataBarang();
            try
            {
                dataBarang.KodeBarang = dummies[index].KodeBarang;
                dataBarang.NamaBarang = dummies[index].NamaBarang;
                dataBarang.JenisBarang = dummies[index].JenisBarang;
                dataBarang.HargaBarang = dummies[index].HargaBarang;
                dataBarang.QtyCart = qty;                
                if (dummies[index].StokBarang > 0)
                {
                    cart.Add(dataBarang);
                    dummies[index].StokBarang = dummies[index].StokBarang - dataBarang.QtyCart;                    
                }
                else
                {
                    Console.WriteLine("Barang Sudah Habis");
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine("Inputan Barang Tidak Tersedia Boss");
            }
            

        }
        public void listCart()
        {
            int i = 1;
            Console.WriteLine("--NO--|--KODE--|--NAMA BARANG--|--HARGA BARANG--|--QTY BARANG--|--JENIS BARANG--|");
            foreach (var list in cart)
            {                
                Console.WriteLine("--{5}--|--{0}--|--{1}--|--{2}--|--{3}--|--{4}--|", list.KodeBarang, list.NamaBarang, list.HargaBarang, list.QtyCart, list.JenisBarang, i);
                i++;
            }
            
        }
        public void updateCart()
        {
            listCart();
            Console.WriteLine("================================");
            Console.WriteLine("Masukkan No Barang untuk diupdate dalam keranjang: ");
            int select = Convert.ToInt32(Console.ReadLine());
            int index = select - 1;

            try 
            {
                int qtyCartOld = cart[index].QtyCart;
                Console.WriteLine("Masukkan No Barang untuk diupdate dalam keranjang: ");
                int qtyCartNew = Convert.ToInt32(Console.ReadLine());
                cart[index].QtyCart = qtyCartNew;
                // Proses pemasukkan barang lama kedalam etalase
                for (int i = 0; i < dummies.Count; i++)
                {
                    if (dummies[i].KodeBarang == cart[index].KodeBarang)
                    {
                        if(dummies[i].StokBarang > 0)
                        {
                            dummies[i].StokBarang = dummies[i].StokBarang + qtyCartOld - qtyCartNew;
                            Console.WriteLine("Update Barang dalam keranjang berhasil");
                            break;                            
                        }
                        else
                        {
                            Console.WriteLine("Barang Yang Ditambah tidak mencukupi karena stok etalase cuman segitu");
                            break;
                        }
                    }
                }                
            }
            catch(Exception e)
            {
                Console.WriteLine("Lu Orang harus input barang yang ada dikeranjang blegug");
            }

            

        }

        public void deleteCart()
        {
            listCart();
            Console.WriteLine("================================");
            Console.WriteLine("Masukkan No Barang untuk didelete dalam keranjang: ");
            int select = Convert.ToInt32(Console.ReadLine());
            int index = select - 1;
            for (int i = 0; i < cart.Count; i++)
            {
                // Proses mencari kodebarang yang sesuai dengan inputan pada cart
                if (cart[i].KodeBarang == cart[index].KodeBarang)
                {
                    //Proses melakukan stok yang di card dikembalikan di stok etalase.
                    for(int x = 0; x < dummies.Count; x++)
                    {
                        if(dummies[x].KodeBarang == cart[index].KodeBarang)
                        {
                            dummies[x].StokBarang = dummies[x].StokBarang + cart[index].QtyCart;
                        }
                    }
                    // Proses Penghapusan
                    cart.RemoveAt(index);
                }
            }
            Console.WriteLine("Delete Berhasil");

        }

        public void showTotal()
        {            
            Console.WriteLine("================================");
            Console.WriteLine("Total  yang harus dibayar");
            int i = 1;
            int totalSemua = 0;
            Console.WriteLine("--NO--|--KODE--|--NAMA BARANG--|--HARGA BARANG--|--STOK BARANG--|--JENIS BARANG--|--TOTAL--");
            foreach (var list in cart)
            {
                int priceBarang = Convert.ToInt32(list.HargaBarang);
                int totalItem = priceBarang * list.QtyCart;
                Console.WriteLine("--{5}--|--{0}--|--{1}--|--{2}--|--{3}--|--{4}--|--{6}--|", list.KodeBarang, list.NamaBarang, list.HargaBarang, list.QtyCart, list.JenisBarang, i, totalItem);
                totalSemua += totalItem;
                i++;
            }
            Console.WriteLine("Harga Yang Harus dibayar dari semua barang yang ada dikeranjang: {0}", totalSemua);


        }

        

    }
}
