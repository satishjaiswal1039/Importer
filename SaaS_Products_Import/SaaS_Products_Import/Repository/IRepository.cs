using Import.Database;
using Import.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Repository
{
    public interface IRepository
    {
        int Import(Product db);
    }
}
