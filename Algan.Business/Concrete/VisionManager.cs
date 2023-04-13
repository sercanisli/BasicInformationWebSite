using System.Collections.Generic;
using Algan.Business.Abstract;
using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Business.Concrete
{
    public class VisionManager : IVisionService
    {
        private IVisionRepository _visionRepository;
        public VisionManager(IVisionRepository visionRepository)
        {
            _visionRepository=visionRepository;
        }
        public void Create(Vision entity)
        {
            _visionRepository.Create(entity);
        }

        public void Delete(Vision entity)
        {
            _visionRepository.Delete(entity);
        }

        public List<Vision> GetAll()
        {
            return _visionRepository.GetAll();
        }

        public Vision GetByID(int id)
        {
            return _visionRepository.GetByID(id);
        }

        public void Update(Vision entity)
        {
            _visionRepository.Update(entity);
        }
    }
}