using Changelog_History.Managers.Interfaces;
using Microsoft.Extensions.Logging;

namespace Changelog_History.Managers
{
    public class GitManager : BaseManager, IGitManager
    {
        private readonly IMainManager _mainManager;
        
        public GitManager(ILogger logger, IMainManager mainManager) : base(logger)
        {
            _mainManager = mainManager;
        }

        public void PullGitHistoryFromTagToTag(string project, string fromTag, string toTag)
        {
            _mainManager.GetContext(project);
        }
    }
}