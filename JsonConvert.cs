using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    internal class JsonConverter
    {
        public void Serialize(string PathForSave, List<Figure> list)
        {
            File.WriteAllText(PathForSave, JsonConvert.SerializeObject(list));
        }
        public List<Figure> Deserialize(string PathToFile)
        {
            return JsonConvert.DeserializeObject<List<Figure>>(File.ReadAllText(PathToFile));
        }

    }
}
