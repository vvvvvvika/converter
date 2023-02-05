using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TextConvert
    {
        public void Serialize(string PathForSave, List<Figure> list)
        {
            string TextFile="";
            foreach(var element in list)
            {
                TextFile = element.Name + "\n" + element.Height + "\n" + element.Wight + "\n";
            }
            File.WriteAllText(PathForSave,TextFile);
        }
        public List<Figure> Deserialize(string PathToFile)
        {
            Console.Clear();
            List<Figure> list = new List<Figure>();
            List<string> str = File.ReadAllText(PathToFile).Split().ToList();
            str.RemoveAt(str.Count() - 1);
            for (int i = 0; i < str.Count; i += 3)
            {
                list.Add(new Figure
                {
                    Name = str[i],
                    Height = Convert.ToInt32(str[i + 1]),
                    Wight = Convert.ToInt32(str[i + 2]),
                });
            }
            return list;
        }
    }
}
