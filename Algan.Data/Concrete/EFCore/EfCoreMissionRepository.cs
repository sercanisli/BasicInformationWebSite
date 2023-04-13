using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Data.Concrete.EFCore
{
    public class EfCoreMissionRepository :
            EfCoreGenericRepository<Mission, AlganContext>, IMissionRepository 

    {
        
    }
}