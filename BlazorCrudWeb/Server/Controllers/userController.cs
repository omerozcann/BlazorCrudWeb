using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorCrudWeb.Shared.Models;
using BlazorCrudWeb.Server.Data;

namespace BlazorCrudWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        BlazorCrudWebContext context = new();
        [HttpPost]
        [Route("SaveUser")]
        public void SaveUser(User usr)
        {
            context.Users.Add(usr); 
            context.SaveChanges();
        }
        [HttpGet]
        [Route("GetUsers")]
        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }
        [HttpGet]
        [Route("GetUser")]
        public User GetUser(int UserId)
        {
            return context.Users.Where(a => a.Id == UserId).FirstOrDefault();
        }
        [HttpDelete]
        [Route("RemoveUser")]
        public void RemoveUser(int UserId)
        {           
            var usr=context.Users.Where(a=>a.Id== UserId).FirstOrDefault(); 
            context.Users.Remove(usr);
            context.SaveChanges();            
        }
        [HttpPost]
        [Route("UpdateUser")]
        public void UpdateUser(User usr)
        {
            var user = context.Users.Where(a => a.Id == usr.Id).FirstOrDefault();
            user.UserName=usr.UserName;
            user.Password=usr.Password;
            user.Email=usr.Email;
            context.Entry(user).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
