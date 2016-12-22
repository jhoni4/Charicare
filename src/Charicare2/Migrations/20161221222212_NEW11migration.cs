using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Charicare2.Migrations
{
    public partial class NEW11migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donate",
                columns: table => new
                {
                    DonateId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "strftime('%Y-%m-%d %H:%M:%S')"),
                    DonateTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 55, nullable: false),
                    Note = table.Column<string>(maxLength: 255, nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donate", x => x.DonateId);
                });

            migrationBuilder.CreateTable(
                name: "DonateType",
                columns: table => new
                {
                    DonateTypeId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonateType", x => x.DonateTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(maxLength: 55, nullable: false),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Telephone = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donate");

            migrationBuilder.DropTable(
                name: "DonateType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
