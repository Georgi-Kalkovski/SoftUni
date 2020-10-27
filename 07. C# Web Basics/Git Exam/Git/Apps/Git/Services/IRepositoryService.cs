using Git.InputModels;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoryService
    {
        bool RepositoryNameExists(string repositoryName, string ownerId);
        void CreateRepository(CreateRepositoryInputModel inputModel);
        CreateCommitViewModel GetRepositoryNameAndId(string repositoryId);
        List<RepositoryViewModel> GetRepositoriesForUser(string userId);
    }
}
