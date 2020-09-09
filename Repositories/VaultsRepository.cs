using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Vault> Get(string userId)
    {
      string sql = "SELECT * FROM vaults WHERE userId = @userId";
      return _db.Query<Vault>(sql, new { userId });
    }

    internal Vault Create(Vault VaultData)
    {
      string sql = @"INSERT INTO vaults
           (name, description, userId)
           VALUES
           (@name, @description, @userId);
           SELECT LAST_INSERT_ID();";
      VaultData.Id = _db.ExecuteScalar<int>(sql, VaultData);
      return VaultData;
    }

    public Vault GetByVaultId(int id, string userId)
    {
      string sql = @"SELECT * FROM vaults WHERE userId = @userId AND id = @id;";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id, userId });
    }

    internal bool Update(Vault updatedVault)
    {
      string sql = @"UPDATE vaults
            SET 
            name = @name,
            description = @description,
            
            WHERE id = @id AND userId = @userId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, updatedVault);
      return rowsAffected == 1;
    }

    public bool Delete(string userId, int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @Id AND userId = @UserId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { userId, id });
      return rowsAffected == 1;
    }
  }
}