namespace Quain.Services.DTO
{
    using Newtonsoft.Json;

    public class CustomerDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; private set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "cuit")]
        public string CUIT { get; set; }

        [JsonProperty(PropertyName = "codClient")]
        public string CodClient { get; set; }

        [JsonProperty(PropertyName = "points")]
        public PointsDto Points { get; set; }
    }
}
