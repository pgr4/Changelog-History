namespace Changelog_History.Managers.Interfaces
{
    public interface IGitManager
    {
        void PullGitHistoryFromTagToTag(string project, string fromTag, string toTag);

        // METHOD TO MOVE COMMIT TO CATEGORY
    }
}