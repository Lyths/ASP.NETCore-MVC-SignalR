using JournalSite.Data;
using JournalSite.Data.Entities;
using JournalSite.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JournalSite.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class PostController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostController(DataManager dataManager, IWebHostEnvironment webHostEnvironment)
        {
            _dataManager = dataManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new PostItem() : _dataManager.PostItems.GetPostItemById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(PostItem model, IFormFile? titleimagefile)
        {
            if (ModelState.IsValid)
            {
                if (titleimagefile != null)
                {
                    model.TitleImagePath = titleimagefile.FileName;
                    using (var stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "images/", titleimagefile.FileName), FileMode.Create))
                    {
                        titleimagefile.CopyTo(stream);
                    }
                }
                _dataManager.PostItems.SavePostItem(model);
                return RedirectToRoute(new { area="", controller = "Home", action = "Index" });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _dataManager.PostItems.DeletePostItem(id);
            return RedirectToRoute(new { area = "", controller = "Home", action = "Index" });
        }
    }
}
