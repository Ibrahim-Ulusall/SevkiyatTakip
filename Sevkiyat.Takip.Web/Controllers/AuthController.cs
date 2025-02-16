using Microsoft.AspNetCore.Mvc;
using Sevkiyat.Takip.Core.Models.Auths;

namespace Sevkiyat.Takip.Web.Controllers;
public class AuthController : Controller
{
    public async Task<IActionResult> Login()
    {
        LoginModel model = new LoginModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        return View();
    }


    public async Task<IActionResult> ForgotPassword()
    {
        return View();
    }

    public async Task<IActionResult> TwoFactorSteps()
    {
        return View();
    }
}
