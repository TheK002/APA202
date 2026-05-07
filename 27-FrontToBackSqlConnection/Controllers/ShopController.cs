using _27_FrontToBackSqlConnection.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class ShopController : Controller
    {
        private readonly IEmailService _emailService;
        public ShopController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public EmailService EmailService { get; }

        public IActionResult Index()
        {
            _emailService.SendEmail();

            return View();
        }
    }
}
