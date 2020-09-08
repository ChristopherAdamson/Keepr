using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Vault> Get(string userId)
    {
      IEnumerable<Vault> vault = _repo.Get(userId);
      return vault;
    }

    public Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    public Vault GetByVaultId(int id)
    {
      Vault vault = _repo.GetByVaultId(id);
      return vault;
    }

    public Vault Update(int id, Vault updatedVault)
    {
      Vault original = GetByVaultId(id);
      original.Name = updatedVault.Name == null ? original.Name : updatedVault.Name;
      original.Description = updatedVault.Description == null ? original.Description : updatedVault.Description;

      bool updated = _repo.Update(updatedVault);
      if (!updated)
      {
        throw new Exception("You dont own this vault");

      }
      return updatedVault;
    }

    public String Delete(string userId, int id)
    {
      GetByVaultId(id);
      bool delorted = _repo.Delete(userId, id);
      if (!delorted)
      {
        throw new Exception("Not your vault to delete");
      }
      return "Deleted!";
    }
  }
}