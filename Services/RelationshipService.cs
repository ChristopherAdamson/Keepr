using System;
using System.Collections;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Keepr.Services;

namespace Keepr.Services
{
  public class RelationshipService
  {
    private readonly RelationshipRepository _repo;
    private readonly KeepsService _keepsService;

    public RelationshipService(RelationshipRepository repo, KeepsService keepsService)
    {
      _repo = repo;
      _keepsService = keepsService;
    }

    public VaultKeep Create(VaultKeep vaultKeep)
    {
      _keepsService.increaseKeepCount(vaultKeep.keepId);
      return _repo.Create(vaultKeep);
    }

    internal IEnumerable<VaultKeepViewModel> Get(VaultKeep vaultKeep)
    {
      return _repo.Get(vaultKeep);
    }
  }
}