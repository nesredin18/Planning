using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Todo.Migrations
{
    /// <inheritdoc />
    public partial class StartInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Objectives_ObjectiveId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Objectives_ObjectiveModelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_User_types_User_typeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ObjectiveModelUserModel");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "User_types");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ObjectiveModelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_User_typeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ObjectiveId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ObjectiveModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_typeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ObjectiveId",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Terms",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "result",
                table: "Terms",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "initial_date",
                table: "Terms",
                newName: "Initial_date");

            migrationBuilder.RenameColumn(
                name: "goal",
                table: "Terms",
                newName: "Goal");

            migrationBuilder.RenameColumn(
                name: "final_date",
                table: "Terms",
                newName: "Final_date");

            migrationBuilder.AddColumn<DateTime>(
                name: "Final_date",
                table: "SubActivities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "SubActivities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Initial_date",
                table: "SubActivities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "SubActivities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SubActivities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Final_date",
                table: "Objectives",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "Objectives",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Initial_date",
                table: "Objectives",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Objectives",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Objectives",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Final_date",
                table: "Activities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "Activities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Initial_date",
                table: "Activities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Activities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Activities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ActivityModelObjectiveModel",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "integer", nullable: false),
                    ObjectiveId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityModelObjectiveModel", x => new { x.ActivitiesId, x.ObjectiveId });
                    table.ForeignKey(
                        name: "FK_ActivityModelObjectiveModel_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityModelObjectiveModel_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserObjectiveModel",
                columns: table => new
                {
                    AppUsersId = table.Column<string>(type: "text", nullable: false),
                    ObjectivesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserObjectiveModel", x => new { x.AppUsersId, x.ObjectivesId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserObjectiveModel_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserObjectiveModel_Objectives_ObjectivesId",
                        column: x => x.ObjectivesId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityModelObjectiveModel_ObjectiveId",
                table: "ActivityModelObjectiveModel",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserObjectiveModel_ObjectivesId",
                table: "ApplicationUserObjectiveModel",
                column: "ObjectivesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityModelObjectiveModel");

            migrationBuilder.DropTable(
                name: "ApplicationUserObjectiveModel");

            migrationBuilder.DropColumn(
                name: "Final_date",
                table: "SubActivities");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "SubActivities");

            migrationBuilder.DropColumn(
                name: "Initial_date",
                table: "SubActivities");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "SubActivities");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SubActivities");

            migrationBuilder.DropColumn(
                name: "Final_date",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "Initial_date",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "Final_date",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Initial_date",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Terms",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Terms",
                newName: "result");

            migrationBuilder.RenameColumn(
                name: "Initial_date",
                table: "Terms",
                newName: "initial_date");

            migrationBuilder.RenameColumn(
                name: "Goal",
                table: "Terms",
                newName: "goal");

            migrationBuilder.RenameColumn(
                name: "Final_date",
                table: "Terms",
                newName: "final_date");

            migrationBuilder.AddColumn<int>(
                name: "ObjectiveModelId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_typeId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ObjectiveId",
                table: "Activities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User_typeId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    User_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModel_User_types_User_typeId",
                        column: x => x.User_typeId,
                        principalTable: "User_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectiveModelUserModel",
                columns: table => new
                {
                    ObjectivesId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveModelUserModel", x => new { x.ObjectivesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ObjectiveModelUserModel_Objectives_ObjectivesId",
                        column: x => x.ObjectivesId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectiveModelUserModel_UserModel_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ObjectiveModelId",
                table: "AspNetUsers",
                column: "ObjectiveModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_User_typeId",
                table: "AspNetUsers",
                column: "User_typeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ObjectiveId",
                table: "Activities",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveModelUserModel_UsersId",
                table: "ObjectiveModelUserModel",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_User_typeId",
                table: "UserModel",
                column: "User_typeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Objectives_ObjectiveId",
                table: "Activities",
                column: "ObjectiveId",
                principalTable: "Objectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Objectives_ObjectiveModelId",
                table: "AspNetUsers",
                column: "ObjectiveModelId",
                principalTable: "Objectives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_User_types_User_typeId",
                table: "AspNetUsers",
                column: "User_typeId",
                principalTable: "User_types",
                principalColumn: "Id");
        }
    }
}
