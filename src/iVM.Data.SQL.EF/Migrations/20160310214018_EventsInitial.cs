using Microsoft.Data.Entity.Migrations;
using System;
using System.Linq;

namespace iVM.Data.SQL.EF.SQLdatabase.Migrations
{
  public partial class EventsInitial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "EventType",
          columns: table => new
          {
            ID = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Icon = table.Column<byte[]>(nullable: true),
            Name = table.Column<string>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_EventType", x => x.ID);
          });
      migrationBuilder.CreateTable(
          name: "EventOccured",
          columns: table => new
          {
            ID = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Date = table.Column<DateTime>(nullable: false),
            Description = table.Column<string>(nullable: true),
            EventTypeID = table.Column<int>(nullable: false),
            Expense = table.Column<uint>(nullable: false),
            Mileage = table.Column<long>(nullable: false),
            Name = table.Column<string>(nullable: false),
            Profit = table.Column<uint>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_EventOccured", x => x.ID);
            table.ForeignKey(
                      name: "FK_EventOccured_EventType_EventTypeID",
                      column: x => x.EventTypeID,
                      principalTable: "EventType",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.NoAction);
          });
      var eventTypes = new string[] { "Other", "FillUp", "Repair" };
      var tmplInsert = "INSERT INTO EventType (ID, Name) VALUES ({0}, '{1}');";
      var fillQuery = eventTypes.Select((e, i) => String.Format(tmplInsert, i, e));
      migrationBuilder.Sql(String.Join(Environment.NewLine, fillQuery));
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable("EventOccured");
      migrationBuilder.DropTable("EventType");
    }
  }
}
