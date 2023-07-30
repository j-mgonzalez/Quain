namespace Quain.Domain.Models
{
    using Microsoft.EntityFrameworkCore;

    [Keyless]
    public class Sale
    {
        public string N_COMP { get; set; }

        public decimal TotalFacturado { get; set; }
    }
}
