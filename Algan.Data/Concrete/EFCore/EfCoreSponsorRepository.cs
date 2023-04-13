using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Data.Concrete.EFCore
{
    public class EfCoreSponsorRepository :
            EfCoreGenericRepository<Sponsor, AlganContext>, ISponsorRepository
    {
        
    }
}