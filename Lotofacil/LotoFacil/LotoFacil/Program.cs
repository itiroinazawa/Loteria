using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoFacil
{
    class Program
    {
        static void Main(string[] args)
        {
            Combinacoes();
        }        

        public class Jogo 
        {
            public int primeiro { get; set; }
            public int segundo { get; set; }
            public int terceiro { get; set; }
            public int quarto { get; set; }
            public int quinto { get; set; }

            public Jogo(int p, int s, int t, int qua, int qui) 
            {
                primeiro = p;
                segundo = s;
                terceiro = t;
                quarto = qua;
                quinto = qui;
            }
        }

        public static List<Jogo> ListaLoto { get; set; }

        private static void Combinacoes()
        {
            ListaLoto = new List<Jogo>();

            List<int> array = new List<int>();
            int i = 0;

            Random r = new Random();
            int number = 0;

            for (i = 0; i < 24; i++)
            {
                number = r.Next(1, 26);

                if (i > 0)
                {
                    number = r.Next(1, 26);
                    while (true)
                    {
                        if (array.Count == 25)
                            break;

                        if (!array.ToList().Contains(number))
                        {
                            if (number > 0)
                            {
                                array.Add(number);
                                break;
                            }
                        }

                        number = r.Next(26);
                    }
                }
                else
                {
                    if (number > 0)
                    {
                        array.Add(number);
                    }
                }
            }

            int count = 0;

            List<Jogo> jogos = new List<Jogo>();
            
            string[] array0;
            string[] array1;
            string[] array2;
            //string[] array3;
            //string[] array4;

            string[] aux = new string[8];

            for (count = 0; count < 8; count++) 
            {
                aux[count] = array[count].ToString();
            }
            
            string[] ar1 = (string[])aux.Clone();            

            for (count = 8; count < 16; count++) 
            {
                aux[count - 8] = array[count].ToString();
            }

            string[] ar2 = (string[])aux.Clone();

            for (count = 16; count < 24; count++)
            {
                aux[count - 16] = array[count].ToString();
            }

            string[] ar3 = (string[])aux.Clone();
            
            string a1 = string.Join(";", ConcatenarArrays(ar1, ar2));
            string a2 = string.Join(";", ConcatenarArrays(ar1, ar3));
            string a3 = string.Join(";", ConcatenarArrays(ar2, ar3));
            
            string a4 = string.Join(";", ConcatenarArrays(ar1, ConcatenarInicioArray(ar2, ar3)));
            string a5 = string.Join(";", ConcatenarArrays(ar1, ConcatenarMeioArray(ar2, ar3)));
            string a6 = string.Join(";", ConcatenarArrays(ar1, ConcatenarFinalArray(ar2, ar3)));
            string a7 = string.Join(";", ConcatenarArrays(ar1, ConcatenarInicioMeioArray(ar2, ar3)));
            string a8 = string.Join(";", ConcatenarArrays(ar1, ConcatenarInicioFimArray(ar2, ar3)));
            string a9 = string.Join(";", ConcatenarArrays(ar1, ConcatenarInicioMeioArray(ar3, ar2)));
            string a10 = string.Join(";", ConcatenarArrays(ar1, ConcatenarInicioFimArray(ar3, ar2)));
            
            string a11 = string.Join(";", ConcatenarArrays(ar2, ConcatenarInicioArray(ar1, ar3)));
            string a12 = string.Join(";", ConcatenarArrays(ar2, ConcatenarMeioArray(ar1, ar3)));
            string a13 = string.Join(";", ConcatenarArrays(ar2, ConcatenarFinalArray(ar1, ar3)));
            string a14 = string.Join(";", ConcatenarArrays(ar2, ConcatenarInicioMeioArray(ar1, ar3)));
            string a15 = string.Join(";", ConcatenarArrays(ar2, ConcatenarInicioFimArray(ar1, ar3)));
            string a16 = string.Join(";", ConcatenarArrays(ar2, ConcatenarInicioMeioArray(ar3, ar1)));
            string a17 = string.Join(";", ConcatenarArrays(ar2, ConcatenarInicioFimArray(ar3, ar1)));

            string a18 = string.Join(";", ConcatenarArrays(ar3, ConcatenarInicioArray(ar1, ar2)));
            string a19 = string.Join(";", ConcatenarArrays(ar3, ConcatenarMeioArray(ar1, ar2)));
            string a20 = string.Join(";", ConcatenarArrays(ar3, ConcatenarFinalArray(ar1, ar2)));
            string a21 = string.Join(";", ConcatenarArrays(ar3, ConcatenarInicioMeioArray(ar1, ar2)));
            string a22 = string.Join(";", ConcatenarArrays(ar3, ConcatenarInicioFimArray(ar1, ar2)));
            string a23 = string.Join(";", ConcatenarArrays(ar3, ConcatenarInicioMeioArray(ar2, ar1)));
            string a24 = string.Join(";", ConcatenarArrays(ar3, ConcatenarInicioFimArray(ar2, ar1)));

            string a25 = string.Join(";", ConcatenarArrays(ar1, ConcatenarInicioFimInicioFimArray(ar2, ar3)));
            string a26 = string.Join(";", ConcatenarArrays(ar2, ConcatenarInicioFimInicioFimArray(ar1, ar3)));
            string a27 = string.Join(";", ConcatenarArrays(ar3, ConcatenarInicioFimInicioFimArray(ar2, ar3)));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Concat("Item 1: ", a1, ";"));
            sb.AppendLine(string.Concat("Item 2: ", a2, ";"));
            sb.AppendLine(string.Concat("Item 3: ", a3, ";"));
            sb.AppendLine(string.Concat("Item 4: ", a4, ";"));
            sb.AppendLine(string.Concat("Item 5: ", a5, ";"));
            sb.AppendLine(string.Concat("Item 6: ", a6, ";"));
            sb.AppendLine(string.Concat("Item 7: ", a7, ";"));
            sb.AppendLine(string.Concat("Item 8: ", a8, ";"));
            sb.AppendLine(string.Concat("Item 9: ", a9, ";"));
            sb.AppendLine(string.Concat("Item 10: ", a10, ";"));
            sb.AppendLine(string.Concat("Item 11: ", a11, ";"));
            sb.AppendLine(string.Concat("Item 12: ", a12, ";"));
            sb.AppendLine(string.Concat("Item 13: ", a13, ";"));
            sb.AppendLine(string.Concat("Item 14: ", a14, ";"));
            sb.AppendLine(string.Concat("Item 15: ", a15, ";"));
            sb.AppendLine(string.Concat("Item 16: ", a16, ";"));
            sb.AppendLine(string.Concat("Item 17: ", a17, ";"));
            sb.AppendLine(string.Concat("Item 18: ", a18, ";"));
            sb.AppendLine(string.Concat("Item 18: ", a19, ";"));
            sb.AppendLine(string.Concat("Item 18: ", a20, ";"));
            sb.AppendLine(string.Concat("Item 18: ", a21, ";"));
            sb.AppendLine(string.Concat("Item 18: ", a22, ";"));
            sb.AppendLine(string.Concat("Item 18: ", a23, ";"));
            sb.AppendLine(string.Concat("Item 18: ", a24, ";"));
            sb.AppendLine(string.Concat("Item 18: ", a25, ";"));
            sb.AppendLine(string.Concat("Item 18: ", a26, ";"));
            sb.AppendLine(string.Concat("Item 18: ", a27, ";"));
            gravarArquivo(sb.ToString());
            
        }

        private static void gravarArquivo(string texto)
        {
            //string path = @"C:\Users\Itiro Inazawa\Desktop\Jogos - Megasena\Jogo.txt";
            string path = @"C:\Users\r.inazawa.araujo\Desktop\Megasena\Jogo.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
                object lock1_ = new object();
                lock (lock1_)
                {
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine(texto);
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                object lock_ = new object();
                lock (lock_)
                {
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine(texto);
                    tw.Close();
                }
            }
        }

        private static string[] ConcatenarArrays(string[] array1, string[] array2) 
        {
            string[] a = new string[16];
            
            for (int i = 0; i < 8; i++) 
            {
                a[i] = array1[i];        
            }

            for (int i = 8; i < 16; i++) 
            {
                a[i] = array2[i - 8];
            }

            return a;
        }

        private static string[] ConcatenarInicioArray(string[] array1, string[] array2) 
        {
            string[] a = new string[8];

            for (int i = 0; i < 4; i++) 
            {
                a[i] = array1[i];
            }
            
            for (int i = 0; i < 4; i++)
            {
                a[i + 4] = array2[i];
            }

            return a;
        }

        private static string[] ConcatenarMeioArray(string[] array1, string[] array2) 
        {
            string[] a = new string[8];

            for (int i = 2; i < 6; i++) 
            {
                a[i - 2] = array1[i];
            }

            for (int i = 2; i < 6; i++)
            {
                a[i + 2] = array2[i];
            } 

            return a;
        }

        private static string[] ConcatenarFinalArray(string[] array1, string[] array2) 
        {
            string[] a = new string[8];

            for (int i = 4; i < 8; i++) 
            {
                a[i - 4] = array1[i];    
            }

            for (int i = 4; i < 8; i++)
            {
                a[i] = array2[i];
            }

            return a;
        }

        private static string[] ConcatenarInicioMeioArray(string[] array1, string[] array2) 
        {
            string[] a = new string[8];

            for (int i = 0; i < 4; i++)
            {
                a[i] = array1[i];
            }

            for (int i = 2; i < 6; i++)
            {
                a[i + 2] = array2[i];
            }

            return a;
        }

        private static string[] ConcatenarInicioFimArray(string[] array1, string[] array2)
        {
            string[] a = new string[8];

            for (int i = 0; i < 4; i++)
            {
                a[i] = array1[i];
            }

            for (int i = 4; i < 8; i++)
            {
                a[i] = array2[i];
            }

            return a;
        }

        private static string[] ConcatenarInicioFimInicioFimArray(string[] array1, string[] array2)
        {
            string[] a = new string[8];

            for (int i = 0; i < 2; i++)
            {
                a[i] = array1[i];
            }

            for (int i = 5; i < 7; i++)
            {
                a[i - 3] = array1[i];
            }

            for (int i = 0; i < 2; i++)
            {
                a[i + 4] = array2[i];
            }

            for (int i = 5; i < 7; i++)
            {
                a[i + 1] = array2[i];
            }

            return a;
        }
    }
}
