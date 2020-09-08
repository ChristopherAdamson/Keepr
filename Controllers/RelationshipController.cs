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
  public class RelationshipsController : ControllerBase
  {
    private readonly RelationshipService _service;

    public RelationshipsController(RelationshipService service)
    {
      _service = service;
    }


    [HttpPost]
    public ActionResult<string> Create([FromBody] VaultKeep relationship)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to add a keep to a vault.");
        }
        relationship.UserId = user.Value;
        return Ok(_service.Create(relationship));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    // [HttpGet]
    // public ActionResult<IEnumerable<VaultKeepViewModel>> Get()
    // {
    //   try
    //   {
    //     Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
    //     if (user == null)
    //     {
    //       throw new Exception("You must be logged in to get yo favorite cars, yo.");
    //     }
    //     return Ok(_service.Get(user.Value));
    //   }
    //   catch (Exception err)
    //   {
    //     return BadRequest(err.Message);
    //   }
    // }
  }
}