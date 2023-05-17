using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfExam.Classes
{
    public class ClassLibary
    {
        //        o фамилия и инициалы;
        //        o номер группы;
        //        o успеваемость по пяти предметам(пять полей целого типа).
        string fio;
        int nambers;
        string performance1;
        string performance2;
        string performance3;
        string performance4;
        string performance5;
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }
        public int Nambers
        {
            get { return nambers; }
            set { nambers = value; }
        }
        public string Performance1
        {
            get { return performance1; }
            set { performance1 = value; }
        }
        public string Performance2
        {
            get { return performance2; }
            set { performance2 = value; }
        }
        public string Performance3
        {
            get { return performance3; }
            set { performance3 = value; }
        }
        public string Performance4
        {
            get { return performance4; }
            set { performance4 = value; }
        }
        public string Performance5
        {
            get { return performance5; }
            set { performance5 = value; }
        }
        public ClassLibary()
        {
            fio = string.Empty;
            nambers = 0;
            performance1 = string.Empty;
            performance2 = string.Empty;
            performance3 = string.Empty;
            performance4 = string.Empty;
            performance5 = string.Empty;
        }
        public ClassLibary(string f, int n, string p1, string p2, string p3, string p4, string p5)
        {
            fio = f;
            nambers = n;
            performance1 = p1;
            performance2 = p2;
            performance3 = p3;
            performance4 = p4;
            performance5 = p5;
        }
    }
   
}
