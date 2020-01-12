using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Database
{
    class MySqlDatabse : IDatabase
    {
        public int ExecuteNonQuery(string query, IDbDataParameter[] dbParams)
        {
            int rowaffect=0;
            //Write a mysql command, connection and transaction 

            return rowaffect;
        }

        public IDataReader ExecuteReader(string query, IDbDataParameter[] dbParams)
        {
            IDataReader reader = null;
            //Write a mysql command, connection 

            return reader;
        }

        public object ExecuteScalar(string query, IDbDataParameter[] dbParams)
        {
            object value = 0;
            //Write a mysql command, connection and transaction 

            return value;
        }
    }
}
