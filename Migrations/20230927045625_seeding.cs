using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITraining.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"), "Shivapuri", "Bishnudwar" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"));
        }
    }
}
