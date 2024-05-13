using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karta.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autocesta_Koncesionar",
                table: "Autocesta");

            migrationBuilder.DropForeignKey(
                name: "FK_Cjenik_NaplatnaPostaja",
                table: "Cjenik");

            migrationBuilder.DropForeignKey(
                name: "FK_Dionica_Autocesta",
                table: "Dionica");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogadaj_Dionica",
                table: "Dogadaj");

            migrationBuilder.DropForeignKey(
                name: "FK_NaplatnaPostaja_Dionica",
                table: "NaplatnaPostaja");

            migrationBuilder.DropForeignKey(
                name: "FK_OdmoristeDionica",
                table: "Odmoriste");

            migrationBuilder.DropForeignKey(
                name: "FK_PrateciSadrzajOdmoriste",
                table: "PrateciSadrzaj");

            migrationBuilder.DropForeignKey(
                name: "FK_VrstaPrateciSadrzaj",
                table: "PrateciSadrzaj");

            migrationBuilder.DropIndex(
                name: "UNIQUE_NazivOdmorista",
                table: "Odmoriste");

            migrationBuilder.DropColumn(
                name: "MedijskiSadrzaj",
                table: "PrateciSadrzaj");

            migrationBuilder.DropColumn(
                name: "PrateciSadrzajKoordinateEW",
                table: "PrateciSadrzaj");

            migrationBuilder.DropColumn(
                name: "PrateciSadrzajKoordinateNS",
                table: "PrateciSadrzaj");

            migrationBuilder.DropColumn(
                name: "Smjer",
                table: "PrateciSadrzaj");

            migrationBuilder.DropColumn(
                name: "Upravitelj",
                table: "PrateciSadrzaj");

            migrationBuilder.DropColumn(
                name: "KapacitetAdr",
                table: "Odmoriste");

            migrationBuilder.DropColumn(
                name: "KapacitetBus",
                table: "Odmoriste");

            migrationBuilder.DropColumn(
                name: "KapacitetTer",
                table: "Odmoriste");

            migrationBuilder.DropColumn(
                name: "KilometarNaAutocesti",
                table: "Odmoriste");

            migrationBuilder.DropColumn(
                name: "BrojNaplatnihStaza",
                table: "NaplatnaPostaja");

            migrationBuilder.DropColumn(
                name: "RadnoVrijemeDo",
                table: "NaplatnaPostaja");

            migrationBuilder.DropColumn(
                name: "RadnoVrijemeOd",
                table: "NaplatnaPostaja");

            migrationBuilder.RenameColumn(
                name: "OdmoristeKoordinateNS",
                table: "Odmoriste",
                newName: "OdmoristeKoordinateNs");

            migrationBuilder.RenameColumn(
                name: "OdmoristeKoordinateEW",
                table: "Odmoriste",
                newName: "OdmoristeKoordinateEw");

            migrationBuilder.RenameColumn(
                name: "IdDionica",
                table: "Odmoriste",
                newName: "IdAutocesta");

            migrationBuilder.RenameIndex(
                name: "IX_Odmoriste_IdDionica",
                table: "Odmoriste",
                newName: "IX_Odmoriste_IdAutocesta");

            migrationBuilder.RenameColumn(
                name: "NaplatnaPostajaKoordinateNS",
                table: "NaplatnaPostaja",
                newName: "NaplatnaPostajaKoordinateNs");

            migrationBuilder.RenameColumn(
                name: "NaplatnaPostajaKoordinateEW",
                table: "NaplatnaPostaja",
                newName: "NaplatnaPostajaKoordinateEw");

            migrationBuilder.RenameColumn(
                name: "IdDionica",
                table: "NaplatnaPostaja",
                newName: "IdAutocesta");

            migrationBuilder.RenameIndex(
                name: "IX_NaplatnaPostaja_IdDionica",
                table: "NaplatnaPostaja",
                newName: "IX_NaplatnaPostaja_IdAutocesta");

            migrationBuilder.RenameColumn(
                name: "vrijemeDogadaja",
                table: "Dogadaj",
                newName: "VrijemeDogadaja");

            migrationBuilder.RenameColumn(
                name: "opisDogadaja",
                table: "Dogadaj",
                newName: "OpisDogadaja");

            migrationBuilder.RenameColumn(
                name: "meteoroloskiUvjeti",
                table: "Dogadaj",
                newName: "MeteoroloskiUvjeti");

            migrationBuilder.RenameColumn(
                name: "idDionica",
                table: "Dogadaj",
                newName: "IdDionica");

            migrationBuilder.RenameColumn(
                name: "idDogadaj",
                table: "Dogadaj",
                newName: "IdDogadaj");

            migrationBuilder.RenameIndex(
                name: "IX_Dogadaj_idDionica",
                table: "Dogadaj",
                newName: "IX_Dogadaj_IdDionica");

            migrationBuilder.RenameColumn(
                name: "IVKategorijaCijenaEuro",
                table: "Cjenik",
                newName: "IvkategorijaCijenaEuro");

            migrationBuilder.RenameColumn(
                name: "IKategorijaCijenaEuro",
                table: "Cjenik",
                newName: "IkategorijaCijenaEuro");

            migrationBuilder.RenameColumn(
                name: "IIKategorijaCijenaEuro",
                table: "Cjenik",
                newName: "IikategorijaCijenaEuro");

            migrationBuilder.RenameColumn(
                name: "IIIKategorijaCijenaEuro",
                table: "Cjenik",
                newName: "IiikategorijaCijenaEuro");

            migrationBuilder.RenameColumn(
                name: "IAKategorijaCijenaEuro",
                table: "Cjenik",
                newName: "IakategorijaCijenaEuro");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "RadnoVrijemeOd",
                table: "PrateciSadrzaj",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "RadnoVrijemeDo",
                table: "PrateciSadrzaj",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Smjer",
                table: "Odmoriste",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldUnicode: false,
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "VrijemeDogadaja",
                table: "Dogadaj",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OpisDogadaja",
                table: "Dogadaj",
                type: "character varying(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(120)",
                oldUnicode: false,
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeteoroloskiUvjeti",
                table: "Dogadaj",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "Dogadaj",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IvkategorijaCijenaEuro",
                table: "Cjenik",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IkategorijaCijenaEuro",
                table: "Cjenik",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IikategorijaCijenaEuro",
                table: "Cjenik",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IiikategorijaCijenaEuro",
                table: "Cjenik",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IakategorijaCijenaEuro",
                table: "Cjenik",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "Autocesta_IdKoncesionar_fkey",
                table: "Autocesta",
                column: "IdKoncesionar",
                principalTable: "Koncesionar",
                principalColumn: "IdKoncesionar");

            migrationBuilder.AddForeignKey(
                name: "Cjenik_IdNaplatnaPostaja_fkey",
                table: "Cjenik",
                column: "IdNaplatnaPostaja",
                principalTable: "NaplatnaPostaja",
                principalColumn: "IdNaplatnaPostaja");

            migrationBuilder.AddForeignKey(
                name: "Dionica_IdAutocesta_fkey",
                table: "Dionica",
                column: "IdAutocesta",
                principalTable: "Autocesta",
                principalColumn: "IdAutocesta");

            migrationBuilder.AddForeignKey(
                name: "Dogadaj_IdDionica_fkey",
                table: "Dogadaj",
                column: "IdDionica",
                principalTable: "Dionica",
                principalColumn: "IdDionica");

            migrationBuilder.AddForeignKey(
                name: "naplatnapostaja_idautocesta_fkey",
                table: "NaplatnaPostaja",
                column: "IdAutocesta",
                principalTable: "Autocesta",
                principalColumn: "IdAutocesta");

            migrationBuilder.AddForeignKey(
                name: "odmoriste_idautocesta_fkey",
                table: "Odmoriste",
                column: "IdAutocesta",
                principalTable: "Autocesta",
                principalColumn: "IdAutocesta");

            migrationBuilder.AddForeignKey(
                name: "pratecisadrzaj_idodmoriste_fkey",
                table: "PrateciSadrzaj",
                column: "IdOdmoriste",
                principalTable: "Odmoriste",
                principalColumn: "IdOdmoriste");

            migrationBuilder.AddForeignKey(
                name: "pratecisadrzaj_idvrstapratecegsadrzaja_fkey",
                table: "PrateciSadrzaj",
                column: "IdVrstaPratecegSadrzaja",
                principalTable: "VrstaPratecegSadrzaj",
                principalColumn: "IdVrstaPratecegSadrzaja");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Autocesta_IdKoncesionar_fkey",
                table: "Autocesta");

            migrationBuilder.DropForeignKey(
                name: "Cjenik_IdNaplatnaPostaja_fkey",
                table: "Cjenik");

            migrationBuilder.DropForeignKey(
                name: "Dionica_IdAutocesta_fkey",
                table: "Dionica");

            migrationBuilder.DropForeignKey(
                name: "Dogadaj_IdDionica_fkey",
                table: "Dogadaj");

            migrationBuilder.DropForeignKey(
                name: "naplatnapostaja_idautocesta_fkey",
                table: "NaplatnaPostaja");

            migrationBuilder.DropForeignKey(
                name: "odmoriste_idautocesta_fkey",
                table: "Odmoriste");

            migrationBuilder.DropForeignKey(
                name: "pratecisadrzaj_idodmoriste_fkey",
                table: "PrateciSadrzaj");

            migrationBuilder.DropForeignKey(
                name: "pratecisadrzaj_idvrstapratecegsadrzaja_fkey",
                table: "PrateciSadrzaj");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Dogadaj");

            migrationBuilder.RenameColumn(
                name: "OdmoristeKoordinateNs",
                table: "Odmoriste",
                newName: "OdmoristeKoordinateNS");

            migrationBuilder.RenameColumn(
                name: "OdmoristeKoordinateEw",
                table: "Odmoriste",
                newName: "OdmoristeKoordinateEW");

            migrationBuilder.RenameColumn(
                name: "IdAutocesta",
                table: "Odmoriste",
                newName: "IdDionica");

            migrationBuilder.RenameIndex(
                name: "IX_Odmoriste_IdAutocesta",
                table: "Odmoriste",
                newName: "IX_Odmoriste_IdDionica");

            migrationBuilder.RenameColumn(
                name: "NaplatnaPostajaKoordinateNs",
                table: "NaplatnaPostaja",
                newName: "NaplatnaPostajaKoordinateNS");

            migrationBuilder.RenameColumn(
                name: "NaplatnaPostajaKoordinateEw",
                table: "NaplatnaPostaja",
                newName: "NaplatnaPostajaKoordinateEW");

            migrationBuilder.RenameColumn(
                name: "IdAutocesta",
                table: "NaplatnaPostaja",
                newName: "IdDionica");

            migrationBuilder.RenameIndex(
                name: "IX_NaplatnaPostaja_IdAutocesta",
                table: "NaplatnaPostaja",
                newName: "IX_NaplatnaPostaja_IdDionica");

            migrationBuilder.RenameColumn(
                name: "VrijemeDogadaja",
                table: "Dogadaj",
                newName: "vrijemeDogadaja");

            migrationBuilder.RenameColumn(
                name: "OpisDogadaja",
                table: "Dogadaj",
                newName: "opisDogadaja");

            migrationBuilder.RenameColumn(
                name: "MeteoroloskiUvjeti",
                table: "Dogadaj",
                newName: "meteoroloskiUvjeti");

            migrationBuilder.RenameColumn(
                name: "IdDionica",
                table: "Dogadaj",
                newName: "idDionica");

            migrationBuilder.RenameColumn(
                name: "IdDogadaj",
                table: "Dogadaj",
                newName: "idDogadaj");

            migrationBuilder.RenameIndex(
                name: "IX_Dogadaj_IdDionica",
                table: "Dogadaj",
                newName: "IX_Dogadaj_idDionica");

            migrationBuilder.RenameColumn(
                name: "IvkategorijaCijenaEuro",
                table: "Cjenik",
                newName: "IVKategorijaCijenaEuro");

            migrationBuilder.RenameColumn(
                name: "IkategorijaCijenaEuro",
                table: "Cjenik",
                newName: "IKategorijaCijenaEuro");

            migrationBuilder.RenameColumn(
                name: "IikategorijaCijenaEuro",
                table: "Cjenik",
                newName: "IIKategorijaCijenaEuro");

            migrationBuilder.RenameColumn(
                name: "IiikategorijaCijenaEuro",
                table: "Cjenik",
                newName: "IIIKategorijaCijenaEuro");

            migrationBuilder.RenameColumn(
                name: "IakategorijaCijenaEuro",
                table: "Cjenik",
                newName: "IAKategorijaCijenaEuro");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "RadnoVrijemeOd",
                table: "PrateciSadrzaj",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "RadnoVrijemeDo",
                table: "PrateciSadrzaj",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AddColumn<string>(
                name: "MedijskiSadrzaj",
                table: "PrateciSadrzaj",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrateciSadrzajKoordinateEW",
                table: "PrateciSadrzaj",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrateciSadrzajKoordinateNS",
                table: "PrateciSadrzaj",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Smjer",
                table: "PrateciSadrzaj",
                type: "character varying(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Upravitelj",
                table: "PrateciSadrzaj",
                type: "character varying(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Smjer",
                table: "Odmoriste",
                type: "character varying(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AddColumn<int>(
                name: "KapacitetAdr",
                table: "Odmoriste",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KapacitetBus",
                table: "Odmoriste",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KapacitetTer",
                table: "Odmoriste",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KilometarNaAutocesti",
                table: "Odmoriste",
                type: "numeric(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "BrojNaplatnihStaza",
                table: "NaplatnaPostaja",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RadnoVrijemeDo",
                table: "NaplatnaPostaja",
                type: "interval",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RadnoVrijemeOd",
                table: "NaplatnaPostaja",
                type: "interval",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "vrijemeDogadaja",
                table: "Dogadaj",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "opisDogadaja",
                table: "Dogadaj",
                type: "character varying(120)",
                unicode: false,
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "meteoroloskiUvjeti",
                table: "Dogadaj",
                type: "character varying(40)",
                unicode: false,
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<decimal>(
                name: "IVKategorijaCijenaEuro",
                table: "Cjenik",
                type: "numeric(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "IKategorijaCijenaEuro",
                table: "Cjenik",
                type: "numeric(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "IIKategorijaCijenaEuro",
                table: "Cjenik",
                type: "numeric(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "IIIKategorijaCijenaEuro",
                table: "Cjenik",
                type: "numeric(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "IAKategorijaCijenaEuro",
                table: "Cjenik",
                type: "numeric(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)");

            migrationBuilder.CreateIndex(
                name: "UNIQUE_NazivOdmorista",
                table: "Odmoriste",
                column: "NazivOdmoriste",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Autocesta_Koncesionar",
                table: "Autocesta",
                column: "IdKoncesionar",
                principalTable: "Koncesionar",
                principalColumn: "IdKoncesionar");

            migrationBuilder.AddForeignKey(
                name: "FK_Cjenik_NaplatnaPostaja",
                table: "Cjenik",
                column: "IdNaplatnaPostaja",
                principalTable: "NaplatnaPostaja",
                principalColumn: "IdNaplatnaPostaja");

            migrationBuilder.AddForeignKey(
                name: "FK_Dionica_Autocesta",
                table: "Dionica",
                column: "IdAutocesta",
                principalTable: "Autocesta",
                principalColumn: "IdAutocesta");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogadaj_Dionica",
                table: "Dogadaj",
                column: "idDionica",
                principalTable: "Dionica",
                principalColumn: "IdDionica");

            migrationBuilder.AddForeignKey(
                name: "FK_NaplatnaPostaja_Dionica",
                table: "NaplatnaPostaja",
                column: "IdDionica",
                principalTable: "Dionica",
                principalColumn: "IdDionica");

            migrationBuilder.AddForeignKey(
                name: "FK_OdmoristeDionica",
                table: "Odmoriste",
                column: "IdDionica",
                principalTable: "Dionica",
                principalColumn: "IdDionica");

            migrationBuilder.AddForeignKey(
                name: "FK_PrateciSadrzajOdmoriste",
                table: "PrateciSadrzaj",
                column: "IdOdmoriste",
                principalTable: "Odmoriste",
                principalColumn: "IdOdmoriste");

            migrationBuilder.AddForeignKey(
                name: "FK_VrstaPrateciSadrzaj",
                table: "PrateciSadrzaj",
                column: "IdVrstaPratecegSadrzaja",
                principalTable: "VrstaPratecegSadrzaj",
                principalColumn: "IdVrstaPratecegSadrzaja");
        }
    }
}
