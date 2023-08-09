namespace Quain.Services.DTO
{
	public class PointsChangesDto
	{
		public int Amount { get; set; }

		public DateTimeOffset ChangeDate { get; set; }

		public string BillNumber { get; set; }
	}
}
