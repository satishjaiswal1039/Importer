using Import.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Parser
{
    public interface IParser
    {
        IEnumerable<Product> Parse(string path);
    }
}
