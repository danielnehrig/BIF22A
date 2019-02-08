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
    //void Update(int id);
    void Delete(int id);
    void Create(object[] arg);
  }

  public class RepoAdmin<TEntity> : IRepoAdmin<TEntity> where TEntity : class, new() {
    private string _tableName;
    public string tableName {
      get { return _tableName; }
      set { _tableName = value; }
    }

    private SqlConnection _cnn;

    private List<string> _columNames;
    public List<string> columNames {
      get { return _columNames; }
      set { _columNames = value; }
    }

    public RepoAdmin(SqlConnection cnn) { 
      _cnn = cnn;
    }

    /*
     * This will get the Column names for use in Create and Update
     */
    private void GetColNames() {
      string[] restrictions = new string[4] { null, null, "<TableName>", null };
      this._cnn.Open();
      // _columNames = this._cnn.GetSchema("Columns", restrictions).AsEnumerable().Select(s => s.Field<String>("Column_Name")).ToList()
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

    public void Delete(int id) {
      try {
        this._cnn.Open();
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = String.Format("DELETE FROM [dbo]." + this.tableName + " WHERE id = @id");
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        this._cnn.Close();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
    }

    public void Create(object[] arg) {
      this._cnn.Open();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        // command.CommandText = String.Format("INSERT INTO [dbo].[Room] ({0}) VALUES ({1})", list(fields.Keys), list(fields.Values));
        int recordsAffected = command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }

      this._cnn.Close();
    }
  }
}
