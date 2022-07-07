namespace DAL.Reponsitories.Interfaces;

public interface IGenericRepository<T> where T: class
{
    public  IEnumerable<T> GetAllDataQuery();
    public Task<string> AddAsync(T entity);
    public Task<string> AddRangeAsync(IEnumerable<T> entity);
    public Task<string> UpdateRangeAsync(IEnumerable<T> entity);
    public Task<string> RemoveRangeAsync(IEnumerable<T> entity);
    public Task<string> UpdateAsync(T entity);
    public Task<string> RemoveAsync(T entity);


}