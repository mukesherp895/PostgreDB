using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreDB.DataAccess.Infrastructures
{
    public interface IDBFactory
    {
        PostgreDBContext GetDBContext();
    }

    public class DBFactory : IDBFactory
    {
        private readonly PostgreDBContext _dbContext;

        public DBFactory(PostgreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public PostgreDBContext GetDBContext()
        {
            return _dbContext;
        }
    }
}
