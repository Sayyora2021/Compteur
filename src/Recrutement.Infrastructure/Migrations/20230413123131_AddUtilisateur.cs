﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recrutement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUtilisateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });
            
            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "Nom", "Prenom" },
                values: new object[,]
                {
                    { "CHOISNET", "Mickael" },
                    { "LEBRETON", "Guillaume" },
                    { "ANDRE", "David" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
