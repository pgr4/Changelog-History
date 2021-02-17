using Microsoft.Extensions.Logging;

namespace Changelog_History.Managers
{
    public class BaseManager
    {
        protected ILogger Logger;
        public BaseManager(ILogger logger)
        {
            Logger = logger;
        }
    }
}