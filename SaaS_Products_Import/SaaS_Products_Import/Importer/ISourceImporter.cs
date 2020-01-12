using Import.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Importer
{
    public interface ISourceImporter
    {
        void ImportData();
    }
}
