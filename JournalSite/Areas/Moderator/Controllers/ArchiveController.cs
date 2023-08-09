using JournalSite.Data;
using JournalSite.Data.Entities;
using JournalSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Globalization;
using System.Web.Mvc;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace JournalSite.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class ArchiveController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArchiveController(DataManager dataManager, IWebHostEnvironment webHostEnvironment)
        {
            _dataManager = dataManager;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult AddJournalNumber()
        {
            return View(new AddJournalNumberViewModel());
        }
        [HttpPost]
        public IActionResult AddJournalNumber(AddJournalNumberViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_dataManager.ArchiveYears.YearIsIn(Convert.ToInt32(model.Year)))
                {
                    Archive_year year1 = new Archive_year
                    {
                        Year = Convert.ToInt32(model.Year),
                    };
                    _dataManager.ArchiveYears.Save(year1);
                    _dataManager.ArchiveNumbers.Save(new Archive_number
                    {
                        Name = model.Name,
                        YearId = year1.Id,
                    });
                    return RedirectToRoute(new { area = "", controller = "Home", action = "Index" });
                }
                Archive_year year2 = _dataManager.ArchiveYears.GetYear(Convert.ToInt32(model.Year));
                _dataManager.ArchiveNumbers.Save(new Archive_number
                {
                    Name = model.Name,
                    YearId = year2.Id,
                });
                return RedirectToRoute(new { area = "", controller = "Home", action = "Index" });
            }
            return View(model);
        }

        public IActionResult AddArticles(Guid id)
        {
            
            return View(new AddArticlesViewModel
            {
                NumberId = id,
            });
        }

        [HttpPost]
        public IActionResult AddArticles(AddArticlesViewModel model, IFormFile articleFile)
        {
            if (ModelState.IsValid)
            {
                if (articleFile != null)
                {
                    Archive_articles arc = new Archive_articles
                    {
                        NumberId = model.NumberId,
                        Title = model.Title,
                        Description = model.Description,
                        Sender = model.Sender,
                        Path = articleFile.FileName,
                    };
                    using (var stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "files/", articleFile.FileName), FileMode.Create))
                    {
                        articleFile.CopyTo(stream);
                    }
                    _dataManager.ArchiveArticles.Save(arc);
                    return RedirectToRoute(new { area = "", controller = "Home", action = "Archive" });
                }
                ModelState.AddModelError("Path", "Загрузите статью");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _dataManager.ArchiveArticles.DeleteArchiveArticle(id);
            return RedirectToRoute(new { area = "", controller = "Home", action = "Archive" });
        }
    }
}
