using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryConsoleAppOrnek
{
    class Program
    {
        static void Main(string[] args)
        {
            //C klasoru içinde kendi adımızla bir klasor oluşturacağız.
            //Kullanıcıya klasoru sil -->1 klasoru taşı -->2 gibi menu  sunmamız isteniyor
            //Kullanıcı hangi işlemi seçerse o işlem uygulanacak
            //Silme işlemini seçerse emin misiniz E/H  sorusu sormamız ve verilecek cevaba göre silme işlemi yapmamız isteniyor.
            //KlasorOlustur(@"C:\BeyzaTasi");
            try
            {
                string myPath = "C:\\Beyza";
                if (KlasordenVarMi(myPath))
                {
                    Console.WriteLine("Klasorünüz sistemde mevcuttur");
                }
                else
                {
                    KlasorOlustur(myPath);
                    Console.WriteLine("Dosyanız oluşturuldu");
                }
                
                ConsoleKeyInfo secim;
                Console.WriteLine("Oluşturulan dosyayı silmek mi istersiniz yoksa taşımak mı S/T");
                Console.WriteLine();
                secim = Console.ReadKey();
                if (secim.Key == ConsoleKey.T)
                {
                    KlasoruTasi(@"C:\Beyza", @"C:\BeyzaTasi");
                    Console.WriteLine("Dosyanız hedef dosyaya taşındı");
                }
                else if (secim.Key == ConsoleKey.S)
                {
                    ConsoleKeyInfo tercih;
                    Console.WriteLine("Silme işlemini yapmak istediğinizden emin misiniz? E/H");
                    Console.WriteLine();
                    tercih = Console.ReadKey();
                    if (tercih.Key == ConsoleKey.E)
                    {
                        KlasoruSil(@"C:\Beyza");
                        Console.WriteLine("Oluşturulan dosya silindi");
                    }
                    else if (tercih.Key == ConsoleKey.H)
                    {
                        Console.WriteLine("Oluşturulan dosyayı silmekten vazgeçtiniz");
                    }
                    else
                    {
                        Console.WriteLine("Lütfen bir tercih yapınız!");
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen bir seçim yapınız!");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("HATA!" + ex.Message);
            }
            
            Console.ReadKey();
        }
        private static void KlasorOlustur(string dosyaYolu)
        {
            DirectoryInfo di = Directory.CreateDirectory(dosyaYolu);
        }
        private static bool KlasordenVarMi(string dosyaYolu)
        {
            bool sonuc = false;
            sonuc = Directory.Exists(dosyaYolu);
            return sonuc;
        }
        
        private static void KlasoruSil(string dosyaYolu)
        {
            Directory.Delete(dosyaYolu);
        }
        private static void KlasoruTasi(string kaynakYol, string hedefYol)
        {
            Directory.Move(kaynakYol, hedefYol);            
        }
    }
}
