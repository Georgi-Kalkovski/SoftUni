using Git.Data;
using Git.InputModels;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitService : ICommitService
    {
        private readonly ApplicationDbContext context;
        public CommitService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool CommitFromUserExists(string commitId, string userId)
        {
            return this.context.Commits.Any(x => x.Id == commitId && x.CreatorId == userId);
        }

        public void CreateCommit(CreateCommitInputModel inputModel)
        {
            var newCommit = new Commit
            {
                CreatedOn = DateTime.Now,
                CreatorId = inputModel.CreatorId,
                Description = inputModel.Description,
                Id = Guid.NewGuid().ToString(),
                RepositoryId = inputModel.RepositoryId,
            };
            this.context.Commits.Add(newCommit);
            this.context.SaveChanges();
        }

        public void DeleteCommit(string commitId)
        {
            var deletedCommit = this.context.Commits.FirstOrDefault(x => x.Id == commitId);
            this.context.Commits.Remove(deletedCommit);
            this.context.SaveChanges();
        }

        public List<CommitViewModel> GetAllCommitsForUser(string userId)
        {
            var allCommits = this.context.Commits
                .Where(x => x.CreatorId == userId)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new CommitViewModel
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn.ToString(),
                    Description = x.Description,
                    Repository = x.Repository.Name
                }).ToList();
            return allCommits;
        }
    }
}
