using Microsoft.Data.Entity.Migrations;

namespace iVM.Data.SQL.EF.SQLdatabase.Migrations
{
  public partial class Sync : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(name: "FK_EventOccured_EventType_EventTypeID", table: "EventOccured");
            //migrationBuilder.DropForeignKey(name: "FK_FillUp_EventOccured_EventOccuredID", table: "FillUp");
            //migrationBuilder.AddForeignKey(
            //    name: "FK_EventOccured_EventType_EventTypeID",
            //    table: "EventOccured",
            //    column: "EventTypeID",
            //    principalTable: "EventType",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.NoAction);
            //migrationBuilder.AddForeignKey(
            //    name: "FK_FillUp_EventOccured_EventOccuredID",
            //    table: "FillUp",
            //    column: "EventOccuredID",
            //    principalTable: "EventOccured",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(name: "FK_EventOccured_EventType_EventTypeID", table: "EventOccured");
            //migrationBuilder.DropForeignKey(name: "FK_FillUp_EventOccured_EventOccuredID", table: "FillUp");
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
