
using _3_Data;

namespace _3_Repository.Query_Objects
{
    public class GetAllSoldOrSpottedUniqueGameIdsQuery
    {
        private readonly AppDbContext _context;

        public GetAllSoldOrSpottedUniqueGameIdsQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HashSet<int>> ExecuteQueryAsync()
        {
            var soldCartdrigesQuery = _context.SoldCartdriges.Select(s => s.IdGame);
            var spottedCartdrigesQuery = _context.Spots.Select(s => s.IdGame);

            var combinedQuery = soldCartdrigesQuery.Union(spottedCartdrigesQuery).Distinct();

            return combinedQuery.ToHashSet();
        }
    }
}
