using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WalktoMordor.Migrations.Tracker
{
    public partial class distancecalcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistCount",
                table: "Tracker",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DistTotal",
                table: "Tracker",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistCount",
                table: "Tracker");

            migrationBuilder.DropColumn(
                name: "DistTotal",
                table: "Tracker");
        }
    }
}
