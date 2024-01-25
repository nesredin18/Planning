using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Todo.Migrations
{
    /// <inheritdoc />
    public partial class progressmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terms_Objectives_ObjectiveId",
                table: "Terms");

            migrationBuilder.DropIndex(
                name: "IX_Terms_ObjectiveId",
                table: "Terms");

            migrationBuilder.DropColumn(
                name: "ObjectiveId",
                table: "Terms");

            migrationBuilder.CreateTable(
                name: "ActivityProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Activity_id = table.Column<int>(type: "integer", nullable: false),
                    Done_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Result = table.Column<string>(type: "text", nullable: false),
                    ActivityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityProgress_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectiveModelTermModel",
                columns: table => new
                {
                    ObjectiveId = table.Column<int>(type: "integer", nullable: false),
                    TermsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveModelTermModel", x => new { x.ObjectiveId, x.TermsId });
                    table.ForeignKey(
                        name: "FK_ObjectiveModelTermModel_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectiveModelTermModel_Terms_TermsId",
                        column: x => x.TermsId,
                        principalTable: "Terms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectiveProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Objective_id = table.Column<int>(type: "integer", nullable: false),
                    Done_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Result = table.Column<string>(type: "text", nullable: false),
                    ObjectiveId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectiveProgress_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityProgress_ActivityId",
                table: "ActivityProgress",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveModelTermModel_TermsId",
                table: "ObjectiveModelTermModel",
                column: "TermsId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveProgress_ObjectiveId",
                table: "ObjectiveProgress",
                column: "ObjectiveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityProgress");

            migrationBuilder.DropTable(
                name: "ObjectiveModelTermModel");

            migrationBuilder.DropTable(
                name: "ObjectiveProgress");

            migrationBuilder.AddColumn<int>(
                name: "ObjectiveId",
                table: "Terms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Terms_ObjectiveId",
                table: "Terms",
                column: "ObjectiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Terms_Objectives_ObjectiveId",
                table: "Terms",
                column: "ObjectiveId",
                principalTable: "Objectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
