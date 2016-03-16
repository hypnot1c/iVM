using Microsoft.Data.Entity.Migrations;

namespace iVM.Data.SQLdatabase.Migrations
{
  public partial class CreateDataBase : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "User",
          columns: table => new
          {
            ID = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_User", x => x.ID);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable("User");
    }
  }
}
