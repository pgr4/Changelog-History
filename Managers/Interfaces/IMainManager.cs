using System.Collections.Generic;
using Changelog_History.Models;

namespace Changelog_History.Managers.Interfaces
{
    public interface IMainManager
    {
        Project GetContext(string projectName);
        void AddCategory(string projectName, string categoryName);
        void AddProject(string projectName);
        Project ReadProject(string projectName);
        IEnumerable<Project> ReadProjects();
    }
}