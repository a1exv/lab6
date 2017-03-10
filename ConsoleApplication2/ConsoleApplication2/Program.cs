using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication23
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = @"E:/Programms/step/c3/OSPR_C__Zadanie_LZ_Day6_2.txt";
            StreamReader sr = new StreamReader(path, Encoding.Default);
            List<string> listString = new List<string>();
            string str = sr.ReadToEnd();
            Console.WriteLine(str);
            int startIndex = str.IndexOf("Вот дом");
            int lastIndex = str.IndexOf("Рисунок 1");
            char[] task = new char[lastIndex - startIndex];
            str.CopyTo(startIndex, task, 0, (lastIndex - startIndex));
            String Task = new String(task);
            for(int i=0; i<Task.Length; i++){

                if ((Task[i] == ' ') || (Task[i] == '\n') || (Task[i] == '.') && (Task[i] == ',')) continue;
                else
                {
                    string tmp = Task[i].ToString();
                    i++;
                    while ((Task[i] != ' ') && (Task[i] != '\n') && (Task[i] != ',') && (Task[i] != '.'))
                    {
                        tmp += Task[i];
                        i++;
                    }
                    listString.Add(tmp);
                }
            }
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for(int i=0; i<listString.Count; i++){
                if (dict.ContainsKey(listString[i]))
                {
                    dict[listString[i]]++;
                }
                else
                {
                    dict.Add(listString[i], 1);
                }
            }
            foreach(KeyValuePair<string, int> tmp in dict)
            {
                Console.WriteLine(tmp);
            }
        }
    }
}
