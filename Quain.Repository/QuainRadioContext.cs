using Microsoft.EntityFrameworkCore;
using Quain.Domain.Models;
using Quain.Repository.Quain;

namespace Quain.Repository;

public partial class QuainRadioContext : DbContext
{
    public QuainRadioContext()
    {
    }

    public QuainRadioContext(DbContextOptions<QuainRadioContext> options)
        : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Gva14> Gva14s { get; set; }

    public virtual DbSet<Gva53> Gva53s { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
                .HasOne(x => x.Points)
                .WithOne(x => x.Customer);

        modelBuilder.Entity<Points>()
            .HasMany(x => x.PointsChanges)
            .WithOne()
            .HasForeignKey(x => x.PointsId);

        modelBuilder.UseCollation("Modern_Spanish_CI_AI");

        modelBuilder.Entity<Gva14>(entity =>
        {
            entity.HasKey(e => e.IdGva14);

            entity.ToTable("GVA14", tb =>
                {
                    tb.HasTrigger("TS_GVA14_PRECIOS_WEBCLIENTES");
                    tb.HasTrigger("TS_GVA14_VENDEDORES_WEBCLIENTES");
                    tb.HasTrigger("TS_GVA14_WEBCLIENTES");
                    tb.HasTrigger("T_CACHE_GVA14");
                    tb.HasTrigger("T_INSENSITIVE_GVA14");
                });

            entity.HasIndex(e => e.IdSucursalDestinoFactura, "GVA14_SUCURSAL_DESTINO_FACTURA_FK");

            entity.HasIndex(e => e.IdSucursalDestinoFacturaRemito, "GVA14_SUCURSAL_DESTINO_FACTURA_REMITO_FK");

            entity.HasIndex(e => e.CodClient, "IX_0").IsUnique();

            entity.HasIndex(e => e.CodProvin, "IX_1");

            entity.HasIndex(e => e.EnvDomic, "IX_10");

            entity.HasIndex(e => e.NroEnvio, "IX_11");

            entity.HasIndex(e => e.FechaAlta, "IX_12");

            entity.HasIndex(e => e.CodClient, "IX_13");

            entity.HasIndex(e => e.CodGva14, "IX_14").IsUnique();

            entity.HasIndex(e => e.NomCom, "IX_15");

            entity.HasIndex(e => e.CodigoAfinidad, "IX_16");

            entity.HasIndex(e => new { e.SaldoCcU, e.SaldoCc, e.EMail, e.CodClient }, "IX_17");

            entity.HasIndex(e => e.CodZona, "IX_2");

            entity.HasIndex(e => e.RazonSoci, "IX_3");

            entity.HasIndex(e => e.Cuit, "IX_4");

            entity.HasIndex(e => new { e.GrupoEmpr, e.CodClient }, "IX_5");

            entity.HasIndex(e => e.Cumpleanio, "IX_6");

            entity.HasIndex(e => e.Telefono1, "IX_7");

            entity.HasIndex(e => e.Domicilio, "IX_8");

            entity.HasIndex(e => e.Telefono2, "IX_9");

            entity.Property(e => e.IdGva14)
                .HasDefaultValueSql("(NEXT VALUE FOR [SEQUENCE_GVA14])")
                .HasColumnName("ID_GVA14");
            entity.Property(e => e.Adjunto)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("ADJUNTO");
            entity.Property(e => e.AliNoCat)
                .HasDefaultValueSql("(0)")
                .HasColumnName("ALI_NO_CAT");
            entity.Property(e => e.AplicaMora)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("APLICA_MORA");
            entity.Property(e => e.AutDe)
                .HasDefaultValueSql("(0)")
                .HasColumnName("AUT_DE");
            entity.Property(e => e.AutorizadoWebClientes)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("AUTORIZADO_WEB_CLIENTES");
            entity.Property(e => e.Bmp)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("BMP");
            entity.Property(e => e.CPostal)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("C_POSTAL");
            entity.Property(e => e.CalDebIn)
                .HasDefaultValueSql("(0)")
                .HasColumnName("CAL_DEB_IN");
            entity.Property(e => e.Calle)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("CALLE");
            entity.Property(e => e.Calle2Env)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("CALLE2_ENV");
            entity.Property(e => e.CamposAdicionales)
                .HasColumnType("xml")
                .HasColumnName("CAMPOS_ADICIONALES");
            entity.Property(e => e.Cbu)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("CBU");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("CIUDAD");
            entity.Property(e => e.CiudadEnvio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("CIUDAD_ENVIO");
            entity.Property(e => e.ClaImpCl)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("CLA_IMP_CL");
            entity.Property(e => e.Clausula)
                .HasDefaultValueSql("(0)")
                .HasColumnName("CLAUSULA");
            entity.Property(e => e.ClaveIs)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("CLAVE_IS");
            entity.Property(e => e.CmVigenciaCoeficiente)
                .HasColumnType("datetime")
                .HasColumnName("CM_VIGENCIA_COEFICIENTE");
            entity.Property(e => e.CobraDomingo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("COBRA_DOMINGO");
            entity.Property(e => e.CobraJueves)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("COBRA_JUEVES");
            entity.Property(e => e.CobraLunes)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("COBRA_LUNES");
            entity.Property(e => e.CobraMartes)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("COBRA_MARTES");
            entity.Property(e => e.CobraMiercoles)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("COBRA_MIERCOLES");
            entity.Property(e => e.CobraSabado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("COBRA_SABADO");
            entity.Property(e => e.CobraViernes)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("COBRA_VIERNES");
            entity.Property(e => e.CodActCna25)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COD_ACT_CNA25");
            entity.Property(e => e.CodClient)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("COD_CLIENT");
            entity.Property(e => e.CodGva05)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COD_GVA05");
            entity.Property(e => e.CodGva05Env)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COD_GVA05_ENV");
            entity.Property(e => e.CodGva14)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COD_GVA14");
            entity.Property(e => e.CodGva150)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COD_GVA150");
            entity.Property(e => e.CodGva151)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COD_GVA151");
            entity.Property(e => e.CodGva18)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COD_GVA18");
            entity.Property(e => e.CodGva18Env)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COD_GVA18_ENV");
            entity.Property(e => e.CodGva23)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COD_GVA23");
            entity.Property(e => e.CodGva24)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COD_GVA24");
            entity.Property(e => e.CodGva62)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COD_GVA62");
            entity.Property(e => e.CodProvin)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("COD_PROVIN");
            entity.Property(e => e.CodRubro)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("COD_RUBRO");
            entity.Property(e => e.CodTransp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("COD_TRANSP");
            entity.Property(e => e.CodVended)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("COD_VENDED");
            entity.Property(e => e.CodZona)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("COD_ZONA");
            entity.Property(e => e.CodigoAfinidad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("CODIGO_AFINIDAD");
            entity.Property(e => e.ComentarioTypFac)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COMENTARIO_TYP_FAC");
            entity.Property(e => e.ComentarioTypNc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COMENTARIO_TYP_NC");
            entity.Property(e => e.ComentarioTypNd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("COMENTARIO_TYP_ND");
            entity.Property(e => e.CondVta)
                .HasDefaultValueSql("(0)")
                .HasColumnName("COND_VTA");
            entity.Property(e => e.CtaCli)
                .HasDefaultValueSql("(0)")
                .HasColumnName("CTA_CLI");
            entity.Property(e => e.CtoCli)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("CTO_CLI");
            entity.Property(e => e.Cuit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("CUIT");
            entity.Property(e => e.Cumpleanio)
                .HasDefaultValueSql("('1800/01/01')")
                .HasColumnType("datetime")
                .HasColumnName("CUMPLEANIO");
            entity.Property(e => e.CupoCredi)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("CUPO_CREDI");
            entity.Property(e => e.DestinoDe)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("DESTINO_DE");
            entity.Property(e => e.DetArtic)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('P')")
                .HasColumnName("DET_ARTIC");
            entity.Property(e => e.DiasMiIn)
                .HasDefaultValueSql("(0)")
                .HasColumnName("DIAS_MI_IN");
            entity.Property(e => e.DirCom)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("DIR_COM");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("DOMICILIO");
            entity.Property(e => e.DtoEnvio)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("DTO_ENVIO");
            entity.Property(e => e.DtoLegal)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("DTO_LEGAL");
            entity.Property(e => e.EMail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("E_MAIL");
            entity.Property(e => e.EnvDomic)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("ENV_DOMIC");
            entity.Property(e => e.EnvLocal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("ENV_LOCAL");
            entity.Property(e => e.EnvPostal)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("ENV_POSTAL");
            entity.Property(e => e.EnvProv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("ENV_PROV");
            entity.Property(e => e.ExpSaldo)
                .HasDefaultValueSql("(0)")
                .HasColumnName("EXP_SALDO");
            entity.Property(e => e.Exporta)
                .HasDefaultValueSql("(0)")
                .HasColumnName("EXPORTA");
            entity.Property(e => e.FechaAlta)
                .HasDefaultValueSql("('1800/01/01')")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ALTA");
            entity.Property(e => e.FechaAnt)
                .HasDefaultValueSql("('1800/01/01')")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ANT");
            entity.Property(e => e.FechaDesd)
                .HasDefaultValueSql("('1800/01/01')")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_DESD");
            entity.Property(e => e.FechaHast)
                .HasDefaultValueSql("('1800/01/01')")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HAST");
            entity.Property(e => e.FechaInha)
                .HasDefaultValueSql("('1800/01/01')")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INHA");
            entity.Property(e => e.FechaModi)
                .HasDefaultValueSql("('1800/01/01')")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODI");
            entity.Property(e => e.FechaVto)
                .HasDefaultValueSql("('1800/01/01')")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_VTO");
            entity.Property(e => e.Filler)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("FILLER");
            entity.Property(e => e.GrupoEmpr)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("GRUPO_EMPR");
            entity.Property(e => e.Habilitado)
                .HasComputedColumnSql("(CONVERT([bit],case when isnull([GVA14].[FECHA_INHA],(0))<=(0) OR [GVA14].[FECHA_INHA]>getdate() then (1) else (0) end))", false)
                .HasColumnName("HABILITADO");
            entity.Property(e => e.HorarioCobranza)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("HORARIO_COBRANZA");
            entity.Property(e => e.IdCategoriaIva).HasColumnName("ID_CATEGORIA_IVA");
            entity.Property(e => e.IdExterno)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("ID_EXTERNO");
            entity.Property(e => e.IdGva01).HasColumnName("ID_GVA01");
            entity.Property(e => e.IdGva05).HasColumnName("ID_GVA05");
            entity.Property(e => e.IdGva05Env).HasColumnName("ID_GVA05_ENV");
            entity.Property(e => e.IdGva10).HasColumnName("ID_GVA10");
            entity.Property(e => e.IdGva150).HasColumnName("ID_GVA150");
            entity.Property(e => e.IdGva151).HasColumnName("ID_GVA151");
            entity.Property(e => e.IdGva18).HasColumnName("ID_GVA18");
            entity.Property(e => e.IdGva18Env).HasColumnName("ID_GVA18_ENV");
            entity.Property(e => e.IdGva23).HasColumnName("ID_GVA23");
            entity.Property(e => e.IdGva24).HasColumnName("ID_GVA24");
            entity.Property(e => e.IdGva41NoCat).HasColumnName("ID_GVA41_NO_CAT");
            entity.Property(e => e.IdGva44Fex).HasColumnName("ID_GVA44_FEX");
            entity.Property(e => e.IdGva44Ncex).HasColumnName("ID_GVA44_NCEX");
            entity.Property(e => e.IdGva44Ndex).HasColumnName("ID_GVA44_NDEX");
            entity.Property(e => e.IdGva62).HasColumnName("ID_GVA62");
            entity.Property(e => e.IdInteresPorMora).HasColumnName("ID_INTERES_POR_MORA");
            entity.Property(e => e.IdInterno)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("ID_INTERNO");
            entity.Property(e => e.IdRg3572TipoOperacionHabitual).HasColumnName("ID_RG_3572_TIPO_OPERACION_HABITUAL");
            entity.Property(e => e.IdRg3685TipoOperacionVentas).HasColumnName("ID_RG_3685_TIPO_OPERACION_VENTAS");
            entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.IdSucursalDestinoFactura).HasColumnName("ID_SUCURSAL_DESTINO_FACTURA");
            entity.Property(e => e.IdSucursalDestinoFacturaRemito).HasColumnName("ID_SUCURSAL_DESTINO_FACTURA_REMITO");
            entity.Property(e => e.IdTipoDocumentoExterior).HasColumnName("ID_TIPO_DOCUMENTO_EXTERIOR");
            entity.Property(e => e.IdTipoDocumentoGv).HasColumnName("ID_TIPO_DOCUMENTO_GV");
            entity.Property(e => e.IdTraOrigenInformacion).HasColumnName("ID_TRA_ORIGEN_INFORMACION");
            entity.Property(e => e.IdentifAfip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("IDENTIF_AFIP");
            entity.Property(e => e.IdiomaCte)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('P')")
                .HasColumnName("IDIOMA_CTE");
            entity.Property(e => e.IiD)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("II_D");
            entity.Property(e => e.IiL)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("II_L");
            entity.Property(e => e.IncComent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('P')")
                .HasColumnName("INC_COMENT");
            entity.Property(e => e.InhabilitadoNexoCobranzas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("INHABILITADO_NEXO_COBRANZAS");
            entity.Property(e => e.InhabilitadoNexoPedidos)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("INHABILITADO_NEXO_PEDIDOS");
            entity.Property(e => e.IvaD)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("IVA_D");
            entity.Property(e => e.IvaL)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("IVA_L");
            entity.Property(e => e.LimcreEn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("LIMCRE_EN");
            entity.Property(e => e.Localidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("LOCALIDAD");
            entity.Property(e => e.MailDe)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("MAIL_DE");
            entity.Property(e => e.MailNexo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("MAIL_NEXO");
            entity.Property(e => e.MonCte)
                .HasDefaultValueSql("(1)")
                .HasColumnName("MON_CTE");
            entity.Property(e => e.MonMiIn)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("MON_MI_IN");
            entity.Property(e => e.NImpuesto)
                .HasMaxLength(160)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("N_IMPUESTO");
            entity.Property(e => e.NIngBrut)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("N_ING_BRUT");
            entity.Property(e => e.NPagoelec)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("N_PAGOELEC");
            entity.Property(e => e.NomCom)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("NOM_COM");
            entity.Property(e => e.NroEnvio)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("NRO_ENVIO");
            entity.Property(e => e.NroInscrRg1817)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("NRO_INSCR_RG1817");
            entity.Property(e => e.NroLegal)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("NRO_LEGAL");
            entity.Property(e => e.NroLista)
                .HasDefaultValueSql("(0)")
                .HasColumnName("NRO_LISTA");
            entity.Property(e => e.NumeroDocumentoExterior)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("NUMERO_DOCUMENTO_EXTERIOR");
            entity.Property(e => e.Observacio)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("OBSERVACIO");
            entity.Property(e => e.Observaciones)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("OBSERVACIONES");
            entity.Property(e => e.Partidoenv)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PARTIDOENV");
            entity.Property(e => e.PermiteIs)
                .HasDefaultValueSql("(0)")
                .HasColumnName("PERMITE_IS");
            entity.Property(e => e.PisoEnvio)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("('0')")
                .HasColumnName("PISO_ENVIO");
            entity.Property(e => e.PisoLegal)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("('0')")
                .HasColumnName("PISO_LEGAL");
            entity.Property(e => e.PorcDesc)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PORC_DESC");
            entity.Property(e => e.PorcExcl)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PORC_EXCL");
            entity.Property(e => e.PorcRecar)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PORC_RECAR");
            entity.Property(e => e.PorceInt)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PORCE_INT");
            entity.Property(e => e.PublicaWebClientes)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("PUBLICA_WEB_CLIENTES");
            entity.Property(e => e.Puntaje)
                .HasDefaultValueSql("(0)")
                .HasColumnName("PUNTAJE");
            entity.Property(e => e.RazonSoci)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("RAZON_SOCI");
            entity.Property(e => e.RecibeDe)
                .HasDefaultValueSql("(0)")
                .HasColumnName("RECIBE_DE");
            entity.Property(e => e.RequiereInformacionAdicional)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("REQUIERE_INFORMACION_ADICIONAL");
            entity.Property(e => e.Rg1361)
                .HasDefaultValueSql("(0)")
                .HasColumnName("RG_1361");
            entity.Property(e => e.Rg3572EmpresaVinculadaCliente)
                .HasDefaultValueSql("((0))")
                .HasColumnName("RG_3572_EMPRESA_VINCULADA_CLIENTE");
            entity.Property(e => e.Rg3572TipoOperacionHabitualVentas)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("RG_3572_TIPO_OPERACION_HABITUAL_VENTAS");
            entity.Property(e => e.Rg3685TipoOperacionVentas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("RG_3685_TIPO_OPERACION_VENTAS");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("ROW_VERSION");
            entity.Property(e => e.SalAnUn)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("SAL_AN_UN");
            entity.Property(e => e.SaldoAnt)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("SALDO_ANT");
            entity.Property(e => e.SaldoCc)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("SALDO_CC");
            entity.Property(e => e.SaldoCcU)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("SALDO_CC_U");
            entity.Property(e => e.SaldoDUn)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("SALDO_D_UN");
            entity.Property(e => e.SaldoDoc)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("SALDO_DOC");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SEXO");
            entity.Property(e => e.SobreIi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("SOBRE_II");
            entity.Property(e => e.SobreIva)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .HasColumnName("SOBRE_IVA");
            entity.Property(e => e.SucurOri)
                .HasDefaultValueSql("(0)")
                .HasColumnName("SUCUR_ORI");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("TELEFONO_1");
            entity.Property(e => e.Telefono2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("TELEFONO_2");
            entity.Property(e => e.TelefonoMovil)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("TELEFONO_MOVIL");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("TIPO");
            entity.Property(e => e.TipoDoc)
                .HasDefaultValueSql("(0)")
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.TypFex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('H')")
                .HasColumnName("TYP_FEX");
            entity.Property(e => e.TypNcex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('H')")
                .HasColumnName("TYP_NCEX");
            entity.Property(e => e.TypNdex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('H')")
                .HasColumnName("TYP_NDEX");
            entity.Property(e => e.Web)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("WEB");
            entity.Property(e => e.WebClientId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WEB_CLIENT_ID");
            entity.Property(e => e.ZonaEnvio)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("ZONA_ENVIO");
        });

        modelBuilder.Entity<Gva53>(entity =>
        {
            entity.HasKey(e => e.IdGva53);

            entity.ToTable("GVA53", tb => tb.HasTrigger("TS_GVA53_WEBCLIENTES"));

            entity.HasIndex(e => new { e.TComp, e.NComp, e.NRenglV }, "IX_0").IsUnique();

            entity.HasIndex(e => new { e.CodArticu, e.FechaMov }, "IX_1");

            entity.HasIndex(e => e.CodClasif, "IX_2");

            entity.HasIndex(e => new { e.CodArticu, e.IdGva53, e.FechaMov, e.TComp, e.NComp, e.CodDeposi }, "IX_3");

            entity.Property(e => e.IdGva53).HasColumnName("ID_GVA53");
            entity.Property(e => e.CanEquiV)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("CAN_EQUI_V");
            entity.Property(e => e.CancCre)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("CANC_CRE");
            entity.Property(e => e.Cantidad)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("CANTIDAD");
            entity.Property(e => e.Cantidad2)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("CANTIDAD_2");
            entity.Property(e => e.CentStk)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("CENT_STK");
            entity.Property(e => e.CodArticu)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("COD_ARTICU");
            entity.Property(e => e.CodArticuKit)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("COD_ARTICU_KIT");
            entity.Property(e => e.CodClasif)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("COD_CLASIF");
            entity.Property(e => e.CodDeposi)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("COD_DEPOSI");
            entity.Property(e => e.FaltanRem)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("FALTAN_REM");
            entity.Property(e => e.FaltanRem2)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("FALTAN_REM_2");
            entity.Property(e => e.FechaModificacionPrecio)
                .HasDefaultValueSql("('18000101')")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION_PRECIO");
            entity.Property(e => e.FechaMov)
                .HasDefaultValueSql("('1800/01/01')")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MOV");
            entity.Property(e => e.Filler)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("FILLER");
            entity.Property(e => e.IdMedidaStock).HasColumnName("ID_MEDIDA_STOCK");
            entity.Property(e => e.IdMedidaStock2).HasColumnName("ID_MEDIDA_STOCK_2");
            entity.Property(e => e.IdMedidaVentas).HasColumnName("ID_MEDIDA_VENTAS");
            entity.Property(e => e.ImNetPE)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("IM_NET_P_E");
            entity.Property(e => e.ImRePaE)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("IM_RE_PA_E");
            entity.Property(e => e.ImpNetoP)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("IMP_NETO_P");
            entity.Property(e => e.ImpRePan)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("IMP_RE_PAN");
            entity.Property(e => e.ImporteExento)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("IMPORTE_EXENTO");
            entity.Property(e => e.ImporteGravado)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("IMPORTE_GRAVADO");
            entity.Property(e => e.InsumoKitSeparado)
                .HasDefaultValueSql("((0))")
                .HasColumnName("INSUMO_KIT_SEPARADO");
            entity.Property(e => e.ItemEspectaculo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("ITEM_ESPECTACULO");
            entity.Property(e => e.NComp)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("N_COMP");
            entity.Property(e => e.NPartida)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("N_PARTIDA");
            entity.Property(e => e.NRenglV).HasColumnName("N_RENGL_V");
            entity.Property(e => e.PorcDto)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PORC_DTO");
            entity.Property(e => e.PorcDtoParam)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PORC_DTO_PARAM");
            entity.Property(e => e.PorcIva)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PORC_IVA");
            entity.Property(e => e.PppEx)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PPP_EX");
            entity.Property(e => e.PppLo)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PPP_LO");
            entity.Property(e => e.PrUlcEE)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PR_ULC_E_E");
            entity.Property(e => e.PrUlcLE)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PR_ULC_L_E");
            entity.Property(e => e.PrecNetE)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PREC_NET_E");
            entity.Property(e => e.PrecPanE)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PREC_PAN_E");
            entity.Property(e => e.PrecUlcE)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PREC_ULC_E");
            entity.Property(e => e.PrecUlcL)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PREC_ULC_L");
            entity.Property(e => e.PrecioBonif)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PRECIO_BONIF");
            entity.Property(e => e.PrecioFecha)
                .HasDefaultValueSql("('18000101')")
                .HasColumnType("datetime")
                .HasColumnName("PRECIO_FECHA");
            entity.Property(e => e.PrecioLista)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PRECIO_LISTA");
            entity.Property(e => e.PrecioNet)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PRECIO_NET");
            entity.Property(e => e.PrecioPan)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PRECIO_PAN");
            entity.Property(e => e.Precsindto)
                .HasDefaultValueSql("(0)")
                .HasColumnType("decimal(22, 7)")
                .HasColumnName("PRECSINDTO");
            entity.Property(e => e.Promocion)
                .HasDefaultValueSql("(0)")
                .HasColumnName("PROMOCION");
            entity.Property(e => e.RenglPadr).HasColumnName("RENGL_PADR");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("ROW_VERSION");
            entity.Property(e => e.TComp)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("T_COMP");
            entity.Property(e => e.TcompInV)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_BIN")
                .HasColumnName("TCOMP_IN_V");
            entity.Property(e => e.TerminalModificacionPrecio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("TERMINAL_MODIFICACION_PRECIO");
            entity.Property(e => e.UnidadMedidaSeleccionada)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("UNIDAD_MEDIDA_SELECCIONADA");
            entity.Property(e => e.UsuarioModificacionPrecio)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("USUARIO_MODIFICACION_PRECIO");
        });
        modelBuilder.HasSequence("NUMERACION_COD_CLIENT");
        modelBuilder.HasSequence("NUMERACION_COD_PROVEE").StartsAt(0L);
        modelBuilder.HasSequence("SEQUENCE_ACTIVIDAD_DGI").StartsAt(900L);
        modelBuilder.HasSequence("SEQUENCE_ACTIVIDAD_EMPRESA_AFIP").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_ACTIVIDAD_LEGAJO_DGI").StartsAt(105L);
        modelBuilder.HasSequence("SEQUENCE_ACUMULA_PAGOS_RETENCION").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_ACUMULADO_DEFINIBLE");
        modelBuilder.HasSequence("SEQUENCE_ACUMULADO_FIJO");
        modelBuilder.HasSequence("SEQUENCE_AFJP");
        modelBuilder.HasSequence("SEQUENCE_AGRUPACION");
        modelBuilder.HasSequence("SEQUENCE_AGRUPACION_ASIENTO").StartsAt(12L);
        modelBuilder.HasSequence("SEQUENCE_AJUSTE");
        modelBuilder.HasSequence("SEQUENCE_ALICUOTA").StartsAt(12L);
        modelBuilder.HasSequence("SEQUENCE_ALICUOTA_IVA").StartsAt(12L);
        modelBuilder.HasSequence("SEQUENCE_ALICUOTAS_ART90_LIG").StartsAt(10L);
        modelBuilder.HasSequence("SEQUENCE_AplicacionNexoParametro");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_ARTICULO");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_ARTICULO_CT");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_BIEN");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_CLIENTE");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_CLIENTE_IV");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_CLIENTE_OCASIONAL");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_CLIENTE_POTENCIAL");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_CONCEPTO_CP");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_CUENTA_SB");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_DEFECTO_ARTICULO");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_DEFECTO_CLIENTE");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_PROVEEDOR");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_PROVEEDOR_IV");
        modelBuilder.HasSequence("SEQUENCE_APROPIACION_PROVEEDOR_OCASIONAL");
        modelBuilder.HasSequence("SEQUENCE_ARCHIVO_SHOPPING_TERMINAL");
        modelBuilder.HasSequence("SEQUENCE_ART");
        modelBuilder.HasSequence("SEQUENCE_ARTICULO_CUENTA");
        modelBuilder.HasSequence("SEQUENCE_ARTICULO_CUENTA_CT");
        modelBuilder.HasSequence("SEQUENCE_ARTICULO_PERCEPCION_VENTAS").StartsAt(210088L);
        modelBuilder.HasSequence("SEQUENCE_ARTICULO_PERCEPCION_VENTAS_DEFECTO").StartsAt(10L);
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_AF");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_ANALITICO_CN");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_COMPROBANTE_AF");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_COMPROBANTE_CP");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_COMPROBANTE_GV");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_COMPROBANTE_IV");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_COMPROBANTE_SB");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_COMPROBANTE_TR");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_COTIZACION_ANALITICO_CN");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_COTIZACION_RESUMEN_CN");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_CP");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_GV");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_IV");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_MODELO");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_MODELO_AF");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_MODELO_CP").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_MODELO_GV").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_RESUMEN_CN");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_SB");
        modelBuilder.HasSequence("SEQUENCE_ASIENTO_TR");
        modelBuilder.HasSequence("SEQUENCE_AUDITORIA").StartsAt(164791L);
        modelBuilder.HasSequence("SEQUENCE_AUDITORIA_CONCEPTO");
        modelBuilder.HasSequence("SEQUENCE_AUDITORIA_DETALLE").StartsAt(890963L);
        modelBuilder.HasSequence("SEQUENCE_AUDITORIA_PRECIO_ORDEN_COMPRA");
        modelBuilder.HasSequence("SEQUENCE_AUDITORIA_STA11");
        modelBuilder.HasSequence("SEQUENCE_AUSENTE_POR_SU_HORARIO");
        modelBuilder.HasSequence("SEQUENCE_AUTORIZACION_HORA_EXTRA");
        modelBuilder.HasSequence("SEQUENCE_AUX_AUTOMATICO_ARTICULO");
        modelBuilder.HasSequence("SEQUENCE_AUX_AUTOMATICO_CLIENTE");
        modelBuilder.HasSequence("SEQUENCE_AUX_AUTOMATICO_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_AUX_AUTOMATICO_PROVEEDOR");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_CUENTA_TIPO_AUXILIAR");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_HABITUAL_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_OCASIONAL_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_ARTICULO");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_ARTICULO_CT");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_BIEN");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_CLIENTE");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_CLIENTE_IV");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_CLIENTE_OCASIONAL");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_CLIENTE_POTENCIAL");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_CONCEPTO_CP");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_CUENTA_SB");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_DEFECTO_ARTICULO");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_DEFECTO_CLIENTE");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_HABITUAL_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_OCASIONAL_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_PROVEEDOR");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_PROVEEDOR_IV");
        modelBuilder.HasSequence("SEQUENCE_AUXILIAR_REGLA_PROVEEDOR_OCASIONAL");
        modelBuilder.HasSequence("SEQUENCE_BANCO").StartsAt(190L);
        modelBuilder.HasSequence("SEQUENCE_BASE_ANALISIS_RETENCION").StartsAt(9L);
        modelBuilder.HasSequence("SEQUENCE_BASE_CALCULO_PERCEPCION").StartsAt(15L);
        modelBuilder.HasSequence("SEQUENCE_BASE_CALCULO_RETENCION").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_BASES_IMPONIBLES");
        modelBuilder.HasSequence("SEQUENCE_BIEN");
        modelBuilder.HasSequence("SEQUENCE_BIEN_ORIGEN");
        modelBuilder.HasSequence("SEQUENCE_BIEN_PRODUCCION");
        modelBuilder.HasSequence("SEQUENCE_BIEN_PRODUCCION_DETALLE");
        modelBuilder.HasSequence("SEQUENCE_BILLETE");
        modelBuilder.HasSequence("SEQUENCE_CAEA_SIN_MOVIMIENTO_PRESENTACION");
        modelBuilder.HasSequence("SEQUENCE_CAEA_SOLICITADO");
        modelBuilder.HasSequence("SEQUENCE_CALCULO_DEPRECIACION");
        modelBuilder.HasSequence("SEQUENCE_CAMBIO_DE_HORARIO");
        modelBuilder.HasSequence("SEQUENCE_CANTIDAD_ASIGNACION_FOLIO_GV");
        modelBuilder.HasSequence("SEQUENCE_CANTIDAD_COPIA").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_CANTIDAD_FAMILIAR");
        modelBuilder.HasSequence("SEQUENCE_CATEGORIA");
        modelBuilder.HasSequence("SEQUENCE_CATEGORIA_IVA").StartsAt(11L);
        modelBuilder.HasSequence("SEQUENCE_CCAF");
        modelBuilder.HasSequence("SEQUENCE_CERTIFICADO_AFIP");
        modelBuilder.HasSequence("SEQUENCE_CHEQUE_RENDICION");
        modelBuilder.HasSequence("SEQUENCE_CIERRE_Z");
        modelBuilder.HasSequence("SEQUENCE_CLASE_CUENTA").StartsAt(9L);
        modelBuilder.HasSequence("SEQUENCE_CLASE_INDICADOR_CONTABLE");
        modelBuilder.HasSequence("SEQUENCE_CLASE_OPERACION").StartsAt(8L);
        modelBuilder.HasSequence("SEQUENCE_CLASIF_CLIENTES_PERFIL_REMITO");
        modelBuilder.HasSequence("SEQUENCE_CLASIFICACION_ARTICULO").StartsAt(23344L);
        modelBuilder.HasSequence("SEQUENCE_CLASIFICACION_CLIENTE");
        modelBuilder.HasSequence("SEQUENCE_CLASIFICACION_CUENTA_TESORERIA");
        modelBuilder.HasSequence("SEQUENCE_CLASIFICACION_PAIS_AFIP").StartsAt(313L);
        modelBuilder.HasSequence("SEQUENCE_CLASIFICACION_PROVEEDOR");
        modelBuilder.HasSequence("SEQUENCE_CLASIFICACION_SIAP").StartsAt(17L);
        modelBuilder.HasSequence("SEQUENCE_CLIENTE");
        modelBuilder.HasSequence("SEQUENCE_CLIENTE_CM_JURISDICCION");
        modelBuilder.HasSequence("SEQUENCE_CLIENTE_CUENTA_IV");
        modelBuilder.HasSequence("SEQUENCE_CLIENTE_POTENCIAL");
        modelBuilder.HasSequence("SEQUENCE_CODIGO_AFIP_PERCEPCION").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_CODIGO_ITEM_TURISMO").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_CODIGO_RELACION");
        modelBuilder.HasSequence("SEQUENCE_COEFICIENTE_PROMOCION_TARJETA");
        modelBuilder.HasSequence("SEQUENCE_COLECTORA");
        modelBuilder.HasSequence("SEQUENCE_COLECTORA_ENCABEZADO");
        modelBuilder.HasSequence("SEQUENCE_COLECTORA_RENGLON");
        modelBuilder.HasSequence("SEQUENCE_COLECTORA_RENGLON_PARTIDA");
        modelBuilder.HasSequence("SEQUENCE_COLECTORA_RENGLON_SERIE");
        modelBuilder.HasSequence("SEQUENCE_COLUMNA_ASCII_BANCO").StartsAt(229L);
        modelBuilder.HasSequence("SEQUENCE_COLUMNA_ASCII_SU");
        modelBuilder.HasSequence("SEQUENCE_COLUMNA_LISTADOR_SU");
        modelBuilder.HasSequence("SEQUENCE_COLUMNA_MULTITABLA");
        modelBuilder.HasSequence("SEQUENCE_COLUMNA_PREVIRED").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_COMANDA_GVA12_RG_3668");
        modelBuilder.HasSequence("SEQUENCE_COMANDA_VOUCHER");
        modelBuilder.HasSequence("SEQUENCE_COMPENSA_POR_RANGO");
        modelBuilder.HasSequence("SEQUENCE_COMPOSICION_CODIGO");
        modelBuilder.HasSequence("SEQUENCE_COMPOSICION_CODIGO_GRUPO");
        modelBuilder.HasSequence("SEQUENCE_COMPROBANTE_AF");
        modelBuilder.HasSequence("SEQUENCE_COMPROBANTE_CLIENTE_OCASIONAL");
        modelBuilder.HasSequence("SEQUENCE_COMPROBANTE_COTIZACION_AF");
        modelBuilder.HasSequence("SEQUENCE_COMPROBANTE_COTIZACION_SB");
        modelBuilder.HasSequence("SEQUENCE_COMPROBANTE_PROVEEDOR_OCASIONAL");
        modelBuilder.HasSequence("SEQUENCE_COMPROBANTE_TURISMO");
        modelBuilder.HasSequence("SEQUENCE_COMUNA");
        modelBuilder.HasSequence("SEQUENCE_CONCEPTO").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_CONCEPTO_AFIP").StartsAt(106L);
        modelBuilder.HasSequence("SEQUENCE_CONCEPTO_COMPROBANTE_AF");
        modelBuilder.HasSequence("SEQUENCE_CONCEPTO_COMPROBANTE_INTERNO_AF");
        modelBuilder.HasSequence("SEQUENCE_CONCEPTO_CONCILIACION").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CONCEPTO_CP").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_CONCEPTO_DESCUENTO_TARJETA");
        modelBuilder.HasSequence("SEQUENCE_CONCEPTO_INE");
        modelBuilder.HasSequence("SEQUENCE_CONCEPTO_JUSTIFICACION").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_CONCEPTO_PARTICULAR");
        modelBuilder.HasSequence("SEQUENCE_CONDICION_COMPRA").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_CONDICION_LEGAJO_DGI").StartsAt(11L);
        modelBuilder.HasSequence("SEQUENCE_CONFIGURACION_PROCESO").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_CONSOLIDACION_CN");
        modelBuilder.HasSequence("SEQUENCE_CONTRATO_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_CONVENIO");
        modelBuilder.HasSequence("SEQUENCE_COPIAR_EMPRESA");
        modelBuilder.HasSequence("SEQUENCE_COTIZACION_MONEDA").StartsAt(15L);
        modelBuilder.HasSequence("SEQUENCE_CPA_AUDITORIA_BAJA_COMPROBANTE");
        modelBuilder.HasSequence("SEQUENCE_CPA_AUDITORIA_BAJA_DTE");
        modelBuilder.HasSequence("SEQUENCE_CPA_AUTORIZACION_OC");
        modelBuilder.HasSequence("SEQUENCE_CPA_CAMPO_AUTORIZACION").StartsAt(13L);
        modelBuilder.HasSequence("SEQUENCE_CPA_CONCEPTO_AUTORIZACION").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CPA_CONCEPTOS_PROVEEDOR");
        modelBuilder.HasSequence("SEQUENCE_CPA_CONTACTOS_PROVEEDOR_HABITUAL").StartsAt(37L);
        modelBuilder.HasSequence("SEQUENCE_CPA_HISTORIAL_AUTORIZACION_OC");
        modelBuilder.HasSequence("SEQUENCE_CPA_HISTORIAL_CUENTAS_CORRIENTES");
        modelBuilder.HasSequence("SEQUENCE_CPA_PARAMETRO_CONCEPTO_AUTORIZACION_OC").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CPA_PERFIL_AUTORIZACION_OC");
        modelBuilder.HasSequence("SEQUENCE_CPA_PERFIL_AUTORIZACION_OC_COMPRADOR");
        modelBuilder.HasSequence("SEQUENCE_CPA_PERFIL_AUTORIZACION_OC_CONCEPTO");
        modelBuilder.HasSequence("SEQUENCE_CPA_PERFIL_AUTORIZACION_OC_SECTOR");
        modelBuilder.HasSequence("SEQUENCE_CPA_PERFIL_AUTORIZACION_OC_SUCURSALES");
        modelBuilder.HasSequence("SEQUENCE_CPA_PERFIL_AUTORIZACION_OC_USUARIO");
        modelBuilder.HasSequence("SEQUENCE_CPA_PERFIL_OC_CONCEPTO_AUTORIZACION");
        modelBuilder.HasSequence("SEQUENCE_CPA_PROVEEDOR_FOTO");
        modelBuilder.HasSequence("SEQUENCE_CPA01").StartsAt(2416L);
        modelBuilder.HasSequence("SEQUENCE_CPA01_DEFECTO");
        modelBuilder.HasSequence("SEQUENCE_CPA03");
        modelBuilder.HasSequence("SEQUENCE_CPA04");
        modelBuilder.HasSequence("SEQUENCE_CPA04_FCE");
        modelBuilder.HasSequence("SEQUENCE_CPA08");
        modelBuilder.HasSequence("SEQUENCE_CPA108").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_CPA112");
        modelBuilder.HasSequence("SEQUENCE_CPA113");
        modelBuilder.HasSequence("SEQUENCE_CPA131");
        modelBuilder.HasSequence("SEQUENCE_CPA14").StartsAt(15L);
        modelBuilder.HasSequence("SEQUENCE_CPA15").StartsAt(23344L);
        modelBuilder.HasSequence("SEQUENCE_CPA21").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_CPA35");
        modelBuilder.HasSequence("SEQUENCE_CPA36");
        modelBuilder.HasSequence("SEQUENCE_CPA37");
        modelBuilder.HasSequence("SEQUENCE_CPA43").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_CPA45").StartsAt(31L);
        modelBuilder.HasSequence("SEQUENCE_CPA46");
        modelBuilder.HasSequence("SEQUENCE_CPA50").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_CPA51").StartsAt(8L);
        modelBuilder.HasSequence("SEQUENCE_CPA56").StartsAt(12L);
        modelBuilder.HasSequence("SEQUENCE_CPA57").StartsAt(26L);
        modelBuilder.HasSequence("SEQUENCE_CPA70").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_CPA85").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_CPA86").StartsAt(91L);
        modelBuilder.HasSequence("SEQUENCE_CPA87").StartsAt(139L);
        modelBuilder.HasSequence("SEQUENCE_CPA89");
        modelBuilder.HasSequence("SEQUENCE_CPA92");
        modelBuilder.HasSequence("SEQUENCE_CRITERIO_ACTUALIZACION_PRECIOS");
        modelBuilder.HasSequence("SEQUENCE_CRITERIO_ACTUALIZACION_RANGOS");
        modelBuilder.HasSequence("SEQUENCE_CTA_ARTICULO");
        modelBuilder.HasSequence("SEQUENCE_CTA_ARTICULO_COSTO");
        modelBuilder.HasSequence("SEQUENCE_CTA_ARTICULO_DESTINO");
        modelBuilder.HasSequence("SEQUENCE_CTA_ARTICULO_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_ARTICULO_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_ARTICULO_TARJETA_REGALO_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_BANCO");
        modelBuilder.HasSequence("SEQUENCE_CTA_CHEQUE");
        modelBuilder.HasSequence("SEQUENCE_CTA_CIERRE_CAJA");
        modelBuilder.HasSequence("SEQUENCE_CTA_CIERRE_CAJA_TERMINAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_CIERRE_Z");
        modelBuilder.HasSequence("SEQUENCE_CTA_CLASIFICACION_COMPROBANTE");
        modelBuilder.HasSequence("SEQUENCE_CTA_CLIENTE").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_CLIENTE_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMANDA_ASOCIADA");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_ALICUOTAS_RG3685");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_ALICUOTAS_RG3685_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_ALICUOTAS_RG4597");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_ALICUOTAS_RG4597_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_COMPROBANTE_RG3685");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_COMPROBANTE_RG3685_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_COMPROBANTE_RG4597");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_COMPROBANTE_RG4597_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_DTE_CONSOLIDADOS");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_IMPORTACIONES_RG3685");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_IMPORTACIONES_RG3685_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_IMPORTACIONES_RG4597");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_IMPORTACIONES_RG4597_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_TURIVA_RG4597");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPRAS_TURIVA_RG4597_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_COMPROBANTE_DUPLICADOS_COMPRA");
        modelBuilder.HasSequence("SEQUENCE_CTA_CONCEPTO");
        modelBuilder.HasSequence("SEQUENCE_CTA_CONDICION_VENTA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_COSTOS_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_CUENTA_RESTO");
        modelBuilder.HasSequence("SEQUENCE_CTA_CUENTA_RESTO_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_CUENTA_TARJETA_PLAN");
        modelBuilder.HasSequence("SEQUENCE_CTA_CUENTA_TESORERIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_CUENTA_TESORERIA_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_CUOTA_CUPON");
        modelBuilder.HasSequence("SEQUENCE_CTA_CUPON_DESCUENTO");
        modelBuilder.HasSequence("SEQUENCE_CTA_CUPON_TARJETA");
        modelBuilder.HasSequence("SEQUENCE_CTA_DEPOSITO");
        modelBuilder.HasSequence("SEQUENCE_CTA_DEPURACION_TRANSFERENCIA").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_CTA_DETALLE_CAJA");
        modelBuilder.HasSequence("SEQUENCE_CTA_DETALLE_COMANDA");
        modelBuilder.HasSequence("SEQUENCE_CTA_DETALLE_DESPACHO");
        modelBuilder.HasSequence("SEQUENCE_CTA_DETALLE_DEVOLUCION");
        modelBuilder.HasSequence("SEQUENCE_CTA_EMPRESA_TICKET");
        modelBuilder.HasSequence("SEQUENCE_CTA_ENCABEZADO_CAJA");
        modelBuilder.HasSequence("SEQUENCE_CTA_ENCABEZADO_COMANDA");
        modelBuilder.HasSequence("SEQUENCE_CTA_ENCABEZADO_DESPACHO");
        modelBuilder.HasSequence("SEQUENCE_CTA_FOLIO_ALERTA_EMAIL");
        modelBuilder.HasSequence("SEQUENCE_CTA_FOLIO_ASIGNADO");
        modelBuilder.HasSequence("SEQUENCE_CTA_FOLIO_SOLICITADO");
        modelBuilder.HasSequence("SEQUENCE_CTA_GASTO_FIJO_CUPON");
        modelBuilder.HasSequence("SEQUENCE_CTA_GRUPO_EMPRESARIO");
        modelBuilder.HasSequence("SEQUENCE_CTA_HORARIO");
        modelBuilder.HasSequence("SEQUENCE_CTA_IEC_CONSOLIDADO");
        modelBuilder.HasSequence("SEQUENCE_CTA_IEV_CONSOLIDADO");
        modelBuilder.HasSequence("SEQUENCE_CTA_LISTA_COMPRA_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_LISTA_PRECIOS_VENTA");
        modelBuilder.HasSequence("SEQUENCE_CTA_LISTA_VENTA_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_MEDIDA").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_CTA_MEDIO_DE_PAGO").StartsAt(9L);
        modelBuilder.HasSequence("SEQUENCE_CTA_MONEDA");
        modelBuilder.HasSequence("SEQUENCE_CTA_MOTIVO_DE_INVITACION").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_MOTIVO_DEVOLUCION").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_MOZO").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_MOZO_RESTO_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_NOTA_CREDITO_POR_TARJETA_REGALO");
        modelBuilder.HasSequence("SEQUENCE_CTA_NOTA_CREDITO_PROMOCION_TARJETA_RESUMEN");
        modelBuilder.HasSequence("SEQUENCE_CTA_PAIS").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_CTA_PARAMETRO_TRANSFERENCIA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_PARAMETRO_TRANSFERENCIA_FOLIO");
        modelBuilder.HasSequence("SEQUENCE_CTA_PARAMETRO_TRANSFERENCIA_MAESTRO").StartsAt(14L);
        modelBuilder.HasSequence("SEQUENCE_CTA_PLAN_TARJETA");
        modelBuilder.HasSequence("SEQUENCE_CTA_POLITICA_PROMOCION");
        modelBuilder.HasSequence("SEQUENCE_CTA_POLITICA_PROMOCION_SUCURSAL_DESTINO");
        modelBuilder.HasSequence("SEQUENCE_CTA_PROMOCION_FACTURA");
        modelBuilder.HasSequence("SEQUENCE_CTA_PROMOCION_TARJETA");
        modelBuilder.HasSequence("SEQUENCE_CTA_PROMOCION_TARJETA_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_PROVEEDOR_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_PROVINCIA").StartsAt(26L);
        modelBuilder.HasSequence("SEQUENCE_CTA_PUESTO_CAJA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_PUESTO_RESTO_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_RELACION_COMPROBANTES_IEC_CONSOLIDADO");
        modelBuilder.HasSequence("SEQUENCE_CTA_RELACION_COMPROBANTES_IEV_CONSOLIDADO");
        modelBuilder.HasSequence("SEQUENCE_CTA_RELACION_DTES_CONSUMO_FOLIOS");
        modelBuilder.HasSequence("SEQUENCE_CTA_RELACION_DTES_RESUMEN_VENTAS_DIARIAS");
        modelBuilder.HasSequence("SEQUENCE_CTA_REPARTIDOR").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_CTA_REPARTIDOR_RESTO_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_REPORTE_FISCAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_REPORTES_CONSUMO_FOLIOS");
        modelBuilder.HasSequence("SEQUENCE_CTA_RESUMEN_CIERRE_CAJA");
        modelBuilder.HasSequence("SEQUENCE_CTA_RESUMEN_VENTAS_DIARIAS");
        modelBuilder.HasSequence("SEQUENCE_CTA_RUBRO_COMERCIAL").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_SALDO_ARTICULO_DEPOSITO");
        modelBuilder.HasSequence("SEQUENCE_CTA_SALDO_ARTICULO_DEPOSITO_PARTIDA");
        modelBuilder.HasSequence("SEQUENCE_CTA_SALDO_CLIENTE");
        modelBuilder.HasSequence("SEQUENCE_CTA_SALDO_CUENTA_RESTO");
        modelBuilder.HasSequence("SEQUENCE_CTA_SALDO_CUENTA_TESORERIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_SALDO_PROVEEDOR");
        modelBuilder.HasSequence("SEQUENCE_CTA_SECTOR").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_SECTOR_RESTO_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA_SEPARADOR").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_STOCK_RENGLON_PARTIDA");
        modelBuilder.HasSequence("SEQUENCE_CTA_STOCK_RENGLON_SERIE");
        modelBuilder.HasSequence("SEQUENCE_CTA_TARJETA");
        modelBuilder.HasSequence("SEQUENCE_CTA_TARJETA_TESORERIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_TICKET_RESTAURANTE");
        modelBuilder.HasSequence("SEQUENCE_CTA_TIPO_ASIENTO");
        modelBuilder.HasSequence("SEQUENCE_CTA_TIPO_COMPROBANTE").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_CTA_TIPO_PROMOCION");
        modelBuilder.HasSequence("SEQUENCE_CTA_TIPO_TURNO").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_TOPES_STOCK_ARTICULO");
        modelBuilder.HasSequence("SEQUENCE_CTA_TRANSPORTE");
        modelBuilder.HasSequence("SEQUENCE_CTA_USUARIO").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_VENDEDOR").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_ALICUOTAS_RG3685");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_ALICUOTAS_RG3685_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_ALICUOTAS_RG4597");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_ALICUOTAS_RG4597_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_ALICUOTAS_TURIVA_RG4597");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_ALICUOTAS_TURIVA_RG4597_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_ANULADOS_RG4597");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_ANULADOS_RG4597_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_COMPROBANTE_RG3685");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_COMPROBANTE_RG3685_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_COMPROBANTE_RG4597");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_COMPROBANTE_RG4597_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_TURIVA_RG4597");
        modelBuilder.HasSequence("SEQUENCE_CTA_VENTAS_TURIVA_RG4597_TRANSFERENCIA");
        modelBuilder.HasSequence("SEQUENCE_CTA_ZONA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_CTA_ZONA_RESTO_POR_SUCURSAL");
        modelBuilder.HasSequence("SEQUENCE_CTA02_FCE");
        modelBuilder.HasSequence("SEQUENCE_CTA05_FCE");
        modelBuilder.HasSequence("SEQUENCE_CUENTA").StartsAt(449L);
        modelBuilder.HasSequence("SEQUENCE_CUENTA_AJUSTABLE");
        modelBuilder.HasSequence("SEQUENCE_CUENTA_BANCARIA");
        modelBuilder.HasSequence("SEQUENCE_CUENTA_CONVERTIBLE");
        modelBuilder.HasSequence("SEQUENCE_CUENTA_COTIZABLE");
        modelBuilder.HasSequence("SEQUENCE_CUENTA_DEFECTO_MODELO_ASIENTO_SUELDOS");
        modelBuilder.HasSequence("SEQUENCE_CUENTA_NEXO_COBRANZAS_CONTADO").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_CUENTA_PUESTO_CAJA");
        modelBuilder.HasSequence("SEQUENCE_CUENTA_SB").StartsAt(94L);
        modelBuilder.HasSequence("SEQUENCE_CUENTA_TARJETA_PLAN").StartsAt(15L);
        modelBuilder.HasSequence("SEQUENCE_CUENTA_TIPO_AUXILIAR");
        modelBuilder.HasSequence("SEQUENCE_CUIT_PAIS_AFIP").StartsAt(260L);
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_AFJP");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_ART");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_ASIENTO_ANALITICO_CN");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_ASIENTO_RESUMEN_CN");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_BANCO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_BIEN");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_CATEGORIA");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_CCAF");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_COMPROBANTE_AF");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_CONTRATO_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_CONVENIO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_CPA01");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_CPA04");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_CPA110");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_CPA35");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_CPA65");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_CUENTA");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_DATO_FIJO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_DEPARTAMENTO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_EJERCICIO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_EMBARGO_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_EMPRESA");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_EX_CAJA");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_FAMILIAR");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_FORMATO_RENDICION");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_GRUPO_JERARQUICO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_GVA01");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_GVA12");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_GVA14");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_IDENTIFICACION_ADICIONAL");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_IVA_CLIENTE");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_IVA_COMPROBANTE");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_IVA_PROVEEDOR");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_JERARQUIA");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_LUGAR_TRABAJO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_MATRIZ");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_MATRIZ_SUELDO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_MODELO_ASIENTO_SU");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_MODIFICACION_GANANCIAS_A_RETENER");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_MULTITABLA");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_OBRA_SOCIAL");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_ORGANISMO_APV");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_PERIODO_MULTITABLA");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_PRESUPUESTO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_REGLA_APROPIACION");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_RESPONSABLE");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_RUBRO_BIEN");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_SBA04");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_SERVICIO_EVENTUAL");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_SINDICATO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_STA11");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_TABLA");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_TIPO_BIEN");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_TIPO_CONTRATO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_TRABAJO_PESADO");
        modelBuilder.HasSequence("SEQUENCE_DATO_ADJUNTO_UBICACION_BIEN");
        modelBuilder.HasSequence("SEQUENCE_DATO_FIJO");
        modelBuilder.HasSequence("SEQUENCE_DATO_LOCADOR");
        modelBuilder.HasSequence("SEQUENCE_DATO_TURISTA");
        modelBuilder.HasSequence("SEQUENCE_DEF_COMPENSA_POR_RANGO");
        modelBuilder.HasSequence("SEQUENCE_DEFECTO_ARTICULO_CUENTA");
        modelBuilder.HasSequence("SEQUENCE_DEFECTO_CLIENTE_CUENTA");
        modelBuilder.HasSequence("SEQUENCE_DEFECTO_CONCEPTO_PARTICULAR");
        modelBuilder.HasSequence("SEQUENCE_DEFECTO_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_DEFECTO_LEGAJO_NOVEDAD");
        modelBuilder.HasSequence("SEQUENCE_DEFECTO_LEGAJO_TELEFONO");
        modelBuilder.HasSequence("SEQUENCE_DEFINICION_ASCII_SU");
        modelBuilder.HasSequence("SEQUENCE_DEPARTAMENTO").StartsAt(8L);
        modelBuilder.HasSequence("SEQUENCE_DETALLE_ALICUOTA_IVA").StartsAt(23L);
        modelBuilder.HasSequence("SEQUENCE_DETALLE_CONCEPTO_RETENCION");
        modelBuilder.HasSequence("SEQUENCE_DETALLE_DEPOSITO");
        modelBuilder.HasSequence("SEQUENCE_DETALLE_EXTRACTO");
        modelBuilder.HasSequence("SEQUENCE_DETALLE_EXTRACTO_MOVIMIENTO");
        modelBuilder.HasSequence("SEQUENCE_DETALLE_FAMILIAR_GCIA");
        modelBuilder.HasSequence("SEQUENCE_DETALLE_LICENCIA");
        modelBuilder.HasSequence("SEQUENCE_DETALLE_PAGO_GENERAL_GCIA");
        modelBuilder.HasSequence("SEQUENCE_DIA_HABIL");
        modelBuilder.HasSequence("SEQUENCE_DIAS_BASE").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_DIRECCION_ENTREGA").StartsAt(65190L);
        modelBuilder.HasSequence("SEQUENCE_DISMINUCION_GCIA").StartsAt(781L);
        modelBuilder.HasSequence("SEQUENCE_DOC_NACIONAL").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_DOC_PROVINCIAL").StartsAt(25L);
        modelBuilder.HasSequence("SEQUENCE_DOCUMENTO_RENDICION");
        modelBuilder.HasSequence("SEQUENCE_EJERCICIO");
        modelBuilder.HasSequence("SEQUENCE_EMBARGO_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_EMBARGO_LEGAJO_RETENCION");
        modelBuilder.HasSequence("SEQUENCE_EMPRESA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_EMPRESA_ACTIVIDAD_SECUNDARIA").StartsAt(8L);
        modelBuilder.HasSequence("SEQUENCE_EMPRESA_TELEFONO");
        modelBuilder.HasSequence("SEQUENCE_EMPRESA_TELEFONO_LEGAL");
        modelBuilder.HasSequence("SEQUENCE_ENCABEZADO_EXTRACTO");
        modelBuilder.HasSequence("SEQUENCE_ENCABEZADO_LISTADOR_SU");
        modelBuilder.HasSequence("SEQUENCE_EQUIVALENCIA_LISTADOR_SU");
        modelBuilder.HasSequence("SEQUENCE_ESTADO_BIEN");
        modelBuilder.HasSequence("SEQUENCE_ESTADO_COMPROBANTE_FCE").StartsAt(8L);
        modelBuilder.HasSequence("SEQUENCE_ESTADO_CTACTE_FCE").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_ESTADO_ORDEN_COMPRA").StartsAt(12L);
        modelBuilder.HasSequence("SEQUENCE_ETIQUETA");
        modelBuilder.HasSequence("SEQUENCE_EX_CAJA");
        modelBuilder.HasSequence("SEQUENCE_EXCEPCION_RG3668_AFIP").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_FAMILIAR");
        modelBuilder.HasSequence("SEQUENCE_FERIADO");
        modelBuilder.HasSequence("SEQUENCE_FICHADA");
        modelBuilder.HasSequence("SEQUENCE_FICHADA_INVALIDA");
        modelBuilder.HasSequence("SEQUENCE_FICHADA_MANUAL");
        modelBuilder.HasSequence("SEQUENCE_FICHADA_RELOJ");
        modelBuilder.HasSequence("SEQUENCE_FICHADOR");
        modelBuilder.HasSequence("SEQUENCE_FILA_MULTITABLA");
        modelBuilder.HasSequence("SEQUENCE_FILA_TABLA");
        modelBuilder.HasSequence("SEQUENCE_FILLER");
        modelBuilder.HasSequence("SEQUENCE_FOLIO_A_UTILIZAR");
        modelBuilder.HasSequence("SEQUENCE_FOLIO_ALERTA_EMAIL");
        modelBuilder.HasSequence("SEQUENCE_FOLIO_DESCARGADO");
        modelBuilder.HasSequence("SEQUENCE_FORMA_COBRO").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_FORMATO_RENDICION");
        modelBuilder.HasSequence("SEQUENCE_FORMULA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_FUNCION");
        modelBuilder.HasSequence("SEQUENCE_GASTO_FIJO").StartsAt(8L);
        modelBuilder.HasSequence("SEQUENCE_GASTO_FIJO_RESUMEN");
        modelBuilder.HasSequence("SEQUENCE_GASTO_FIJO_TARJETA").StartsAt(64L);
        modelBuilder.HasSequence("SEQUENCE_GRUPO");
        modelBuilder.HasSequence("SEQUENCE_GRUPO_DEFECTO");
        modelBuilder.HasSequence("SEQUENCE_GRUPO_JERARQUICO");
        modelBuilder.HasSequence("SEQUENCE_GRUPO_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_GRUPO_NOVEDAD");
        modelBuilder.HasSequence("SEQUENCE_GVA_AUDITORIA_BAJA_COMPROBANTES");
        modelBuilder.HasSequence("SEQUENCE_GVA_CLIENTE_FOTO");
        modelBuilder.HasSequence("SEQUENCE_GVA_PARAMETROS_PEDIDOS_TIENDAS");
        modelBuilder.HasSequence("SEQUENCE_GVA_PARAMETROS_PEDIDOS_TIENDAS_COBRO");
        modelBuilder.HasSequence("SEQUENCE_GVA_PARAMETROS_PEDIDOS_TIENDAS_TALONARIO_FACTURA");
        modelBuilder.HasSequence("SEQUENCE_GVA01").StartsAt(32L);
        modelBuilder.HasSequence("SEQUENCE_GVA05").StartsAt(10L);
        modelBuilder.HasSequence("SEQUENCE_GVA10").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_GVA10_PARAMETROS_AUTOMATIZACION").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_GVA11");
        modelBuilder.HasSequence("SEQUENCE_GVA111").StartsAt(2472L);
        modelBuilder.HasSequence("SEQUENCE_GVA117");
        modelBuilder.HasSequence("SEQUENCE_GVA118");
        modelBuilder.HasSequence("SEQUENCE_GVA12_FCE");
        modelBuilder.HasSequence("SEQUENCE_GVA12_JSON");
        modelBuilder.HasSequence("SEQUENCE_GVA12_RG_3668");
        modelBuilder.HasSequence("SEQUENCE_GVA125").StartsAt(7340L);
        modelBuilder.HasSequence("SEQUENCE_GVA12DE_OBSERVACIONES_AFIP");
        modelBuilder.HasSequence("SEQUENCE_GVA12DE_PDF");
        modelBuilder.HasSequence("SEQUENCE_GVA12DE_REFERENCIA_BOLETA");
        modelBuilder.HasSequence("SEQUENCE_GVA12DE_TICKET_ESPECTACULO");
        modelBuilder.HasSequence("SEQUENCE_GVA13");
        modelBuilder.HasSequence("SEQUENCE_GVA133").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_GVA14").StartsAt(65190L);
        modelBuilder.HasSequence("SEQUENCE_GVA14_DEFECTO");
        modelBuilder.HasSequence("SEQUENCE_GVA144").StartsAt(17585L);
        modelBuilder.HasSequence("SEQUENCE_GVA144_DEFECTO");
        modelBuilder.HasSequence("SEQUENCE_GVA147").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_GVA148").StartsAt(220L);
        modelBuilder.HasSequence("SEQUENCE_GVA149").StartsAt(9L);
        modelBuilder.HasSequence("SEQUENCE_GVA14ITC_DEFECTO");
        modelBuilder.HasSequence("SEQUENCE_GVA15").StartsAt(9L);
        modelBuilder.HasSequence("SEQUENCE_GVA150").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_GVA151").StartsAt(119L);
        modelBuilder.HasSequence("SEQUENCE_GVA17").StartsAt(68886L);
        modelBuilder.HasSequence("SEQUENCE_GVA18").StartsAt(27L);
        modelBuilder.HasSequence("SEQUENCE_GVA22").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_GVA23").StartsAt(28L);
        modelBuilder.HasSequence("SEQUENCE_GVA24").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_GVA27");
        modelBuilder.HasSequence("SEQUENCE_GVA41").StartsAt(11L);
        modelBuilder.HasSequence("SEQUENCE_GVA62");
        modelBuilder.HasSequence("SEQUENCE_GVA66");
        modelBuilder.HasSequence("SEQUENCE_GVA75");
        modelBuilder.HasSequence("SEQUENCE_GVA76");
        modelBuilder.HasSequence("SEQUENCE_GVA78").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_GVA79").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_GVA80").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_GVA81");
        modelBuilder.HasSequence("SEQUENCE_GVA85");
        modelBuilder.HasSequence("SEQUENCE_HISTORIAL");
        modelBuilder.HasSequence("SEQUENCE_HISTORIAL_CUENTAS_CORRIENTES");
        modelBuilder.HasSequence("SEQUENCE_HISTORIAL_EXPORTACION_ENTIDAD");
        modelBuilder.HasSequence("SEQUENCE_HISTORIAL_ITEM_COSTO_LABORAL");
        modelBuilder.HasSequence("SEQUENCE_HISTORIAL_ITEM_SUELDO");
        modelBuilder.HasSequence("SEQUENCE_HISTORIAL_RENDICION");
        modelBuilder.HasSequence("SEQUENCE_HORA_COMPENSADA");
        modelBuilder.HasSequence("SEQUENCE_HORA_NO_TRABAJADA");
        modelBuilder.HasSequence("SEQUENCE_HORA_REAL_NO_TRAB");
        modelBuilder.HasSequence("SEQUENCE_HORARIO");
        modelBuilder.HasSequence("SEQUENCE_HOST").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_IDENTIFICACION_ADICIONAL");
        modelBuilder.HasSequence("SEQUENCE_INCAPACIDAD_LEGAJO_DGI").StartsAt(14L);
        modelBuilder.HasSequence("SEQUENCE_INCREMENTO_DEDUCCION_ESPECIAL_FIJA").StartsAt(972L);
        modelBuilder.HasSequence("SEQUENCE_INDICADOR_CONTABLE");
        modelBuilder.HasSequence("SEQUENCE_INDICE");
        modelBuilder.HasSequence("SEQUENCE_INDICE_VALOR");
        modelBuilder.HasSequence("SEQUENCE_INGRESO_EGRESO");
        modelBuilder.HasSequence("SEQUENCE_INTERES_POR_MORA").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_ITEM_COSTO_LABORAL").StartsAt(15L);
        modelBuilder.HasSequence("SEQUENCE_ITEM_SUELDO");
        modelBuilder.HasSequence("SEQUENCE_IVA_ACTIVIDAD_IB");
        modelBuilder.HasSequence("SEQUENCE_IVA_AJUSTE_BASE_IMPONIBLE");
        modelBuilder.HasSequence("SEQUENCE_IVA_ALICUOTA_IB");
        modelBuilder.HasSequence("SEQUENCE_IVA_APROPIACION_MODELO_INGRESO");
        modelBuilder.HasSequence("SEQUENCE_IVA_BASE_IMPONIBLE").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_IVA_CATEGORIA_REPORTE").StartsAt(101L);
        modelBuilder.HasSequence("SEQUENCE_IVA_CLASIFICACION_CITI").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_IVA_CLASIFICACION_CITI_FORMULA");
        modelBuilder.HasSequence("SEQUENCE_IVA_CLASIFICACION_CITI_VENTAS").StartsAt(12L);
        modelBuilder.HasSequence("SEQUENCE_IVA_CLASIFICACION_SIAP").StartsAt(20L);
        modelBuilder.HasSequence("SEQUENCE_IVA_CLASIFICACION_SIAP_COMPROBANTE");
        modelBuilder.HasSequence("SEQUENCE_IVA_CLASIFICACION_SICORE");
        modelBuilder.HasSequence("SEQUENCE_IVA_CLASIFICACION_SIFERE").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_IVA_CLIENTE").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_IVA_COEFICIENTE_UNIFICADO");
        modelBuilder.HasSequence("SEQUENCE_IVA_COLUMNA_ASCII");
        modelBuilder.HasSequence("SEQUENCE_IVA_COLUMNA_REPORTE").StartsAt(1858L);
        modelBuilder.HasSequence("SEQUENCE_IVA_COMPORTAMIENTO").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_IVA_COMPROBANTE");
        modelBuilder.HasSequence("SEQUENCE_IVA_COMPROBANTE_IB");
        modelBuilder.HasSequence("SEQUENCE_IVA_DEFINICION_ASCII");
        modelBuilder.HasSequence("SEQUENCE_IVA_DETALLE_IB_COMPROBANTE");
        modelBuilder.HasSequence("SEQUENCE_IVA_DETALLE_LETRA_TIPO_COMPROBANTE");
        modelBuilder.HasSequence("SEQUENCE_IVA_EQUIVALENCIA_REPORTE");
        modelBuilder.HasSequence("SEQUENCE_IVA_FORMULA").StartsAt(298L);
        modelBuilder.HasSequence("SEQUENCE_IVA_FORMULA_FORMULARIO").StartsAt(2392L);
        modelBuilder.HasSequence("SEQUENCE_IVA_FORMULARIO").StartsAt(13L);
        modelBuilder.HasSequence("SEQUENCE_IVA_IMPORTACION_TXT_PARAMETRO");
        modelBuilder.HasSequence("SEQUENCE_IVA_IMPORTACION_TXT_TIPO_IMPORTE");
        modelBuilder.HasSequence("SEQUENCE_IVA_IMPORTE_AUXILIAR_FIJO");
        modelBuilder.HasSequence("SEQUENCE_IVA_IMPORTE_AUXILIAR_MODIFICABLE").StartsAt(19L);
        modelBuilder.HasSequence("SEQUENCE_IVA_IMPORTE_AUXILIAR_MODIFICABLE_DETALLE");
        modelBuilder.HasSequence("SEQUENCE_IVA_IMPORTE_DEPOSITADO_IB");
        modelBuilder.HasSequence("SEQUENCE_IVA_IMPORTE_DEPOSITADO_SALDO");
        modelBuilder.HasSequence("SEQUENCE_IVA_LETRA_REPORTE").StartsAt(24L);
        modelBuilder.HasSequence("SEQUENCE_IVA_MODELO_INGRESO").StartsAt(37L);
        modelBuilder.HasSequence("SEQUENCE_IVA_OCASIONAL_COMPROBANTE");
        modelBuilder.HasSequence("SEQUENCE_IVA_OPERACION_CITI").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_IVA_ORIGEN_CUENTA").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_IVA_PARAMETRO").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_IVA_PROVEEDOR").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_IVA_RELACION_ACTIVIDAD_IB");
        modelBuilder.HasSequence("SEQUENCE_IVA_RELACION_CONCEPTO_CP");
        modelBuilder.HasSequence("SEQUENCE_IVA_RELACION_CONCEPTO_GV");
        modelBuilder.HasSequence("SEQUENCE_IVA_RELACION_PROVINCIA_CP");
        modelBuilder.HasSequence("SEQUENCE_IVA_RELACION_PROVINCIA_GV");
        modelBuilder.HasSequence("SEQUENCE_IVA_RELACION_TIPO_COMP_CP");
        modelBuilder.HasSequence("SEQUENCE_IVA_RELACION_TIPO_COMP_GV").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_IVA_RENGLON_COMPROBANTE");
        modelBuilder.HasSequence("SEQUENCE_IVA_RENGLON_MODELO_INGRESO").StartsAt(977L);
        modelBuilder.HasSequence("SEQUENCE_IVA_REPORTE").StartsAt(12L);
        modelBuilder.HasSequence("SEQUENCE_IVA_RESULTADO_REPORTE").StartsAt(29L);
        modelBuilder.HasSequence("SEQUENCE_IVA_RG3685_FORMULA");
        modelBuilder.HasSequence("SEQUENCE_IVA_SECCION_ASCII");
        modelBuilder.HasSequence("SEQUENCE_IVA_SUJETO_VINCULADO_FORMULA");
        modelBuilder.HasSequence("SEQUENCE_IVA_TIPO_COMPROBANTE").StartsAt(18L);
        modelBuilder.HasSequence("SEQUENCE_IVA_TIPO_COMPROBANTE_AFIP").StartsAt(27L);
        modelBuilder.HasSequence("SEQUENCE_IVA_TIPO_COMPROBANTE_IB").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_IVA_TIPO_COMPROBANTE_REPORTE").StartsAt(173L);
        modelBuilder.HasSequence("SEQUENCE_IVA_TIPO_DOCUMENTO").StartsAt(39L);
        modelBuilder.HasSequence("SEQUENCE_IVA_TIPO_FORMULA").StartsAt(19L);
        modelBuilder.HasSequence("SEQUENCE_IVA_TIPO_IMPORTE_RG3685").StartsAt(22L);
        modelBuilder.HasSequence("SEQUENCE_IVA_TIPO_IMPORTE_SUJETO_VINCULADO").StartsAt(8L);
        modelBuilder.HasSequence("SEQUENCE_IVA_VALOR_EQUIVALENCIA_REPORTE");
        modelBuilder.HasSequence("SEQUENCE_JERARQUIA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_JURISDICCION");
        modelBuilder.HasSequence("SEQUENCE_JUZGADO_DGI").StartsAt(875L);
        modelBuilder.HasSequence("SEQUENCE_LAYOUT_CAMPOS_ADICIONALES").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_LEGAJO_CLOUD_FILTER");
        modelBuilder.HasSequence("SEQUENCE_LEGAJO_CONTABLE_HABITUAL");
        modelBuilder.HasSequence("SEQUENCE_LEGAJO_CONTABLE_OCASIONAL");
        modelBuilder.HasSequence("SEQUENCE_LEGAJO_FOTO");
        modelBuilder.HasSequence("SEQUENCE_LEGAJO_NOVEDAD");
        modelBuilder.HasSequence("SEQUENCE_LEGAJO_SU_COSTO_LABORAL");
        modelBuilder.HasSequence("SEQUENCE_LEGAJO_SU_CUENTA_BANCARIA");
        modelBuilder.HasSequence("SEQUENCE_LEGAJO_SU_ITEM_SUELDO");
        modelBuilder.HasSequence("SEQUENCE_LEGAJO_TELEFONO");
        modelBuilder.HasSequence("SEQUENCE_LEYENDA_ENCABEZADO").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_LEYENDA_ENCABEZADO_TIPO_ASIENTO").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_LEYENDA_MOVIMIENTO");
        modelBuilder.HasSequence("SEQUENCE_LEYENDA_MOVIMIENTO_CUENTA");
        modelBuilder.HasSequence("SEQUENCE_LIBRO_BOLETAS_ELECTRONICAS");
        modelBuilder.HasSequence("SEQUENCE_LIBRO_SUELDOS_DIGITAL_REGISTRO_01");
        modelBuilder.HasSequence("SEQUENCE_LIBRO_SUELDOS_DIGITAL_REGISTRO_02");
        modelBuilder.HasSequence("SEQUENCE_LIBRO_SUELDOS_DIGITAL_REGISTRO_03");
        modelBuilder.HasSequence("SEQUENCE_LIBRO_SUELDOS_DIGITAL_REGISTRO_04");
        modelBuilder.HasSequence("SEQUENCE_LIBRO_SUELDOS_DIGITAL_REGISTRO_05");
        modelBuilder.HasSequence("SEQUENCE_LISTADOR_SU");
        modelBuilder.HasSequence("SEQUENCE_LOCALIDAD_DGI").StartsAt(11048L);
        modelBuilder.HasSequence("SEQUENCE_LOTE_CN_GENERADO");
        modelBuilder.HasSequence("SEQUENCE_LOTE_CN_RECIBIDO");
        modelBuilder.HasSequence("SEQUENCE_LOTE_NOVEDAD");
        modelBuilder.HasSequence("SEQUENCE_LUGAR_TRABAJO");
        modelBuilder.HasSequence("SEQUENCE_MAESTRO_ACUMULADO_DEFINIBLE");
        modelBuilder.HasSequence("SEQUENCE_MAESTRO_CUENTA_TIPO_AUXILIAR");
        modelBuilder.HasSequence("SEQUENCE_MAESTRO_DISMINUCION_GCIA").StartsAt(133L);
        modelBuilder.HasSequence("SEQUENCE_MAESTRO_GVA17");
        modelBuilder.HasSequence("SEQUENCE_MAESTRO_TRAMO_GCIA").StartsAt(133L);
        modelBuilder.HasSequence("SEQUENCE_MATRIZ");
        modelBuilder.HasSequence("SEQUENCE_MATRIZ_SUELDO");
        modelBuilder.HasSequence("SEQUENCE_MEDIDA").StartsAt(9L);
        modelBuilder.HasSequence("SEQUENCE_MEDIO_PAGO_SPS").StartsAt(30L);
        modelBuilder.HasSequence("SEQUENCE_METODO_DEPRECIACION");
        modelBuilder.HasSequence("SEQUENCE_METODO_SAC_GANANCIAS").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_MODELO_ASIENTO_SU");
        modelBuilder.HasSequence("SEQUENCE_MODELO_INGRESO_SB").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_MODELO_INGRESO_SB_COTIZ_EXTR");
        modelBuilder.HasSequence("SEQUENCE_MODELO_INGRESO_SB_CUENTAS").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_MODELO_INGRESO_SB_USUARIO").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_MODELO_INTEG_SU");
        modelBuilder.HasSequence("SEQUENCE_MODELO_RELOJ").StartsAt(9L);
        modelBuilder.HasSequence("SEQUENCE_MODIFICACION_GANANCIAS_A_RETENER");
        modelBuilder.HasSequence("SEQUENCE_MODULO_AGRUPACION");
        modelBuilder.HasSequence("SEQUENCE_MODULO_CUENTA").StartsAt(3281L);
        modelBuilder.HasSequence("SEQUENCE_MODULO_FERIADO");
        modelBuilder.HasSequence("SEQUENCE_MODULO_MEDIDA").StartsAt(41L);
        modelBuilder.HasSequence("SEQUENCE_MODULO_NOVEDAD");
        modelBuilder.HasSequence("SEQUENCE_MODULO_REGLA_APROPIACION");
        modelBuilder.HasSequence("SEQUENCE_MODULO_TIPO_ASIENTO").StartsAt(137L);
        modelBuilder.HasSequence("SEQUENCE_MONEDA").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_MOPRE").StartsAt(15L);
        modelBuilder.HasSequence("SEQUENCE_MOTIVO_EGRESO");
        modelBuilder.HasSequence("SEQUENCE_MOTIVO_EGRESO_CONCEPTO");
        modelBuilder.HasSequence("SEQUENCE_MOTIVO_FICHADA_MANUAL");
        modelBuilder.HasSequence("SEQUENCE_MOTIVO_NOTA_CREDITO");
        modelBuilder.HasSequence("SEQUENCE_MOTIVO_OTRAS_DEDUCCIONES").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_MULTITABLA");
        modelBuilder.HasSequence("SEQUENCE_MULTITABLA_COMPONENTE");
        modelBuilder.HasSequence("SEQUENCE_NACIONALIDAD").StartsAt(57L);
        modelBuilder.HasSequence("SEQUENCE_NEXO_COBRANZAS_COMP_VENC_PAGO");
        modelBuilder.HasSequence("SEQUENCE_NEXO_COBRANZAS_COMPROBANTE");
        modelBuilder.HasSequence("SEQUENCE_NEXO_COBRANZAS_PAGO");
        modelBuilder.HasSequence("SEQUENCE_NEXO_COBRANZAS_VENCIMIENTO");
        modelBuilder.HasSequence("SEQUENCE_NEXO_MEDIOS_PAGO_TIENDA").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_CLIENTES");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_COMPRADORES");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_COMPROBANTES");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_DIRECCIONES");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_ETIQUETA");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_HISTORIAL");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_ORDEN");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_PAGO");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_PAQUETES");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_PROMOCION");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_RELACION_FACTURA");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_RELACION_REMITO");
        modelBuilder.HasSequence("SEQUENCE_NEXO_PEDIDOS_RENGLON_ORDEN");
        modelBuilder.HasSequence("SEQUENCE_NEXO_RELACION_ARTICULO_TIENDA");
        modelBuilder.HasSequence("SEQUENCE_NEXO_RELACION_CLIENTE_TIENDA");
        modelBuilder.HasSequence("SEQUENCE_NIVEL_ESTUDIO_DGI").StartsAt(21L);
        modelBuilder.HasSequence("SEQUENCE_NOTA_CREDITO_POR_TARJETA_REGALO");
        modelBuilder.HasSequence("SEQUENCE_NOTA_CREDITO_PROMOCION_TARJETA_RESUMEN");
        modelBuilder.HasSequence("SEQUENCE_NOTA_TIENDA");
        modelBuilder.HasSequence("SEQUENCE_NOVEDAD");
        modelBuilder.HasSequence("SEQUENCE_NOVEDAD_COMPONENTE");
        modelBuilder.HasSequence("SEQUENCE_NOVEDAD_GRUPO");
        modelBuilder.HasSequence("SEQUENCE_NOVEDAD_REGISTRADA");
        modelBuilder.HasSequence("SEQUENCE_OBRA_SOCIAL");
        modelBuilder.HasSequence("SEQUENCE_OBRA_SOCIAL_DGI").StartsAt(437L);
        modelBuilder.HasSequence("SEQUENCE_OPERACION_AFIP").StartsAt(17L);
        modelBuilder.HasSequence("SEQUENCE_ORGANISMO_APV");
        modelBuilder.HasSequence("SEQUENCE_ORGANISMO_GCIA");
        modelBuilder.HasSequence("SEQUENCE_ORIGEN_EXPORTACION").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_OTRO_EMPLEO_GCIA");
        modelBuilder.HasSequence("SEQUENCE_PADRON_RENTAS_BSAS");
        modelBuilder.HasSequence("SEQUENCE_PADRON_RENTAS_BSAS_VIGENCIA");
        modelBuilder.HasSequence("SEQUENCE_PADRON_RENTAS_EXENTOS_AGIP");
        modelBuilder.HasSequence("SEQUENCE_PADRON_RENTAS_EXENTOS_AGIP_VIGENCIA");
        modelBuilder.HasSequence("SEQUENCE_PADRON_RENTAS_REGIMEN_GENERAL_AGIP");
        modelBuilder.HasSequence("SEQUENCE_PADRON_RENTAS_REGIMEN_GENERAL_AGIP_VIGENCIA");
        modelBuilder.HasSequence("SEQUENCE_PAGO_A_CUENTA_GANANCIAS");
        modelBuilder.HasSequence("SEQUENCE_PAGO_GENERAL_GCIA");
        modelBuilder.HasSequence("SEQUENCE_PAIS").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PAIS_AFIP").StartsAt(300L);
        modelBuilder.HasSequence("SEQUENCE_PAPEL_TRABAJO");
        modelBuilder.HasSequence("SEQUENCE_PAPEL_TRABAJO_COLUMNA");
        modelBuilder.HasSequence("SEQUENCE_PAPEL_TRABAJO_COLUMNA_DEFECTO").StartsAt(21L);
        modelBuilder.HasSequence("SEQUENCE_PAPEL_TRABAJO_DEFECTO").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_PAPEL_TRABAJO_RUBRO");
        modelBuilder.HasSequence("SEQUENCE_PAPEL_TRABAJO_RUBRO_ASIGNADO");
        modelBuilder.HasSequence("SEQUENCE_PAPEL_TRABAJO_RUBRO_DEFECTO").StartsAt(120L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_AF").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_ASCII_BANCO").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_ASIGNACION_FOLIO_CP");
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_ASIGNACION_FOLIO_GV");
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_CIERRE_CAJA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_CN").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_COBRANZAS").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_CONCILIACION").StartsAt(11L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_CONCILIACION_CONCEPTO");
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_CONCILIACION_CUENTA");
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_CP").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_EMAIL").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_GBL").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_GV").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_INTERES_POR_MORA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_IV").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_PROMOCION").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_RE").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_SB").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_SU").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARAMETRO_TR").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PARENTESCO").StartsAt(23L);
        modelBuilder.HasSequence("SEQUENCE_PARTE_DIARIO");
        modelBuilder.HasSequence("SEQUENCE_PENDIENTE_RENDICION");
        modelBuilder.HasSequence("SEQUENCE_PERCEPCION_COMPROBANTE_EXENCION");
        modelBuilder.HasSequence("SEQUENCE_PERCEPCION_VENTAS").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PERCEPCION_VENTAS_ALICUOTA").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_PERCEPCION_VENTAS_BASE_CALCULO").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_PERFIL_CIERRE_CAJA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PERFIL_FACTURA_POS").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_PERFIL_NOTA_CREDITO").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_PERFIL_PEDIDO");
        modelBuilder.HasSequence("SEQUENCE_PERFIL_PEDIDO_USUARIO");
        modelBuilder.HasSequence("SEQUENCE_PERFIL_REMITO").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_PERFIL_REVISION_PEDIDO_WEB");
        modelBuilder.HasSequence("SEQUENCE_PERIODO");
        modelBuilder.HasSequence("SEQUENCE_PERIODO_MULTITABLA");
        modelBuilder.HasSequence("SEQUENCE_PERSONERIA_RG3668_AFIP").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_PLAN_OS");
        modelBuilder.HasSequence("SEQUENCE_PLAN_TARJETA").StartsAt(9L);
        modelBuilder.HasSequence("SEQUENCE_PLANIFICACION_VACACION");
        modelBuilder.HasSequence("SEQUENCE_PLANTILLA_CONCILIACION_CUPONES");
        modelBuilder.HasSequence("SEQUENCE_POLITICA_REDONDEO");
        modelBuilder.HasSequence("SEQUENCE_POLITICA_REDONDEO_RANGOS");
        modelBuilder.HasSequence("SEQUENCE_POS_USUARIO_PREFERENCIAS");
        modelBuilder.HasSequence("SEQUENCE_PRECIOS_SOLICITADOS");
        modelBuilder.HasSequence("SEQUENCE_PREFIJO_BIEN").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_PRESENTACION_F1357");
        modelBuilder.HasSequence("SEQUENCE_PRESENTACION_SIRADIG");
        modelBuilder.HasSequence("SEQUENCE_PRESUPUESTO");
        modelBuilder.HasSequence("SEQUENCE_PRESUPUESTO_COMPONENTE");
        modelBuilder.HasSequence("SEQUENCE_PRESUPUESTO_IMPORTE");
        modelBuilder.HasSequence("SEQUENCE_PRESUPUESTO_PERIODO");
        modelBuilder.HasSequence("SEQUENCE_PREV_ANORMALIDAD");
        modelBuilder.HasSequence("SEQUENCE_PREV_AUSENCIA");
        modelBuilder.HasSequence("SEQUENCE_PROCESO").StartsAt(13L);
        modelBuilder.HasSequence("SEQUENCE_PROMOCION");
        modelBuilder.HasSequence("SEQUENCE_PROMOCION_DESCUENTO_CANTIDAD");
        modelBuilder.HasSequence("SEQUENCE_PROMOCION_DESCUENTO_IMPORTE");
        modelBuilder.HasSequence("SEQUENCE_PROMOCION_GRUPO");
        modelBuilder.HasSequence("SEQUENCE_PROMOCION_MEDIO_PAGO");
        modelBuilder.HasSequence("SEQUENCE_PROMOCION_SUCURSAL_DESTINO");
        modelBuilder.HasSequence("SEQUENCE_PROMOCION_TARJETA");
        modelBuilder.HasSequence("SEQUENCE_PROMOCION_TARJETA_ARTICULO");
        modelBuilder.HasSequence("SEQUENCE_PROMOCION_TARJETA_BENEFICIO");
        modelBuilder.HasSequence("SEQUENCE_PROMOCION_TARJETA_HABILITADA");
        modelBuilder.HasSequence("SEQUENCE_PROVEEDOR");
        modelBuilder.HasSequence("SEQUENCE_PROVEEDOR_CM_JURISDICCION");
        modelBuilder.HasSequence("SEQUENCE_PROVEEDOR_CUENTA_IV");
        modelBuilder.HasSequence("SEQUENCE_PROVIDER_NRO_ASIENTO_CORRELATIVO");
        modelBuilder.HasSequence("SEQUENCE_PROVIDER_NRO_ASIENTO_DIA");
        modelBuilder.HasSequence("SEQUENCE_PROVIDER_NRO_ASIENTO_EJERCICIO");
        modelBuilder.HasSequence("SEQUENCE_PROVIDER_NRO_ASIENTO_PERIODO");
        modelBuilder.HasSequence("SEQUENCE_PROVINCIA").StartsAt(26L);
        modelBuilder.HasSequence("SEQUENCE_PROVINCIA_ARBA").StartsAt(25L);
        modelBuilder.HasSequence("SEQUENCE_PUESTO").StartsAt(392L);
        modelBuilder.HasSequence("SEQUENCE_PUESTO_CAJA");
        modelBuilder.HasSequence("SEQUENCE_QUERY").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_RANGO_MATRIZ");
        modelBuilder.HasSequence("SEQUENCE_RANGO_MATRIZ_SUELDO");
        modelBuilder.HasSequence("SEQUENCE_REGLA_APROPIACION");
        modelBuilder.HasSequence("SEQUENCE_RELACION_COMPROBANTES_LIBRO_BOLETAS");
        modelBuilder.HasSequence("SEQUENCE_RELACION_DTES_CONSUMO_FOLIOS");
        modelBuilder.HasSequence("SEQUENCE_RELACION_DTES_RESUMEN_VENTAS_DIARIAS");
        modelBuilder.HasSequence("SEQUENCE_RELACION_EMISOR_RECEPTOR_TURISMO").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_RELOJ");
        modelBuilder.HasSequence("SEQUENCE_REMITO_ELECTRONICO_AFIP");
        modelBuilder.HasSequence("SEQUENCE_RENGLON_ANALITICO_CN");
        modelBuilder.HasSequence("SEQUENCE_RENGLON_COMPROBANTE_AF");
        modelBuilder.HasSequence("SEQUENCE_RENGLON_CONDICION_COMPRA").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_RENGLON_CONDICION_VENTA").StartsAt(29L);
        modelBuilder.HasSequence("SEQUENCE_RENGLON_COTIZACION_MONEDA").StartsAt(1204L);
        modelBuilder.HasSequence("SEQUENCE_RENGLON_IMPORTE_ANALITICO_CN");
        modelBuilder.HasSequence("SEQUENCE_RENGLON_IMPORTE_RESUMEN_CN");
        modelBuilder.HasSequence("SEQUENCE_RENGLON_MODELO");
        modelBuilder.HasSequence("SEQUENCE_RENGLON_MODELO_AF");
        modelBuilder.HasSequence("SEQUENCE_RENGLON_MODELO_ASIENTO_SU");
        modelBuilder.HasSequence("SEQUENCE_RENGLON_MODELO_CP").StartsAt(73L);
        modelBuilder.HasSequence("SEQUENCE_RENGLON_MODELO_GV").StartsAt(23L);
        modelBuilder.HasSequence("SEQUENCE_RENGLON_RESUMEN_CN");
        modelBuilder.HasSequence("SEQUENCE_RENGLON_TURISMO");
        modelBuilder.HasSequence("SEQUENCE_RENGLON_VALORIZACION_UNIDAD_ADICIONAL");
        modelBuilder.HasSequence("SEQUENCE_REPORTE_FISCAL");
        modelBuilder.HasSequence("SEQUENCE_REPORTES_CONSUMO_FOLIOS");
        modelBuilder.HasSequence("SEQUENCE_RESPONSABLE");
        modelBuilder.HasSequence("SEQUENCE_RESULTADOS_FACTURACION_AUTOMATICA_PEDIDOS_TIENDAS");
        modelBuilder.HasSequence("SEQUENCE_RESUMEN_CIERRE_CAJA");
        modelBuilder.HasSequence("SEQUENCE_RESUMEN_TARJETA");
        modelBuilder.HasSequence("SEQUENCE_RESUMEN_TARJETA_CONCEPTO_DESCUENTO");
        modelBuilder.HasSequence("SEQUENCE_RESUMEN_VENTAS_DIARIAS");
        modelBuilder.HasSequence("SEQUENCE_RETENCION_COMPRAS").StartsAt(18L);
        modelBuilder.HasSequence("SEQUENCE_RETENCION_COMPRAS_ESCALA").StartsAt(20L);
        modelBuilder.HasSequence("SEQUENCE_RG_3572_TIPO_OPERACION_HABITUAL").StartsAt(43L);
        modelBuilder.HasSequence("SEQUENCE_RG_AFIP_GANANCIAS").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_RUBRO_BIEN");
        modelBuilder.HasSequence("SEQUENCE_RUBRO_CN").StartsAt(44L);
        modelBuilder.HasSequence("SEQUENCE_SALDO_PREVIO_ADECUACION");
        modelBuilder.HasSequence("SEQUENCE_SBA01").StartsAt(103L);
        modelBuilder.HasSequence("SEQUENCE_SBA02").StartsAt(40L);
        modelBuilder.HasSequence("SEQUENCE_SBA03").StartsAt(11L);
        modelBuilder.HasSequence("SEQUENCE_SBA11");
        modelBuilder.HasSequence("SEQUENCE_SBA13").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_SBA16");
        modelBuilder.HasSequence("SEQUENCE_SBA19");
        modelBuilder.HasSequence("SEQUENCE_SBA21").StartsAt(16L);
        modelBuilder.HasSequence("SEQUENCE_SBA22").StartsAt(10L);
        modelBuilder.HasSequence("SEQUENCE_SBA30");
        modelBuilder.HasSequence("SEQUENCE_SBA31").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_SBA32");
        modelBuilder.HasSequence("SEQUENCE_SBA35");
        modelBuilder.HasSequence("SEQUENCE_SBA36");
        modelBuilder.HasSequence("SEQUENCE_SBA37").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_SBA39").StartsAt(74L);
        modelBuilder.HasSequence("SEQUENCE_SBA40").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_SBA41").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_SBA43").StartsAt(53L);
        modelBuilder.HasSequence("SEQUENCE_SBA50");
        modelBuilder.HasSequence("SEQUENCE_SBA51");
        modelBuilder.HasSequence("SEQUENCE_SBA52");
        modelBuilder.HasSequence("SEQUENCE_SECCION_ASCII_BANCO").StartsAt(19L);
        modelBuilder.HasSequence("SEQUENCE_SECCION_ASCII_SU");
        modelBuilder.HasSequence("SEQUENCE_SECCION_PREVIRED").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_SERVICIO_EVENTUAL");
        modelBuilder.HasSequence("SEQUENCE_SINDICATO");
        modelBuilder.HasSequence("SEQUENCE_SITUACION_LEGAJO_DGI").StartsAt(44L);
        modelBuilder.HasSequence("SEQUENCE_SITUACION_REVISTA").StartsAt(11L);
        modelBuilder.HasSequence("SEQUENCE_SOLICITUD_FOLIO");
        modelBuilder.HasSequence("SEQUENCE_SOLICITUD_PAGO_ELECTRONICO");
        modelBuilder.HasSequence("SEQUENCE_STA_ARTICULO_FOTO");
        modelBuilder.HasSequence("SEQUENCE_STA_ARTICULO_UNIDAD_COMPRA").StartsAt(23344L);
        modelBuilder.HasSequence("SEQUENCE_STA_ARTICULO_UNIDAD_COMPRA_DEFECTO").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_STA_AUDITORIA_BAJA_COMPROBANTE");
        modelBuilder.HasSequence("SEQUENCE_STA_AUDITORIA_COSTO_COMPRA").StartsAt(25207L);
        modelBuilder.HasSequence("SEQUENCE_STA_CORRECCION_MONETARIA");
        modelBuilder.HasSequence("SEQUENCE_STA03");
        modelBuilder.HasSequence("SEQUENCE_STA04");
        modelBuilder.HasSequence("SEQUENCE_STA05");
        modelBuilder.HasSequence("SEQUENCE_STA11").StartsAt(23344L);
        modelBuilder.HasSequence("SEQUENCE_STA11_DEFECTO").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_STA115");
        modelBuilder.HasSequence("SEQUENCE_STA116");
        modelBuilder.HasSequence("SEQUENCE_STA11ITC_DEFECTO").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_STA12").StartsAt(25206L);
        modelBuilder.HasSequence("SEQUENCE_STA13").StartsAt(8L);
        modelBuilder.HasSequence("SEQUENCE_STA17").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_STA22").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_STA29");
        modelBuilder.HasSequence("SEQUENCE_STA32");
        modelBuilder.HasSequence("SEQUENCE_STA33");
        modelBuilder.HasSequence("SEQUENCE_STA83").StartsAt(23344L);
        modelBuilder.HasSequence("SEQUENCE_STA83_DEFECTO");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_ARTICULO");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_ARTICULO_CT");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_BIEN");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_CLIENTE");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_CLIENTE_IV");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_CLIENTE_OCASIONAL");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_CLIENTE_POTENCIAL");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_CONCEPTO_CP");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_CUENTA_SB");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_DEFECTO_ARTICULO");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_DEFECTO_CLIENTE");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_HABITUAL_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_OCASIONAL_LEGAJO");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_PROVEEDOR");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_PROVEEDOR_IV");
        modelBuilder.HasSequence("SEQUENCE_SUBAUXILIAR_REGLA_PROVEEDOR_OCASIONAL");
        modelBuilder.HasSequence("SEQUENCE_SUBTIPO");
        modelBuilder.HasSequence("SEQUENCE_SUCURSAL").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_SUCURSAL_PERFIL_PRECIOS_SALDOS");
        modelBuilder.HasSequence("SEQUENCE_TABLA");
        modelBuilder.HasSequence("SEQUENCE_TALONARIO_AF");
        modelBuilder.HasSequence("SEQUENCE_TALONARIO_COMPROBANTE_INTERNO_AF");
        modelBuilder.HasSequence("SEQUENCE_TALONARIO_EXCLUIDO_ACTUALIZACION_PRECIOS");
        modelBuilder.HasSequence("SEQUENCE_TALONARIO_PERFIL_REMITO");
        modelBuilder.HasSequence("SEQUENCE_TAREA");
        modelBuilder.HasSequence("SEQUENCE_TARJETA_ABREVIATURA");
        modelBuilder.HasSequence("SEQUENCE_TARJETA_COEFICIENTE_CUOTA").StartsAt(226L);
        modelBuilder.HasSequence("SEQUENCE_TARJETA_CONCEPTO_DESCUENTO_TARJETA");
        modelBuilder.HasSequence("SEQUENCE_TARJETA_PLAN_COEFICIENTE").StartsAt(16L);
        modelBuilder.HasSequence("SEQUENCE_TARJETA_REGALO_CONFIGURACION");
        modelBuilder.HasSequence("SEQUENCE_TARJETA_VIGENCIA_COEFICIENTE").StartsAt(10L);
        modelBuilder.HasSequence("SEQUENCE_TERMINAL_POS");
        modelBuilder.HasSequence("SEQUENCE_TERMINAL_POS_HOST");
        modelBuilder.HasSequence("SEQUENCE_TERMINAL_POS_NO_INTEGRADO");
        modelBuilder.HasSequence("SEQUENCE_TERMINAL_POS_TARJETA");
        modelBuilder.HasSequence("SEQUENCE_TIENDA").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_ASIENTO").StartsAt(41L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_AUXILIAR");
        modelBuilder.HasSequence("SEQUENCE_TIPO_AUXILIAR_AUTOMATICO").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_AUXILIAR_MODELO");
        modelBuilder.HasSequence("SEQUENCE_TIPO_AUXILIAR_MODELO_AF");
        modelBuilder.HasSequence("SEQUENCE_TIPO_AUXILIAR_MODELO_CP");
        modelBuilder.HasSequence("SEQUENCE_TIPO_AUXILIAR_MODELO_GV");
        modelBuilder.HasSequence("SEQUENCE_TIPO_BIEN");
        modelBuilder.HasSequence("SEQUENCE_TIPO_BIEN_IDENTIFICACION_ADICIONAL");
        modelBuilder.HasSequence("SEQUENCE_TIPO_COMPROBANTE_AF");
        modelBuilder.HasSequence("SEQUENCE_TIPO_COMPROBANTE_AFIP").StartsAt(114L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_COMPROBANTE_COMPRAS").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_COMPROBANTE_CP").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_COMPROBANTE_GV").StartsAt(10L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_COMPROBANTE_INTERNO").StartsAt(44L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_COMPROBANTE_IV");
        modelBuilder.HasSequence("SEQUENCE_TIPO_COMPROBANTE_SB").StartsAt(34L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_COMPROBANTE_TALONARIO_COMPRAS").StartsAt(8L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_COMPROBANTE_TR");
        modelBuilder.HasSequence("SEQUENCE_TIPO_CONCEPTO_GANANCIAS").StartsAt(10L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_CONTABLE").StartsAt(54L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_CONTRATO").StartsAt(79L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_COTIZACION").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_CUENTA_PAGO_TURISMO").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_DOCUMENTACION_DGI").StartsAt(20L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_DOCUMENTACION_EXT_DGI").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_DOCUMENTO").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_DOCUMENTO_EXTERIOR").StartsAt(25L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_DOCUMENTO_GV").StartsAt(42L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_EMBARGO_LEGAJO").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_EMPLEADOR_DGI").StartsAt(11L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_EVENTO_DGI").StartsAt(22L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_EXCEPCION_GANANCIAS").StartsAt(12L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_FECHA_INDICE_ORIGEN").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_FORMA_PAGO_TURISMO").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_GASTO_CP").StartsAt(7L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_HORA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_ITEM_AFIP").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_ITEM_SUELDO").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_MONEDA_AFIP").StartsAt(52L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_MOVIMIENTO_AF").StartsAt(14L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_PAGO_A_CUENTA").StartsAt(16L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_PRESENTACION_AFIP").StartsAt(5L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_PROMOCION").StartsAt(16L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_RETENCION_GANANCIAS").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_SAC").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_SERVICIO_AFIP");
        modelBuilder.HasSequence("SEQUENCE_TIPO_TARJETA_REGALO").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_UNIDAD_TURISMO").StartsAt(11L);
        modelBuilder.HasSequence("SEQUENCE_TIPO_VALORACION");
        modelBuilder.HasSequence("SEQUENCE_TIPO_VALORIZACION");
        modelBuilder.HasSequence("SEQUENCE_TMP_ACT_MASIVA_ARTICULOS");
        modelBuilder.HasSequence("SEQUENCE_TMP_ACT_MASIVA_CLIENTES");
        modelBuilder.HasSequence("SEQUENCE_TMP_AJUSTE_INFLACION_AF");
        modelBuilder.HasSequence("SEQUENCE_TMP_DETALLE_EXTRACTO_MOVIMIENTO");
        modelBuilder.HasSequence("SEQUENCE_TMP_LIQUIDACION_GCIA_AJUSTE_DESDE");
        modelBuilder.HasSequence("SEQUENCE_TMP_LIQUIDACION_GCIA_ANUAL");
        modelBuilder.HasSequence("SEQUENCE_TMP_SIMULACION");
        modelBuilder.HasSequence("SEQUENCE_TMP_TOT_SIMULACION");
        modelBuilder.HasSequence("SEQUENCE_TOPE_BENEFICIO_GANANCIAS").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_TOT_LIQUIDACION");
        modelBuilder.HasSequence("SEQUENCE_TOTAL_LISTADOR_SU");
        modelBuilder.HasSequence("SEQUENCE_TRA_CLASE_ARTICULO").StartsAt(6L);
        modelBuilder.HasSequence("SEQUENCE_TRA_COMANDA_COBRANZA");
        modelBuilder.HasSequence("SEQUENCE_TRA_COMANDA_COBRANZA_DETALLE");
        modelBuilder.HasSequence("SEQUENCE_TRA_COMANDA_COBRANZA_DETALLE_CHEQUE");
        modelBuilder.HasSequence("SEQUENCE_TRA_COMANDA_COBRANZA_DETALLE_CUPON");
        modelBuilder.HasSequence("SEQUENCE_TRA_COMANDA_COBRANZA_DETALLE_TICKET");
        modelBuilder.HasSequence("SEQUENCE_TRA_COMANDA_FACTURA");
        modelBuilder.HasSequence("SEQUENCE_TRA_CTA_CAJA_RESTO_CTA_TESORERIA");
        modelBuilder.HasSequence("SEQUENCE_TRA_CUENTA_LISTA_PRECIO");
        modelBuilder.HasSequence("SEQUENCE_TRA_FAVORITOS_PUESTO");
        modelBuilder.HasSequence("SEQUENCE_TRA_GRUPO_DE_CLIENTES");
        modelBuilder.HasSequence("SEQUENCE_TRA_IMAGEN_ARTICULO_MOBILE");
        modelBuilder.HasSequence("SEQUENCE_TRA_LICENCIA_MOBILE");
        modelBuilder.HasSequence("SEQUENCE_TRA_MOTIVO_DE_INVITACION").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_TRA_MOTIVOS_BOLIVIA");
        modelBuilder.HasSequence("SEQUENCE_TRA_ORIGEN_INFORMACION").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_TRA_RELACION_FACTURA_RENDICION");
        modelBuilder.HasSequence("SEQUENCE_TRA_RUBROS_POR_SECTOR");
        modelBuilder.HasSequence("SEQUENCE_TRA_SESION_MOBILE");
        modelBuilder.HasSequence("SEQUENCE_TRA_TERMINAL_POS_HOST");
        modelBuilder.HasSequence("SEQUENCE_TRA125");
        modelBuilder.HasSequence("SEQUENCE_TRA43");
        modelBuilder.HasSequence("SEQUENCE_TRA82").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_TRA91_INFORMACION_ADICIONAL");
        modelBuilder.HasSequence("SEQUENCE_TRABAJO_PESADO");
        modelBuilder.HasSequence("SEQUENCE_TRAMO_GCIA").StartsAt(953L);
        modelBuilder.HasSequence("SEQUENCE_TRAMO_UTM");
        modelBuilder.HasSequence("SEQUENCE_TS_TAREA").StartsAt(12011L);
        modelBuilder.HasSequence("SEQUENCE_TS_TRA_PARAMETRO_NEXO");
        modelBuilder.HasSequence("SEQUENCE_UBICACION_BIEN");
        modelBuilder.HasSequence("SEQUENCE_UNIDAD_ADICIONAL");
        modelBuilder.HasSequence("SEQUENCE_UNIDAD_MEDIDA_AFIP").StartsAt(57L);
        modelBuilder.HasSequence("SEQUENCE_UNIDAD_MONETARIA");
        modelBuilder.HasSequence("SEQUENCE_UNIDAD_NO_MONETARIA");
        modelBuilder.HasSequence("SEQUENCE_USER_PREFERENCE");
        modelBuilder.HasSequence("SEQUENCE_USUARIO_FILTRO_LEGAJO_CLOUD");
        modelBuilder.HasSequence("SEQUENCE_USUARIO_PERFIL_CIERRE_CAJA").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_USUARIO_PERFIL_NOTA_CREDITO").StartsAt(2L);
        modelBuilder.HasSequence("SEQUENCE_USUARIO_PERFIL_REMITO").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_USUARIO_PERFIL_REVISION_PEDIDO_WEB");
        modelBuilder.HasSequence("SEQUENCE_USUARIO_PUESTO_CAJA");
        modelBuilder.HasSequence("SEQUENCE_VALOR_ADICIONAL_GCIA");
        modelBuilder.HasSequence("SEQUENCE_VALOR_EQUIVALENCIA_LISTADOR_SU");
        modelBuilder.HasSequence("SEQUENCE_VALORIZACION_UNIDAD_ADICIONAL");
        modelBuilder.HasSequence("SEQUENCE_VARIABLE").StartsAt(3786L);
        modelBuilder.HasSequence("SEQUENCE_VARIABLE_ADICIONAL");
        modelBuilder.HasSequence("SEQUENCE_VARIABLE_ASCII_BANCO").StartsAt(88L);
        modelBuilder.HasSequence("SEQUENCE_VARIABLE_CN").StartsAt(88L);
        modelBuilder.HasSequence("SEQUENCE_VARIABLE_COMPONENTE").StartsAt(20L);
        modelBuilder.HasSequence("SEQUENCE_VARIABLE_COMPONENTE_CN").StartsAt(3L);
        modelBuilder.HasSequence("SEQUENCE_VARIABLE_GRUPO").StartsAt(34L);
        modelBuilder.HasSequence("SEQUENCE_VARIABLE_GRUPO_CN").StartsAt(12L);
        modelBuilder.HasSequence("SEQUENCE_VARIABLE_IMPRESION_FISCAL").StartsAt(94L);
        modelBuilder.HasSequence("SEQUENCE_VARIABLE_PARAMETRO").StartsAt(508L);
        modelBuilder.HasSequence("SEQUENCE_VARIABLE_PARAMETRO_CN").StartsAt(327L);
        modelBuilder.HasSequence("SEQUENCE_VENDEDOR_PERFIL_REVISION_PEDIDO_WEB");
        modelBuilder.HasSequence("SEQUENCE_VENTAS_COMPROBANTE_PAGO_VIRTUAL");
        modelBuilder.HasSequence("SEQUENCE_XML_COMPONENTE").StartsAt(4L);
        modelBuilder.HasSequence("SEQUENCE_ZONA_DE_ENTREGA");
        modelBuilder.HasSequence("SEQUENCE_ZONA_DE_ENTREGA_TRAMO_HORARIO");
        modelBuilder.HasSequence("SEQUENCE_ZONA_DGI").StartsAt(188L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
