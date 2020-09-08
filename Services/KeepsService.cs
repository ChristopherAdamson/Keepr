using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    public Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    public Keep GetByKeepId(int id)
    {
      Keep keep = _repo.GetByKeepId(id);
      return keep;
    }

    public Keep Update(int id, Keep updatedKeep)
    {
      Keep original = GetByKeepId(id);
      original.Name = updatedKeep.Name == null ? original.Name : updatedKeep.Name;
      original.Description = updatedKeep.Description == null ? original.Description : updatedKeep.Description;
      original.Img = updatedKeep.Img == null ? original.Img : updatedKeep.Img;
      original.Views = updatedKeep.Views > 0 ? updatedKeep.Views : original.Views;
      original.Shares = updatedKeep.Shares > 0 ? updatedKeep.Shares : original.Shares;
      original.Keeps = updatedKeep.Keeps > 0 ? updatedKeep.Keeps : original.Keeps;
      //   need to do isprivate when i learn the data default
      bool updated = _repo.Update(updatedKeep);
      if (!updated)
      {
        throw new Exception("You dont own this keep");

      }
      return updatedKeep;
    }

    public String Delete(string userId, int id)
    {
      GetByKeepId(id);
      bool delorted = _repo.Delete(userId, id);
      if (!delorted)
      {
        throw new Exception("Not your keep to delete");
      }
      return "Deleted!";
    }
  }
}