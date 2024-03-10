using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RobotApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableRobot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Robot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "getutcdate()"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleteDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robot", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Robot");
        }
    }
}
