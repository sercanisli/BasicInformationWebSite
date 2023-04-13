using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Data.Concrete.EFCore
{
    public class EfCoreAboutUsRepository :
            EfCoreGenericRepository<AboutUs, AlganContext>, IAboutUsRepository 
    {
        
    }
}