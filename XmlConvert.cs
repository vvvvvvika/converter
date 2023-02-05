using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    internal class XmlConverter
    {
        public void Serelialize(string PathForSave, List<Figure> list)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
            using (FileStream fs = new FileStream(PathForSave, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, list);
            }
        }
        public List<Figure> Deserialize(string PathToFile)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
            using(FileStream fs = new FileStream(PathToFile, FileMode.Open))
            {
                return (List<Figure>)xml.Deserialize(fs);
            }
        }
    }
}
