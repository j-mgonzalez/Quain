namespace Quain.Services.DTO
{
    using Newtonsoft.Json;
	using Quain.Domain.Models;

    public class PointsDto
    {
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "pointsChanges")]
		public IEnumerable<PointsChangesDto> PointsChanges { get; set; }
	}
}
