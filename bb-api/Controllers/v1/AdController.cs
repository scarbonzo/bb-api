using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bb_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace bb_api.Controllers.v1
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/ad")]
    public class AdController : Controller
    {
        private readonly StaffDirectoryContext _context;

        public AdController(StaffDirectoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("users")]
        public IEnumerable<Adusers> Get(int skip = 0, int take = 25)
        {
            var results = _context.Adusers.AsQueryable();

            results = results
                .Where(u => u.Deleted == false)
                .Where(u => u.Enabled == true)
                .Where(u => u.Program != "")
                .Where(u => !u.Ou.Contains("OU=General"));

            return results
                .OrderBy(u => u.Displayname)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        [HttpGet]
        [Route("users/{id:guid}")]
        public Adusers GetById(Guid id)
        {
            return _context.Adusers
                .Where(u => u.Id == id)
                .FirstOrDefault();
        }

        [HttpGet]
        [Route("~/v1/programs")]
        public IEnumerable<string> GetPrograms()
        {
            var results = _context.Adusers.AsQueryable();

            results = results
                .Where(u => u.Deleted == false)
                .Where(u => u.Enabled == true)
                .Where(u => u.Program != "")
                .Where(u => !u.Ou.Contains("OU=General"));

            return results
                .Select(u => u.Program)
                .Distinct();
        }

        [HttpGet]
        [Route("~/v1/programs/{program}/users")]
        public IEnumerable<Adusers> GetProgramUsers(string program, int skip = 0, int take = 25)
        {
            var results = _context.Adusers.AsQueryable();

            results = results
                .Where(u => u.Deleted == false)
                .Where(u => u.Enabled == true)
                .Where(u => u.Program == program)
                .Where(u => u.Office != "")
                .Where(u => !u.Ou.Contains("OU=General"));

            return results
                .OrderBy(u => u.Displayname)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        [HttpGet]
        [Route("~/v1/programs/{program}/offices")]
        public IEnumerable<string> GetProgramOffices(string program)
        {
            var results = _context.Adusers.AsQueryable();

            results = results
                .Where(u => u.Deleted == false)
                .Where(u => u.Enabled == true)
                .Where(u => u.Program == program)
                .Where(u => u.Office != "")
                .Where(u => !u.Ou.Contains("OU=General"));

            return results
                .Select(u => u.Office)
                .Distinct();
        }

        [HttpGet]
        [Route("~/v1/programs/{program}/{office}/users")]
        public IEnumerable<Adusers> GetProgramOfficeUsers(string program, string office, int skip = 0, int take = 25)
        {
            var results = _context.Adusers.AsQueryable();

            results = results
                .Where(u => u.Deleted == false)
                .Where(u => u.Enabled == true)
                .Where(u => u.Program == program)
                .Where(u => u.Office == office)
                .Where(u => !u.Ou.Contains("OU=General"));

            return results
                .OrderBy(u => u.Displayname)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}
