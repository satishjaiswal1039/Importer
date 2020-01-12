using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Database
{
    public class DatabaseFactory
    {
        /// <summary>
        /// On the basis of what parameter have you passed it provide that type od database object.
        /// </summary>
        /// <param name="dbType">MySql or MongoDB</param>
        /// <returns></returns>
        public IDatabase GetDatabase( string dbType)
        {
            IDatabase db=null;
            switch (dbType)
            {
                case "MySql":
                    db = new MySqlDatabse();
                    break;
                case "MongoDB":
                    db = new MongoDatabase();
                    break;
                    //if there is need any other database type then prvoide that type of database object 
            }
            return db;
        }
    }
}
