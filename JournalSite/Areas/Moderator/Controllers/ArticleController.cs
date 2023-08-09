using JournalSite.Data;
using JournalSite.Data.Entities;
using JournalSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JournalSite.Areas.Moderator.Controllers
{
    [Area("Moderator")]
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
            return View(_datamanager.Articles.GetArticles());
        }

        public IActionResult Deny(Guid artState)
        {
            _datamanager.Articles.DenyState(artState);
            return RedirectToRoute(new { area = "Moderator", controller = "Article", action = "Articles" });
        }

        public IActionResult Accept(Guid artState)
        {
            _datamanager.Articles.AcceptState(artState);
            return RedirectToRoute(new { area = "Moderator", controller = "Article", action = "Articles" });
        }

        public FileResult Download(string filePath)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "files/", filePath);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", filePath);
        }
    }
}
