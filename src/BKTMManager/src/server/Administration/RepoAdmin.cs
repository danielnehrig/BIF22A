using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BKTMManager.Controller;

namespace BKTMManager.Administration {
  public interface IRepoAdmin<TEntity> where TEntity : class {
    // non generic 18 28
    IEnumerable<TEntity> GetAll() where TEntity : new();
    TEntity GetById(int id) where TEntity : new();
    // void Update(int id);
    // void Delete(int id);
    // void Create(TEntity entity);
  }

  public abstract class RepoAdmin<TEntity> : IOController, IRepoAdmin<TEntity> where TEntity : class {
    private string _tableName;
    public string tableName {
      get { return _tableName; }
      set { _tableName = value; }
    }

    public RepoAdmin(string ip, string db, string user, string pw):base(ip, db, user, pw) { }

    public IEnumerable<TEntity> GetAll() where TEntity : new() {
      List<TEntity> entitys = new List<TEntity>();
      try {
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = "SELECT * FROM [dbo]." + this.tableName;
        SqlDataReader reader = command.ExecuteReader();
        this.openConnection();
        while(reader.Read()) {
          object[] args = new Object[] { reader.GetInt32(0) };
          entitys.Add((TEntity)Activator.CreateInstance(typeof(TEntity), args));
          // GetName
          // GetValues
          // TEntity entity = new TEntity();
          // reader.GetValues(entity);
          // entity.id = reader.GetInt32(0);
          // entity.description = reader.GetString(1);
          // entitys.Add(entity);
        }
        Console.WriteLine("abc " + entitys[0]);
      this.closeConnection();
      } catch(Exception ex) {
        Console.WriteLine(ex);
        return entitys;
      }
      return entitys;
    }

    public TEntity GetById<TEntity>(int id) where TEntity : new() {
      TEntity entity = new TEntity();
      try {
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = "SELECT * FROM [dbo]." + this.tableName + "WHERE id LIKE " + id;
        SqlDataReader reader = command.ExecuteReader();
        this.openConnection();

        while(reader.Read()) {
        }
      this.closeConnection();
      } catch(Exception ex) {
        Console.WriteLine(ex);
        return entity;
      }
      return entity;
    }
  }
}
