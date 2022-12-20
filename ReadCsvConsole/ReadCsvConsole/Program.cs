using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            Task<string[]> task1 = Method1();
            Task<string[]> task2 = Method2();
            Task<string[]> task3 = Method3();
            StringBuilder strHtml = new StringBuilder();
            foreach(string line in await task1)
            {
                strHtml.Append(line);
            }
            foreach (string line in await task2)
            {
                strHtml.Append(line);
            }
            foreach (string line in await task3)
            {
                strHtml.Append(line);
            }
          
            Console.ReadLine();

        }

        public static async Task<string[]> Method1()
        {
            string[] lines = null;
            await Task.Run(() =>
            {
                string path = (@"C:\Users\janvi\Documents\ExcelDemos\ReadCsvConsole\ExcelFiles\Employee_Janvi_1.csv");
                lines = System.IO.File.ReadAllLines(path);
                
                foreach (string line in lines)
                {
                    Console.WriteLine("Employee_Janvi_1 => " + line);
                    Console.WriteLine();                   
                }
                
            });
            return lines;
        }

        public static async Task<string[]> Method2()
        {
            string[] lines = null;
            await Task.Run(() =>
            {
                string path = (@"C:\Users\janvi\Documents\ExcelDemos\ReadCsvConsole\ExcelFiles\Employee_Janvi_2.csv");
                lines = System.IO.File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    Console.WriteLine("Employee_Janvi_2 => " + line);
                    Console.WriteLine();
                    
                }

            });
            return lines;
        }

        public static async Task<string[]> Method3()
        {
            string[] lines = null;
            await Task.Run(() =>
            {
                string path = (@"C:\Users\janvi\Documents\ExcelDemos\ReadCsvConsole\ExcelFiles\Employee_Janvi_3.csv");
                lines = System.IO.File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    Console.WriteLine("Employee_Janvi_3 => " + line);
                    Console.WriteLine();  
                }

            });
            return lines;
        }

        public static void GenerateFile(string filepath, ref StringBuilder builder)
        {
            using (FileStream fs = new FileStream(filepath, FileMode.Append))
            {
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(builder.ToString());
                sw.Flush();
                sw.Close();
            }
        }
    }
}
