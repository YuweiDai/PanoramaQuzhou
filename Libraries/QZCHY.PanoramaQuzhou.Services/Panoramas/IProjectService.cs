using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Services.Panoramas
{
    public interface IProjectService
    {
        Project GetProjectById(int id);

        void InsertProject(Project project);

        void UpdateProject(Project project);

        IQueryable<Project> GetTopProjects(int count = 5);

        IQueryable<Project> GetAllProjects();
    }
}
