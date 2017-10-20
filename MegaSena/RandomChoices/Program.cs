using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChoices
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
            public int terceira { get; set; }
            public int quarta { get; set; }
            public int quinta { get; set; }
            public int sexta { get; set; }

            public Jogo(int p, int s, int t, int qa, int qi, int se)
            {
                primeiro = p;
                segundo = s;
                terceira = t;
                quarta = qa;
                quinta = qi;
                sexta = se;
            }
        }

        private static void Combinacoes()
        {
            List<int> array = new List<int>();
            int i = 0;

            Random r = new Random();
            int number = 0;

            for (i = 0; i < 60; i++)
            {
                number = r.Next(1, 61);

                if (i > 0)
                {
                    number = r.Next(1, 61);
                    while (true)
                    {
                        if (array.Count == 60)
                            break;

                        if (!array.ToList().Contains(number))
                        {
                            if (number > 0)
                            {
                                array.Add(number);
                                break;
                            }
                        }

                        number = r.Next(61);
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

            //array.Sort();
            List<Jogo> jogos = new List<Jogo>();
            int[] arrayx = new int[6];

            int[] array1 = new int[6];
            int[] array2 = new int[6];
            int counter = 0;
            int final = 12;

            for (int z = 0; z < 5; z++)
            {
                i = 0;

                for (counter = counter; counter < final; counter++)
                {
                    if (i < 6) { array1[i] = array[counter]; }
                    else if (i < 12) { array2[i - 6] = array[counter]; }
                    i++;
                }

                
                final = final + 12;

                Array.Sort(array1);
                Array.Sort(array2);

                int n = 0;
                int o = 0;
                //int xy = 6;

                for (n = 0; n < 6; n++)
                {
                    for (o = 0; o < 6; o++)
                    {
                        Jogo j = adicionar(array1, array2, 5 - n, o);
                        jogos.Add(j);
                    }

                    //array1[5 - (xy - 1)] = array2[5 - (xy - 1)];
                    //xy -= 1;
                }

                for (n = 0; n < 6; n++)
                {
                    for (o = 0; o < 6; o++)
                    {
                        Jogo j = adicionar(array2, array1, 5 - n, o);
                        jogos.Add(j);
                    }

                    //array1[5 - (xy - 1)] = array2[5 - (xy - 1)];
                    //xy -= 1;
                }
            }

            Console.WriteLine("Quantidade de jogos: " + jogos.Count.ToString());

            StringBuilder sb = new StringBuilder();
            sb.Append("Numeros: ");
            for (int op = 0; op < array.Count; op++)
            {
                sb.Append(array[op].ToString() + " ");
            }
            sb.AppendLine(" ");

            jogos.OrderBy(x => x.primeiro).ThenBy(x => x.segundo).ThenBy(x => x.terceira).ThenBy(x => x.quarta).ThenBy(x => x.quinta).ThenBy(x => x.sexta);

            for (int z = 0; z < jogos.Count; z++)
            {
                sb.Append(string.Concat("Jogo: ", (z + 1).ToString().PadLeft(2, '0'), " - "));
                sb.Append(" " + jogos[z].primeiro.ToString() + " ");
                sb.Append(jogos[z].segundo.ToString() + " ");
                sb.Append(jogos[z].terceira.ToString() + " ");
                sb.Append(jogos[z].quarta.ToString() + " ");
                sb.Append(jogos[z].quinta.ToString() + " ");
                sb.AppendLine(jogos[z].sexta.ToString() + " ");
            }

            gravarArquivo(sb.ToString());

            Console.ReadKey();
        }

        private static Jogo adicionar(int[] arrayPadrao, int[] arrayNova, int variavelFixa, int variavelSubstituir)
        {
            int[] arrayAux = (int[])arrayPadrao.Clone();
            arrayAux[variavelFixa] = arrayNova[variavelSubstituir];
            Array.Sort(arrayAux);
            Jogo j = new Jogo(arrayAux[0], arrayAux[1], arrayAux[2], arrayAux[3], arrayAux[4], arrayAux[5]);
            return j;
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
    }


}
