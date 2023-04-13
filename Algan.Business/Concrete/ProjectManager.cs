using System.Collections.Generic;
using Algan.Business.Abstract;
using Algan.Data.Abstract;
using Algan.Entity;


namespace Algan.Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        private IProjectRepository _projectRepository; 
        public ProjectManager(IProjectRepository projectRepository)
        {
            _projectRepository=projectRepository;
        }
        public void Create(Project entity)
        {
            _projectRepository.Create(entity);
        }

        public void Delete(Project entity)
        {
            _projectRepository.Delete(entity);
        }

        public List<Project> GetAll()
        {
            return _projectRepository.GetAll();
        }

        public Project GetByID(int id)
        {
            return _projectRepository.GetByID(id);
            
        }

        public void Update(Project entity)
        {
            _projectRepository.Update(entity);
        }
    }
}