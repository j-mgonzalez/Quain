namespace Quain.Repository
{
    public interface IPointsChangeRepository
    {
        Task<bool> BillNumberWasUsed(string ncomp);
    }
}