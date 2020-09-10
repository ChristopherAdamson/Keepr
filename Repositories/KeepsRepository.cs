using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal Keep Create(Keep KeepData)
    {
      string sql = @"INSERT INTO keeps
           (name, description, userId, img, isPrivate, views, shares, keeps)
           VALUES
           (@name, @description, @userId, @img, @isPrivate, @views, @shares, @keeps);
           SELECT LAST_INSERT_ID();";
      KeepData.Id = _db.ExecuteScalar<int>(sql, KeepData);
      return KeepData;
    }

    internal Keep increaseKeepCount(int keepId)
    {
      string sql1 = @"UPDATE keeps
      SET
      Keeps = Keeps + 1
      WHERE id = @keepId;
      SELECT * FROM keeps WHERE id = @keepId";
      return _db.QueryFirstOrDefault<Keep>(sql1, new { keepId });

    }

    public Keep GetByKeepId(int id, string userId)
    {
      string sql1 = @"UPDATE keeps
      SET
        Views = Views + 1
        WHERE id = @id;";
      _db.Execute(sql1, new { id });
      string sql = @"SELECT * FROM keeps WHERE isPrivate = 0 AND id = @id;";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    internal bool Update(Keep updatedKeep)
    {
      string sql = @"UPDATE keeps
            SET 
            name = @name,
            description = @description,
            Img = @Img,
            
            WHERE id = @id AND userId = @userId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, updatedKeep);
      return rowsAffected == 1;
    }

    public IEnumerable<Keep> GetByUser(string userId)
    {
      string sql = "SELECT * FROM Keeps WHERE userId = @userId;";
      return _db.Query<Keep>(sql, new { userId });
    }

    public void decreaseKeepCount(int keepId)
    {
      string sql1 = @"UPDATE keeps
      SET
      Keeps = Keeps - 1
      WHERE id = @keepId;";
      _db.Execute(sql1, new { keepId });
    }

    internal bool UpdatePrivacy(int id, string userId)
    {
      string sql = @"UPDATE keeps
            SET 
            isPrivate = 0
            WHERE id = @id AND userId = @userId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { id, userId });
      return rowsAffected == 1;
    }

    public bool Delete(string userId, int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @Id AND userId = @UserId AND isPrivate = 1 LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { userId, id });
      return rowsAffected == 1;
    }

    internal Keep UpdateShares(int id)
    {
      string sql = @"UPDATE keeps
            SET 
            shares = shares +1
            WHERE id = @id;
            SELECT * FROM keeps WHERE id = @id;";

      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
  }
}