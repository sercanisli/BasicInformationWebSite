using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Data.Concrete.EFCore
{
    public class EfCoreFooterRepository :
            EfCoreGenericRepository<Footer, AlganContext>, IFooterRepository 

    {
        
    }
}