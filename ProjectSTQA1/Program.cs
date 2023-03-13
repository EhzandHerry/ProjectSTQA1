using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Globalization;

//membuat nama project
namespace UAS_PAW_2
{
    /// <summary>
    /// main class
    /// </summary>
    /// <remarks>class kasir untuk membuat daftar menu dan membuat hasil nota</remarks>
    public class Kasir
    {
        public void KasirCafe() //membuat method KasirCafe
        {
            /// <example> membuat tampilan awal </example>
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("        Program Kasir Cafe Sedehana         ");
            Console.WriteLine("---------------------------------------------");
            Console.Write("\n");
            Console.WriteLine("Silahkan Memilih MENU");
            Console.Write("\n");

            /// <example> membuat tampilan menu makanan</example>
            Console.WriteLine("=================MAKANAN=================");
            Console.Write("\n");
            Console.WriteLine("1. Nasi Goreng               : Rp 15000");
            Console.WriteLine("2. Nasi Goreng Seafood       : Rp 17000");
            Console.WriteLine("3. Mie Goreng                : Rp 15000");
            Console.WriteLine("4. Mie Goreng Seafood        : Rp 17000");
            Console.Write("\n");
            /// <example> membuat tampilan menu minuman</example>
            Console.WriteLine("=================MINUMAN=================");
            Console.Write("\n");
            Console.WriteLine("1. Jus Jeruk                 : Rp 15000");
            Console.WriteLine("2. Jus Alpukat               : Rp 17000");
            Console.WriteLine("3. Jus Mangga                : Rp 18000");
            Console.WriteLine("4. Jus Sirsak                : Rp 15000");

            int jumlah; //membuat variabel jumlah menggunakan tipe data int
            //looping dengan menginput jumlah barang menggunakan kondisi do while
            do
            {
                Console.Write("\nMasukan Jumlah Barang : ");
                jumlah = int.Parse(Console.ReadLine());
            } while (jumlah <= 0 || jumlah > 100);

            //mendeklarasikan atau mendefinisikan variabel data
            string[] nama = new string[jumlah];
            int[] harga = new int[jumlah];
            int total = 0;
            int bayar, kembalian;

            /// <example> membuat tampilan untuk memasukkan nama pelanggan</example>
            Console.WriteLine("========================");
            Console.WriteLine("Masukan Nama Pelanggan :");
            //deklarasi variabel data string
            string namap1 = Console.ReadLine();

            //Looping menggunakan kombinasi array
            for (int i = 0; i < jumlah; i++)
            {
                do
                {
                    //menampilkan input nama barang 
                    Console.WriteLine("====================");
                    Console.Write("Masukkan Nama Barang Ke-" + (i + 1) + " : ");
                    nama[i] = Console.ReadLine();
                }//user harus menginput nama barang diatas 0 karakter sampai dengan 20 karakter
                while (nama[i].Length <= 0 || nama[i].Length >= 20);

                do
                {
                    //menampilkan input harga
                    Console.Write("Masukkan Harga Barang Ke-" + (i + 1) + " : ");
                    harga[i] = int.Parse(Console.ReadLine());
                }//user harus menginput harga barang min 15000 sampai 100000
                while (harga[i] <= 14000 || harga[i] >= 100000);
            }
            /// <example> membuat tampilan untuk daftar menu yang dipilih</example>
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("============================");
            Console.WriteLine("daftar Barang yang Dipilih");
            Console.WriteLine("============================");
            for (int i = 0; i < jumlah; i++)
            {
                Console.WriteLine((i + 1) + ". " + nama[i] + " " + harga[i]);
            }
            foreach (int i in harga)
            {
                total += i;
            }

            /// <example> membuat tampilan untuk total harga barang</example>
            Console.WriteLine("===================");
            Console.WriteLine("Total Harga : Rp" + total);

            do
            {
                Console.Write("Masukkan Tunai : Rp");
                bayar = int.Parse(Console.ReadLine());

                //menampilkan kembalian dari uang yang dibayarkan dikurangi uang total
                kembalian = bayar - total;

                //kondisi jika input uang yang dibayarkan kurang
                if (bayar < total)
                {
                    Console.WriteLine("Maaf Uangmu Tidak Cukup !");
                }
                //kondisi jika input uang yang dibayarkan lebih 
                else //menampilkan kembalian
                {
                    Console.WriteLine("Uang Kembalian Anda : Rp" + kembalian);
                }
            } while (bayar < total);
            Console.Write("\n");
            Console.Write("Nama Pelanggan : {0}", namap1.ToString());
            Console.Write("\n");

            /// <example>membuat tampilan untuk waktu transaksi</example>
            Console.WriteLine("Tanggal Transaksi :" + DateTime.Today.ToString("yyyy-MM-dd"));
            Console.WriteLine("Jam Transaksi :" + DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine("=======================================");
            Console.WriteLine("Nama Kasir : Ehzand Herry Pragansya ");
            Console.WriteLine("Terima Kasih :)");
            Console.WriteLine("=======================================");

            /// <example> membuat tampilan untuk mencetak nota menggunalan streamwriter</example>
            using (StreamWriter sw = new StreamWriter(@"D:\Microsoft Studio Code\UAS_PAW_2\Nota/Nota.txt"))
            {
                sw.WriteLine("========================================");
                sw.WriteLine("============ NOTA PEMBAYARAN ===========");
                sw.WriteLine("========================================");
                sw.WriteLine("Nama Barang Yang Dibeli");
                for (int i = 0; i < jumlah; i++)
                {
                    sw.WriteLine((i + 1) + ". " + nama[i] + " " + harga[i]);
                }
                sw.WriteLine("========================================");
                sw.WriteLine("Total Harga           : Rp" + total);
                sw.WriteLine("Tunai                 : Rp" + bayar);
                sw.WriteLine("Kembalian             : Rp" + kembalian);
                sw.WriteLine("\n");
                //menampilkan nama pelanggan 
                sw.WriteLine("Nama Pelanggan : {0}", namap1.ToString());
                sw.WriteLine("Tanggal Transaksi :" + DateTime.Today.ToString("yyyy-MM-dd"));
                sw.WriteLine("Jam Transaksi :" + DateTime.Now.ToString("HH:mm:ss"));
                sw.WriteLine("=======================================");
                sw.WriteLine(" Nama Kasir : Ehzand Herry Pragansya ");
                sw.WriteLine("      TERIMA KASIH :)      ");
                sw.WriteLine("=======================================");
                Console.Write("\n");
                Console.WriteLine("Nota Telah Di Cetak !");
            }
            /// <example> membuat tampilan untuk keluar</example>
            Console.WriteLine();
            Console.Write("Tekan 'Enter' untuk Keluar . . . .");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            //memanggil kelas Kasir
            Kasir KasirC = new Kasir();
            KasirC.KasirCafe();
        }
    }
}