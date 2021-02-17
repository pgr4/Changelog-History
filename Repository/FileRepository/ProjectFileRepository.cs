using System.Collections.Generic;
using System.Linq;
using Changelog_History.Models;
using Changelog_History.Repository.Interfaces;

namespace Changelog_History.Repository.FileRepository
{
    public class ProjectFileRepository : BaseFileRepository<Project>, IProjectRepository
    {
        protected override string FileName { get {return "project-repository.txt"; } }

        public Project Get(string name)
        {
            return GetAll()?.FirstOrDefault(t => t.Name == name);
        }
    }
}