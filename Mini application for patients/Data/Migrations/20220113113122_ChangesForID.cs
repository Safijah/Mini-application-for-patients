using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ChangesForID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_PatientID1",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PatientID1",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientID1",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "PatientID",
                table: "Appointment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientID",
                table: "Appointment",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patient_PatientID",
                table: "Appointment",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_PatientID",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PatientID",
                table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Appointment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientID1",
                table: "Appointment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientID1",
                table: "Appointment",
                column: "PatientID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patient_PatientID1",
                table: "Appointment",
                column: "PatientID1",
                principalTable: "Patient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
