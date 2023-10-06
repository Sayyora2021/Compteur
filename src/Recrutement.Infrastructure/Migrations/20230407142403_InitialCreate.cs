using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recrutement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appareils",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroSerie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatePose = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateDepose = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appareils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Releves",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppareilId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    DateMesure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valeur = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Releves_Appareils_AppareilId",
                        column: x => x.AppareilId,
                        principalTable: "Appareils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            var appareilId1 = Guid.NewGuid();
            var appareilId2 = Guid.NewGuid();
            migrationBuilder.InsertData(
                table: "Appareils",
                columns: new[] { "Id", "NumeroSerie", "DatePose", "Type" },
                values: new object[,]
                {
                    { appareilId1, "NS00001", new DateTimeOffset(DateTime.UtcNow.AddMonths(-1)), "Compteur" },
                    { appareilId2, "NS00002", new DateTimeOffset(DateTime.UtcNow.AddDays(-5)), "Compteur" },
                    { Guid.NewGuid(), "NS00003", new DateTimeOffset(DateTime.UtcNow.AddDays(-5)), "ModuleRadio" },
                    { Guid.NewGuid(), "NS00004", new DateTimeOffset(DateTime.UtcNow), "ModuleRadio" },
                    { Guid.NewGuid(), "NS00005", new DateTimeOffset(DateTime.UtcNow), "Compteur" }
                });

            migrationBuilder.InsertData(
                table: "Releves",
                columns: new[] { "AppareilId", "DateMesure", "Valeur", "Type" },
                values: new object[,]
                {
                    { appareilId1, DateTime.UtcNow.AddDays(-9), 10000m, "Index" },
                    { appareilId1, DateTime.UtcNow.AddDays(-8), 10010m, "Index" },
                    { appareilId1, DateTime.UtcNow.AddDays(-7), 10050m, "Index" },
                    { appareilId1, DateTime.UtcNow.AddDays(-6), 10090m, "Index" },
                    { appareilId1, DateTime.UtcNow.AddDays(-5), 10290m, "Index" },
                    { appareilId1, DateTime.UtcNow.AddDays(-5), 5m, "DebitMin" },
                    { appareilId1, DateTime.UtcNow.AddDays(-4), 10320m, "Index" },
                    { appareilId1, DateTime.UtcNow.AddDays(-3), 10350m, "Index" },
                    { appareilId1, DateTime.UtcNow.AddDays(-2), 10390m, "Index" },
                    { appareilId1, DateTime.UtcNow.AddDays(-1), 10450m, "Index" },
                    { appareilId1, DateTime.UtcNow, 10500m, "Index" },
                    { appareilId2, DateTime.UtcNow.AddDays(-9), 0m, "Index" },
                    { appareilId2, DateTime.UtcNow.AddDays(-8), 100m, "Index" },
                    { appareilId2, DateTime.UtcNow.AddDays(-7), 150m, "Index" },
                    { appareilId2, DateTime.UtcNow.AddDays(-6), 250m, "Index" },
                    { appareilId2, DateTime.UtcNow.AddDays(-5), 400m, "Index" },
                    { appareilId2, DateTime.UtcNow.AddDays(-4), 510m, "Index" },
                    { appareilId2, DateTime.UtcNow.AddDays(-3), 590m, "Index" },
                    { appareilId2, DateTime.UtcNow.AddDays(-2), 660m, "Index" },
                    { appareilId2, DateTime.UtcNow.AddDays(-1), 700m, "Index" },
                    { appareilId2, DateTime.UtcNow, 730m, "Index" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Releves_AppareilId",
                table: "Releves",
                column: "AppareilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Releves");

            migrationBuilder.DropTable(
                name: "Appareils");
        }
    }
}
