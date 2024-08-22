using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobile.DB.Migrations
{
    /// <inheritdoc />
    public partial class dbupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ContryCodeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContryCodeId",
                table: "Users",
                column: "ContryCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Dropdowns_ContryCodeId",
                table: "Users",
                column: "ContryCodeId",
                principalTable: "Dropdowns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Dropdowns_ContryCodeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ContryCodeId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ContryCodeId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
