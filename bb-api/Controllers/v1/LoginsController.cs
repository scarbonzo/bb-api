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
        public IEnumerable<TblLoginsV2> Get(int skip = 0, int take = 10)
        {
            return _context.TblLoginsV2
                .OrderByDescending(l => l.Date)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}