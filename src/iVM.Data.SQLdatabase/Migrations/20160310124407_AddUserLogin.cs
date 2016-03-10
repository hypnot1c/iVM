using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace iVM.Data.SQLdatabase.Migrations
{
    public partial class AddUserLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "User",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Login", table: "User");
        }
    }
}
