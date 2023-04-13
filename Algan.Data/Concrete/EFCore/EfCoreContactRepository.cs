using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Data.Concrete.EFCore
{
    public class EfCoreContactRepository :
            EfCoreGenericRepository<Contact, AlganContext>, IContactRepository 
    {
        
    }
}