using System.Collections.Generic;
using Algan.Business.Abstract;
using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Business.Concrete
{
    public class MissionManager : IMissionService
    {
        private IMissionRepository _missionRepository;
        public MissionManager(IMissionRepository missionRepository)
        {
            _missionRepository=missionRepository;
        }
        public void Create(Mission entity)
        {
            _missionRepository.Create(entity);
        }

        public void Delete(Mission entity)
        {
            _missionRepository.Delete(entity);
        }

        public List<Mission> GetAll()
        {
            return _missionRepository.GetAll();
        }

        public Mission GetByID(int id)
        {
            return _missionRepository.GetByID(id);
        }

        public void Update(Mission entity)
        {
            _missionRepository.Update(entity);
        }
    }
}