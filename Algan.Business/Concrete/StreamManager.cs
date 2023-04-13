using System.Collections.Generic;
using Algan.Business.Abstract;
using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Business.Concrete
{
    public class StreamManager : IStreamService
    {
        private IStreamRepository _streamRepository;
        public StreamManager (IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }
        public void Create(Stream entity)
        {
            _streamRepository.Create(entity);
        }

        public void Delete(Stream entity)
        {
            _streamRepository.Delete(entity);
        }

        public List<Stream> GetAll()
        {
            return _streamRepository.GetAll();
        }

        public Stream GetByID(int id)
        {
            return _streamRepository.GetByID(id);
        }

        public void Update(Stream entity)
        {
            _streamRepository.Update(entity);
        }
         
    }
}