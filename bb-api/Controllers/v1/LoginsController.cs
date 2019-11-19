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
    [Route("v1/[controller]")]
    public class LoginsController : Controller
    {
        private readonly LoginTrackingContext _context;

        public LoginsController(LoginTrackingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TblLoginsV2> Get(int skip = 0, int take = 10, string username = null, string machine = null, string gw = null, string dc = null, DateTime? start = null, DateTime? end = null)
        {
            if (start == null) { start = DateTime.Now.Date; }
            if (end == null) { end = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59); }

             var results = _context.TblLoginsV2
                .Where(l => l.Date >= start && l.Date <= end);

            if(username != null)
            {
                results = results
                    .Where(l => l.Username.Contains(username.ToLower()));
            }

            if (machine != null)
            {
                results = results
                    .Where(l => l.Machine.Contains(machine.ToLower()));
            }

            if (dc != null)
            {
                results = results
                    .Where(l => l.Dc.Contains(dc.ToLower()));
            }

            if (gw != null)
            {
                results = results
                    .Where(l => l.Gw.Contains(gw.ToLower()));
            }

            return results
                .OrderByDescending(l => l.Date)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}