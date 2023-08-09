using JournalSite.Data;
using Microsoft.AspNetCore.Mvc;

namespace JournalSite.Controllers
{
    public class PostsController : Controller
    {
        private readonly DataManager _dataManager;
        public PostsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            return View("Show", _dataManager.PostItems.GetPostItemById(id));
        }
    }
}
