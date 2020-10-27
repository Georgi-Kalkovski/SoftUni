using Git.InputModels;
using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;
        public RepositoriesController(RepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            var allRepositoriesViewModel = this.repositoryService.GetRepositoriesForUser(this.GetUserId());
            return this.View(allRepositoriesViewModel);
        }

        public HttpResponse Create()
        {
            if(this.IsUserSignedIn() == false)
            {
                return this.Error("Only signed in users can create a repository");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoryInputModel inputModel)
        {
            if (this.IsUserSignedIn() == false)
            {
                return this.Error("Only signed in users can create a repository");
            }

            if(string.IsNullOrEmpty(inputModel.Name) || inputModel.Name.Length < 3 || inputModel.Name.Length > 10)
            {
                return this.Error("Repository name should be between 3 and 10 characters long.");
            }

            this.repositoryService.CreateRepository(inputModel);

            return this.Redirect("/Repositories/All");
        }
    }
}
