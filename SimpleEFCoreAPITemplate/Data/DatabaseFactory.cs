using Microsoft.EntityFrameworkCore;
using SimpleEFCoreAPITemplate.Data.Interfaces;

namespace SimpleEFCoreAPITemplate.Data
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private DBCtx _context;
        public DatabaseFactory(DBCtx context) { _context = context; }
        public DBCtx GetContext()
        {
            return _context;
        }
    }
}
