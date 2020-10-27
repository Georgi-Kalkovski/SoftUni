using Git.InputModels;
using Git.ViewModels;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitService
    {
        List<CommitViewModel> GetAllCommitsForUser(string userId);
        void CreateCommit(CreateCommitInputModel inputModel);
        void DeleteCommit(string commitId);
        bool CommitFromUserExists(string commitId, string userId);
    }
}