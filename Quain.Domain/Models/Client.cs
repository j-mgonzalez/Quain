namespace Quain.Domain.Models
{
    using Microsoft.EntityFrameworkCore;

    [Keyless]
    public class Client
    {
        public string COD_CLIENT { get; set; }
        public string NOM_COM { get; set; }
        public string CUIT { get; set; }
        public short TIPO_DOC { get; set; }
    }
}
