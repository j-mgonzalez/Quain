using System;
using System.Collections.Generic;

namespace Quain.Repository.Quain;

public partial class Gva53
{
    public int IdGva53 { get; set; }

    public string? Filler { get; set; }

    public decimal? CancCre { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? CanEquiV { get; set; }

    public string? CentStk { get; set; }

    public string? CodArticu { get; set; }

    public string? CodDeposi { get; set; }

    public decimal? FaltanRem { get; set; }

    public DateTime? FechaMov { get; set; }

    public decimal? ImpNetoP { get; set; }

    public decimal? ImpRePan { get; set; }

    public string NComp { get; set; } = null!;

    public string? NPartida { get; set; }

    public int? NRenglV { get; set; }

    public decimal? PorcDto { get; set; }

    public decimal? PorcIva { get; set; }

    public decimal? PppEx { get; set; }

    public decimal? PppLo { get; set; }

    public decimal? PrecioNet { get; set; }

    public decimal? PrecioPan { get; set; }

    public decimal? PrecUlcE { get; set; }

    public decimal? PrecUlcL { get; set; }

    public bool? Promocion { get; set; }

    public string TComp { get; set; } = null!;

    public string? TcompInV { get; set; }

    public string? CodClasif { get; set; }

    public decimal? ImNetPE { get; set; }

    public decimal? ImRePaE { get; set; }

    public decimal? PrecNetE { get; set; }

    public decimal? PrecPanE { get; set; }

    public decimal? PrUlcEE { get; set; }

    public decimal? PrUlcLE { get; set; }

    public decimal? Precsindto { get; set; }

    public decimal? ImporteExento { get; set; }

    public decimal? ImporteGravado { get; set; }

    public decimal? Cantidad2 { get; set; }

    public decimal? FaltanRem2 { get; set; }

    public int? IdMedidaVentas { get; set; }

    public int? IdMedidaStock2 { get; set; }

    public int? IdMedidaStock { get; set; }

    public string? UnidadMedidaSeleccionada { get; set; }

    public int? RenglPadr { get; set; }

    public string? CodArticuKit { get; set; }

    public bool? InsumoKitSeparado { get; set; }

    public DateTime? PrecioFecha { get; set; }

    public decimal? PrecioLista { get; set; }

    public decimal? PrecioBonif { get; set; }

    public decimal? PorcDtoParam { get; set; }

    public DateTime? FechaModificacionPrecio { get; set; }

    public string? UsuarioModificacionPrecio { get; set; }

    public string? TerminalModificacionPrecio { get; set; }

    public string? ItemEspectaculo { get; set; }

    public byte[] RowVersion { get; set; } = null!;
}
