
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class RelationshipRepository
  {
    private readonly IDbConnection _db;

    public RelationshipRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep Create(VaultKeep VaultKeep)
    {
      string sql = @"INSERT INTO vaultkeeps
            (keepId, userId, vaultId)
            VALUES
            (@KeepId, @UserId, @VaultId);
            SELECT LAST_INSERT_ID();";
      VaultKeep.Id = _db.ExecuteScalar<int>(sql, VaultKeep);
      return VaultKeep;
    }

    internal IEnumerable<VaultKeepViewModel> Get(VaultKeep vaultkeep)
    {
      string sql = @"
          -- SELECT 
-- k.*,
-- vk.id as vaultKeepId
-- FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 
            ";
      return _db.Query<VaultKeepViewModel>(sql, vaultkeep);
    }
  }
}