using Microsoft.Data.Entity.Migrations;

namespace iVM.Data.SQL.EF.SQLdatabase.Migrations.Main
{
  public partial class FillUpInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(name: "FK_EventOccured_EventType_EventTypeID", table: "EventOccured");
            migrationBuilder.CreateTable(
                name: "FillUp",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventOccuredID = table.Column<int>(nullable: false),
                    LiterCost = table.Column<decimal>(nullable: false),
                    LitresValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillUp", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FillUp_EventOccured_EventOccuredID",
                        column: x => x.EventOccuredID,
                        principalTable: "EventOccured",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });
            //migrationBuilder.AddForeignKey(
            //    name: "FK_EventOccured_EventType_EventTypeID",
            //    table: "EventOccured",
            //    column: "EventTypeID",
            //    principalTable: "EventType",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(name: "FK_EventOccured_EventType_EventTypeID", table: "EventOccured");
            migrationBuilder.DropTable("FillUp");
            //migrationBuilder.AddForeignKey(
            //    name: "FK_EventOccured_EventType_EventTypeID",
            //    table: "EventOccured",
            //    column: "EventTypeID",
            //    principalTable: "EventType",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
