using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Model;
using System.IO;
using Newtonsoft.Json;

namespace Import.Parser
{
    public class SoftwareadviceParser : IParser
    {
        /// <summary>
        // Json parser and deserialize into Product
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IEnumerable<Product> Parse(string path)
        {
            IEnumerable<Product> products = null;
            if (Path.GetExtension(path) == ".json")
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    products = JsonConvert.DeserializeObject<SoftwareadviceProducts>(json).Products;
                }
            }
            return products;
        }

        public class SoftwareadviceProducts
        {
           public  List<Product> Products { get; set; }
        }
    }
}
