namespace Quain.Domain.Models
{
    using Microsoft.EntityFrameworkCore;

    [Keyless]
    public class Sale
    {
        public string N_COMP { get; set; }

        public int Importe { get; set; }
    }
}
