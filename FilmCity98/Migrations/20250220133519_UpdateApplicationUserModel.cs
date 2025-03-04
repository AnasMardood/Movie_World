﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmCity98.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "security",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                schema: "security",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                schema: "security",
                table: "Users");
        }
    }
}
