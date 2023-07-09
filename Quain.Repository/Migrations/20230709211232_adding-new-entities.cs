using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quain.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addingnewentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    PointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentValue = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.PointsId);
                    table.ForeignKey(
                        name: "FK_Points_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointsChanges",
                columns: table => new
                {
                    PointsChangesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ChangeDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BillNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsChanges", x => x.PointsChangesId);
                    table.ForeignKey(
                        name: "FK_PointsChanges_Points_PointsId",
                        column: x => x.PointsId,
                        principalTable: "Points",
                        principalColumn: "PointsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Points_CustomerId",
                table: "Points",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PointsChanges_PointsId",
                table: "PointsChanges",
                column: "PointsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GVA14");

            migrationBuilder.DropTable(
                name: "GVA53");

            migrationBuilder.DropTable(
                name: "PointsChanges");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropSequence(
                name: "NUMERACION_COD_CLIENT");

            migrationBuilder.DropSequence(
                name: "NUMERACION_COD_PROVEE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ACTIVIDAD_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ACTIVIDAD_EMPRESA_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ACTIVIDAD_LEGAJO_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ACUMULA_PAGOS_RETENCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ACUMULADO_DEFINIBLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ACUMULADO_FIJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AFJP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AGRUPACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AGRUPACION_ASIENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AJUSTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ALICUOTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ALICUOTA_IVA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ALICUOTAS_ART90_LIG");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AplicacionNexoParametro");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_ARTICULO_CT");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_CLIENTE_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_CLIENTE_OCASIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_CLIENTE_POTENCIAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_CONCEPTO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_CUENTA_SB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_DEFECTO_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_DEFECTO_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_PROVEEDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_PROVEEDOR_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_APROPIACION_PROVEEDOR_OCASIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ARCHIVO_SHOPPING_TERMINAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ART");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ARTICULO_CUENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ARTICULO_CUENTA_CT");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ARTICULO_PERCEPCION_VENTAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ARTICULO_PERCEPCION_VENTAS_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_ANALITICO_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_COMPROBANTE_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_COMPROBANTE_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_COMPROBANTE_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_COMPROBANTE_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_COMPROBANTE_SB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_COMPROBANTE_TR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_COTIZACION_ANALITICO_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_COTIZACION_RESUMEN_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_MODELO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_MODELO_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_MODELO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_MODELO_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_RESUMEN_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_SB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ASIENTO_TR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUDITORIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUDITORIA_CONCEPTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUDITORIA_DETALLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUDITORIA_PRECIO_ORDEN_COMPRA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUDITORIA_STA11");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUSENTE_POR_SU_HORARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUTORIZACION_HORA_EXTRA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUX_AUTOMATICO_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUX_AUTOMATICO_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUX_AUTOMATICO_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUX_AUTOMATICO_PROVEEDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_CUENTA_TIPO_AUXILIAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_HABITUAL_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_OCASIONAL_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_ARTICULO_CT");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_CLIENTE_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_CLIENTE_OCASIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_CLIENTE_POTENCIAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_CONCEPTO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_CUENTA_SB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_DEFECTO_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_DEFECTO_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_HABITUAL_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_OCASIONAL_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_PROVEEDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_PROVEEDOR_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_AUXILIAR_REGLA_PROVEEDOR_OCASIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_BANCO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_BASE_ANALISIS_RETENCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_BASE_CALCULO_PERCEPCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_BASE_CALCULO_RETENCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_BASES_IMPONIBLES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_BIEN_ORIGEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_BIEN_PRODUCCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_BIEN_PRODUCCION_DETALLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_BILLETE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CAEA_SIN_MOVIMIENTO_PRESENTACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CAEA_SOLICITADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CALCULO_DEPRECIACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CAMBIO_DE_HORARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CANTIDAD_ASIGNACION_FOLIO_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CANTIDAD_COPIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CANTIDAD_FAMILIAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CATEGORIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CATEGORIA_IVA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CCAF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CERTIFICADO_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CHEQUE_RENDICION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CIERRE_Z");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLASE_CUENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLASE_INDICADOR_CONTABLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLASE_OPERACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLASIF_CLIENTES_PERFIL_REMITO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLASIFICACION_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLASIFICACION_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLASIFICACION_CUENTA_TESORERIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLASIFICACION_PAIS_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLASIFICACION_PROVEEDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLASIFICACION_SIAP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLIENTE_CM_JURISDICCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLIENTE_CUENTA_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CLIENTE_POTENCIAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CODIGO_AFIP_PERCEPCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CODIGO_ITEM_TURISMO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CODIGO_RELACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COEFICIENTE_PROMOCION_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COLECTORA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COLECTORA_ENCABEZADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COLECTORA_RENGLON");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COLECTORA_RENGLON_PARTIDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COLECTORA_RENGLON_SERIE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COLUMNA_ASCII_BANCO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COLUMNA_ASCII_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COLUMNA_LISTADOR_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COLUMNA_MULTITABLA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COLUMNA_PREVIRED");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMANDA_GVA12_RG_3668");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMANDA_VOUCHER");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMPENSA_POR_RANGO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMPOSICION_CODIGO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMPOSICION_CODIGO_GRUPO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMPROBANTE_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMPROBANTE_CLIENTE_OCASIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMPROBANTE_COTIZACION_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMPROBANTE_COTIZACION_SB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMPROBANTE_PROVEEDOR_OCASIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMPROBANTE_TURISMO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COMUNA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONCEPTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONCEPTO_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONCEPTO_COMPROBANTE_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONCEPTO_COMPROBANTE_INTERNO_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONCEPTO_CONCILIACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONCEPTO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONCEPTO_DESCUENTO_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONCEPTO_INE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONCEPTO_JUSTIFICACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONCEPTO_PARTICULAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONDICION_COMPRA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONDICION_LEGAJO_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONFIGURACION_PROCESO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONSOLIDACION_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONTRATO_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CONVENIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COPIAR_EMPRESA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_COTIZACION_MONEDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_AUDITORIA_BAJA_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_AUDITORIA_BAJA_DTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_AUTORIZACION_OC");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_CAMPO_AUTORIZACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_CONCEPTO_AUTORIZACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_CONCEPTOS_PROVEEDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_CONTACTOS_PROVEEDOR_HABITUAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_HISTORIAL_AUTORIZACION_OC");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_HISTORIAL_CUENTAS_CORRIENTES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_PARAMETRO_CONCEPTO_AUTORIZACION_OC");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_PERFIL_AUTORIZACION_OC");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_PERFIL_AUTORIZACION_OC_COMPRADOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_PERFIL_AUTORIZACION_OC_CONCEPTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_PERFIL_AUTORIZACION_OC_SECTOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_PERFIL_AUTORIZACION_OC_SUCURSALES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_PERFIL_AUTORIZACION_OC_USUARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_PERFIL_OC_CONCEPTO_AUTORIZACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA_PROVEEDOR_FOTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA01");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA01_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA03");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA04");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA04_FCE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA08");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA108");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA112");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA113");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA131");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA14");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA15");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA21");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA35");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA36");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA37");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA43");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA45");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA46");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA50");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA51");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA56");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA57");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA70");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA85");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA86");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA87");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA89");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CPA92");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CRITERIO_ACTUALIZACION_PRECIOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CRITERIO_ACTUALIZACION_RANGOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_ARTICULO_COSTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_ARTICULO_DESTINO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_ARTICULO_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_ARTICULO_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_ARTICULO_TARJETA_REGALO_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_BANCO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CHEQUE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CIERRE_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CIERRE_CAJA_TERMINAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CIERRE_Z");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CLASIFICACION_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CLIENTE_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMANDA_ASOCIADA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_ALICUOTAS_RG3685");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_ALICUOTAS_RG3685_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_ALICUOTAS_RG4597");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_ALICUOTAS_RG4597_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_COMPROBANTE_RG3685");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_COMPROBANTE_RG3685_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_COMPROBANTE_RG4597");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_COMPROBANTE_RG4597_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_DTE_CONSOLIDADOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_IMPORTACIONES_RG3685");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_IMPORTACIONES_RG3685_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_IMPORTACIONES_RG4597");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_IMPORTACIONES_RG4597_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_TURIVA_RG4597");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPRAS_TURIVA_RG4597_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COMPROBANTE_DUPLICADOS_COMPRA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CONCEPTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CONDICION_VENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_COSTOS_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CUENTA_RESTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CUENTA_RESTO_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CUENTA_TARJETA_PLAN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CUENTA_TESORERIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CUENTA_TESORERIA_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CUOTA_CUPON");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CUPON_DESCUENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_CUPON_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_DEPOSITO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_DEPURACION_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_DETALLE_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_DETALLE_COMANDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_DETALLE_DESPACHO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_DETALLE_DEVOLUCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_EMPRESA_TICKET");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_ENCABEZADO_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_ENCABEZADO_COMANDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_ENCABEZADO_DESPACHO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_FOLIO_ALERTA_EMAIL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_FOLIO_ASIGNADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_FOLIO_SOLICITADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_GASTO_FIJO_CUPON");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_GRUPO_EMPRESARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_HORARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_IEC_CONSOLIDADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_IEV_CONSOLIDADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_LISTA_COMPRA_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_LISTA_PRECIOS_VENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_LISTA_VENTA_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_MEDIDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_MEDIO_DE_PAGO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_MONEDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_MOTIVO_DE_INVITACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_MOTIVO_DEVOLUCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_MOZO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_MOZO_RESTO_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_NOTA_CREDITO_POR_TARJETA_REGALO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_NOTA_CREDITO_PROMOCION_TARJETA_RESUMEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PAIS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PARAMETRO_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PARAMETRO_TRANSFERENCIA_FOLIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PARAMETRO_TRANSFERENCIA_MAESTRO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PLAN_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_POLITICA_PROMOCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_POLITICA_PROMOCION_SUCURSAL_DESTINO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PROMOCION_FACTURA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PROMOCION_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PROMOCION_TARJETA_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PROVEEDOR_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PROVINCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PUESTO_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_PUESTO_RESTO_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_RELACION_COMPROBANTES_IEC_CONSOLIDADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_RELACION_COMPROBANTES_IEV_CONSOLIDADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_RELACION_DTES_CONSUMO_FOLIOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_RELACION_DTES_RESUMEN_VENTAS_DIARIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_REPARTIDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_REPARTIDOR_RESTO_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_REPORTE_FISCAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_REPORTES_CONSUMO_FOLIOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_RESUMEN_CIERRE_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_RESUMEN_VENTAS_DIARIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_RUBRO_COMERCIAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_SALDO_ARTICULO_DEPOSITO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_SALDO_ARTICULO_DEPOSITO_PARTIDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_SALDO_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_SALDO_CUENTA_RESTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_SALDO_CUENTA_TESORERIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_SALDO_PROVEEDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_SECTOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_SECTOR_RESTO_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_SEPARADOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_STOCK_RENGLON_PARTIDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_STOCK_RENGLON_SERIE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_TARJETA_TESORERIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_TICKET_RESTAURANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_TIPO_ASIENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_TIPO_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_TIPO_PROMOCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_TIPO_TURNO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_TOPES_STOCK_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_TRANSPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_USUARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENDEDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_ALICUOTAS_RG3685");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_ALICUOTAS_RG3685_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_ALICUOTAS_RG4597");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_ALICUOTAS_RG4597_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_ALICUOTAS_TURIVA_RG4597");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_ALICUOTAS_TURIVA_RG4597_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_ANULADOS_RG4597");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_ANULADOS_RG4597_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_COMPROBANTE_RG3685");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_COMPROBANTE_RG3685_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_COMPROBANTE_RG4597");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_COMPROBANTE_RG4597_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_TURIVA_RG4597");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_VENTAS_TURIVA_RG4597_TRANSFERENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_ZONA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA_ZONA_RESTO_POR_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA02_FCE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CTA05_FCE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUENTA_AJUSTABLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUENTA_BANCARIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUENTA_CONVERTIBLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUENTA_COTIZABLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUENTA_DEFECTO_MODELO_ASIENTO_SUELDOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUENTA_NEXO_COBRANZAS_CONTADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUENTA_PUESTO_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUENTA_SB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUENTA_TARJETA_PLAN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUENTA_TIPO_AUXILIAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_CUIT_PAIS_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_AFJP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_ART");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_ASIENTO_ANALITICO_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_ASIENTO_RESUMEN_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_BANCO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_CATEGORIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_CCAF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_COMPROBANTE_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_CONTRATO_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_CONVENIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_CPA01");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_CPA04");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_CPA110");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_CPA35");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_CPA65");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_CUENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_DATO_FIJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_DEPARTAMENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_EJERCICIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_EMBARGO_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_EMPRESA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_EX_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_FAMILIAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_FORMATO_RENDICION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_GRUPO_JERARQUICO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_GVA01");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_GVA12");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_GVA14");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_IDENTIFICACION_ADICIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_IVA_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_IVA_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_IVA_PROVEEDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_JERARQUIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_LUGAR_TRABAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_MATRIZ");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_MATRIZ_SUELDO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_MODELO_ASIENTO_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_MODIFICACION_GANANCIAS_A_RETENER");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_MULTITABLA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_OBRA_SOCIAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_ORGANISMO_APV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_PERIODO_MULTITABLA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_PRESUPUESTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_REGLA_APROPIACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_RESPONSABLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_RUBRO_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_SBA04");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_SERVICIO_EVENTUAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_SINDICATO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_STA11");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_TABLA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_TIPO_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_TIPO_CONTRATO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_TRABAJO_PESADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_ADJUNTO_UBICACION_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_FIJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_LOCADOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DATO_TURISTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DEF_COMPENSA_POR_RANGO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DEFECTO_ARTICULO_CUENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DEFECTO_CLIENTE_CUENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DEFECTO_CONCEPTO_PARTICULAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DEFECTO_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DEFECTO_LEGAJO_NOVEDAD");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DEFECTO_LEGAJO_TELEFONO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DEFINICION_ASCII_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DEPARTAMENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DETALLE_ALICUOTA_IVA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DETALLE_CONCEPTO_RETENCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DETALLE_DEPOSITO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DETALLE_EXTRACTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DETALLE_EXTRACTO_MOVIMIENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DETALLE_FAMILIAR_GCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DETALLE_LICENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DETALLE_PAGO_GENERAL_GCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DIA_HABIL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DIAS_BASE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DIRECCION_ENTREGA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DISMINUCION_GCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DOC_NACIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DOC_PROVINCIAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DOCUMENTO_RENDICION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_EJERCICIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_EMBARGO_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_EMBARGO_LEGAJO_RETENCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_EMPRESA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_EMPRESA_ACTIVIDAD_SECUNDARIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_EMPRESA_TELEFONO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_EMPRESA_TELEFONO_LEGAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ENCABEZADO_EXTRACTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ENCABEZADO_LISTADOR_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_EQUIVALENCIA_LISTADOR_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ESTADO_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ESTADO_COMPROBANTE_FCE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ESTADO_CTACTE_FCE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ESTADO_ORDEN_COMPRA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ETIQUETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_EX_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_EXCEPCION_RG3668_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FAMILIAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FERIADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FICHADA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FICHADA_INVALIDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FICHADA_MANUAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FICHADA_RELOJ");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FICHADOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FILA_MULTITABLA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FILA_TABLA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FILLER");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FOLIO_A_UTILIZAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FOLIO_ALERTA_EMAIL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FOLIO_DESCARGADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FORMA_COBRO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FORMATO_RENDICION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FORMULA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_FUNCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GASTO_FIJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GASTO_FIJO_RESUMEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GASTO_FIJO_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GRUPO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GRUPO_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GRUPO_JERARQUICO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GRUPO_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GRUPO_NOVEDAD");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA_AUDITORIA_BAJA_COMPROBANTES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA_CLIENTE_FOTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA_PARAMETROS_PEDIDOS_TIENDAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA_PARAMETROS_PEDIDOS_TIENDAS_COBRO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA_PARAMETROS_PEDIDOS_TIENDAS_TALONARIO_FACTURA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA01");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA05");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA10");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA10_PARAMETROS_AUTOMATIZACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA11");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA111");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA117");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA118");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA12_FCE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA12_JSON");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA12_RG_3668");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA125");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA12DE_OBSERVACIONES_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA12DE_PDF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA12DE_REFERENCIA_BOLETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA12DE_TICKET_ESPECTACULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA13");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA133");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA14");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA14_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA144");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA144_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA147");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA148");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA149");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA14ITC_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA15");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA150");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA151");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA17");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA18");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA22");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA23");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA24");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA27");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA41");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA62");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA66");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA75");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA76");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA78");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA79");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA80");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA81");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_GVA85");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_HISTORIAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_HISTORIAL_CUENTAS_CORRIENTES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_HISTORIAL_EXPORTACION_ENTIDAD");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_HISTORIAL_ITEM_COSTO_LABORAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_HISTORIAL_ITEM_SUELDO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_HISTORIAL_RENDICION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_HORA_COMPENSADA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_HORA_NO_TRABAJADA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_HORA_REAL_NO_TRAB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_HORARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_HOST");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IDENTIFICACION_ADICIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_INCAPACIDAD_LEGAJO_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_INCREMENTO_DEDUCCION_ESPECIAL_FIJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_INDICADOR_CONTABLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_INDICE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_INDICE_VALOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_INGRESO_EGRESO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_INTERES_POR_MORA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ITEM_COSTO_LABORAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ITEM_SUELDO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_ACTIVIDAD_IB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_AJUSTE_BASE_IMPONIBLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_ALICUOTA_IB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_APROPIACION_MODELO_INGRESO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_BASE_IMPONIBLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_CATEGORIA_REPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_CLASIFICACION_CITI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_CLASIFICACION_CITI_FORMULA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_CLASIFICACION_CITI_VENTAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_CLASIFICACION_SIAP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_CLASIFICACION_SIAP_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_CLASIFICACION_SICORE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_CLASIFICACION_SIFERE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_COEFICIENTE_UNIFICADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_COLUMNA_ASCII");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_COLUMNA_REPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_COMPORTAMIENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_COMPROBANTE_IB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_DEFINICION_ASCII");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_DETALLE_IB_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_DETALLE_LETRA_TIPO_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_EQUIVALENCIA_REPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_FORMULA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_FORMULA_FORMULARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_FORMULARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_IMPORTACION_TXT_PARAMETRO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_IMPORTACION_TXT_TIPO_IMPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_IMPORTE_AUXILIAR_FIJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_IMPORTE_AUXILIAR_MODIFICABLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_IMPORTE_AUXILIAR_MODIFICABLE_DETALLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_IMPORTE_DEPOSITADO_IB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_IMPORTE_DEPOSITADO_SALDO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_LETRA_REPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_MODELO_INGRESO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_OCASIONAL_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_OPERACION_CITI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_ORIGEN_CUENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_PARAMETRO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_PROVEEDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_RELACION_ACTIVIDAD_IB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_RELACION_CONCEPTO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_RELACION_CONCEPTO_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_RELACION_PROVINCIA_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_RELACION_PROVINCIA_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_RELACION_TIPO_COMP_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_RELACION_TIPO_COMP_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_RENGLON_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_RENGLON_MODELO_INGRESO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_REPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_RESULTADO_REPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_RG3685_FORMULA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_SECCION_ASCII");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_SUJETO_VINCULADO_FORMULA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_TIPO_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_TIPO_COMPROBANTE_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_TIPO_COMPROBANTE_IB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_TIPO_COMPROBANTE_REPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_TIPO_DOCUMENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_TIPO_FORMULA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_TIPO_IMPORTE_RG3685");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_TIPO_IMPORTE_SUJETO_VINCULADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_IVA_VALOR_EQUIVALENCIA_REPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_JERARQUIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_JURISDICCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_JUZGADO_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LAYOUT_CAMPOS_ADICIONALES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEGAJO_CLOUD_FILTER");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEGAJO_CONTABLE_HABITUAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEGAJO_CONTABLE_OCASIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEGAJO_FOTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEGAJO_NOVEDAD");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEGAJO_SU_COSTO_LABORAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEGAJO_SU_CUENTA_BANCARIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEGAJO_SU_ITEM_SUELDO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEGAJO_TELEFONO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEYENDA_ENCABEZADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEYENDA_ENCABEZADO_TIPO_ASIENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEYENDA_MOVIMIENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LEYENDA_MOVIMIENTO_CUENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LIBRO_BOLETAS_ELECTRONICAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LIBRO_SUELDOS_DIGITAL_REGISTRO_01");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LIBRO_SUELDOS_DIGITAL_REGISTRO_02");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LIBRO_SUELDOS_DIGITAL_REGISTRO_03");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LIBRO_SUELDOS_DIGITAL_REGISTRO_04");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LIBRO_SUELDOS_DIGITAL_REGISTRO_05");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LISTADOR_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LOCALIDAD_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LOTE_CN_GENERADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LOTE_CN_RECIBIDO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LOTE_NOVEDAD");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_LUGAR_TRABAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MAESTRO_ACUMULADO_DEFINIBLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MAESTRO_CUENTA_TIPO_AUXILIAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MAESTRO_DISMINUCION_GCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MAESTRO_GVA17");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MAESTRO_TRAMO_GCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MATRIZ");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MATRIZ_SUELDO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MEDIDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MEDIO_PAGO_SPS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_METODO_DEPRECIACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_METODO_SAC_GANANCIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODELO_ASIENTO_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODELO_INGRESO_SB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODELO_INGRESO_SB_COTIZ_EXTR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODELO_INGRESO_SB_CUENTAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODELO_INGRESO_SB_USUARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODELO_INTEG_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODELO_RELOJ");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODIFICACION_GANANCIAS_A_RETENER");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODULO_AGRUPACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODULO_CUENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODULO_FERIADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODULO_MEDIDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODULO_NOVEDAD");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODULO_REGLA_APROPIACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MODULO_TIPO_ASIENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MONEDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MOPRE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MOTIVO_EGRESO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MOTIVO_EGRESO_CONCEPTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MOTIVO_FICHADA_MANUAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MOTIVO_NOTA_CREDITO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MOTIVO_OTRAS_DEDUCCIONES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MULTITABLA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_MULTITABLA_COMPONENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NACIONALIDAD");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_COBRANZAS_COMP_VENC_PAGO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_COBRANZAS_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_COBRANZAS_PAGO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_COBRANZAS_VENCIMIENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_MEDIOS_PAGO_TIENDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_CLIENTES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_COMPRADORES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_COMPROBANTES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_DIRECCIONES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_ETIQUETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_HISTORIAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_ORDEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_PAGO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_PAQUETES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_PROMOCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_RELACION_FACTURA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_RELACION_REMITO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_PEDIDOS_RENGLON_ORDEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_RELACION_ARTICULO_TIENDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NEXO_RELACION_CLIENTE_TIENDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NIVEL_ESTUDIO_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NOTA_CREDITO_POR_TARJETA_REGALO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NOTA_CREDITO_PROMOCION_TARJETA_RESUMEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NOTA_TIENDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NOVEDAD");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NOVEDAD_COMPONENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NOVEDAD_GRUPO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_NOVEDAD_REGISTRADA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_OBRA_SOCIAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_OBRA_SOCIAL_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_OPERACION_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ORGANISMO_APV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ORGANISMO_GCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ORIGEN_EXPORTACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_OTRO_EMPLEO_GCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PADRON_RENTAS_BSAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PADRON_RENTAS_BSAS_VIGENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PADRON_RENTAS_EXENTOS_AGIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PADRON_RENTAS_EXENTOS_AGIP_VIGENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PADRON_RENTAS_REGIMEN_GENERAL_AGIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PADRON_RENTAS_REGIMEN_GENERAL_AGIP_VIGENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PAGO_A_CUENTA_GANANCIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PAGO_GENERAL_GCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PAIS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PAIS_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PAPEL_TRABAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PAPEL_TRABAJO_COLUMNA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PAPEL_TRABAJO_COLUMNA_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PAPEL_TRABAJO_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PAPEL_TRABAJO_RUBRO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PAPEL_TRABAJO_RUBRO_ASIGNADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PAPEL_TRABAJO_RUBRO_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_ASCII_BANCO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_ASIGNACION_FOLIO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_ASIGNACION_FOLIO_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_CIERRE_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_COBRANZAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_CONCILIACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_CONCILIACION_CONCEPTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_CONCILIACION_CUENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_EMAIL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_GBL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_INTERES_POR_MORA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_PROMOCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_RE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_SB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARAMETRO_TR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARENTESCO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PARTE_DIARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PENDIENTE_RENDICION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERCEPCION_COMPROBANTE_EXENCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERCEPCION_VENTAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERCEPCION_VENTAS_ALICUOTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERCEPCION_VENTAS_BASE_CALCULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERFIL_CIERRE_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERFIL_FACTURA_POS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERFIL_NOTA_CREDITO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERFIL_PEDIDO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERFIL_PEDIDO_USUARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERFIL_REMITO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERFIL_REVISION_PEDIDO_WEB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERIODO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERIODO_MULTITABLA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PERSONERIA_RG3668_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PLAN_OS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PLAN_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PLANIFICACION_VACACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PLANTILLA_CONCILIACION_CUPONES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_POLITICA_REDONDEO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_POLITICA_REDONDEO_RANGOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_POS_USUARIO_PREFERENCIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PRECIOS_SOLICITADOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PREFIJO_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PRESENTACION_F1357");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PRESENTACION_SIRADIG");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PRESUPUESTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PRESUPUESTO_COMPONENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PRESUPUESTO_IMPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PRESUPUESTO_PERIODO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PREV_ANORMALIDAD");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PREV_AUSENCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROCESO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROMOCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROMOCION_DESCUENTO_CANTIDAD");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROMOCION_DESCUENTO_IMPORTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROMOCION_GRUPO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROMOCION_MEDIO_PAGO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROMOCION_SUCURSAL_DESTINO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROMOCION_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROMOCION_TARJETA_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROMOCION_TARJETA_BENEFICIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROMOCION_TARJETA_HABILITADA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROVEEDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROVEEDOR_CM_JURISDICCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROVEEDOR_CUENTA_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROVIDER_NRO_ASIENTO_CORRELATIVO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROVIDER_NRO_ASIENTO_DIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROVIDER_NRO_ASIENTO_EJERCICIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROVIDER_NRO_ASIENTO_PERIODO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROVINCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PROVINCIA_ARBA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PUESTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_PUESTO_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_QUERY");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RANGO_MATRIZ");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RANGO_MATRIZ_SUELDO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_REGLA_APROPIACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RELACION_COMPROBANTES_LIBRO_BOLETAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RELACION_DTES_CONSUMO_FOLIOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RELACION_DTES_RESUMEN_VENTAS_DIARIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RELACION_EMISOR_RECEPTOR_TURISMO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RELOJ");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_REMITO_ELECTRONICO_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_ANALITICO_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_COMPROBANTE_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_CONDICION_COMPRA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_CONDICION_VENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_COTIZACION_MONEDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_IMPORTE_ANALITICO_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_IMPORTE_RESUMEN_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_MODELO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_MODELO_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_MODELO_ASIENTO_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_MODELO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_MODELO_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_RESUMEN_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_TURISMO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RENGLON_VALORIZACION_UNIDAD_ADICIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_REPORTE_FISCAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_REPORTES_CONSUMO_FOLIOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RESPONSABLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RESULTADOS_FACTURACION_AUTOMATICA_PEDIDOS_TIENDAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RESUMEN_CIERRE_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RESUMEN_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RESUMEN_TARJETA_CONCEPTO_DESCUENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RESUMEN_VENTAS_DIARIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RETENCION_COMPRAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RETENCION_COMPRAS_ESCALA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RG_3572_TIPO_OPERACION_HABITUAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RG_AFIP_GANANCIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RUBRO_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_RUBRO_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SALDO_PREVIO_ADECUACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA01");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA02");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA03");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA11");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA13");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA16");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA19");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA21");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA22");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA30");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA31");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA32");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA35");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA36");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA37");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA39");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA40");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA41");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA43");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA50");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA51");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SBA52");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SECCION_ASCII_BANCO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SECCION_ASCII_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SECCION_PREVIRED");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SERVICIO_EVENTUAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SINDICATO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SITUACION_LEGAJO_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SITUACION_REVISTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SOLICITUD_FOLIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SOLICITUD_PAGO_ELECTRONICO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA_ARTICULO_FOTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA_ARTICULO_UNIDAD_COMPRA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA_ARTICULO_UNIDAD_COMPRA_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA_AUDITORIA_BAJA_COMPROBANTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA_AUDITORIA_COSTO_COMPRA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA_CORRECCION_MONETARIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA03");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA04");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA05");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA11");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA11_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA115");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA116");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA11ITC_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA12");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA13");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA17");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA22");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA29");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA32");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA33");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA83");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_STA83_DEFECTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_ARTICULO_CT");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_CLIENTE_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_CLIENTE_OCASIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_CLIENTE_POTENCIAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_CONCEPTO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_CUENTA_SB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_DEFECTO_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_DEFECTO_CLIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_HABITUAL_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_OCASIONAL_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_PROVEEDOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_PROVEEDOR_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBAUXILIAR_REGLA_PROVEEDOR_OCASIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUBTIPO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUCURSAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_SUCURSAL_PERFIL_PRECIOS_SALDOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TABLA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TALONARIO_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TALONARIO_COMPROBANTE_INTERNO_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TALONARIO_EXCLUIDO_ACTUALIZACION_PRECIOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TALONARIO_PERFIL_REMITO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TAREA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TARJETA_ABREVIATURA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TARJETA_COEFICIENTE_CUOTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TARJETA_CONCEPTO_DESCUENTO_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TARJETA_PLAN_COEFICIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TARJETA_REGALO_CONFIGURACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TARJETA_VIGENCIA_COEFICIENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TERMINAL_POS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TERMINAL_POS_HOST");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TERMINAL_POS_NO_INTEGRADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TERMINAL_POS_TARJETA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIENDA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_ASIENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_AUXILIAR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_AUXILIAR_AUTOMATICO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_AUXILIAR_MODELO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_AUXILIAR_MODELO_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_AUXILIAR_MODELO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_AUXILIAR_MODELO_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_BIEN_IDENTIFICACION_ADICIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_COMPROBANTE_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_COMPROBANTE_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_COMPROBANTE_COMPRAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_COMPROBANTE_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_COMPROBANTE_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_COMPROBANTE_INTERNO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_COMPROBANTE_IV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_COMPROBANTE_SB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_COMPROBANTE_TALONARIO_COMPRAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_COMPROBANTE_TR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_CONCEPTO_GANANCIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_CONTABLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_CONTRATO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_COTIZACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_CUENTA_PAGO_TURISMO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_DOCUMENTACION_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_DOCUMENTACION_EXT_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_DOCUMENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_DOCUMENTO_EXTERIOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_DOCUMENTO_GV");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_EMBARGO_LEGAJO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_EMPLEADOR_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_EVENTO_DGI");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_EXCEPCION_GANANCIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_FECHA_INDICE_ORIGEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_FORMA_PAGO_TURISMO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_GASTO_CP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_HORA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_ITEM_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_ITEM_SUELDO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_MONEDA_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_MOVIMIENTO_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_PAGO_A_CUENTA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_PRESENTACION_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_PROMOCION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_RETENCION_GANANCIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_SAC");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_SERVICIO_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_TARJETA_REGALO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_UNIDAD_TURISMO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_VALORACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TIPO_VALORIZACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TMP_ACT_MASIVA_ARTICULOS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TMP_ACT_MASIVA_CLIENTES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TMP_AJUSTE_INFLACION_AF");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TMP_DETALLE_EXTRACTO_MOVIMIENTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TMP_LIQUIDACION_GCIA_AJUSTE_DESDE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TMP_LIQUIDACION_GCIA_ANUAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TMP_SIMULACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TMP_TOT_SIMULACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TOPE_BENEFICIO_GANANCIAS");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TOT_LIQUIDACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TOTAL_LISTADOR_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_CLASE_ARTICULO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_COMANDA_COBRANZA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_COMANDA_COBRANZA_DETALLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_COMANDA_COBRANZA_DETALLE_CHEQUE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_COMANDA_COBRANZA_DETALLE_CUPON");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_COMANDA_COBRANZA_DETALLE_TICKET");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_COMANDA_FACTURA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_CTA_CAJA_RESTO_CTA_TESORERIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_CUENTA_LISTA_PRECIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_FAVORITOS_PUESTO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_GRUPO_DE_CLIENTES");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_IMAGEN_ARTICULO_MOBILE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_LICENCIA_MOBILE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_MOTIVO_DE_INVITACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_MOTIVOS_BOLIVIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_ORIGEN_INFORMACION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_RELACION_FACTURA_RENDICION");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_RUBROS_POR_SECTOR");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_SESION_MOBILE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA_TERMINAL_POS_HOST");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA125");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA43");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA82");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRA91_INFORMACION_ADICIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRABAJO_PESADO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRAMO_GCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TRAMO_UTM");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TS_TAREA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_TS_TRA_PARAMETRO_NEXO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_UBICACION_BIEN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_UNIDAD_ADICIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_UNIDAD_MEDIDA_AFIP");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_UNIDAD_MONETARIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_UNIDAD_NO_MONETARIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_USER_PREFERENCE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_USUARIO_FILTRO_LEGAJO_CLOUD");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_USUARIO_PERFIL_CIERRE_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_USUARIO_PERFIL_NOTA_CREDITO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_USUARIO_PERFIL_REMITO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_USUARIO_PERFIL_REVISION_PEDIDO_WEB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_USUARIO_PUESTO_CAJA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VALOR_ADICIONAL_GCIA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VALOR_EQUIVALENCIA_LISTADOR_SU");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VALORIZACION_UNIDAD_ADICIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VARIABLE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VARIABLE_ADICIONAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VARIABLE_ASCII_BANCO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VARIABLE_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VARIABLE_COMPONENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VARIABLE_COMPONENTE_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VARIABLE_GRUPO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VARIABLE_GRUPO_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VARIABLE_IMPRESION_FISCAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VARIABLE_PARAMETRO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VARIABLE_PARAMETRO_CN");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VENDEDOR_PERFIL_REVISION_PEDIDO_WEB");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_VENTAS_COMPROBANTE_PAGO_VIRTUAL");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_XML_COMPONENTE");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ZONA_DE_ENTREGA");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ZONA_DE_ENTREGA_TRAMO_HORARIO");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_ZONA_DGI");
        }
    }
}
