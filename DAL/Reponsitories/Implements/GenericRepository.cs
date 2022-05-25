using DAL.DBcontext;
using DAL.Reponsitories.Interfaces;

namespace DAL.Reponsitories.Implements;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly Context _context;

    public GenericRepository(Context context)
    {
        _context = context?? throw new ArgumentNullException(nameof(context));
    }

    public IQueryable<T> GetAllDataQuery()
    {
        throw new NotImplementedException();
    }

    public void AddDataCommand(T entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateDataCommand(T entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteDataCommand(T entity)
    {
        throw new NotImplementedException();
    }
}