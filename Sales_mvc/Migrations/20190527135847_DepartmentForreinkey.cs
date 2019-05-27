using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales_mvc.Migrations
{
    public partial class DepartmentForreinkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Department_departmentId",
                table: "Sellers");

            migrationBuilder.AlterColumn<int>(
                name: "departmentId",
                table: "Sellers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Department_departmentId",
                table: "Sellers",
                column: "departmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Department_departmentId",
                table: "Sellers");

            migrationBuilder.AlterColumn<int>(
                name: "departmentId",
                table: "Sellers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Department_departmentId",
                table: "Sellers",
                column: "departmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
