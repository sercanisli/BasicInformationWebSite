using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Data.Concrete.EFCore
{
    public class EfCoreStreamRepository : 
            EfCoreGenericRepository<Stream, AlganContext>, IStreamRepository 

    {
        
    }
}