using JournalSite.Data;
using JournalSite.Models;
using JournalSite.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JournalSite.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class ChatController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly UserManager<IdentityUser> _userManager;
        public ChatController(DataManager dataManager, UserManager<IdentityUser> userManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult Hub(string username)
        {
            return View(_dataManager.Groups.GetGroupsByUserNameMod(username));
        }

        [HttpPost]
        public IActionResult Room(string groupname)
        {
            TempData["groupname"] = groupname;
            return View(_dataManager.Messages.GetMessagesByGroupName(groupname));
        }
    }
}
