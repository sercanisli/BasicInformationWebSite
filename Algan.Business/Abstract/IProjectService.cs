using System.Collections.Generic;
using Algan.Entity;

namespace Algan.Business.Abstract
{
    public interface IProjectService
    {
        List<Project> GetAll();
        Project GetByID (int id);
        void Create (Project entity);
        void Update (Project entity);
        void Delete (Project entity);
    }
}