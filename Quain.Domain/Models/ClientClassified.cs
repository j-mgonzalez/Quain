namespace Quain.Domain.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;

    [Keyless]
    public class ClientClassified
    {
        [AllowNull]
        public string COD_CLIENT { get; set; }
        [AllowNull]
        public string RAZON_SOCI { get; set; }
        [AllowNull]
        public string DESCRIP { get; set; }
        [Column("PUNTOS (Adic.)"), AllowNull]
        public string Puntos_Adic { get; set; }
    }
}
