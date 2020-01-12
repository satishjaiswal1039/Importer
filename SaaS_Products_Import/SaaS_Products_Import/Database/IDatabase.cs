using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Database
{
    public interface IDatabase
    {
        int ExecuteNonQuery(string query, IDbDataParameter[] dbParams);
        object ExecuteScalar(string query, IDbDataParameter[] dbParams);
        IDataReader ExecuteReader(string query, IDbDataParameter[] dbParams);


    }
}
