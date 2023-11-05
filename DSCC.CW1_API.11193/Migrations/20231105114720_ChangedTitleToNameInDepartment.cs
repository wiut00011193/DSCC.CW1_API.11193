using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSCC.CW1_API._11193.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTitleToNameInDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Departments",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "Title");
        }
    }
}
