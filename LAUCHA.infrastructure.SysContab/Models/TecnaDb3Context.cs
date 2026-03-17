using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class TecnaDb3Context : DbContext
{
    public TecnaDb3Context()
    {
    }

    public TecnaDb3Context(DbContextOptions<TecnaDb3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Acobrar> Acobrars { get; set; }

    public virtual DbSet<AcobrarCccliente> AcobrarCcclientes { get; set; }

    public virtual DbSet<Agastar> Agastars { get; set; }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<ArticulosVariable> ArticulosVariables { get; set; }

    public virtual DbSet<AvancesMontaje> AvancesMontajes { get; set; }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<CamposCsv> CamposCsvs { get; set; }

    public virtual DbSet<Cccliente> Ccclientes { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cobro> Cobros { get; set; }

    public virtual DbSet<CodigoSubcodigo> CodigoSubcodigos { get; set; }

    public virtual DbSet<CodigosConceptoConciliacion> CodigosConceptoConciliacions { get; set; }

    public virtual DbSet<CodigosGasto> CodigosGastos { get; set; }

    public virtual DbSet<CodigosGastoFinal> CodigosGastoFinals { get; set; }

    public virtual DbSet<ConciliaSantander> ConciliaSantanders { get; set; }

    public virtual DbSet<Conciliacione> Conciliaciones { get; set; }

    public virtual DbSet<ConciliacionesControl> ConciliacionesControls { get; set; }

    public virtual DbSet<ConciliacionesVerificar> ConciliacionesVerificars { get; set; }

    public virtual DbSet<Configuracione> Configuraciones { get; set; }

    public virtual DbSet<ContactosWapp> ContactosWapps { get; set; }

    public virtual DbSet<Contenedore> Contenedores { get; set; }

    public virtual DbSet<ContenedoresFiltrado> ContenedoresFiltrados { get; set; }

    public virtual DbSet<ContenedoresOc> ContenedoresOcs { get; set; }

    public virtual DbSet<ContratosTrabajo> ContratosTrabajos { get; set; }

    public virtual DbSet<CostoMxxUsd> CostoMxxUsds { get; set; }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<CuentaCliente> CuentaClientes { get; set; }

    public virtual DbSet<CuentaCorrienteCliente> CuentaCorrienteClientes { get; set; }

    public virtual DbSet<CuentaCorrienteCliente1> CuentaCorrienteClientes1 { get; set; }

    public virtual DbSet<CuentaDolare> CuentaDolares { get; set; }

    public virtual DbSet<Cuentum> Cuenta { get; set; }

    public virtual DbSet<DatosBancoAconciliar> DatosBancoAconciliars { get; set; }

    public virtual DbSet<DescripcionMateriale> DescripcionMateriales { get; set; }

    public virtual DbSet<DiscriminanteContenedor> DiscriminanteContenedors { get; set; }

    public virtual DbSet<DiscriminanteTipoDePieza> DiscriminanteTipoDePiezas { get; set; }

    public virtual DbSet<EstadosCompra> EstadosCompras { get; set; }

    public virtual DbSet<GastadosAgastar> GastadosAgastars { get; set; }

    public virtual DbSet<GastoMaquinasMxx> GastoMaquinasMxxes { get; set; }

    public virtual DbSet<GastosMe> GastosMes { get; set; }

    public virtual DbSet<GastosMxxItem> GastosMxxItems { get; set; }

    public virtual DbSet<Gastosusd> Gastosusds { get; set; }

    public virtual DbSet<Historial> Historials { get; set; }

    public virtual DbSet<ItemsOrdenDeCompra> ItemsOrdenDeCompras { get; set; }

    public virtual DbSet<ItemsSolo> ItemsSolos { get; set; }

    public virtual DbSet<Maquina> Maquinas { get; set; }

    public virtual DbSet<Materiale> Materiales { get; set; }

    public virtual DbSet<Moneda> Monedas { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<MovimientosCuenta> MovimientosCuentas { get; set; }

    public virtual DbSet<MovimientosSinTransferencia> MovimientosSinTransferencias { get; set; }

    public virtual DbSet<Movimientosvista1> Movimientosvista1s { get; set; }

    public virtual DbSet<MrAgastaresOriginale> MrAgastaresOriginales { get; set; }

    public virtual DbSet<MrGastado> MrGastados { get; set; }

    public virtual DbSet<MrVenta> MrVentas { get; set; }

    public virtual DbSet<Mresultado> Mresultados { get; set; }

    public virtual DbSet<NewView> NewViews { get; set; }

    public virtual DbSet<NewView1> NewView1s { get; set; }

    public virtual DbSet<NewView10> NewView10s { get; set; }

    public virtual DbSet<NewView2> NewView2s { get; set; }

    public virtual DbSet<NewView3> NewView3s { get; set; }

    public virtual DbSet<NewView4> NewView4s { get; set; }

    public virtual DbSet<NewView5> NewView5s { get; set; }

    public virtual DbSet<NewView6> NewView6s { get; set; }

    public virtual DbSet<NewView7> NewView7s { get; set; }

    public virtual DbSet<NewView8> NewView8s { get; set; }

    public virtual DbSet<NewView9> NewView9s { get; set; }

    public virtual DbSet<NombresConfiguracionesDatagrid> NombresConfiguracionesDatagrids { get; set; }

    public virtual DbSet<NomenclaturaDiscriminante> NomenclaturaDiscriminantes { get; set; }

    public virtual DbSet<OcEstadoAactual> OcEstadoAactuals { get; set; }

    public virtual DbSet<Ocitem> Ocitems { get; set; }

    public virtual DbSet<Operacione> Operaciones { get; set; }

    public virtual DbSet<Operadore> Operadores { get; set; }

    public virtual DbSet<OrdenDeCompraEstadoCompra> OrdenDeCompraEstadoCompras { get; set; }

    public virtual DbSet<OrdenesDeCompra> OrdenesDeCompras { get; set; }

    public virtual DbSet<OtrosArticulo> OtrosArticulos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<PagoSueldosManual> PagoSueldosManuals { get; set; }

    public virtual DbSet<PermisoOrdenUsuariosAprobar> PermisoOrdenUsuariosAprobars { get; set; }

    public virtual DbSet<PermisoOrdenUsuariosRevisar> PermisoOrdenUsuariosRevisars { get; set; }

    public virtual DbSet<PermisosOrdenDeCompra> PermisosOrdenDeCompras { get; set; }

    public virtual DbSet<Pieza> Piezas { get; set; }

    public virtual DbSet<PiezaUbicacion> PiezaUbicacions { get; set; }

    public virtual DbSet<PorCodigo> PorCodigos { get; set; }

    public virtual DbSet<PorCuenta2> PorCuenta2s { get; set; }

    public virtual DbSet<PorCuentum> PorCuenta { get; set; }

    public virtual DbSet<PorMonedum> PorMoneda { get; set; }

    public virtual DbSet<PorMonedum1> PorMoneda1 { get; set; }

    public virtual DbSet<ProveedorRubroVistum> ProveedorRubroVista { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<RastreoPiezas2> RastreoPiezas2s { get; set; }

    public virtual DbSet<RazonPararProceso> RazonPararProcesos { get; set; }

    public virtual DbSet<Rprl> Rprls { get; set; }

    public virtual DbSet<Rubro> Rubros { get; set; }

    public virtual DbSet<SaldosCliente> SaldosClientes { get; set; }

    public virtual DbSet<Segguimiento2> Segguimiento2s { get; set; }

    public virtual DbSet<Seguimiento2> Seguimiento2s { get; set; }

    public virtual DbSet<SubcodigosGasto> SubcodigosGastos { get; set; }

    public virtual DbSet<Subconciliacione> Subconciliaciones { get; set; }

    public virtual DbSet<Subconjunto> Subconjuntos { get; set; }

    public virtual DbSet<SumPorCuentaDolarOficial> SumPorCuentaDolarOficials { get; set; }

    public virtual DbSet<TipoCambioDeCadaPago> TipoCambioDeCadaPagos { get; set; }

    public virtual DbSet<TiposPermisoOrden> TiposPermisoOrdens { get; set; }

    public virtual DbSet<TransferenciasInterna> TransferenciasInternas { get; set; }

    public virtual DbSet<Ubicacione> Ubicaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<ValoresDolar> ValoresDolars { get; set; }

    public virtual DbSet<View1> View1s { get; set; }

    public virtual DbSet<View2> View2s { get; set; }

    public virtual DbSet<VwItemsOrdenCompraConPrecio> VwItemsOrdenCompraConPrecios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acobrar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ACobrar");

            entity.Property(e => e.Cliente).HasColumnName("cliente");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Maquina).HasColumnName("maquina");
            entity.Property(e => e.Moneda).HasColumnName("moneda");
        });

        modelBuilder.Entity<AcobrarCccliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AcobrarCCclientes");

            entity.Property(e => e.Cliente).HasColumnName("cliente");
            entity.Property(e => e.Descpago).HasColumnName("descpago");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Maquina).HasColumnName("maquina");
            entity.Property(e => e.Moneda).HasColumnName("moneda");
        });

        modelBuilder.Entity<Agastar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Agastar");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
        });

        modelBuilder.Entity<Articulo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Articulos");

            entity.Property(e => e.Descripcioncompra).HasColumnName("descripcioncompra");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombreproveedor).HasColumnName("nombreproveedor");
            entity.Property(e => e.Nombrerubro).HasColumnName("nombrerubro");
        });

        modelBuilder.Entity<ArticulosVariable>(entity =>
        {
            entity.ToTable("articulosVariables");

            entity.HasIndex(e => e.ProveedorId, "IX_articulosVariables_proveedorId");

            entity.HasIndex(e => e.Rubroid, "IX_articulosVariables_rubroid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataTable).HasColumnName("dataTable");
            entity.Property(e => e.DescripcionGenerica).HasColumnName("descripcionGenerica");
            entity.Property(e => e.Dto).HasColumnName("dto");
            entity.Property(e => e.FormulaPrecio)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("formulaPrecio");
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.NombreArticulo).HasColumnName("nombreArticulo");
            entity.Property(e => e.PrecioEnDolares)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("precioEnDolares");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedorId");
            entity.Property(e => e.Rubroid).HasColumnName("rubroid");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.ArticulosVariables).HasForeignKey(d => d.ProveedorId);

            entity.HasOne(d => d.Rubro).WithMany(p => p.ArticulosVariables).HasForeignKey(d => d.Rubroid);

            entity.HasMany(d => d.CodigoGastoFinals).WithMany(p => p.ArticuloVariables)
                .UsingEntity<Dictionary<string, object>>(
                    "CodigoGastoFinalArticuloVariable",
                    r => r.HasOne<CodigosGastoFinal>().WithMany().HasForeignKey("CodigoGastoFinalId"),
                    l => l.HasOne<ArticulosVariable>().WithMany().HasForeignKey("ArticuloVariableId"),
                    j =>
                    {
                        j.HasKey("ArticuloVariableId", "CodigoGastoFinalId");
                        j.ToTable("codigoGastoFinal_ArticuloVariable");
                        j.HasIndex(new[] { "CodigoGastoFinalId" }, "IX_codigoGastoFinal_ArticuloVariable_codigoGastoFinalId");
                        j.IndexerProperty<int>("ArticuloVariableId").HasColumnName("articuloVariableId");
                        j.IndexerProperty<int>("CodigoGastoFinalId").HasColumnName("codigoGastoFinalId");
                    });
        });

        modelBuilder.Entity<AvancesMontaje>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AvancesMontaje");

            entity.Property(e => e.Contador).HasColumnName("contador");
            entity.Property(e => e.Estadoactual).HasColumnName("estadoactual");
            entity.Property(e => e.Nombrecontenedor).HasColumnName("nombrecontenedor");
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Caja");

            entity.Property(e => e.Fecha).HasMaxLength(4000);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Monto).HasColumnName("monto");
        });

        modelBuilder.Entity<CamposCsv>(entity =>
        {
            entity.ToTable("camposCSV");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CantidadFinal).HasColumnName("cantidadFinal");
            entity.Property(e => e.Categoria).HasColumnName("categoria");
            entity.Property(e => e.Conjunto).HasColumnName("conjunto");
            entity.Property(e => e.Destino)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("destino");
            entity.Property(e => e.Discriminante).HasColumnName("discriminante");
            entity.Property(e => e.Foto).HasColumnName("foto");
            entity.Property(e => e.Material).HasColumnName("material");
            entity.Property(e => e.NoPasar).HasColumnName("noPasar");
            entity.Property(e => e.NumFoto).HasColumnName("numFoto");
            entity.Property(e => e.NumMaquina).HasColumnName("numMaquina");
            entity.Property(e => e.NumVersion).HasColumnName("numVersion");
            entity.Property(e => e.PartNumber).HasColumnName("partNumber");
            entity.Property(e => e.PasarAproMec).HasColumnName("pasarAProMec");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.StockNumber).HasColumnName("stockNumber");
            entity.Property(e => e.Thumbnail).HasColumnName("thumbnail");
            entity.Property(e => e.Ubicacion).HasColumnName("ubicacion");
            entity.Property(e => e.YaEnProMec).HasColumnName("yaEnProMec");
        });

        modelBuilder.Entity<Cccliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CCclientes");

            entity.Property(e => e.Cliente).HasColumnName("cliente");
            entity.Property(e => e.Contrato).HasColumnName("contrato");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Maquina).HasColumnName("maquina");
            entity.Property(e => e.Moneda).HasColumnName("moneda");
            entity.Property(e => e.TcCobro).HasColumnName("TC_Cobro");
            entity.Property(e => e.TcMonCob).HasColumnName("TC_MonCob");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("clientes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoCliente).HasColumnName("codigoCliente");
            entity.Property(e => e.Cuit).HasColumnName("cuit");
            entity.Property(e => e.NombreCliente).HasColumnName("nombreCliente");
        });

        modelBuilder.Entity<Cobro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Cobros");

            entity.Property(e => e.EnMonCtrto).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Maquina).HasColumnName("maquina");
            entity.Property(e => e.Mes).HasColumnName("mes");
            entity.Property(e => e.Nombremoneda).HasColumnName("nombremoneda");
        });

        modelBuilder.Entity<CodigoSubcodigo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CodigoSubcodigo");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Subcodigo).HasColumnName("subcodigo");
        });

        modelBuilder.Entity<CodigosConceptoConciliacion>(entity =>
        {
            entity.ToTable("codigosConceptoConciliacion");

            entity.HasIndex(e => e.CodigoGastoId, "IX_codigosConceptoConciliacion_codigoGastoId");

            entity.HasIndex(e => e.CuentaId, "IX_codigosConceptoConciliacion_cuentaId");

            entity.HasIndex(e => e.SubodigoGastoId, "IX_codigosConceptoConciliacion_subodigoGastoId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoConcepto).HasColumnName("codigoConcepto");
            entity.Property(e => e.CodigoGastoId).HasColumnName("codigoGastoId");
            entity.Property(e => e.Concepto15Chars).HasColumnName("concepto15Chars");
            entity.Property(e => e.CuentaId).HasColumnName("cuentaId");
            entity.Property(e => e.EsGastoDirecto)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("esGastoDirecto");
            entity.Property(e => e.SubodigoGastoId).HasColumnName("subodigoGastoId");

            entity.HasOne(d => d.CodigoGasto).WithMany(p => p.CodigosConceptoConciliacions).HasForeignKey(d => d.CodigoGastoId);

            entity.HasOne(d => d.Cuenta).WithMany(p => p.CodigosConceptoConciliacions).HasForeignKey(d => d.CuentaId);

            entity.HasOne(d => d.SubodigoGasto).WithMany(p => p.CodigosConceptoConciliacions).HasForeignKey(d => d.SubodigoGastoId);
        });

        modelBuilder.Entity<CodigosGasto>(entity =>
        {
            entity.ToTable("codigosGasto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.EsCodigoMaquina)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("esCodigoMaquina");
            entity.Property(e => e.Interno)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("interno");
            entity.Property(e => e.TipoCodigo)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("tipoCodigo");
        });

        modelBuilder.Entity<CodigosGastoFinal>(entity =>
        {
            entity.ToTable("codigosGastoFinal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoGastoFinal).HasColumnName("codigoGastoFinal");
            entity.Property(e => e.OrigenId).HasColumnName("origenId");
        });

        modelBuilder.Entity<ConciliaSantander>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ConciliaSantander");

            entity.Property(e => e.Fecha).HasMaxLength(4000);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Mont).HasColumnName("mont");
            entity.Property(e => e.Subconciliacionid).HasColumnName("subconciliacionid");
        });

        modelBuilder.Entity<Conciliacione>(entity =>
        {
            entity.ToTable("conciliaciones");

            entity.HasIndex(e => e.PagoId, "IX_conciliaciones_pagoId")
                .IsUnique()
                .HasFilter("([pagoId] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaGeneracion).HasColumnName("fechaGeneracion");
            entity.Property(e => e.PagoId).HasColumnName("pagoId");

            entity.HasOne(d => d.Pago).WithOne(p => p.Conciliacione).HasForeignKey<Conciliacione>(d => d.PagoId);
        });

        modelBuilder.Entity<ConciliacionesControl>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Conciliaciones_Control");

            entity.Property(e => e.SubconciliacionId).HasColumnName("subconciliacionId");
        });

        modelBuilder.Entity<ConciliacionesVerificar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Conciliaciones_Verificar");

            entity.Property(e => e.FechaConciliacion).HasMaxLength(4000);
        });

        modelBuilder.Entity<Configuracione>(entity =>
        {
            entity.ToTable("configuraciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MapConfig).HasColumnName("mapConfig");
            entity.Property(e => e.TagDatagrid).HasColumnName("tagDatagrid");
        });

        modelBuilder.Entity<ContactosWapp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ContactosWapp");

            entity.Property(e => e.CodigoContacto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Contenedore>(entity =>
        {
            entity.ToTable("contenedores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EsAptoCompras).HasColumnName("esAptoCompras");
            entity.Property(e => e.GrupoAsignable).HasColumnName("grupoAsignable");
            entity.Property(e => e.GrupoContenedor).HasColumnName("grupoContenedor");
            entity.Property(e => e.NombreContenedor).HasColumnName("nombreContenedor");
            entity.Property(e => e.TipoContenedor).HasColumnName("tipoContenedor");
        });

        modelBuilder.Entity<ContenedoresFiltrado>(entity =>
        {
            entity.ToTable("contenedoresFiltrados");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NombreGrupoAsignable).HasColumnName("nombreGrupoAsignable");
        });

        modelBuilder.Entity<ContenedoresOc>(entity =>
        {
            entity.ToTable("contenedoresOC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreContenedor).HasColumnName("nombreContenedor");
        });

        modelBuilder.Entity<ContratosTrabajo>(entity =>
        {
            entity.ToTable("contratosTrabajo");

            entity.HasIndex(e => e.CodigoGastoId, "IX_contratosTrabajo_codigoGastoId");

            entity.HasIndex(e => e.CodigoPagoId, "IX_contratosTrabajo_codigoPagoId");

            entity.HasIndex(e => e.MaquinaId, "IX_contratosTrabajo_maquinaId");

            entity.HasIndex(e => e.MonedaId, "IX_contratosTrabajo_monedaId");

            entity.HasIndex(e => e.UsuarioId, "IX_contratosTrabajo_usuarioId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AGastar).HasColumnName("aGastar");
            entity.Property(e => e.CodigoContrato).HasColumnName("codigoContrato");
            entity.Property(e => e.CodigoGastoId).HasColumnName("codigoGastoId");
            entity.Property(e => e.CodigoPagoId).HasColumnName("codigoPagoId");
            entity.Property(e => e.Descripcion)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("descripcion");
            entity.Property(e => e.MaquinaId).HasColumnName("maquinaId");
            entity.Property(e => e.MonedaId).HasColumnName("monedaId");
            entity.Property(e => e.PrecioEnDolares)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("precioEnDolares");
            entity.Property(e => e.PrecioTrabajoDolares).HasColumnName("precioTrabajoDolares");
            entity.Property(e => e.PrecioTrabajoPesos).HasColumnName("precioTrabajoPesos");
            entity.Property(e => e.TipoDeCambio).HasColumnName("tipoDeCambio");
            entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

            entity.HasOne(d => d.CodigoGasto).WithMany(p => p.ContratosTrabajoCodigoGastos).HasForeignKey(d => d.CodigoGastoId);

            entity.HasOne(d => d.CodigoPago).WithMany(p => p.ContratosTrabajoCodigoPagos).HasForeignKey(d => d.CodigoPagoId);

            entity.HasOne(d => d.Maquina).WithMany(p => p.ContratosTrabajos).HasForeignKey(d => d.MaquinaId);

            entity.HasOne(d => d.Moneda).WithMany(p => p.ContratosTrabajos).HasForeignKey(d => d.MonedaId);

            entity.HasOne(d => d.Usuario).WithMany(p => p.ContratosTrabajos).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<CostoMxxUsd>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CostoMxxUsd");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Mes).HasColumnName("mes");
            entity.Property(e => e.NombreRubro).HasColumnName("nombreRubro");
            entity.Property(e => e.TotUss)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("totUSS");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.ToTable("cuentas");

            entity.HasIndex(e => e.ChequeraId, "IX_cuentas_chequeraId");

            entity.HasIndex(e => e.MonedaId, "IX_cuentas_monedaId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChequeraId).HasColumnName("chequeraId");
            entity.Property(e => e.EsAptoCompras)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("esAptoCompras");
            entity.Property(e => e.MonedaId).HasColumnName("monedaId");
            entity.Property(e => e.NombreCuenta).HasColumnName("nombreCuenta");
            entity.Property(e => e.TipoCuenta).HasColumnName("tipoCuenta");

            entity.HasOne(d => d.Chequera).WithMany(p => p.InverseChequera).HasForeignKey(d => d.ChequeraId);

            entity.HasOne(d => d.Moneda).WithMany(p => p.Cuenta).HasForeignKey(d => d.MonedaId);
        });

        modelBuilder.Entity<CuentaCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CuentaClientes");

            entity.Property(e => e.Cliente).HasColumnName("cliente");
            entity.Property(e => e.Contrato).HasColumnName("contrato");
            entity.Property(e => e.FechaPagocc).HasMaxLength(4000);
            entity.Property(e => e.Tccobro).HasColumnName("TCcobro");
            entity.Property(e => e.Tcmoncont).HasColumnName("TCMoncont");
            entity.Property(e => e.VaríacionCc).HasColumnName("VaríacionCC");
        });

        modelBuilder.Entity<CuentaCorrienteCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CuentaCorrienteCliente");

            entity.Property(e => e.Cliente).HasColumnName("cliente");
            entity.Property(e => e.Contrato).HasColumnName("contrato");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Maquina).HasColumnName("maquina");
            entity.Property(e => e.Moneda).HasColumnName("moneda");
        });

        modelBuilder.Entity<CuentaCorrienteCliente1>(entity =>
        {
            entity.ToTable("cuentaCorrienteClientes");

            entity.HasIndex(e => e.ClienteId, "IX_cuentaCorrienteClientes_clienteId");

            entity.HasIndex(e => e.ContratoTrabajoId, "IX_cuentaCorrienteClientes_contratoTrabajoId");

            entity.HasIndex(e => e.MovimientoId, "IX_cuentaCorrienteClientes_movimientoId");

            entity.HasIndex(e => e.PagoId, "IX_cuentaCorrienteClientes_pagoId")
                .IsUnique()
                .HasFilter("([pagoId] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("clienteId");
            entity.Property(e => e.ContratoTrabajoId).HasColumnName("contratoTrabajoId");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')")
                .HasColumnName("fecha");
            entity.Property(e => e.MontoMonedaCobro).HasColumnName("montoMonedaCobro");
            entity.Property(e => e.MontoMonedaContrato).HasColumnName("montoMonedaContrato");
            entity.Property(e => e.MovimientoId).HasColumnName("movimientoId");
            entity.Property(e => e.PagoId).HasColumnName("pagoId");
            entity.Property(e => e.PagoNro).HasColumnName("pagoNro");
            entity.Property(e => e.ValorMonedaCobro).HasColumnName("valorMonedaCobro");
            entity.Property(e => e.ValorMonedaContratoTrabajo).HasColumnName("valorMonedaContratoTrabajo");

            entity.HasOne(d => d.Cliente).WithMany(p => p.CuentaCorrienteCliente1s).HasForeignKey(d => d.ClienteId);

            entity.HasOne(d => d.ContratoTrabajo).WithMany(p => p.CuentaCorrienteCliente1s).HasForeignKey(d => d.ContratoTrabajoId);

            entity.HasOne(d => d.Movimiento).WithMany(p => p.CuentaCorrienteCliente1s).HasForeignKey(d => d.MovimientoId);

            entity.HasOne(d => d.Pago).WithOne(p => p.CuentaCorrienteCliente1).HasForeignKey<CuentaCorrienteCliente1>(d => d.PagoId);
        });

        modelBuilder.Entity<CuentaDolare>(entity =>
        {
            entity.ToTable("cuentaDolares");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EsCompra).HasColumnName("esCompra");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.TipoDeCambio).HasColumnName("tipoDeCambio");
        });

        modelBuilder.Entity<Cuentum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Cuenta");

            entity.Property(e => e.Fecha).HasMaxLength(4000);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Montoenpesos)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("montoenpesos");
        });

        modelBuilder.Entity<DatosBancoAconciliar>(entity =>
        {
            entity.ToTable("datosBancoAConciliar");

            entity.HasIndex(e => e.CodigoConceptoId, "IX_datosBancoAConciliar_codigoConceptoId");

            entity.HasIndex(e => e.CuentaId, "IX_datosBancoAConciliar_cuentaId");

            entity.HasIndex(e => e.SubconciliacionId, "IX_datosBancoAConciliar_subconciliacionId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoConceptoId).HasColumnName("codigoConceptoId");
            entity.Property(e => e.Concepto).HasColumnName("concepto");
            entity.Property(e => e.CuentaId).HasColumnName("cuentaId");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.Referencia).HasColumnName("referencia");
            entity.Property(e => e.Saldo).HasColumnName("saldo");
            entity.Property(e => e.SubconciliacionId).HasColumnName("subconciliacionId");

            entity.HasOne(d => d.CodigoConcepto).WithMany(p => p.DatosBancoAconciliars).HasForeignKey(d => d.CodigoConceptoId);

            entity.HasOne(d => d.Cuenta).WithMany(p => p.DatosBancoAconciliars).HasForeignKey(d => d.CuentaId);

            entity.HasOne(d => d.Subconciliacion).WithMany(p => p.DatosBancoAconciliars).HasForeignKey(d => d.SubconciliacionId);
        });

        modelBuilder.Entity<DescripcionMateriale>(entity =>
        {
            entity.ToTable("descripcionMateriales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.NombreMaterial).HasColumnName("nombreMaterial");
        });

        modelBuilder.Entity<DiscriminanteContenedor>(entity =>
        {
            entity.ToTable("discriminanteContenedor");

            entity.HasIndex(e => e.ContenedorId, "IX_discriminanteContenedor_contenedorId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContenedorId).HasColumnName("contenedorId");
            entity.Property(e => e.Discriminante).HasColumnName("discriminante");

            entity.HasOne(d => d.Contenedor).WithMany(p => p.DiscriminanteContenedors).HasForeignKey(d => d.ContenedorId);
        });

        modelBuilder.Entity<DiscriminanteTipoDePieza>(entity =>
        {
            entity.ToTable("discriminanteTipoDePieza");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discriminante).HasColumnName("discriminante");
            entity.Property(e => e.TipoDePieza).HasColumnName("tipoDePieza");
        });

        modelBuilder.Entity<EstadosCompra>(entity =>
        {
            entity.ToTable("estadosCompra");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreEstado).HasColumnName("nombreEstado");
            entity.Property(e => e.Orden).HasColumnName("orden");
        });

        modelBuilder.Entity<GastadosAgastar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GastadosAgastar");

            entity.Property(e => e.AGastar).HasColumnName("aGastar");
            entity.Property(e => e.Codigogastoid).HasColumnName("codigogastoid");
        });

        modelBuilder.Entity<GastoMaquinasMxx>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GastoMaquinasMxx");

            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.NombreProveedor).HasColumnName("nombreProveedor");
            entity.Property(e => e.Oc).HasColumnName("OC");
        });

        modelBuilder.Entity<GastosMe>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GastosMes$");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Mes).HasColumnName("mes");
            entity.Property(e => e.Subcodigo).HasColumnName("subcodigo");
            entity.Property(e => e.Tot)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("tot");
        });

        modelBuilder.Entity<GastosMxxItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GastosMxxItem");

            entity.Property(e => e.Cant).HasColumnName("cant");
            entity.Property(e => e.DescripcionCompra).HasColumnName("descripcionCompra");
            entity.Property(e => e.Dto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("dto");
            entity.Property(e => e.EquivUsd).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.FechPag).HasMaxLength(4000);
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.PrUnit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PrUnit$");
            entity.Property(e => e.PrUnitUsd).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tc)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TC");
        });

        modelBuilder.Entity<Gastosusd>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Gastosusd");

            entity.Property(e => e.CodigoGastoId).HasColumnName("codigoGastoId");
            entity.Property(e => e.Montodolares).HasColumnName("montodolares");
            entity.Property(e => e.Montousd).HasColumnName("montousd");
        });

        modelBuilder.Entity<Historial>(entity =>
        {
            entity.ToTable("Historial");

            entity.HasIndex(e => e.FechaEntradaContainer, "IX_Historial_FechaEntradaContainer");

            entity.HasIndex(e => e.PiezaId, "UX_Historial_PiezaId").IsUnique();

            entity.Property(e => e.FechaCreacion)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.FechaEntradaContainer).HasPrecision(0);

            entity.HasOne(d => d.Pieza).WithOne(p => p.Historial)
                .HasForeignKey<Historial>(d => d.PiezaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Piezas");
        });

        modelBuilder.Entity<ItemsOrdenDeCompra>(entity =>
        {
            entity.ToTable("itemsOrdenDeCompra");

            entity.HasIndex(e => e.ArticuloId, "IX_itemsOrdenDeCompra_articuloId");

            entity.HasIndex(e => e.ArticuloVariableId, "IX_itemsOrdenDeCompra_articuloVariableId");

            entity.HasIndex(e => e.CodigoGastoId, "IX_itemsOrdenDeCompra_codigoGastoId");

            entity.HasIndex(e => e.ContenedorId, "IX_itemsOrdenDeCompra_contenedorId");

            entity.HasIndex(e => e.OrdenDeCompraId, "IX_itemsOrdenDeCompra_ordenDeCompraId");

            entity.HasIndex(e => e.PiezaId, "IX_itemsOrdenDeCompra_piezaId");

            entity.HasIndex(e => e.SubcodigoGasto2Id, "IX_itemsOrdenDeCompra_subcodigoGasto2Id");

            entity.HasIndex(e => e.SubcodigoGastoId, "IX_itemsOrdenDeCompra_subcodigoGastoId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgrupaPago).HasColumnName("agrupaPago");
            entity.Property(e => e.ArticuloId).HasColumnName("articuloId");
            entity.Property(e => e.ArticuloVariableId).HasColumnName("articuloVariableId");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodigoGastoId).HasColumnName("codigoGastoId");
            entity.Property(e => e.CodigoPago).HasColumnName("codigoPago");
            entity.Property(e => e.ContenedorId).HasColumnName("contenedorId");
            entity.Property(e => e.DescripcionCompra).HasColumnName("descripcionCompra");
            entity.Property(e => e.Dto).HasColumnName("dto");
            entity.Property(e => e.Factura).HasColumnName("factura");
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.Observacion).HasColumnName("observacion");
            entity.Property(e => e.OrdenDeCompraId).HasColumnName("ordenDeCompraId");
            entity.Property(e => e.OrdenOriginalId).HasColumnName("ordenOriginalId");
            entity.Property(e => e.Origen).HasColumnName("origen");
            entity.Property(e => e.OrigenId).HasColumnName("origenId");
            entity.Property(e => e.PiezaId).HasColumnName("piezaId");
            entity.Property(e => e.PrecioDolares).HasColumnName("precioDolares");
            entity.Property(e => e.PrecioEnDolares)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("precioEnDolares");
            entity.Property(e => e.PrecioPesos).HasColumnName("precioPesos");
            entity.Property(e => e.Remito).HasColumnName("remito");
            entity.Property(e => e.SubcodigoGasto2Id).HasColumnName("subcodigoGasto2Id");
            entity.Property(e => e.SubcodigoGastoId).HasColumnName("subcodigoGastoId");
            entity.Property(e => e.TipoDeCambio).HasColumnName("tipoDeCambio");

            entity.HasOne(d => d.Articulo).WithMany(p => p.ItemsOrdenDeCompras).HasForeignKey(d => d.ArticuloId);

            entity.HasOne(d => d.ArticuloVariable).WithMany(p => p.ItemsOrdenDeCompras).HasForeignKey(d => d.ArticuloVariableId);

            entity.HasOne(d => d.CodigoGasto).WithMany(p => p.ItemsOrdenDeCompras).HasForeignKey(d => d.CodigoGastoId);

            entity.HasOne(d => d.Contenedor).WithMany(p => p.ItemsOrdenDeCompras).HasForeignKey(d => d.ContenedorId);

            entity.HasOne(d => d.OrdenDeCompra).WithMany(p => p.ItemsOrdenDeCompras).HasForeignKey(d => d.OrdenDeCompraId);

            entity.HasOne(d => d.Pieza).WithMany(p => p.ItemsOrdenDeCompras).HasForeignKey(d => d.PiezaId);

            entity.HasOne(d => d.SubcodigoGasto2).WithMany(p => p.ItemsOrdenDeCompras).HasForeignKey(d => d.SubcodigoGasto2Id);

            entity.HasOne(d => d.SubcodigoGasto).WithMany(p => p.ItemsOrdenDeCompras).HasForeignKey(d => d.SubcodigoGastoId);

            entity.HasMany(d => d.CodigoGastoFinals).WithMany(p => p.ItemOrdenDeCompras)
                .UsingEntity<Dictionary<string, object>>(
                    "CodigoGastoFinalItemOrdenDeCompra",
                    r => r.HasOne<CodigosGastoFinal>().WithMany().HasForeignKey("CodigoGastoFinalId"),
                    l => l.HasOne<ItemsOrdenDeCompra>().WithMany().HasForeignKey("ItemOrdenDeCompraId"),
                    j =>
                    {
                        j.HasKey("ItemOrdenDeCompraId", "CodigoGastoFinalId");
                        j.ToTable("codigoGastoFinal_ItemOrdenDeCompra");
                        j.HasIndex(new[] { "CodigoGastoFinalId" }, "IX_codigoGastoFinal_ItemOrdenDeCompra_codigoGastoFinalId");
                        j.IndexerProperty<int>("ItemOrdenDeCompraId").HasColumnName("itemOrdenDeCompraId");
                        j.IndexerProperty<int>("CodigoGastoFinalId").HasColumnName("codigoGastoFinalId");
                    });
        });

        modelBuilder.Entity<ItemsSolo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ItemsSolos");

            entity.Property(e => e.DescripcionCompra).HasColumnName("descripcionCompra");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
        });

        modelBuilder.Entity<Maquina>(entity =>
        {
            entity.ToTable("maquinas");

            entity.HasIndex(e => e.ClienteId, "IX_maquinas_clienteId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activa).HasColumnName("activa");
            entity.Property(e => e.ClienteId).HasColumnName("clienteId");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.NumMaquina).HasColumnName("numMaquina");
            entity.Property(e => e.Prioridad).HasColumnName("prioridad");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Maquinas).HasForeignKey(d => d.ClienteId);
        });

        modelBuilder.Entity<Materiale>(entity =>
        {
            entity.ToTable("materiales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Material).HasColumnName("material");
        });

        modelBuilder.Entity<Moneda>(entity =>
        {
            entity.ToTable("monedas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreMoneda).HasColumnName("nombreMoneda");
            entity.Property(e => e.NombreMonedaPlural)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("nombreMonedaPlural");
            entity.Property(e => e.ValorActual).HasColumnName("valorActual");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.ToTable("movimientos");

            entity.HasIndex(e => e.ClienteId, "IX_movimientos_clienteId");

            entity.HasIndex(e => e.CodigoGastoId, "IX_movimientos_codigoGastoId");

            entity.HasIndex(e => e.CuentaId, "IX_movimientos_cuentaId");

            entity.HasIndex(e => e.PagoId, "IX_movimientos_pagoId");

            entity.HasIndex(e => e.SubcodigoGasto2Id, "IX_movimientos_subcodigoGasto2Id");

            entity.HasIndex(e => e.SubcodigoGastoId, "IX_movimientos_subcodigoGastoId");

            entity.HasIndex(e => e.SubconciliacionId, "IX_movimientos_subconciliacionId");

            entity.HasIndex(e => e.UsuarioId, "IX_movimientos_usuarioId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChequeUsado).HasColumnName("chequeUsado");
            entity.Property(e => e.ClienteId).HasColumnName("clienteId");
            entity.Property(e => e.CodigoGastoId).HasColumnName("codigoGastoId");
            entity.Property(e => e.CuentaId).HasColumnName("cuentaId");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaCt).HasColumnName("fechaCT");
            entity.Property(e => e.FechaGeneracion)
                .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')")
                .HasColumnName("fechaGeneracion");
            entity.Property(e => e.IdMovOrigen).HasColumnName("idMovOrigen");
            entity.Property(e => e.MontoDolares).HasColumnName("montoDolares");
            entity.Property(e => e.MontoEnDolares)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("montoEnDolares");
            entity.Property(e => e.MontoPesos).HasColumnName("montoPesos");
            entity.Property(e => e.NroCt).HasColumnName("nroCT");
            entity.Property(e => e.NroInterno).HasColumnName("nroInterno");
            entity.Property(e => e.PagoId).HasColumnName("pagoId");
            entity.Property(e => e.PagoNro).HasColumnName("pagoNro");
            entity.Property(e => e.SubcodigoGasto2Id).HasColumnName("subcodigoGasto2Id");
            entity.Property(e => e.SubcodigoGastoId).HasColumnName("subcodigoGastoId");
            entity.Property(e => e.SubconciliacionId).HasColumnName("subconciliacionId");
            entity.Property(e => e.TipoPago).HasColumnName("tipoPago");
            entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");
            entity.Property(e => e.ValorMonedaDestino).HasColumnName("valorMonedaDestino");
            entity.Property(e => e.ValorMonedaOrien).HasColumnName("valorMonedaOrien");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Movimientos).HasForeignKey(d => d.ClienteId);

            entity.HasOne(d => d.CodigoGasto).WithMany(p => p.Movimientos).HasForeignKey(d => d.CodigoGastoId);

            entity.HasOne(d => d.Cuenta).WithMany(p => p.Movimientos).HasForeignKey(d => d.CuentaId);

            entity.HasOne(d => d.Pago).WithMany(p => p.Movimientos).HasForeignKey(d => d.PagoId);

            entity.HasOne(d => d.SubcodigoGasto2).WithMany(p => p.Movimientos).HasForeignKey(d => d.SubcodigoGasto2Id);

            entity.HasOne(d => d.SubcodigoGasto).WithMany(p => p.Movimientos).HasForeignKey(d => d.SubcodigoGastoId);

            entity.HasOne(d => d.Subconciliacion).WithMany(p => p.Movimientos).HasForeignKey(d => d.SubconciliacionId);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Movimientos).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<MovimientosCuenta>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MovimientosCuentas");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Fechapago).HasColumnName("fechapago");
            entity.Property(e => e.NombreCuenta).HasColumnName("nombreCuenta");
            entity.Property(e => e.NombreMoneda).HasColumnName("nombreMoneda");
            entity.Property(e => e.Nombreproveedor).HasColumnName("nombreproveedor");
            entity.Property(e => e.Pagoid).HasColumnName("pagoid");
            entity.Property(e => e.Subcodigo).HasColumnName("subcodigo");
        });

        modelBuilder.Entity<MovimientosSinTransferencia>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MovimientosSinTransferencias");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MontoPesos).HasColumnName("montoPesos");
            entity.Property(e => e.NombreCuenta).HasColumnName("nombreCuenta");
            entity.Property(e => e.PagoId).HasColumnName("pagoId");
        });

        modelBuilder.Entity<Movimientosvista1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Movimientosvista1");

            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Montopesos).HasColumnName("montopesos");
            entity.Property(e => e.NombreCuenta).HasColumnName("nombreCuenta");
        });

        modelBuilder.Entity<MrAgastaresOriginale>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MR_AgastaresOriginales");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Codigoid).HasColumnName("codigoid");
        });

        modelBuilder.Entity<MrGastado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MR_Gastado");

            entity.Property(e => e.Cgid).HasColumnName("cgid");
            entity.Property(e => e.Codigog).HasColumnName("codigog");
        });

        modelBuilder.Entity<MrVenta>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MR_Ventas");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodigoSdid).HasColumnName("codigoSDID");
        });

        modelBuilder.Entity<Mresultado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MResultados");

            entity.Property(e => e.Agastarorigen).HasColumnName("agastarorigen");
        });

        modelBuilder.Entity<NewView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewView");

            entity.Property(e => e.ChequeUsado).HasColumnName("chequeUsado");
            entity.Property(e => e.ClienteId).HasColumnName("clienteId");
            entity.Property(e => e.CodigoGastoId).HasColumnName("codigoGastoId");
            entity.Property(e => e.CuentaId).HasColumnName("cuentaId");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaCt).HasColumnName("fechaCT");
            entity.Property(e => e.FechaGeneracion).HasColumnName("fechaGeneracion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdMovOrigen).HasColumnName("idMovOrigen");
            entity.Property(e => e.MontoDolares).HasColumnName("montoDolares");
            entity.Property(e => e.MontoEnDolares).HasColumnName("montoEnDolares");
            entity.Property(e => e.MontoPesos).HasColumnName("montoPesos");
            entity.Property(e => e.NroCt).HasColumnName("nroCT");
            entity.Property(e => e.NroInterno).HasColumnName("nroInterno");
            entity.Property(e => e.PagoId).HasColumnName("pagoId");
            entity.Property(e => e.PagoNro).HasColumnName("pagoNro");
            entity.Property(e => e.SubcodigoGasto2Id).HasColumnName("subcodigoGasto2Id");
            entity.Property(e => e.SubcodigoGastoId).HasColumnName("subcodigoGastoId");
            entity.Property(e => e.SubconciliacionId).HasColumnName("subconciliacionId");
            entity.Property(e => e.TipoPago).HasColumnName("tipoPago");
            entity.Property(e => e.ValorMonedaDestino).HasColumnName("valorMonedaDestino");
            entity.Property(e => e.ValorMonedaOrien).HasColumnName("valorMonedaOrien");
        });

        modelBuilder.Entity<NewView1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewView_1");

            entity.Property(e => e.Descmov).HasColumnName("descmov");
            entity.Property(e => e.Descpago).HasColumnName("descpago");
            entity.Property(e => e.FechaGeneracion).HasColumnName("fechaGeneracion");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Montopesos).HasColumnName("montopesos");
            entity.Property(e => e.Pagoid).HasColumnName("pagoid");
            entity.Property(e => e.Tipopago).HasColumnName("tipopago");
        });

        modelBuilder.Entity<NewView10>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewView_10");

            entity.Property(e => e.SubOc).HasColumnName("SubOC");
        });

        modelBuilder.Entity<NewView2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewView_2");

            entity.Property(e => e.Descmov).HasColumnName("descmov");
            entity.Property(e => e.Descpago).HasColumnName("descpago");
            entity.Property(e => e.FechaGeneracion).HasColumnName("fechaGeneracion");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Montopesos).HasColumnName("montopesos");
            entity.Property(e => e.Pagoid).HasColumnName("pagoid");
            entity.Property(e => e.Tipopago).HasColumnName("tipopago");
        });

        modelBuilder.Entity<NewView3>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewView_3");

            entity.Property(e => e.Cant).HasColumnName("cant");
            entity.Property(e => e.MaquinaId).HasColumnName("MaquinaID");
            entity.Property(e => e.Ubic).HasColumnName("ubic");
        });

        modelBuilder.Entity<NewView4>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewView_4");

            entity.Property(e => e.Item).HasColumnName("ITEM");
            entity.Property(e => e.Oc).HasColumnName("OC");
            entity.Property(e => e.Proveedor).HasColumnName("PROVEEDOR");
        });

        modelBuilder.Entity<NewView5>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewView_5");

            entity.Property(e => e.Ocid).HasColumnName("ocid");
        });

        modelBuilder.Entity<NewView6>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewView_6");

            entity.Property(e => e.NombreContenedor).HasColumnName("nombreContenedor");
            entity.Property(e => e.NombrePieza).HasColumnName("nombrePieza");
        });

        modelBuilder.Entity<NewView7>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewView_7");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<NewView8>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewView_8");

            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.OcId).HasColumnName("OC_Id");
        });

        modelBuilder.Entity<NewView9>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NewView_9");

            entity.Property(e => e.EstadoOc).HasColumnName("Estado_OC");
        });

        modelBuilder.Entity<NombresConfiguracionesDatagrid>(entity =>
        {
            entity.ToTable("nombresConfiguracionesDatagrid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreConfiguracion).HasColumnName("nombreConfiguracion");
            entity.Property(e => e.NombreDgSegunTipoDeDatosAsociados).HasColumnName("nombreDgSegunTipoDeDatosASociados");
        });

        modelBuilder.Entity<NomenclaturaDiscriminante>(entity =>
        {
            entity.ToTable("nomenclaturaDiscriminante");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discriminante).HasColumnName("discriminante");
            entity.Property(e => e.Nomenclatura).HasColumnName("nomenclatura");
        });

        modelBuilder.Entity<OcEstadoAactual>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OC_EstadoAactual");

            entity.Property(e => e.Ocid).HasColumnName("ocid");
        });

        modelBuilder.Entity<Ocitem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OCItems");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Dto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("dto");
            entity.Property(e => e.Item).HasColumnName("item");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NombreProveedor).HasColumnName("nombreProveedor");
            entity.Property(e => e.Nombreestado).HasColumnName("nombreestado");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.PagoId).HasColumnName("pagoId");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Preciousd)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("preciousd");
            entity.Property(e => e.SiUD).HasColumnName("Si_U$D");
            entity.Property(e => e.SubcodigoG).HasColumnName("subcodigoG");
            entity.Property(e => e.SubcodigoM).HasColumnName("subcodigoM");
            entity.Property(e => e.Tc).HasColumnName("TC");
        });

        modelBuilder.Entity<Operacione>(entity =>
        {
            entity.ToTable("operaciones");

            entity.HasIndex(e => e.ContenedorId, "IX_operaciones_contenedorId");

            entity.HasIndex(e => e.MotivoId, "IX_operaciones_motivoId");

            entity.HasIndex(e => e.OperadorId, "IX_operaciones_operadorId");

            entity.HasIndex(e => e.PiezaId, "IX_operaciones_piezaId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aclaracion).HasColumnName("aclaracion");
            entity.Property(e => e.ContenedorId).HasColumnName("contenedorId");
            entity.Property(e => e.FechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.FechaIni).HasColumnName("fechaIni");
            entity.Property(e => e.FechaIniComputada).HasColumnName("fechaIniComputada");
            entity.Property(e => e.Finalizada).HasColumnName("finalizada");
            entity.Property(e => e.MotivoId).HasColumnName("motivoId");
            entity.Property(e => e.OperadorId).HasColumnName("operadorId");
            entity.Property(e => e.PiezaId).HasColumnName("piezaId");
            entity.Property(e => e.TAjustado).HasColumnName("tAjustado");
            entity.Property(e => e.TFresa).HasColumnName("tFresa");
            entity.Property(e => e.TMec).HasColumnName("tMec");
            entity.Property(e => e.TProgresoTotal).HasColumnName("tProgresoTotal");
            entity.Property(e => e.TRealTotal).HasColumnName("tRealTotal");
            entity.Property(e => e.TTorno).HasColumnName("tTorno");
            entity.Property(e => e.TiempoOperacion).HasColumnName("tiempoOperacion");

            entity.HasOne(d => d.Contenedor).WithMany(p => p.Operaciones).HasForeignKey(d => d.ContenedorId);

            entity.HasOne(d => d.Motivo).WithMany(p => p.Operaciones).HasForeignKey(d => d.MotivoId);

            entity.HasOne(d => d.Operador).WithMany(p => p.Operaciones).HasForeignKey(d => d.OperadorId);

            entity.HasOne(d => d.Pieza).WithMany(p => p.Operaciones).HasForeignKey(d => d.PiezaId);
        });

        modelBuilder.Entity<Operadore>(entity =>
        {
            entity.ToTable("operadores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreOperador).HasColumnName("nombreOperador");
        });

        modelBuilder.Entity<OrdenDeCompraEstadoCompra>(entity =>
        {
            entity.HasKey(e => new { e.OrdenDeCompraId, e.EstadoCompraId, e.Id });

            entity.ToTable("ordenDeCompra_EstadoCompra");

            entity.HasIndex(e => e.EstadoCompraId, "IX_ordenDeCompra_EstadoCompra_estadoCompraId");

            entity.HasIndex(e => e.ResponsableId, "IX_ordenDeCompra_EstadoCompra_responsableId");

            entity.Property(e => e.OrdenDeCompraId).HasColumnName("ordenDeCompraId");
            entity.Property(e => e.EstadoCompraId).HasColumnName("estadoCompraId");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Comentario).HasColumnName("comentario");
            entity.Property(e => e.EsValido).HasColumnName("esValido");
            entity.Property(e => e.FechaGeneracion).HasColumnName("fechaGeneracion");
            entity.Property(e => e.ResponsableId).HasColumnName("responsableId");

            entity.HasOne(d => d.EstadoCompra).WithMany(p => p.OrdenDeCompraEstadoCompras).HasForeignKey(d => d.EstadoCompraId);

            entity.HasOne(d => d.OrdenDeCompra).WithMany(p => p.OrdenDeCompraEstadoCompras).HasForeignKey(d => d.OrdenDeCompraId);

            entity.HasOne(d => d.Responsable).WithMany(p => p.OrdenDeCompraEstadoCompras).HasForeignKey(d => d.ResponsableId);
        });

        modelBuilder.Entity<OrdenesDeCompra>(entity =>
        {
            entity.ToTable("ordenesDeCompra");

            entity.HasIndex(e => e.PagoId, "IX_ordenesDeCompra_pagoId");

            entity.HasIndex(e => e.PermisoOrdenId, "IX_ordenesDeCompra_permisoOrdenId");

            entity.HasIndex(e => e.ProveedorId, "IX_ordenesDeCompra_proveedorId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Eliminada)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("eliminada");
            entity.Property(e => e.Factura)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("factura");
            entity.Property(e => e.FechaDeGeneracion).HasColumnName("fechaDeGeneracion");
            entity.Property(e => e.FechaEntrega).HasColumnName("fechaEntrega");
            entity.Property(e => e.Observacion).HasColumnName("observacion");
            entity.Property(e => e.OrdenOriginalId).HasColumnName("ordenOriginalId");
            entity.Property(e => e.Pagada)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("pagada");
            entity.Property(e => e.PagoId).HasColumnName("pagoId");
            entity.Property(e => e.PagoNro).HasColumnName("pagoNro");
            entity.Property(e => e.PermisoOrdenId).HasColumnName("permisoOrdenId");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedorId");
            entity.Property(e => e.Remito)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("remito");

            entity.HasOne(d => d.Pago).WithMany(p => p.OrdenesDeCompras).HasForeignKey(d => d.PagoId);

            entity.HasOne(d => d.PermisoOrden).WithMany(p => p.OrdenesDeCompras).HasForeignKey(d => d.PermisoOrdenId);

            entity.HasOne(d => d.Proveedor).WithMany(p => p.OrdenesDeCompras).HasForeignKey(d => d.ProveedorId);
        });

        modelBuilder.Entity<OtrosArticulo>(entity =>
        {
            entity.ToTable("otrosArticulos");

            entity.HasIndex(e => e.ProveedorId, "IX_otrosArticulos_proveedorId");

            entity.HasIndex(e => e.Rubroid, "IX_otrosArticulos_rubroid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DescripcionCompra).HasColumnName("descripcionCompra");
            entity.Property(e => e.Dto).HasColumnName("dto");
            entity.Property(e => e.EnDesuso)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("enDesuso");
            entity.Property(e => e.FechaGeneracion).HasColumnName("fechaGeneracion");
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.PrecioDolares).HasColumnName("precioDolares");
            entity.Property(e => e.PrecioEnDolares)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("precioEnDolares");
            entity.Property(e => e.PrecioPesos).HasColumnName("precioPesos");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedorId");
            entity.Property(e => e.Rubroid).HasColumnName("rubroid");
            entity.Property(e => e.TipoCompra).HasColumnName("tipoCompra");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.OtrosArticulos).HasForeignKey(d => d.ProveedorId);

            entity.HasOne(d => d.Rubro).WithMany(p => p.OtrosArticulos).HasForeignKey(d => d.Rubroid);

            entity.HasMany(d => d.CodigoGastoFinals).WithMany(p => p.OtroArticulos)
                .UsingEntity<Dictionary<string, object>>(
                    "CodigoGastoFinalOtrosArticulo",
                    r => r.HasOne<CodigosGastoFinal>().WithMany().HasForeignKey("CodigoGastoFinalId"),
                    l => l.HasOne<OtrosArticulo>().WithMany().HasForeignKey("OtroArticuloId"),
                    j =>
                    {
                        j.HasKey("OtroArticuloId", "CodigoGastoFinalId");
                        j.ToTable("codigoGastoFinal_OtrosArticulos");
                        j.HasIndex(new[] { "CodigoGastoFinalId" }, "IX_codigoGastoFinal_OtrosArticulos_codigoGastoFinalId");
                        j.IndexerProperty<int>("OtroArticuloId").HasColumnName("otroArticuloId");
                        j.IndexerProperty<int>("CodigoGastoFinalId").HasColumnName("codigoGastoFinalId");
                    });
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.ToTable("pagos");

            entity.HasIndex(e => e.UsuarioId, "IX_pagos_usuarioId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConciliacionId).HasColumnName("conciliacionId");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaPago).HasColumnName("fechaPago");
            entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pagos).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<PagoSueldosManual>(entity =>
        {
            entity.ToTable("pagoSueldosManual");

            entity.HasIndex(e => e.EmpleadoId, "IX_pagoSueldosManual_empleadoId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ausentes).HasColumnName("ausentes");
            entity.Property(e => e.Bolisllo).HasColumnName("bolisllo");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleadoId");
            entity.Property(e => e.HsComunes).HasColumnName("hsComunes");
            entity.Property(e => e.HsDobles).HasColumnName("hsDobles");
            entity.Property(e => e.HsExtras).HasColumnName("hsExtras");
            entity.Property(e => e.MontoTotalBruto).HasColumnName("montoTotalBruto");
            entity.Property(e => e.RetencionesTot).HasColumnName("retencionesTot");
            entity.Property(e => e.Tardes).HasColumnName("tardes");
            entity.Property(e => e.ValorHora).HasColumnName("valorHora");
            entity.Property(e => e.ValorMes).HasColumnName("valorMes");

            entity.HasOne(d => d.Empleado).WithMany(p => p.PagoSueldosManuals).HasForeignKey(d => d.EmpleadoId);
        });

        modelBuilder.Entity<PermisoOrdenUsuariosAprobar>(entity =>
        {
            entity.HasKey(e => new { e.PermisosOrdenId, e.UsuarioId });

            entity.ToTable("permisoOrden_UsuariosAprobar");

            entity.HasIndex(e => e.PermisoOrdenDeCompraid, "IX_permisoOrden_UsuariosAprobar_PermisoOrdenDeCompraid");

            entity.HasIndex(e => e.UsuarioId, "IX_permisoOrden_UsuariosAprobar_usuarioId");

            entity.Property(e => e.PermisosOrdenId).HasColumnName("permisosOrdenId");
            entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.PermisoOrdenDeCompra).WithMany(p => p.PermisoOrdenUsuariosAprobarPermisoOrdenDeCompras).HasForeignKey(d => d.PermisoOrdenDeCompraid);

            entity.HasOne(d => d.PermisosOrden).WithMany(p => p.PermisoOrdenUsuariosAprobarPermisosOrdens).HasForeignKey(d => d.PermisosOrdenId);

            entity.HasOne(d => d.Usuario).WithMany(p => p.PermisoOrdenUsuariosAprobars).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<PermisoOrdenUsuariosRevisar>(entity =>
        {
            entity.HasKey(e => new { e.PermisosOrdenId, e.UsuarioId });

            entity.ToTable("permisoOrden_UsuariosRevisar");

            entity.HasIndex(e => e.PermisoOrdenDeCompraid, "IX_permisoOrden_UsuariosRevisar_PermisoOrdenDeCompraid");

            entity.HasIndex(e => e.UsuarioId, "IX_permisoOrden_UsuariosRevisar_usuarioId");

            entity.Property(e => e.PermisosOrdenId).HasColumnName("permisosOrdenId");
            entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.PermisoOrdenDeCompra).WithMany(p => p.PermisoOrdenUsuariosRevisarPermisoOrdenDeCompras).HasForeignKey(d => d.PermisoOrdenDeCompraid);

            entity.HasOne(d => d.PermisosOrden).WithMany(p => p.PermisoOrdenUsuariosRevisarPermisosOrdens).HasForeignKey(d => d.PermisosOrdenId);

            entity.HasOne(d => d.Usuario).WithMany(p => p.PermisoOrdenUsuariosRevisars).HasForeignKey(d => d.UsuarioId);
        });

        modelBuilder.Entity<PermisosOrdenDeCompra>(entity =>
        {
            entity.ToTable("permisosOrdenDeCompra");

            entity.HasIndex(e => e.TipoPermisoOrdenId, "IX_permisosOrdenDeCompra_tipoPermisoOrdenId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MontoMinimoDolares).HasColumnName("montoMinimoDolares");
            entity.Property(e => e.RestriccionAprobar).HasColumnName("restriccionAprobar");
            entity.Property(e => e.RestriccionRevisar).HasColumnName("restriccionRevisar");
            entity.Property(e => e.TipoPermisoOrdenId).HasColumnName("tipoPermisoOrdenId");

            entity.HasOne(d => d.TipoPermisoOrden).WithMany(p => p.PermisosOrdenDeCompras).HasForeignKey(d => d.TipoPermisoOrdenId);
        });

        modelBuilder.Entity<Pieza>(entity =>
        {
            entity.ToTable("piezas");

            entity.HasIndex(e => e.ContenedorId, "IX_piezas_contenedorId");

            entity.HasIndex(e => e.MaquinaId, "IX_piezas_maquinaId");

            entity.HasIndex(e => e.MaterialId, "IX_piezas_materialId");

            entity.HasIndex(e => e.OrdenDeCompraId, "IX_piezas_ordenDeCompraId");

            entity.HasIndex(e => e.SubconjuntoId, "IX_piezas_subconjuntoId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aclaracion).HasColumnName("aclaracion");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Categoria).HasColumnName("categoria");
            entity.Property(e => e.ContenedorId).HasColumnName("contenedorId");
            entity.Property(e => e.DescripcionDeCompra).HasColumnName("descripcionDeCompra");
            entity.Property(e => e.Discriminante).HasColumnName("discriminante");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FinMec).HasColumnName("finMec");
            entity.Property(e => e.Foto).HasColumnName("foto");
            entity.Property(e => e.LoteTratamiento).HasColumnName("loteTratamiento");
            entity.Property(e => e.MaquinaId).HasColumnName("maquinaId");
            entity.Property(e => e.MaterialId).HasColumnName("materialId");
            entity.Property(e => e.NombrePieza).HasColumnName("nombrePieza");
            entity.Property(e => e.NumPieza).HasColumnName("numPieza");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.OrdenDeCompraId).HasColumnName("ordenDeCompraId");
            entity.Property(e => e.Prioridad).HasColumnName("prioridad");
            entity.Property(e => e.PrioridadFinal).HasColumnName("prioridadFinal");
            entity.Property(e => e.SobreCodigo).HasColumnName("sobreCodigo");
            entity.Property(e => e.SubconjuntoId).HasColumnName("subconjuntoId");
            entity.Property(e => e.TFresa).HasColumnName("tFresa");
            entity.Property(e => e.TTorno).HasColumnName("tTorno");
            entity.Property(e => e.TipoDePieza).HasColumnName("tipoDePieza");

            entity.HasOne(d => d.Contenedor).WithMany(p => p.Piezas).HasForeignKey(d => d.ContenedorId);

            entity.HasOne(d => d.Maquina).WithMany(p => p.Piezas).HasForeignKey(d => d.MaquinaId);

            entity.HasOne(d => d.MaterialNavigation).WithMany(p => p.Piezas).HasForeignKey(d => d.MaterialId);

            entity.HasOne(d => d.OrdenDeCompra).WithMany(p => p.Piezas).HasForeignKey(d => d.OrdenDeCompraId);

            entity.HasOne(d => d.Subconjunto).WithMany(p => p.Piezas).HasForeignKey(d => d.SubconjuntoId);
        });

        modelBuilder.Entity<PiezaUbicacion>(entity =>
        {
            entity.ToTable("piezaUbicacion");

            entity.HasIndex(e => e.PiezaId, "IX_piezaUbicacion_piezaId");

            entity.HasIndex(e => e.UbicacionPiezaId, "IX_piezaUbicacion_ubicacionPiezaID");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PiezaId).HasColumnName("piezaId");
            entity.Property(e => e.UbicacionPiezaId).HasColumnName("ubicacionPiezaID");

            entity.HasOne(d => d.Pieza).WithMany(p => p.PiezaUbicacions).HasForeignKey(d => d.PiezaId);

            entity.HasOne(d => d.UbicacionPieza).WithMany(p => p.PiezaUbicacions).HasForeignKey(d => d.UbicacionPiezaId);
        });

        modelBuilder.Entity<PorCodigo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PorCodigos");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.NombreMoneda).HasColumnName("nombreMoneda");
            entity.Property(e => e.ValorActual).HasColumnName("valorActual");
        });

        modelBuilder.Entity<PorCuenta2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PorCuenta2");

            entity.Property(e => e.CuentaId).HasColumnName("cuentaId");
            entity.Property(e => e.NombreCuenta).HasColumnName("nombreCuenta");
            entity.Property(e => e.NombreMoneda).HasColumnName("nombreMoneda");
            entity.Property(e => e.Tc2)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TC2");
        });

        modelBuilder.Entity<PorCuentum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PorCuenta");

            entity.Property(e => e.CuentaId).HasColumnName("cuentaId");
            entity.Property(e => e.NombreCuenta).HasColumnName("nombreCuenta");
            entity.Property(e => e.NombreMoneda).HasColumnName("nombreMoneda");
        });

        modelBuilder.Entity<PorMonedum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Por Moneda");

            entity.Property(e => e.NombreMoneda).HasColumnName("nombreMoneda");
            entity.Property(e => e.ValorActual).HasColumnName("valorActual");
        });

        modelBuilder.Entity<PorMonedum1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PorMoneda");

            entity.Property(e => e.NombreMoneda).HasColumnName("nombreMoneda");
            entity.Property(e => e.Tc)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TC");
        });

        modelBuilder.Entity<ProveedorRubroVistum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ProveedorRubroVista");

            entity.Property(e => e.NombreProveedor).HasColumnName("nombreProveedor");
            entity.Property(e => e.NombreRubro).HasColumnName("nombreRubro");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.ToTable("proveedores");

            entity.HasIndex(e => e.TipoPermisoOrdenId, "IX_proveedores_tipoPermisoOrdenId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreProveedor).HasColumnName("nombreProveedor");
            entity.Property(e => e.TipoPermisoOrdenId).HasColumnName("tipoPermisoOrdenId");

            entity.HasOne(d => d.TipoPermisoOrden).WithMany(p => p.Proveedores).HasForeignKey(d => d.TipoPermisoOrdenId);

            entity.HasMany(d => d.Rubros).WithMany(p => p.Proveedores)
                .UsingEntity<Dictionary<string, object>>(
                    "ProveedorRubro",
                    r => r.HasOne<Rubro>().WithMany().HasForeignKey("Rubrosid"),
                    l => l.HasOne<Proveedore>().WithMany().HasForeignKey("Proveedoresid"),
                    j =>
                    {
                        j.HasKey("Proveedoresid", "Rubrosid");
                        j.ToTable("ProveedorRubro");
                        j.HasIndex(new[] { "Rubrosid" }, "IX_ProveedorRubro_rubrosid");
                        j.IndexerProperty<int>("Proveedoresid").HasColumnName("proveedoresid");
                        j.IndexerProperty<int>("Rubrosid").HasColumnName("rubrosid");
                    });
        });

        modelBuilder.Entity<RastreoPiezas2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("RastreoPiezas2");

            entity.Property(e => e.Descripciondecompra).HasColumnName("descripciondecompra");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Material).HasColumnName("material");
            entity.Property(e => e.NombreContenedor).HasColumnName("nombreContenedor");
            entity.Property(e => e.NombrePieza).HasColumnName("nombrePieza");
            entity.Property(e => e.Tipodepieza).HasColumnName("tipodepieza");
        });

        modelBuilder.Entity<RazonPararProceso>(entity =>
        {
            entity.ToTable("razonPararProcesos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Razon).HasColumnName("razon");
        });

        modelBuilder.Entity<Rprl>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("RPRL");

            entity.Property(e => e.CodRpRl)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("Cod_RpRl");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.MonedaId).HasColumnName("monedaId");
            entity.Property(e => e.NombreCuenta).HasColumnName("nombreCuenta");
            entity.Property(e => e.Subcodigo).HasColumnName("subcodigo");
            entity.Property(e => e.ValorMonedaDestino).HasColumnName("valorMonedaDestino");
            entity.Property(e => e.ValorMonedaOrien).HasColumnName("valorMonedaOrien");
        });

        modelBuilder.Entity<Rubro>(entity =>
        {
            entity.ToTable("rubros");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreRubro).HasColumnName("nombreRubro");
        });

        modelBuilder.Entity<SaldosCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SaldosClientes");

            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.NombreCliente).HasColumnName("nombreCliente");
            entity.Property(e => e.Nombremoneda).HasColumnName("nombremoneda");
        });

        modelBuilder.Entity<Segguimiento2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Segguimiento2");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodigoGastoId).HasColumnName("codigoGastoId");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.DescripcionCompra).HasColumnName("descripcionCompra");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MontoDolares).HasColumnName("montoDolares");
            entity.Property(e => e.MontoPesos).HasColumnName("montoPesos");
            entity.Property(e => e.NombreCuenta).HasColumnName("nombreCuenta");
            entity.Property(e => e.NombreProveedor).HasColumnName("nombreProveedor");
            entity.Property(e => e.NroCt).HasColumnName("nroCT");
        });

        modelBuilder.Entity<Seguimiento2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Seguimiento 2");

            entity.Property(e => e.CodigoGastoId).HasColumnName("codigoGastoId");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaCt).HasColumnName("fechaCT");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MontoPesos).HasColumnName("montoPesos");
            entity.Property(e => e.NombreCuenta).HasColumnName("nombreCuenta");
            entity.Property(e => e.NroCt).HasColumnName("nroCT");
            entity.Property(e => e.PagoId).HasColumnName("pagoId");
            entity.Property(e => e.PagoNro).HasColumnName("pagoNro");
            entity.Property(e => e.SubcodigoGastoId).HasColumnName("subcodigoGastoId");
            entity.Property(e => e.TipoPago).HasColumnName("tipoPago");
            entity.Property(e => e.ValorMonedaOrien).HasColumnName("valorMonedaOrien");
        });

        modelBuilder.Entity<SubcodigosGasto>(entity =>
        {
            entity.ToTable("subcodigosGasto");

            entity.HasIndex(e => e.CodigoGastoId, "IX_subcodigosGasto_codigoGastoId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoGastoId).HasColumnName("codigoGastoId");
            entity.Property(e => e.Subcodigo).HasColumnName("subcodigo");

            entity.HasOne(d => d.CodigoGasto).WithMany(p => p.SubcodigosGastos).HasForeignKey(d => d.CodigoGastoId);
        });

        modelBuilder.Entity<Subconciliacione>(entity =>
        {
            entity.ToTable("subconciliaciones");

            entity.HasIndex(e => e.ConciliacionId, "IX_subconciliaciones_conciliacionId");

            entity.HasIndex(e => e.CuentaId, "IX_subconciliaciones_cuentaId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConciliacionId).HasColumnName("conciliacionId");
            entity.Property(e => e.CuentaId).HasColumnName("cuentaId");
            entity.Property(e => e.NumSubConciliacion).HasColumnName("numSubConciliacion");

            entity.HasOne(d => d.Conciliacion).WithMany(p => p.Subconciliaciones).HasForeignKey(d => d.ConciliacionId);

            entity.HasOne(d => d.Cuenta).WithMany(p => p.Subconciliaciones).HasForeignKey(d => d.CuentaId);
        });

        modelBuilder.Entity<Subconjunto>(entity =>
        {
            entity.ToTable("subconjuntos");

            entity.HasIndex(e => e.MaquinaId, "IX_subconjuntos_maquinaId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MaquinaId).HasColumnName("maquinaId");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.NumSubconjunto).HasColumnName("numSubconjunto");
            entity.Property(e => e.Prioridad).HasColumnName("prioridad");

            entity.HasOne(d => d.Maquina).WithMany(p => p.Subconjuntos).HasForeignKey(d => d.MaquinaId);
        });

        modelBuilder.Entity<SumPorCuentaDolarOficial>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SumPorCuentaDolarOficial");

            entity.Property(e => e.Totusd).HasColumnName("totusd");
        });

        modelBuilder.Entity<TipoCambioDeCadaPago>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TipoCambioDeCadaPago");

            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaGeneracion).HasColumnName("fechaGeneracion");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdMovOrigen).HasColumnName("idMovOrigen");
            entity.Property(e => e.MontoPesos).HasColumnName("montoPesos");
            entity.Property(e => e.NombreCuenta).HasColumnName("nombreCuenta");
            entity.Property(e => e.PagoId).HasColumnName("pagoId");
            entity.Property(e => e.PagoNro).HasColumnName("pagoNro");
            entity.Property(e => e.ValorMonedaDestino).HasColumnName("valorMonedaDestino");
            entity.Property(e => e.ValorMonedaOrien).HasColumnName("valorMonedaOrien");
        });

        modelBuilder.Entity<TiposPermisoOrden>(entity =>
        {
            entity.ToTable("tiposPermisoOrden");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreTipoPermiso).HasColumnName("nombreTipoPermiso");
        });

        modelBuilder.Entity<TransferenciasInterna>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Transferencias_Internas");

            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.DesdeId).HasColumnName("DesdeID");
            entity.Property(e => e.FechaTrasf).HasMaxLength(4000);
            entity.Property(e => e.HaciaId).HasColumnName("HaciaID");
            entity.Property(e => e.TcD).HasColumnName("TC_d");
            entity.Property(e => e.TcO).HasColumnName("TC_o");
        });

        modelBuilder.Entity<Ubicacione>(entity =>
        {
            entity.ToTable("ubicaciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Ubicacion).HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("contraseña");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.NombreDeUsuario).HasColumnName("nombreDeUsuario");
        });

        modelBuilder.Entity<ValoresDolar>(entity =>
        {
            entity.ToTable("ValoresDolar");

            entity.HasIndex(e => e.UsuarioResponsableid, "IX_ValoresDolar_usuarioResponsableid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.UsuarioResponsableid).HasColumnName("usuarioResponsableid");
            entity.Property(e => e.ValorDolar).HasColumnName("valorDolar");

            entity.HasOne(d => d.UsuarioResponsable).WithMany(p => p.ValoresDolars).HasForeignKey(d => d.UsuarioResponsableid);
        });

        modelBuilder.Entity<View1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view1");

            entity.Property(e => e.Ubicacion).HasColumnName("ubicacion");
        });

        modelBuilder.Entity<View2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view2");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Categoria).HasColumnName("categoria");
            entity.Property(e => e.DescripcionDeCompra).HasColumnName("descripcionDeCompra");
            entity.Property(e => e.Entrega).HasMaxLength(4000);
            entity.Property(e => e.Material).HasColumnName("material");
            entity.Property(e => e.NombreContenedor).HasColumnName("nombreContenedor");
            entity.Property(e => e.NombreEstado).HasColumnName("nombreEstado");
            entity.Property(e => e.Oc).HasColumnName("OC");
            entity.Property(e => e.Pedido).HasMaxLength(4000);
            entity.Property(e => e.Pieza).HasColumnName("PIEZA");
            entity.Property(e => e.SobreCodigo).HasColumnName("sobreCodigo");
        });

        modelBuilder.Entity<VwItemsOrdenCompraConPrecio>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ItemsOrdenCompraConPrecios");

            entity.Property(e => e.DescripcionCompra).HasColumnName("Descripcion_Compra");
            entity.Property(e => e.DescripcionPago).HasColumnName("descripcion_Pago");
            entity.Property(e => e.Dto).HasColumnName("dto");
            entity.Property(e => e.FechaPago).HasColumnName("fecha_pago");
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.NroPago).HasColumnName("Nro_Pago");
            entity.Property(e => e.Oc).HasColumnName("oc");
            entity.Property(e => e.Precio).HasColumnName("Precio$");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
