using DefaultProject.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultProject.Infra.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultContext _context;        

        public UnitOfWork(DefaultContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
