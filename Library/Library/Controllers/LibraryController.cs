using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.DataAccess;
using Library.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryDBContext _context;

        public LibraryController(LibraryDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetBooks()
        {
            var books = _context.Books
                .Include(a=>a.User)
                .ToList();
            return Ok(books);
        }

        [HttpGet]
        [Route("AllUsers")]
        public ActionResult GetUsers()
        {
            var users = _context.User.ToList();
            return Ok(users);
        }

        [HttpPost]
        public ActionResult CreateUsers(Users user)
        {
            user.UserID = new Guid();
            user.Name.Trim();
            _context.User.Update(user);
            _context.Entry(user).State = EntityState.Added;
            _context.SaveChanges();
            return Ok(user);
        }
    }
}