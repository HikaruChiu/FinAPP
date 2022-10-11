using System.Data;
namespace FinAPP.Repository.Interface
{
    public interface IDapper
    {
        IDbConnection OpenConnection();

        Task<Tuple<IEnumerable<dynamic>, int>> FindWithOffsetFetch(string sql, object parameters, int pageIndex, int pageSize, List<SortDescriptor> sortings);

    }
}
