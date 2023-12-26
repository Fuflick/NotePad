using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotePad.DAL;
using NotePad.Domain;

namespace NotePad.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private MyDbContext dbContext = new MyDbContext();
        
        [HttpPost]
        [Route("CreateUser")]
        public async Task Registration(string login, string password)
        {
            try
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Login == login);
                if (user != null)
                {
                    throw new Exception("User already exist");
                }
                else
                {
                    user = new UserEntity
                    {
                        Id = Guid.NewGuid().ToString(),
                        Login = login,
                        Password = password,
                        Notes = new List<NoteEntity>(),
                    };
                    
                    await dbContext.Users.AddAsync(user);
                    await dbContext.SaveChangesAsync();
                    
                    await Response.WriteAsJsonAsync(user);
                }
                
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
                await Response.WriteAsJsonAsync(new { message = "Not correct data." });
            }
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task GetUsers()
        {
            await Response.WriteAsJsonAsync(dbContext.Users.ToList());
        }
    }
}
