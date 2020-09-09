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

    public VaultKeep Create(VaultKeep vaultKeep)
    {
      VaultKeep check = _repo.Check(vaultKeep);
      if (check == null)
      {
        _keepsService.increaseKeepCount(vaultKeep.keepId);
        return _repo.Create(vaultKeep);
      }
      return vaultKeep;
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

    internal object delete(VaultKeep vaultKeep)
    {
      VaultKeep check = _repo.Check(vaultKeep);
      if (check != null)
      {
        _keepsService.decreaseKeepCount(vaultKeep.keepId);
        return _repo.Delete(vaultKeep);
      }
      return vaultKeep;
    }
  }
}