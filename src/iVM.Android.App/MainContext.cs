using Android.Content;
using Android.Database.Sqlite;
using SQLite;

namespace iVM.Android.App
{
  public class MainContext : SQLiteOpenHelper
  {
    private const string DatabaseName = "iVM";
    //specifies the database version (increment this number each time you make database related changes)
    private const int DatabaseVersion = 3;
    public SQLiteConnection con { get; set; }

    public MainContext(Context context) : base(context, DatabaseName, null, DatabaseVersion)
    {
      this.con = new SQLiteConnection(DatabaseName);
    }

    public override void OnCreate(SQLiteDatabase db)
    {
      //db.sq
      //create database tables
      db.ExecSQL(@"
        CREATE TABLE EventType (
          ID INTEGER NOT NULL CONSTRAINT PK_EventType PRIMARY KEY AUTOINCREMENT,
          Icon BLOB,
          Name TEXT NOT NULL)");
      //create database indexes
      //db.ExecSQL(@"CREATE INDEX IF NOT EXISTS FIRSTNAME_CUSTOMER ON CUSTOMER (FIRSTNAME)");
    }

    public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {
      if (oldVersion < 2)
      {
        //perform any database upgrade tasks for versions prior to  version 2              
      }
      if (oldVersion < 3)
      {
        //perform any database upgrade tasks for versions prior to  version 3
      }
    }
  }
}