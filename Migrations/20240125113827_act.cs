using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Migrations
{
    /// <inheritdoc />
    public partial class act : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityProgress_Activities_ActivityId",
                table: "ActivityProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectiveProgress_Objectives_ObjectiveId",
                table: "ObjectiveProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_SubActivities_Activities_ActivityId",
                table: "SubActivities");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Terms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "SubActivities",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectiveId",
                table: "ObjectiveProgress",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "ActivityProgress",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityProgress_Activities_ActivityId",
                table: "ActivityProgress",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectiveProgress_Objectives_ObjectiveId",
                table: "ObjectiveProgress",
                column: "ObjectiveId",
                principalTable: "Objectives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubActivities_Activities_ActivityId",
                table: "SubActivities",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityProgress_Activities_ActivityId",
                table: "ActivityProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectiveProgress_Objectives_ObjectiveId",
                table: "ObjectiveProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_SubActivities_Activities_ActivityId",
                table: "SubActivities");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Terms");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "SubActivities",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ObjectiveId",
                table: "ObjectiveProgress",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "ActivityProgress",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityProgress_Activities_ActivityId",
                table: "ActivityProgress",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectiveProgress_Objectives_ObjectiveId",
                table: "ObjectiveProgress",
                column: "ObjectiveId",
                principalTable: "Objectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubActivities_Activities_ActivityId",
                table: "SubActivities",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
