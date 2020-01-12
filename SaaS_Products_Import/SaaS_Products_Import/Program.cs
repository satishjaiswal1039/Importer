using Import.Importer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                string sourceName = args[0];
                string sourcePath = args[1];
                SourceImporterFactory provider = new SourceImporterFactory();
                ISourceImporter sp = provider.GetSourceProvider(sourceName.ToLower(), sourcePath.ToLower());
                if (sp == null)
                {
                    Console.WriteLine("For now this system supports only two sources capterra and softwareadvice");
                    return;
                }
                sp.ImportData();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You are providing wrong arguments. Please pass two parameters one is source name and other is source path....");
                return;
            }
        }
    }
}
