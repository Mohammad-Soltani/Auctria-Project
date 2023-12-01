namespace AuctriaProject.Infrastructure.Interfaces
{
    public interface ISharedContext
    {
        Task<IEnumerable<T>> QueryAsync<T>(string query, object queryParameters = null);
        Task<int> ExecuteAsync(string query, object queryParameters, int? commandTimeout = null);
    }
}
