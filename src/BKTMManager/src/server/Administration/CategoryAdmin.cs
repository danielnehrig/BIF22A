using System;
using System.Data.SqlClient;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class CategoryAdministration : RepoAdmin<Category> {
    public CategoryAdministration(SqlConnection cnn):base(cnn) { 
      tableName = "Category";
    }
  }
}
