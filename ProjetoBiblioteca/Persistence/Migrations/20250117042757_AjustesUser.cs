using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBiblioteca.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AjustesUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Books_BookId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Loans_LoanId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BookId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LoanId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdBook",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdLoan",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdBook",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLoan",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoanId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BookId",
                table: "Users",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoanId",
                table: "Users",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Books_BookId",
                table: "Users",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Loans_LoanId",
                table: "Users",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
