using Microsoft.AspNetCore.Mvc;

namespace MVC_Core_UI_Layer.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
