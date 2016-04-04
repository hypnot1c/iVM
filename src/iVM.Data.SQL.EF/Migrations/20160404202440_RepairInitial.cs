using Microsoft.Data.Entity.Migrations;

namespace iVM.Data.SQL.EF.SQLdatabase.Migrations
{
  public partial class RepairInitial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      //migrationBuilder.DropForeignKey(name: "FK_EventOccured_EventType_EventTypeID", table: "EventOccured");
      //migrationBuilder.DropForeignKey(name: "FK_FillUp_EventOccured_EventOccuredID", table: "FillUp");
      migrationBuilder.CreateTable(
          name: "Repair",
          columns: table => new
          {
            ID = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            EventOccuredID = table.Column<int>(nullable: false),
            MaintenanceID = table.Column<int>(nullable: false),
            ServiceStationName = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Repair", x => x.ID);
            table.ForeignKey(
                      name: "FK_Repair_EventOccured_EventOccuredID",
                      column: x => x.EventOccuredID,
                      principalTable: "EventOccured",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Cascade);
          });
      //migrationBuilder.AddForeignKey(
      //    name: "FK_EventOccured_EventType_EventTypeID",
      //    table: "EventOccured",
      //    column: "EventTypeID",
      //    principalTable: "EventType",
      //    principalColumn: "ID",
      //    onDelete: ReferentialAction.Cascade);
      //migrationBuilder.AddForeignKey(
      //    name: "FK_FillUp_EventOccured_EventOccuredID",
      //    table: "FillUp",
      //    column: "EventOccuredID",
      //    principalTable: "EventOccured",
      //    principalColumn: "ID",
      //    onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      //migrationBuilder.DropForeignKey(name: "FK_EventOccured_EventType_EventTypeID", table: "EventOccured");
      //migrationBuilder.DropForeignKey(name: "FK_FillUp_EventOccured_EventOccuredID", table: "FillUp");
      migrationBuilder.DropTable("Repair");
      //migrationBuilder.AddForeignKey(
      //    name: "FK_EventOccured_EventType_EventTypeID",
      //    table: "EventOccured",
      //    column: "EventTypeID",
      //    principalTable: "EventType",
      //    principalColumn: "ID",
      //    onDelete: ReferentialAction.Restrict);
      //migrationBuilder.AddForeignKey(
      //    name: "FK_FillUp_EventOccured_EventOccuredID",
      //    table: "FillUp",
      //    column: "EventOccuredID",
      //    principalTable: "EventOccured",
      //    principalColumn: "ID",
      //    onDelete: ReferentialAction.Restrict);
    }
  }
}
