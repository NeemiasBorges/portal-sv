using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class nvmigration0201 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_endereco",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "id_telefone",
                table: "clientes");

            migrationBuilder.AddColumn<string>(
                name: "cep",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "datacriacao",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "sexo",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cep",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "datacriacao",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "sexo",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "telefone",
                table: "clientes");

            migrationBuilder.AddColumn<int>(
                name: "id_endereco",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_telefone",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
