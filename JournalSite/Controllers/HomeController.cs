using JournalSite.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JournalSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;
        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.PostItems.GetPostItems());
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult Requirements()
        {
            return View();
        }
        public IActionResult Numbers(Guid Id)
        {
            return View(_dataManager.ArchiveNumbers.GetAllById(Id));
        }
        public IActionResult Archive()
        {
            return View(_dataManager.ArchiveYears.GetAllYears());
        }
    }
}
