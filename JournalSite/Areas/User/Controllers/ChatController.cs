using JournalSite.Data;
using JournalSite.Data.Entities;
using JournalSite.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace JournalSite.Areas.User.Controllers
{
    [Area("User")]
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
        public RedirectToActionResult Group(string username)
        {
            if (_dataManager.Groups.GetCountGroupsByUserName(username) == 0)
            {
                Group group = new Group
                {
                    GroupName = RandomString.Random(),
                    UserName = username
                };
                _dataManager.Groups.SaveGroup(group);
                var usersInRole = _userManager.GetUsersInRoleAsync("moderator").Result;
                var namesInRole = usersInRole.Select(x => x.UserName).ToList();
                Group group2 = new Group
                {
                    GroupName = group.GroupName,
                    UserName = namesInRole[new Random().Next(namesInRole.Count)]
                };
                _dataManager.Groups.SaveGroup(group2);
            }
            return RedirectToAction("Hub", "Chat", new { username = username});
        }
        
        public IActionResult Hub(string username)
        {
            return View(_dataManager.Groups.GetGroupsByUserNameUs(username));
        }

        [HttpPost]
        public IActionResult Room(string groupname)
        {
            TempData["groupname"] = groupname;
            return View(_dataManager.Messages.GetMessagesByGroupName(groupname));
        }
    }
}
