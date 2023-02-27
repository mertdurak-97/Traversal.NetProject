using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addmigContactUs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                  name: "ContactUses",
                  columns: table => new
                  {
                      ContactUsId = table.Column<int>(type: "int", nullable: false)
                          .Annotation("SqlServer:Identity", "1, 1"),
                      NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                      MessageStatus = table.Column<bool>(type: "bit", nullable: false)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_ContactUses", x => x.ContactUsId);
                  });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUses");

            migrationBuilder.CreateTable(
                name: "MyContacts",
                columns: table => new
                {
                    ContactUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageStatus = table.Column<bool>(type: "bit", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyContacts", x => x.ContactUsId);
                });
        }
    }
}
