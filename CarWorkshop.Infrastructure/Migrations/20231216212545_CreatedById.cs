using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorkshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "carWorkshops",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_carWorkshops_CreatedById",
                table: "carWorkshops",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_carWorkshops_AspNetUsers_CreatedById",
                table: "carWorkshops",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carWorkshops_AspNetUsers_CreatedById",
                table: "carWorkshops");

            migrationBuilder.DropIndex(
                name: "IX_carWorkshops_CreatedById",
                table: "carWorkshops");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "carWorkshops");
        }
    }
}
