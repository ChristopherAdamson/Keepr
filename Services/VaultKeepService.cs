using System;
using System.Collections;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Keepr.Services;

namespace Keepr.Services
{
  public class VaultKeepService
  {
    private readonly VaultKeepRepository _repo;
    private readonly KeepsService _keepsService;

    public VaultKeepService(VaultKeepRepository repo, KeepsService keepsService)
    {
      _repo = repo;
      _keepsService = keepsService;
    }

    public Keep Create(VaultKeep vaultKeep)
    {
      VaultKeep check = _repo.Check(vaultKeep);
      if (check == null)
      {
        bool isCreated = _repo.Create(vaultKeep);
        if (isCreated)
        {
          return _keepsService.increaseKeepCount(vaultKeep.keepId);
        }
      }
      throw new Exception("could not add to vault, have you already added it?");
    }

    internal IEnumerable<VaultKeepViewModel> Get(VaultKeep vaultKeep)
    {
      return _repo.Get(vaultKeep);
    }

    public IEnumerable<VaultKeepViewModel> getKeepByVaultId(int id, string userId)
    {
      IEnumerable<VaultKeepViewModel> check = _repo.GetKeepByVaultId(id, userId);
      return check;
    }

    internal string delete(int id, int keepId, string userId)
    {
      // VaultKeep check = _repo.Check(vaultKeep);
      // if (check != null)
      // {
      _keepsService.decreaseKeepCount(keepId);

      bool deleted = _repo.Delete(id, userId);
      if (!deleted)
      {
        throw new Exception("something went wrong");
      }
      // }
      return "deleted!";
    }
  }
}