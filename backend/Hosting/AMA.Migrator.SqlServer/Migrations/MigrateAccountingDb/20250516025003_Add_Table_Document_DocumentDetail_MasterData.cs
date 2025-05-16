using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMA.Migrator.SqlServer.Migrations.MigrateAccountingDb
{
    public partial class Add_Table_Document_DocumentDetail_MasterData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AMA");

            migrationBuilder.CreateTable(
                name: "MasterData",
                schema: "AMA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                schema: "AMA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_MasterData_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "AMA",
                        principalTable: "MasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentDetail",
                schema: "AMA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDetail_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "AMA",
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentDetail_MasterData_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalSchema: "AMA",
                        principalTable: "MasterData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_TypeId",
                schema: "AMA",
                table: "Document",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetail_DocumentId",
                schema: "AMA",
                table: "DocumentDetail",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetail_TransactionTypeId",
                schema: "AMA",
                table: "DocumentDetail",
                column: "TransactionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentDetail",
                schema: "AMA");

            migrationBuilder.DropTable(
                name: "Document",
                schema: "AMA");

            migrationBuilder.DropTable(
                name: "MasterData",
                schema: "AMA");
        }
    }
}
