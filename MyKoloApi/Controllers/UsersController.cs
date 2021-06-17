using Microsoft.AspNetCore.Mvc;
using MyKoloApi.Data;
using MyKoloApi.DTOS;
using MyKoloApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKoloApi.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AddUser(AddUserDto requestBody)
        {
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = requestBody.UserName,
                Password = requestBody.Password,
                Email = requestBody.Email
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user.Id);
        }
    }
}
