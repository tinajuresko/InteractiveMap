using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Karta.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENCUredaj",
                columns: table => new
                {
                    IdENC = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrojRacuna = table.Column<string>(type: "character(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: false),
                    StanjeNaRacunuEuro = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    ImeVlasnika = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: false),
                    PrezimeVlasnika = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: false),
                    EmailVlasnika = table.Column<string>(type: "character varying(320)", unicode: false, maxLength: 320, nullable: false),
                    VrijediOd = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__0F3CDA59D3292AFD", x => x.IdENC);
                });

            migrationBuilder.CreateTable(
                name: "Koncesionar",
                columns: table => new
                {
                    IdKoncesionar = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NazivKoncesionar = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: false),
                    OIBKoncesionar = table.Column<string>(type: "character varying(13)", unicode: false, maxLength: 13, nullable: false),
                    TipKoncesionar = table.Column<string>(type: "character varying(13)", unicode: false, maxLength: 13, nullable: false),
                    Adresa = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: false),
                    NazivMjesto = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    Tel = table.Column<string>(type: "character varying(13)", unicode: false, maxLength: 13, nullable: false),
                    Fax = table.Column<string>(type: "character varying(13)", unicode: false, maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: false),
                    WebURL = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koncesionar", x => x.IdKoncesionar);
                });

            migrationBuilder.CreateTable(
                name: "VrstaOdrzavanja",
                columns: table => new
                {
                    IdVrsta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NazivVrsta = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaOdrzavanja", x => x.IdVrsta);
                });

            migrationBuilder.CreateTable(
                name: "VrstaOdziva",
                columns: table => new
                {
                    idVrstaOdziva = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    opisOdziva = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: true),
                    imeOdziva = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaOdziva", x => x.idVrstaOdziva);
                });

            migrationBuilder.CreateTable(
                name: "VrstaPratecegSadrzaj",
                columns: table => new
                {
                    IdVrstaPratecegSadrzaja = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NazivVrstePratecegSadrzaja = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaPratecegSadrzaja", x => x.IdVrstaPratecegSadrzaja);
                });

            migrationBuilder.CreateTable(
                name: "Autocesta",
                columns: table => new
                {
                    IdAutocesta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NazivAutocesta = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    IdKoncesionar = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autocesta", x => x.IdAutocesta);
                    table.ForeignKey(
                        name: "FK_Autocesta_Koncesionar",
                        column: x => x.IdKoncesionar,
                        principalTable: "Koncesionar",
                        principalColumn: "IdKoncesionar");
                });

            migrationBuilder.CreateTable(
                name: "Dionica",
                columns: table => new
                {
                    IdDionica = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdAutocesta = table.Column<int>(type: "integer", nullable: false),
                    NazivDionica = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: false),
                    Kilometraža = table.Column<decimal>(type: "numeric(10,3)", nullable: false),
                    BrojTraka = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dionica", x => x.IdDionica);
                    table.ForeignKey(
                        name: "FK_Dionica_Autocesta",
                        column: x => x.IdAutocesta,
                        principalTable: "Autocesta",
                        principalColumn: "IdAutocesta");
                });

            migrationBuilder.CreateTable(
                name: "Dogadaj",
                columns: table => new
                {
                    idDogadaj = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idDionica = table.Column<int>(type: "integer", nullable: false),
                    meteoroloskiUvjeti = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: true),
                    opisDogadaja = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: true),
                    vrijemeDogadaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogadaj", x => x.idDogadaj);
                    table.ForeignKey(
                        name: "FK_Dogadaj_Dionica",
                        column: x => x.idDionica,
                        principalTable: "Dionica",
                        principalColumn: "IdDionica");
                });

            migrationBuilder.CreateTable(
                name: "NaplatnaPostaja",
                columns: table => new
                {
                    IdNaplatnaPostaja = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdDionica = table.Column<int>(type: "integer", nullable: false),
                    NazivNaplatnaPostaja = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    NaplatnaPostajaKoordinateNS = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    NaplatnaPostajaKoordinateEW = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    RadnoVrijemeOd = table.Column<TimeSpan>(type: "interval", nullable: true),
                    RadnoVrijemeDo = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Kontakt = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: true),
                    BrojNaplatnihStaza = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaplatnaPostaja", x => x.IdNaplatnaPostaja);
                    table.ForeignKey(
                        name: "FK_NaplatnaPostaja_Dionica",
                        column: x => x.IdDionica,
                        principalTable: "Dionica",
                        principalColumn: "IdDionica");
                });

            migrationBuilder.CreateTable(
                name: "Objekt",
                columns: table => new
                {
                    IdObjekt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdDionica = table.Column<int>(type: "integer", nullable: false),
                    NazivObjekt = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: false),
                    ObjektKoordinateNS = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    ObjektKoordinateEW = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    Tip = table.Column<string>(type: "character varying(8)", unicode: false, maxLength: 8, nullable: false),
                    Podtip = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    NadmorskaVisina = table.Column<int>(type: "integer", nullable: true),
                    Duljina = table.Column<int>(type: "integer", nullable: true),
                    Opis = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true),
                    Stacionaza = table.Column<decimal>(type: "numeric(10,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objekt", x => x.IdObjekt);
                    table.ForeignKey(
                        name: "FK_Objekt_Dionica",
                        column: x => x.IdDionica,
                        principalTable: "Dionica",
                        principalColumn: "IdDionica");
                });

            migrationBuilder.CreateTable(
                name: "Odmoriste",
                columns: table => new
                {
                    IdOdmoriste = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NazivOdmoriste = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    IdDionica = table.Column<int>(type: "integer", nullable: false),
                    KilometarNaAutocesti = table.Column<decimal>(type: "numeric(10,3)", nullable: false),
                    Smjer = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    KapacitetAdr = table.Column<int>(type: "integer", nullable: true),
                    KapacitetTer = table.Column<int>(type: "integer", nullable: true),
                    KapacitetBus = table.Column<int>(type: "integer", nullable: true),
                    OdmoristeKoordinateNS = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    OdmoristeKoordinateEW = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odmoriste", x => x.IdOdmoriste);
                    table.ForeignKey(
                        name: "FK_OdmoristeDionica",
                        column: x => x.IdDionica,
                        principalTable: "Dionica",
                        principalColumn: "IdDionica");
                });

            migrationBuilder.CreateTable(
                name: "Odziv",
                columns: table => new
                {
                    idOdziv = table.Column<int>(type: "integer", nullable: false),
                    idVrstaOdziva = table.Column<int>(type: "integer", nullable: false),
                    idDogadaj = table.Column<int>(type: "integer", nullable: false),
                    vrijemeOdziva = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odziv", x => x.idOdziv);
                    table.ForeignKey(
                        name: "fk_odzivDogadaj",
                        column: x => x.idOdziv,
                        principalTable: "Dogadaj",
                        principalColumn: "idDogadaj");
                    table.ForeignKey(
                        name: "fk_odzivVrstaOdziva",
                        column: x => x.idOdziv,
                        principalTable: "VrstaOdziva",
                        principalColumn: "idVrstaOdziva"); 
                });

            migrationBuilder.CreateTable(
                name: "Cjenik",
                columns: table => new
                {
                    IdCjenik = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdNaplatnaPostaja = table.Column<int>(type: "integer", nullable: false),
                    IzlaznaPostaja = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    IAKategorijaCijenaEuro = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    IKategorijaCijenaEuro = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    IIKategorijaCijenaEuro = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    IIIKategorijaCijenaEuro = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    IVKategorijaCijenaEuro = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cjenik", x => x.IdCjenik);
                    table.ForeignKey(
                        name: "FK_Cjenik_NaplatnaPostaja",
                        column: x => x.IdNaplatnaPostaja,
                        principalTable: "NaplatnaPostaja",
                        principalColumn: "IdNaplatnaPostaja");
                });

            migrationBuilder.CreateTable(
                name: "NaplatnaKucica",
                columns: table => new
                {
                    IdNaplatnaKucica = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdNaplatnaPostaja = table.Column<int>(type: "integer", nullable: false),
                    BrojStaze = table.Column<int>(type: "integer", nullable: false),
                    MinKategorijaVozila = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    MaxKategorijaVozila = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    OtvorenaNaplatnaKucica = table.Column<string>(type: "text", nullable: true),
                    PodrzavaENC = table.Column<string>(type: "text", nullable: true),
                    NadoplataENCa = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaplatnaKucica", x => x.IdNaplatnaKucica);
                    table.ForeignKey(
                        name: "FK_NaplatnaKucica_NaplatnaPostaja",
                        column: x => x.IdNaplatnaPostaja,
                        principalTable: "NaplatnaPostaja",
                        principalColumn: "IdNaplatnaPostaja");
                });

            migrationBuilder.CreateTable(
                name: "Odrzavanje",
                columns: table => new
                {
                    IdOdržavanje = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdObjekt = table.Column<int>(type: "integer", nullable: false),
                    Vrijeme = table.Column<DateTime>(type: "datetime", nullable: false),
                    Opis = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: false),
                    IdVrstaOdrzavanja = table.Column<int>(type: "integer", nullable: false),
                    Izvodac = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odrzavanje", x => x.IdOdržavanje);
                    table.ForeignKey(
                        name: "FK_Odrzavanje_Objekt",
                        column: x => x.IdObjekt,
                        principalTable: "Objekt",
                        principalColumn: "IdObjekt");
                    table.ForeignKey(
                        name: "FK_Odrzavanje_VrstaOdrzavanja",
                        column: x => x.IdVrstaOdrzavanja,
                        principalTable: "VrstaOdrzavanja",
                        principalColumn: "IdVrsta");
                });

            migrationBuilder.CreateTable(
                name: "PrateciSadrzaj",
                columns: table => new
                {
                    IdPratecegSadrzaja = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NazivPratecegSadrzaja = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: false),
                    IdOdmoriste = table.Column<int>(type: "integer", nullable: false),
                    IdVrstaPratecegSadrzaja = table.Column<int>(type: "integer", nullable: false),
                    RadnoVrijemeOd = table.Column<TimeSpan>(type: "interval", nullable: true),
                    RadnoVrijemeDo = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Smjer = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    Upravitelj = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: false),
                    MedijskiSadrzaj = table.Column<string>(type: "character varying(1024)", unicode: false, maxLength: 1024, nullable: true),
                    PrateciSadrzajKoordinateNS = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    PrateciSadrzajKoordinateEW = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrateciSadrzaj", x => x.IdPratecegSadrzaja);
                    table.ForeignKey(
                        name: "FK_PrateciSadrzajOdmoriste",
                        column: x => x.IdOdmoriste,
                        principalTable: "Odmoriste",
                        principalColumn: "IdOdmoriste");
                    table.ForeignKey(
                        name: "FK_VrstaPrateciSadrzaj",
                        column: x => x.IdVrstaPratecegSadrzaja,
                        principalTable: "VrstaPratecegSadrzaj",
                        principalColumn: "IdVrstaPratecegSadrzaja");
                });

            migrationBuilder.CreateTable(
                name: "ENCProlazak",
                columns: table => new
                {
                    IdProlaska = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VrijemeProlaska = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdNaplatnaKucica = table.Column<int>(type: "integer", nullable: false),
                    IdENC = table.Column<int>(type: "integer", nullable: false),
                    KategorijaVozila = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENCProlazak", x => x.IdProlaska);
                    table.ForeignKey(
                        name: "FK_ENC",
                        column: x => x.IdENC,
                        principalTable: "ENCUredaj",
                        principalColumn: "IdENC");
                    table.ForeignKey(
                        name: "FK_Kucica",
                        column: x => x.IdNaplatnaKucica,
                        principalTable: "NaplatnaKucica",
                        principalColumn: "IdNaplatnaKucica");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autocesta_IdKoncesionar",
                table: "Autocesta",
                column: "IdKoncesionar");

            migrationBuilder.CreateIndex(
                name: "IX_Cjenik_IdNaplatnaPostaja",
                table: "Cjenik",
                column: "IdNaplatnaPostaja");

            migrationBuilder.CreateIndex(
                name: "IX_Dionica_IdAutocesta",
                table: "Dionica",
                column: "IdAutocesta");

            migrationBuilder.CreateIndex(
                name: "IX_Dogadaj_idDionica",
                table: "Dogadaj",
                column: "idDionica");

            migrationBuilder.CreateIndex(
                name: "Index_",
                table: "ENCProlazak",
                columns: new[] { "VrijemeProlaska", "IdNaplatnaKucica" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_vrijemeVozilo",
                table: "ENCProlazak",
                columns: new[] { "VrijemeProlaska", "IdENC" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ENCProlazak_IdENC",
                table: "ENCProlazak",
                column: "IdENC");

            migrationBuilder.CreateIndex(
                name: "IX_ENCProlazak_IdNaplatnaKucica",
                table: "ENCProlazak",
                column: "IdNaplatnaKucica");

            migrationBuilder.CreateIndex(
                name: "email_unique",
                table: "ENCUredaj",
                column: "EmailVlasnika",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "racun_unique",
                table: "ENCUredaj",
                column: "BrojRacuna",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__tmp_ms_x__41822FC0EADFFB03",
                table: "ENCUredaj",
                column: "EmailVlasnika",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "index_naplatnaKucicaStazaUnique",
                table: "NaplatnaKucica",
                columns: new[] { "IdNaplatnaPostaja", "BrojStaze" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NaplatnaPostaja_IdDionica",
                table: "NaplatnaPostaja",
                column: "IdDionica");

            migrationBuilder.CreateIndex(
                name: "IX_Objekt_IdDionica",
                table: "Objekt",
                column: "IdDionica");

            migrationBuilder.CreateIndex(
                name: "IX_Odmoriste_IdDionica",
                table: "Odmoriste",
                column: "IdDionica");

            migrationBuilder.CreateIndex(
                name: "UNIQUE_NazivOdmorista",
                table: "Odmoriste",
                column: "NazivOdmoriste",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Odrzavanje_IdObjekt",
                table: "Odrzavanje",
                column: "IdObjekt");

            migrationBuilder.CreateIndex(
                name: "IX_Odrzavanje_IdVrstaOdrzavanja",
                table: "Odrzavanje",
                column: "IdVrstaOdrzavanja");

            migrationBuilder.CreateIndex(
                name: "IX_PrateciSadrzaj_IdOdmoriste",
                table: "PrateciSadrzaj",
                column: "IdOdmoriste");

            migrationBuilder.CreateIndex(
                name: "IX_PrateciSadrzaj_IdVrstaPratecegSadrzaja",
                table: "PrateciSadrzaj",
                column: "IdVrstaPratecegSadrzaja");

            migrationBuilder.CreateIndex(
                name: "UNIQUE_NazivVrstePratecegSadrzaja",
                table: "VrstaPratecegSadrzaj",
                column: "NazivVrstePratecegSadrzaja",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cjenik");

            migrationBuilder.DropTable(
                name: "ENCProlazak");

            migrationBuilder.DropTable(
                name: "Odrzavanje");

            migrationBuilder.DropTable(
                name: "Odziv");

            migrationBuilder.DropTable(
                name: "PrateciSadrzaj");

            migrationBuilder.DropTable(
                name: "ENCUredaj");

            migrationBuilder.DropTable(
                name: "NaplatnaKucica");

            migrationBuilder.DropTable(
                name: "Objekt");

            migrationBuilder.DropTable(
                name: "VrstaOdrzavanja");

            migrationBuilder.DropTable(
                name: "Dogadaj");

            migrationBuilder.DropTable(
                name: "VrstaOdziva");

            migrationBuilder.DropTable(
                name: "Odmoriste");

            migrationBuilder.DropTable(
                name: "VrstaPratecegSadrzaj");

            migrationBuilder.DropTable(
                name: "NaplatnaPostaja");

            migrationBuilder.DropTable(
                name: "Dionica");

            migrationBuilder.DropTable(
                name: "Autocesta");

            migrationBuilder.DropTable(
                name: "Koncesionar");
        }
    }
}
