using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Data.Concrete.EFCore
{
    public class EfCoreProjectRepository : 
            EfCoreGenericRepository<Project, AlganContext>, IProjectRepository

    {
        
    }
}