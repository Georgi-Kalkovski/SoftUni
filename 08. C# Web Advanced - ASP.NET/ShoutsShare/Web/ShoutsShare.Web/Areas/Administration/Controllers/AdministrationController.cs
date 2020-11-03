namespace ShoutsShare.Web.Areas.Administration.Controllers
{
    using ShoutsShare.Common;
    using ShoutsShare.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
