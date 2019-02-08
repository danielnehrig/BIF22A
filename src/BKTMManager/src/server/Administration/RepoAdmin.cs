using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BKTMManager.Controller;

/*
 * A Generic Repository to Manage the CRUD pattern among all the Managers(Tables)
 */
namespace BKTMManager.Administration {
  public interface IRepoAdmin<TEntity> where TEntity : class, new() {
    List<TEntity> GetAll();
    TEntity GetById(int id);
    void Update(int id, string old, string change);
    void Delete(int id);
    void Create(string values);
  }

  public class RepoAdmin<TEntity> : IRepoAdmin<TEntity> where TEntity : class, new() {
    private string _tableName;
    public string tableName {
      get { return _tableName; }
      set { _tableName = value; }
    }

    private SqlConnection _cnn;

    private string _columNames;
    public string columNames {
      get { return _columNames; }
      set { _columNames = value; }
    }

    public RepoAdmin(SqlConnection cnn) { 
      _cnn = cnn;
    }

    /*
     * This will get the Column names for use in Create and Update
     */
    public string getColumnsName() {
      List<string> listacolumnas=new List<string>();
      using (SqlCommand command = this._cnn.CreateCommand()) {
        command.CommandText = String.Format("select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = '{0}' and t.type = 'U'", this.tableName);
        this._cnn.Open();

        using (var reader = command.ExecuteReader()) {
          while (reader.Read()) {
            listacolumnas.Add(reader.GetString(0));
          }
        }
      }
      string[] result = listacolumnas.ToArray();
      this._cnn.Close();
      return String.Join(", ", result);
    }

    /**
     * Get All Entries from the given Repos Table
     */
    public List<TEntity> GetAll() {
      List<TEntity> entitys = new List<TEntity>();
      try {
        this._cnn.Open();
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = String.Format("SELECT * FROM [dbo].[{0}]", this.tableName);
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          object[] args = new Object[] { reader };
          entitys.Add((TEntity)Activator.CreateInstance(typeof(TEntity), args));
        }
        this._cnn.Close();
      } catch(Exception ex) {
        Console.WriteLine("Error : " + ex);
        return null;
      }
      return entitys;
    }

    /**
     * Get one entry by ID
     */
    public TEntity GetById(int id){
      TEntity entity;
      try {
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = "SELECT * FROM [dbo]." + this.tableName + "WHERE id LIKE " + id;
        SqlDataReader reader = command.ExecuteReader();
        this._cnn.Open();
        object[] args = new Object[] { reader };
        entity = (TEntity)Activator.CreateInstance(typeof(TEntity), args);
        this._cnn.Close();
      } catch(Exception ex) {
        Console.WriteLine(ex);
        return null;
      }
      return entity;
    }

    /**
     * Delete one entry by ID
     */
    public void Delete(int id) {
      try {
        this._cnn.Open();
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = String.Format("DELETE FROM [dbo].[{0}] WHERE id = @id", this.tableName);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        this._cnn.Close();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
    }

    /**
     * Create one entry
     */
    public void Create(string values) {
      try {
        this._cnn.Open();
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = String.Format("INSERT INTO [dbo].[{0}] ({1}) VALUES ({2})", this.tableName, this.columNames, values);
        int recordsAffected = command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
      this._cnn.Close();
    }

    /**
     * Update one entry by ID
     */
    public void Update(int id, string old, string change) {
      try {
        this._cnn.Open();
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = String.Format("UPDATE [dbo].[{0}] SET {1} = change WHERE id = @id", this.tableName, old, change);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
      this._cnn.Close();
    }
  }
}
