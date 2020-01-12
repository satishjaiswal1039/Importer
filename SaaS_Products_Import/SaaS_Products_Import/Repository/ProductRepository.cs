using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Database;
using Import.Model;

namespace Import.Repository
{
    class ProductRepository : IRepository
    {
        IDatabase _db;
        public ProductRepository( IDatabase db)
        {
            _db = db;
        }
        public int Import(Product product)
        {
            int noOfRowImported = 0;
            //
            //TODO
            //
            noOfRowImported = _db.ExecuteNonQuery("Import",new System.Data.IDbDataParameter[] { /*...*/ });
            return noOfRowImported;
        }
    }
}
