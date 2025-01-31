using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymAppWeDo.Migrations
{
    /// <inheritdoc />
    public partial class Trainin_record_with_date_time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAndTimeOfTheTraining",
                table: "TrainingRecords",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAndTimeOfTheTraining",
                table: "TrainingRecords");
        }
    }
}
