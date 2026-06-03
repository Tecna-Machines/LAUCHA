using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Reinicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CatalogoRetenciones",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unidades = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PrimeraQuincena = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoRetenciones", x => x.Codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Dni = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Dni);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Acuerdos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorBlanco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notas = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DniEmpleado = table.Column<string>(type: "varchar(80)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoSueldo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acuerdos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Acuerdos_Empleados_DniEmpleado",
                        column: x => x.DniEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Adicionales",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EsEnBlanco = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CodigoAcuerdo = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adicionales", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Adicionales_Acuerdos_CodigoAcuerdo",
                        column: x => x.CodigoAcuerdo,
                        principalTable: "Acuerdos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Liquidaciones",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DniEmpleado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Quincena = table.Column<int>(type: "int", nullable: false),
                    CodigoAcuerdo = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaSello = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidaciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Liquidaciones_Acuerdos_CodigoAcuerdo",
                        column: x => x.CodigoAcuerdo,
                        principalTable: "Acuerdos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RetencionAcuerdo",
                columns: table => new
                {
                    CodigoRetencion = table.Column<string>(type: "varchar(80)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoAcuerdo = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unidades = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PrimeraQuincena = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetencionAcuerdo", x => new { x.CodigoRetencion, x.CodigoAcuerdo });
                    table.ForeignKey(
                        name: "FK_RetencionAcuerdo_Acuerdos_CodigoAcuerdo",
                        column: x => x.CodigoAcuerdo,
                        principalTable: "Acuerdos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RetencionAcuerdo_CatalogoRetenciones_CodigoRetencion",
                        column: x => x.CodigoRetencion,
                        principalTable: "CatalogoRetenciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Creditos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MontoPrestado = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MontoDevolver = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DniEmpleado = table.Column<string>(type: "varchar(80)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoLiquidacionAcreditacion = table.Column<string>(type: "varchar(95)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModoPago = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CantidadCuotas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Creditos_Empleados_DniEmpleado",
                        column: x => x.DniEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Creditos_Liquidaciones_CodigoLiquidacionAcreditacion",
                        column: x => x.CodigoLiquidacionAcreditacion,
                        principalTable: "Liquidaciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItemLiquidacion",
                columns: table => new
                {
                    NroItem = table.Column<int>(type: "int", nullable: false),
                    CodigoLiquidacion = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EsEnBlanco = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EsIncremento = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EsAutomatico = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLiquidacion", x => new { x.CodigoLiquidacion, x.NroItem });
                    table.ForeignKey(
                        name: "FK_ItemLiquidacion_Liquidaciones_CodigoLiquidacion",
                        column: x => x.CodigoLiquidacion,
                        principalTable: "Liquidaciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LiquidacionId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReferenciaContabilidad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstadoContable = table.Column<int>(type: "int", nullable: false),
                    Modo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Liquidaciones_LiquidacionId",
                        column: x => x.LiquidacionId,
                        principalTable: "Liquidaciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    Nro = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    CodigoCredito = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Creacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    QuincenaDebitar = table.Column<int>(type: "int", nullable: false),
                    MesDebitar = table.Column<int>(type: "int", nullable: false),
                    AnioDebitar = table.Column<int>(type: "int", nullable: false),
                    CodigoLiquidacion = table.Column<string>(type: "varchar(95)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => new { x.Nro, x.CodigoCredito });
                    table.ForeignKey(
                        name: "FK_Cuotas_Creditos_CodigoCredito",
                        column: x => x.CodigoCredito,
                        principalTable: "Creditos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cuotas_Liquidaciones_CodigoLiquidacion",
                        column: x => x.CodigoLiquidacion,
                        principalTable: "Liquidaciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Acuerdos_DniEmpleado",
                table: "Acuerdos",
                column: "DniEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Adicionales_CodigoAcuerdo",
                table: "Adicionales",
                column: "CodigoAcuerdo");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_CodigoLiquidacionAcreditacion",
                table: "Creditos",
                column: "CodigoLiquidacionAcreditacion");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_DniEmpleado",
                table: "Creditos",
                column: "DniEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_CodigoCredito",
                table: "Cuotas",
                column: "CodigoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_CodigoLiquidacion",
                table: "Cuotas",
                column: "CodigoLiquidacion");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidaciones_CodigoAcuerdo",
                table: "Liquidaciones",
                column: "CodigoAcuerdo");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_LiquidacionId",
                table: "Pagos",
                column: "LiquidacionId");

            migrationBuilder.CreateIndex(
                name: "IX_RetencionAcuerdo_CodigoAcuerdo",
                table: "RetencionAcuerdo",
                column: "CodigoAcuerdo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adicionales");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "ItemLiquidacion");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "RetencionAcuerdo");

            migrationBuilder.DropTable(
                name: "Creditos");

            migrationBuilder.DropTable(
                name: "CatalogoRetenciones");

            migrationBuilder.DropTable(
                name: "Liquidaciones");

            migrationBuilder.DropTable(
                name: "Acuerdos");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
