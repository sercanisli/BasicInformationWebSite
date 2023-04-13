using System.Collections.Generic;
using Algan.Entity;

namespace Algan.Business.Abstract
{
    public interface ISponsorService
    {
        List<Sponsor> GetAll();
        Sponsor GetByID (int id);
        void Create (Sponsor entity);
        void Update (Sponsor entity);
        void Delete (Sponsor entity);

    }
}