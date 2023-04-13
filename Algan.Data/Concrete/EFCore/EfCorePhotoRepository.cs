using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Data.Concrete.EFCore
{
    public class EfCorePhotoRepository : 
            EfCoreGenericRepository<Photo, AlganContext>, IPhotoRepository
    {
        
    }
}