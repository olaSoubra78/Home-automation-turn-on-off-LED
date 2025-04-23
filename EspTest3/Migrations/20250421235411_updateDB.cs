using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EspTest3.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "TblAction",
            //    columns: table => new
            //    {
            //        ActionId = table.Column<int>(type: "int", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TblAction", x => x.ActionId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TblLed",
            //    columns: table => new
            //    {
            //        LedId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LedColour = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TblLed", x => x.LedId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TblLedAction",
            //    columns: table => new
            //    {
            //        LedActionId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ActionId = table.Column<int>(type: "int", nullable: false),
            //        LedId = table.Column<int>(type: "int", nullable: false),
            //        Time = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TblLedAction", x => x.LedActionId);
            //        table.ForeignKey(
            //            name: "FK_TblLedAction_TblAction",
            //            column: x => x.ActionId,
            //            principalTable: "TblAction",
            //            principalColumn: "ActionId");
            //        table.ForeignKey(
            //            name: "FK_TblLedAction_TblLed",
            //            column: x => x.LedId,
            //            principalTable: "TblLed",
            //            principalColumn: "LedId");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_TblLedAction_ActionId",
            //    table: "TblLedAction",
            //    column: "ActionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TblLedAction_LedId",
            //    table: "TblLedAction",
            //    column: "LedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "TblLedAction");

            //migrationBuilder.DropTable(
            //    name: "TblAction");

            //migrationBuilder.DropTable(
            //    name: "TblLed");
        }
    }
}
