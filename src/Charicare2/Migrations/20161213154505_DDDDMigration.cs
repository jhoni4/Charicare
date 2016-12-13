using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Charicare2.Migrations
{
    public partial class DDDDMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonateType",
                columns: table => new
                {
                    DonateTypeId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
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
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MoneyDonate",
                columns: table => new
                {
                    MoneyId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Amount = table.Column<double>(nullable: false),
                    DonateTypeId = table.Column<int>(nullable: true),
                    Note = table.Column<string>(maxLength: 255, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyDonate", x => x.MoneyId);
                    table.ForeignKey(
                        name: "FK_MoneyDonate_DonateType_DonateTypeId",
                        column: x => x.DonateTypeId,
                        principalTable: "DonateType",
                        principalColumn: "DonateTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClothesDonate",
                columns: table => new
                {
                    ClothesId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    DonateTypeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 55, nullable: false),
                    Note = table.Column<string>(maxLength: 255, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesDonate", x => x.ClothesId);
                    table.ForeignKey(
                        name: "FK_ClothesDonate_DonateType_DonateTypeId",
                        column: x => x.DonateTypeId,
                        principalTable: "DonateType",
                        principalColumn: "DonateTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClothesDonate_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsDonate",
                columns: table => new
                {
                    GoodsId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    DonateTypeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 55, nullable: false),
                    Note = table.Column<string>(maxLength: 255, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsDonate", x => x.GoodsId);
                    table.ForeignKey(
                        name: "FK_GoodsDonate_DonateType_DonateTypeId",
                        column: x => x.DonateTypeId,
                        principalTable: "DonateType",
                        principalColumn: "DonateTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsDonate_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalDonate",
                columns: table => new
                {
                    MedicalId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    DonateTypeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 55, nullable: false),
                    Note = table.Column<string>(maxLength: 255, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDonate", x => x.MedicalId);
                    table.ForeignKey(
                        name: "FK_MedicalDonate_DonateType_DonateTypeId",
                        column: x => x.DonateTypeId,
                        principalTable: "DonateType",
                        principalColumn: "DonateTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalDonate_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothesDonate_DonateTypeId",
                table: "ClothesDonate",
                column: "DonateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothesDonate_UserId",
                table: "ClothesDonate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsDonate_DonateTypeId",
                table: "GoodsDonate",
                column: "DonateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsDonate_UserId",
                table: "GoodsDonate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDonate_DonateTypeId",
                table: "MedicalDonate",
                column: "DonateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDonate_UserId",
                table: "MedicalDonate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyDonate_DonateTypeId",
                table: "MoneyDonate",
                column: "DonateTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothesDonate");

            migrationBuilder.DropTable(
                name: "GoodsDonate");

            migrationBuilder.DropTable(
                name: "MedicalDonate");

            migrationBuilder.DropTable(
                name: "MoneyDonate");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "DonateType");
        }
    }
}
