using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Data.Concrete.EFCore
{
    public class EfCoreVisionRepository : 
            EfCoreGenericRepository<Vision, AlganContext>, IVisionRepository
    {
        
    }
}