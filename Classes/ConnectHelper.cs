using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfExam.Classes
{
    class ConnectHelper
    {
        public static List<ClassLibary> performances = new List<ClassLibary> ();
        public static string fileName;
        public static void ReadListFromFile(string filename)
        {
            try
            {
                StreamReader sr = new StreamReader(filename, Encoding.UTF8);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] items = line.Split(';');
                    ClassLibary performanc = new ClassLibary()
                    {
                        Fio = items[0].Trim(),
                        Nambers = int.Parse(items[1].Trim()),
                        Performance1 = string.Concat(items[2].Trim()),
                        Performance2 = string.Concat(items[3].Trim()),
                        Performance3 = string.Concat(items[4].Trim()),
                        Performance4 = string.Concat(items[5].Trim()),
                        Performance5 = string.Concat(items[6].Trim())
                    };
                    performances.Add(performanc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", "Неверный формат данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        public static void SaveListToFile(string filename)
        {
            StreamWriter streamWriter = new StreamWriter(filename, false, Encoding.UTF8);
            foreach(var item in performances)
            {
                streamWriter.WriteLine($"{item.Fio}; {item.Nambers}; {item.Performance1}; {item.Performance2}; {item.Performance3}; {item.Performance4}; {item.Performance5}; ");
            }
            streamWriter.Close();
        }
        public static List<int> namberses = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32
        };
    }
}
