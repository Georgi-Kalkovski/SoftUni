using Git.Data;
using Git.InputModels;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext context;
        public RepositoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public CreateCommitViewModel GetRepositoryNameAndId(string repositoryId)
        {
            return new CreateCommitViewModel()
            {
                Id = repositoryId,
                RepositoryName = this.context.Repositories.FirstOrDefault(x => x.Id == repositoryId).Name
            };
        }

        public void CreateRepository(CreateRepositoryInputModel inputModel)
        {
            var newRepository = new Repository
            {
                Name = inputModel.Name,
                CreatedOn = DateTime.Now,
                OwnerId = inputModel.OwnerId,
                Id = Guid.NewGuid().ToString(),
                IsPublic = inputModel.RepositoryType == "Public" ? true : false,
            };
            this.context.Repositories.Add(newRepository);
            this.context.SaveChanges();
        }

        public bool RepositoryNameExists(string repositoryName, string ownerId)
        {
            return this.context.Repositories.Any(x => x.Name == repositoryName && x.OwnerId == ownerId);
        }

        public List<RepositoryViewModel> GetRepositoriesForUser(string userId)
        {
            var allRepositories = this.context.Repositories
                .Where(x => x.OwnerId == userId || x.IsPublic == true)
                .OrderByDescending(x => x.OwnerId == userId)
                .ThenByDescending(x => x.CreatedOn)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedOn = x.CreatedOn.ToString(),
                    CommitsCount = x.Commits.Count,
                    OwnerName = x.Owner.Username
                }).ToList();
            return allRepositories;
        }
    }
}
