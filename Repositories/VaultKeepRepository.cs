
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }
    public VaultKeep Check(VaultKeep vaultkeep)
    {
      string sql = @"SELECT * FROM vaultkeeps WHERE vaultId = @vaultId AND keepId = @keepId;";
      return _db.QueryFirstOrDefault(sql, vaultkeep);
    }
    internal bool Create(VaultKeep VaultKeep)
    {
      string sql = @"INSERT INTO vaultkeeps
            (keepId, userId, vaultId)
            VALUES
            (@KeepId, @UserId, @VaultId);
            SELECT LAST_INSERT_ID();";

      int rowsAffected = _db.Execute(sql, VaultKeep);
      return rowsAffected == 1;
    }

    internal IEnumerable<VaultKeepViewModel> Get(VaultKeep vaultkeep)
    {
      string sql = @"
          SELECT 
          k.*,
          vk.id as vaultKeepId
          FROM vaultkeeps vk
          INNER JOIN keeps k ON k.id = vk.keepId 
          WHERE (vaultId = @vaultId AND vk.userId = @userId) 
            ";
      return _db.Query<VaultKeepViewModel>(sql, vaultkeep);
    }

    internal IEnumerable<VaultKeepViewModel> GetKeepByVaultId(int vaultId, string userId)
    {
      string sql = @"
          SELECT 
          k.*,
          vk.id as vaultKeepId
          FROM vaultkeeps vk
          INNER JOIN keeps k ON k.id = vk.keepId 
          WHERE (vaultId = @vaultId AND vk.userId = @userId);";
      return _db.Query<VaultKeepViewModel>(sql, new { vaultId, userId });
    }

    public bool Delete(int id, string userId)
    {
      string sql = @"DELETE FROM vaultkeeps WHERE id = @id AND userId = @userId;";
      int rowsAffected = _db.Execute(sql, new { id, userId });
      return rowsAffected == 1;
    }

    internal VaultKeep CreateTest(VaultKeep relationship)
    {
      string sql = @"INSERT INTO vaultkeeps
            (keepId, userId, vaultId)
            VALUES
            (@KeepId, @UserId, @VaultId);
            SELECT LAST_INSERT_ID();";

      relationship.Id = _db.ExecuteScalar<int>(sql, relationship);
      return relationship;
    }

    public bool DeleteTest(int id, string userId)
    {
      string sql = @"DELETE FROM vaultkeeps WHERE id = @id AND userId = @userId;";
      int rowsAffected = _db.Execute(sql, new { id, userId });
      return rowsAffected == 1;
    }
  }
}