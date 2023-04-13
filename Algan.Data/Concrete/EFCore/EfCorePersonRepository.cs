using System.Collections.Generic;
using System.Linq;
using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Data.Concrete.EFCore
{
    public class EfCorePersonRepository : 
            EfCoreGenericRepository<Person, AlganContext>, IPersonRepository
    {
       
    }
}