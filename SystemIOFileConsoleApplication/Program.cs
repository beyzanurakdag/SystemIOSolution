using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SystemIOFileConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            bool theFileisExists = false;
            theFileisExists = File.Exists("C:\\Beyza103\\Merhaba.txt");
            if (!theFileisExists)
            {
                FileCreate("C:\\Beyza103\\Merhaba.txt"); //c deki beyza103 dosyasının içine merhaba isminde bir txt oluşturdu
            }
            else
            {
                Console.WriteLine("Merhaba.txt dosyası sistemde bulunuyor.");
            }
            Console.WriteLine("Dosya içine yazılacak metni giriniz:");
            Console.WriteLine();
            string metin = Console.ReadLine();
            FileAppendTheText("C:\\Beyza103\\Merhaba.txt", metin);
            Console.WriteLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("Dosyanızı kopyalıyoruz");
            FileCopy("C:\\Beyza103\\Merhaba.txt", "C:\\Beyza103\\Merhaba-Copy.txt");

            Console.WriteLine();

            Console.WriteLine("Dosyanızı taşıyoruz");
            FileMove("C:\\Beyza103\\Merhaba.txt", "C:\\Byz103\\Merhaba.txt");

            Console.WriteLine("Merhaba.txt metin belgesini silmek ister misini? E/H");
            ConsoleKeyInfo cevap;
            cevap = Console.ReadKey();
            Console.WriteLine();
            if (cevap.Key==ConsoleKey.E)
            {
                File.Delete("C:\\Beyza103\\Merhaba.txt");
                Console.WriteLine("Silindi");
            }
            else if(cevap.Key==ConsoleKey.H)
            {
                Console.WriteLine("Silinmedi");
            }
            else
            {
                Console.WriteLine("Geçerli bir cevap vermediniz");
            }
            Console.ReadKey();
        }
        private static void FileCreate(string path)
        {
            FileStream fs = File.Create(path);
            fs.Close();
        }
        private static void FileAppendTheText(string path, string text)
        {
            File.AppendAllText(path, text);
        }
        private static void FileDelete(string path)
        {
            File.Delete(path);
        }
        private static void FileCopy(string sourceFile, string destFile)
        {
            File.Copy(sourceFile,destFile);
            //File.Copy(sourceFile, destFile,true); 
            //overwrite parametresi true olarak verilirse var olan bir dosyaya kopyalama yapılabilir.
            //false olarak verilirse kendisinin oluşturması için bir dosya ismi destFile'a verilir.
        }
        private static void FileMove(string sourceFile, string destFile)
        {
            File.Move(sourceFile, destFile);
        }
    }
}
