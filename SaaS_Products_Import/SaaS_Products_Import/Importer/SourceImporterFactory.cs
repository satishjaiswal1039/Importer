using Import.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Importer
{
    public class SourceImporterFactory
    {
        public ISourceImporter GetSourceProvider(string sourceType, string sourcePath)
        {
            //which type of database do you want to use, please provide the name in the app.config file Like MySql, MongoDB etc in the dbType key value...
            string dbType = System.Configuration.ConfigurationManager.AppSettings["DbType"];
            DatabaseFactory dbfactory = new DatabaseFactory();
            IDatabase db = dbfactory.GetDatabase(dbType);

            switch (sourceType)
            {
                case "capterra":
                    return new CapterraSourceImporter(sourcePath, db);
                case "softwareadvice":
                    return new SoftwareadviceSourceImporter(sourcePath, db); 
                    //To add new sources type like csv file or other, only need to add that type of importer here... 
                default:
                    return null;
            }
        }
    }
}
