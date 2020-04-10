using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DApp.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    private readonly DataContext _context;

    public ValuesController(DataContext context)
    {
      _context = context;

    }
    //GET api/values
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetValues()
    {
      //throw new Exception("Test Exception");
      var values = await _context.Values.ToListAsync();
      return Ok(values);
      //return new string[] { "value1", "value3" };
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetValue(int id)
    {
      //throw new Exception("Test Exception");
      var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
      return Ok(value);
      //return new string[] { "value1", "value3" };
    }

  }
}