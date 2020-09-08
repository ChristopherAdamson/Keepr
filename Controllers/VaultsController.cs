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
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _ks;
    public VaultsController(VaultsService ks)
    {
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Must be logged in update a vault");
        }
        return Ok(_ks.Get(user.Value));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }
    [HttpGet("{id}")]
    public ActionResult<Vault> GetByVaultId(int id)
    {
      try
      {
        return Ok(_ks.GetByVaultId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }


    [HttpPut("{id}")]
    public ActionResult<Vault> Update(int id, [FromBody] Vault updatedVault)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Must be logged in update a vault");
        }
        updatedVault.UserId = user.Value;
        updatedVault.Id = id;
        return Ok(_ks.Update(id, updatedVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }


    [HttpPost]

    public ActionResult<Vault> Post([FromBody] Vault newVault)
    {
      try
      {
        Claim userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
          throw new Exception("you must be logged in to make a vault.");
        }
        newVault.UserId = userId.Value;
        return Ok(_ks.Create(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Must be logged in update a vault");
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