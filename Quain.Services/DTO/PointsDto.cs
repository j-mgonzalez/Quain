namespace Quain.Services.DTO
{
    using Newtonsoft.Json;

    public class PointsDto
    {
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }
    }
}
