using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultProject.Infra.Data.Transactions
{
    public interface IUnitOfWork
    {
        bool Commit();        
    }
}
