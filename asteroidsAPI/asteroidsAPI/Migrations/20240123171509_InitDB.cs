using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asteroidsAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TopAsteroids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopAsteroids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asteroids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diameter = table.Column<double>(type: "float", nullable: false),
                    Velocity = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Planet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPotentiallyHazardous = table.Column<bool>(type: "bit", nullable: false),
                    TopAsteroidId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asteroids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asteroids_TopAsteroids_TopAsteroidId",
                        column: x => x.TopAsteroidId,
                        principalTable: "TopAsteroids",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asteroids_TopAsteroidId",
                table: "Asteroids",
                column: "TopAsteroidId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asteroids");

            migrationBuilder.DropTable(
                name: "TopAsteroids");
        }
    }
}
