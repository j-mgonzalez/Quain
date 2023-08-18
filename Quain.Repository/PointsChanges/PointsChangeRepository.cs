namespace Quain.Repository
{
    using Microsoft.EntityFrameworkCore;
    public class PointsChangeRepository : IPointsChangeRepository
    {
        private readonly QuainPointsContext _context;

        public PointsChangeRepository(QuainPointsContext context)
        {
            _context = context;
        }

        public async Task<bool> BillNumberWasUsed(string ncomp)
         => await _context.PointsChanges.Where(p => p.BillNumber == ncomp).AnyAsync();
    }
}
