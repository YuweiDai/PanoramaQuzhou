using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QZCHY.PanoramaQuzhou.Core.Data;
using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Services.Events;

namespace QZCHY.PanoramaQuzhou.Services.Panoramas
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projectRepository;
        private readonly IEventPublisher _eventPublisher;

        public ProjectService(IRepository<Project> projectRepository, IEventPublisher eventPublisher)
        {
            this._projectRepository = projectRepository;
            this._eventPublisher = eventPublisher;
        }


        public IQueryable<Project> GetTop5Projects()
        {
            var query = from p in _projectRepository.TableNoTracking
                        where !p.Deleted                    
                        select p;

            query = query.OrderBy(p => p.Order).Take(5);

            return query;
        }


        public IQueryable<Project> GetAllProjects()
        {
            var query = from p in _projectRepository.TableNoTracking
                        where !p.Deleted
                        select p;

            query = query.OrderBy(p => p.Order);

            return query;
        }


        public Project GetProjectById(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project.Deleted) return null;

            return project;
        }


        public void InsertProject(Project project)
        {
            if (project == null) throw new ArgumentNullException("Project");
            else
            {
                _projectRepository.Insert(project);
                _eventPublisher.EntityInserted(project);
            }
        }
    }
}
