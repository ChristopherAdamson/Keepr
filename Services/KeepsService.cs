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

    public Keep GetByKeepId(int id, string userId)
    {
      Keep keep = _repo.GetByKeepId(id, userId);
      if (keep != null)
      {
        return keep;
      }
      throw new Exception("something went wrong");
    }

    internal Keep increaseKeepCount(int keepId)
    {
      Keep update = _repo.increaseKeepCount(keepId);
      if (update != null)
      {
        return update;
      }
      throw new Exception("something went wrong");

    }

    public Keep Update(int id, Keep updatedKeep)
    {
      Keep original = GetByKeepId(id, updatedKeep.UserId);
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

    public IEnumerable<Keep> GetByUser(string userId)
    {
      IEnumerable<Keep> keeps = _repo.GetByUser(userId);
      if (keeps != null)
      {
        return keeps;
      }
      throw new Exception("Are you logged in?");
    }

    internal void decreaseKeepCount(int keepId)
    {
      _repo.decreaseKeepCount(keepId);
    }

    public String Delete(string userId, int id)
    {

      bool delorted = _repo.Delete(userId, id);
      if (!delorted)
      {
        throw new Exception("Not your keep to delete");
      }
      return "Deleted!";
    }

    internal string UpdatePrivacy(int id, string userId)
    {
      bool updated = _repo.UpdatePrivacy(id, userId);
      if (updated)
      {
        return "Privacy set";
      }
      return "something went wrong";
    }

    internal Keep UpdateShares(int id)
    {
      Keep updated = _repo.UpdateShares(id);
      if (updated != null)
      {
        return updated;
      }
      throw new Exception("something went wrong");
    }
  }
}