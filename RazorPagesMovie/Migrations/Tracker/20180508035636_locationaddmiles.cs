using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WalktoMordor.Migrations.Tracker
{
    public partial class locationaddmiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoalMiles",
                table: "Location",
                newName: "StartMiles");

            migrationBuilder.AddColumn<decimal>(
                name: "DistTotal",
                table: "Location",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EndMiles",
                table: "Location",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistTotal",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "EndMiles",
                table: "Location");

            migrationBuilder.RenameColumn(
                name: "StartMiles",
                table: "Location",
                newName: "GoalMiles");
        }
    }
}
