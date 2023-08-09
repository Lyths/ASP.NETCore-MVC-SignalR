using JournalSite.Data;
using JournalSite.Data.Entities;
using JournalSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JournalSite.Areas.User.Controllers
{
    [Area("User")]
    public class ArticleController : Controller
    {
        private readonly DataManager _datamanager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ArticleController(DataManager datamanager, IWebHostEnvironment webHostEnvironment)
        {
            _datamanager = datamanager;
            _webHostEnvironment = webHostEnvironment;
        }
        
        public IActionResult Articles()
        {
            return View(_datamanager.Articles.GetArticlesByUserName(HttpContext.User.Identity.Name));
        }

        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send(Article model, IEnumerable<IFormFile> upload)
        {
            if (ModelState.IsValid)
            {
                _datamanager.Articles.SaveArticle(model);
                if (upload.Count() != 0)
                {
                    foreach (var item in upload)
                    {
                        Data.Entities.File file = new Data.Entities.File
                        {
                            FilePath = item.FileName,
                            ArticleId = model.Id
                        };
                        using (var stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "files/", item.FileName), FileMode.Create))
                        {
                            item.CopyTo(stream);
                        }
                        _datamanager.Files.SaveFile(file);
                    }
                    return RedirectToRoute(new { area = "User", controller = "Article", action = "Articles" });
                }
                ModelState.AddModelError("", "Прикрепите файлы");
            }
            return View(model);
        }
        public FileResult Download(string filePath)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "files/", filePath);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", filePath);
        }
    }
}
