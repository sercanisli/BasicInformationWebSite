using System.Collections.Generic;
using Algan.Business.Abstract;
using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Business.Concrete
{
    public class SponsorManager : ISponsorService
    {
        private ISponsorRepository _sponsorRepository;
        public SponsorManager (ISponsorRepository sponsorRepository)
        {
            _sponsorRepository=sponsorRepository;
        }
        public void Create(Sponsor entity)
        {
            _sponsorRepository.Create(entity);
        }

        public void Delete(Sponsor entity)
        {
            _sponsorRepository.Delete(entity);
        }

        public List<Sponsor> GetAll() 
        {
            return _sponsorRepository.GetAll();
        }

        public Sponsor GetByID(int id)
        {
            return _sponsorRepository.GetByID(id);
        }

        public void Update(Sponsor entity)
        {
            _sponsorRepository.Update(entity);
        }
    }
}