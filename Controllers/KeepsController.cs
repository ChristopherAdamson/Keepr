using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetByUser()
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Must be logged in update a keep");
        }
        return Ok(_ks.GetByUser(user.Value));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> GetByKeepId(int id)
    {
      try
      {

        return Ok(_ks.GetByKeepId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Keep> Update(int id, [FromBody] Keep updatedKeep)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Must be logged in update a keep");
        }
        updatedKeep.UserId = user.Value;
        updatedKeep.Id = id;
        return Ok(_ks.Update(id, updatedKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [Authorize]
    [HttpPut("{id}/shares")]
    public ActionResult<Keep> UpdateShares(int id)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Must be logged in to Share a keep");
        }

        return Ok(_ks.UpdateShares(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [Authorize]
    [HttpPut("{id}/private")]
    public ActionResult<string> UpdatePrivacy(int id)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Must be logged in update a keep");
        }


        return Ok(_ks.UpdatePrivacy(id, user.Value));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [Authorize]
    [HttpPost]

    public ActionResult<Keep> Post([FromBody] Keep newKeep)
    {
      try
      {
        Claim userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
          throw new Exception("you must be logged in to make a keep.");
        }
        newKeep.UserId = userId.Value;
        return Ok(_ks.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Must be logged in to delete a keep");
        }

        return Ok(_ks.Delete(user.Value, id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }



  }
}