namespace Quain.Services.Inputs
{
    public class PointsInput
    {
        public int PointsToUse { get; set; }

        public string CodClient { get; set; }

        public void SetCodClient(string codClient) => CodClient = codClient;
    }
}
