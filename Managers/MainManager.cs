using System.Collections.Generic;
using Changelog_History.Managers.Interfaces;
using Changelog_History.Models;
using Changelog_History.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Changelog_History.Managers
{
    public class MainManager : BaseManager, IMainManager
    {
        private readonly IProjectRepository _projectRepository;
        public MainManager(ILogger<IMainManager> logger, IProjectRepository projectRepository) : base(logger)
        {
            _projectRepository = projectRepository;
        }
        
        public Project GetContext(string projectName)
        {
            return _projectRepository.Get(projectName);
        }

        public void AddCategory(string projectName, string categoryName)
        {
            Project project = GetContext(projectName);
        }

        public void AddProject(string projectName)
        {
            _projectRepository.Add(new Project 
            {
                Name = projectName
            });
        }

        public Project ReadProject(string projectName)
        {
            return _projectRepository.Get(projectName);
        }

        public IEnumerable<Project> ReadProjects()
        {
            return _projectRepository.GetAll();
        }
    }
}