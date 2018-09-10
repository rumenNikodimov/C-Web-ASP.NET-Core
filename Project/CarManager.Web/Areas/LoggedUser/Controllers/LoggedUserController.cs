using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarManager.Web.Areas.LoggedUser.Controllers
{
    [Area("LoggedUser")]
    [Authorize]
    public class LoggedUserController : Controller
    {
        
    }
}