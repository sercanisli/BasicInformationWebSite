using System.Collections.Generic;
using Algan.Business.Abstract;
using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Business.Concrete
{
    public class PhotoManager : IPhotoService 
    {
        private IPhotoRepository _photoRepository; 
        public PhotoManager(IPhotoRepository photoRepository)
        {
            _photoRepository=photoRepository;
        }
        public void Create(Photo entity)
        {
            _photoRepository.Create(entity);
        }

        public void Delete(Photo entity)
        {
            _photoRepository.Delete(entity);
        }

        public List<Photo> GetAll()
        {
            return _photoRepository.GetAll();
        }

        public Photo GetByID(int id)
        {
            return _photoRepository.GetByID(id);
        }

        public void Update(Photo entity)
        {
            _photoRepository.Update(entity);
        }
    }
}