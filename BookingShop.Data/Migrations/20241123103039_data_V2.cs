using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class data_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_paymentStatuses_PaymentStatusId",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentStatusId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_paymentStatuses_PaymentStatusId",
                table: "Orders",
                column: "PaymentStatusId",
                principalTable: "paymentStatuses",
                principalColumn: "PaymentStatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_paymentStatuses_PaymentStatusId",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentStatusId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_paymentStatuses_PaymentStatusId",
                table: "Orders",
                column: "PaymentStatusId",
                principalTable: "paymentStatuses",
                principalColumn: "PaymentStatusID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
