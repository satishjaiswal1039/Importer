using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Model;
using System.IO;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace Import.Parser
{
    public class CapterraParser : IParser
    {
        /// <summary>
        /// YML Parser and deserialize into Product 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IEnumerable<Product> Parse(string path)
        {
            //Implement YAML deserializer 
            IList<Product> products = null;
            if (Path.GetExtension(path) == ".yaml")
            {
                using (var reader = new StreamReader(path))
                {
                    var deserializer = new Deserializer();
                    var capterraProducts = (List<CapterraProduct>)deserializer.Deserialize(reader, typeof(List<CapterraProduct>));
                    products = new List<Product>();
                    foreach (var cp in capterraProducts)
                    {
                        var p = new Product() { Title = cp.name, Categories = cp.tags.Split(','), Twitter = cp.twitter };
                        products.Add(p);
                    }
                }
            }
            return products;
        }

        class CapterraProduct
        {
            public string tags { get; set; }  //Tags and Categories
            public string name { get; set; }       //Name and Title
            public string twitter { get; set; }     //Twitter
        }
    }
}
