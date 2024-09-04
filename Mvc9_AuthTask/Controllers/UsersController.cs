using Microsoft.AspNetCore.Mvc;
using Mvc9_AuthTask.Data;
using Mvc9_AuthTask.Models;

namespace Mvc9_AuthTask.Controllers
{
    
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]        
        public IActionResult Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult AllUsers()
        {

            var users = context.Users.ToList();

            return View(users);
        }
        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user) 
        {
            var checkUser = context.Users.Where(x=>x.Name==user.Name && x.Password == user.Password);
            if(checkUser.Any())
            {
                return RedirectToAction(nameof(AllUsers));
            }

            return View(user);
        }
        public IActionResult Activated() 
        {
            var activatedUsers = context.Users.ToList();
            
            return View(activatedUsers);
        }

        public IActionResult ActiveUser(Guid id) 
        {
            var user = context.Users.Find(id);
            if(user == null)
            {
                return RedirectToAction(nameof(AllUsers));
            }
            else
            {
                user.IsActive = true;
                context.SaveChanges();
            return RedirectToAction(nameof(Activated));
            }

        }




    }
}
