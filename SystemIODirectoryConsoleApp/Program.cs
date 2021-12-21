using System;
using System.IO;

namespace SystemIODirectoryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string myPath = "C:\\Beyzaeski";
            //if ile kontrol edelim
            if (KlasordenVarMi(myPath))
            {
                Console.WriteLine($"{myPath} dosya yolu zaten oluşmuştur"); //true gelirse
            }
            else //false dönmüş demektir.Directorynin oluşması için metodu çağıralım.
            {
                YeniKlasorOlustur(myPath);
            }

            Console.WriteLine();
           
            //KlasoruSil(myPath);
            //Console.WriteLine($"{myPath} directory silindi");

            //YeniKlasorOlustur(@"C:\Beyza103");
            KlasoruTasi(myPath, @"C:\Beyza103");
           
            Console.ReadKey();
        }
        private static void YeniKlasorOlustur(string dosyaYolu)
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
        
        //Taşıma işlemi yapacağımız için eski ve yeni yere ihtiyacımız var.
        private static void KlasoruTasi(string kaynakYol, string HedefYol)
        {
            //Directory.Move (source,dest)
            //NOT: dest yolunu metot içeride kendisi oluşturuyor.
            Directory.Move(kaynakYol, HedefYol);
            Console.WriteLine($"Kaynak : {kaynakYol}, {HedefYol} hedefine taşındı");
        }
    }
}
