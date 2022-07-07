using DAL.DBcontext;
using DAL.Entities;
using DAL.Reponsitories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace DAL.Reponsitories.Implements;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly Context _context;

    public GenericRepository(Context context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }



    public  IEnumerable<T> GetAllDataQuery()
    {
        //var data = _context.Set<T>().Where(p => p.GetType() == typeof(T));
        var data =  _context.Set<T>().AsNoTracking();
        return data;
    }

    public async Task<string> AddAsync(T entity)
    {
         await _context.AddAsync<T>(entity);
        await _context.SaveChangesAsync();
        return "Add data successfully";
    }
    public async Task<string> AddRangeAsync(IEnumerable<T> entity)
    {
        await _context.Set<T>().AddRangeAsync(entity);
        await _context.SaveChangesAsync();
        return "Add data successfully";
    }
    public async Task<string> UpdateRangeAsync(IEnumerable<T> entity)
    {
         _context.Set<T>().UpdateRange(entity);
        await _context.SaveChangesAsync();
        return "Update data successfully";
    }
    public async Task<string> RemoveRangeAsync(IEnumerable<T> entity)
    {
         _context.Set<T>().RemoveRange(entity);
        await _context.SaveChangesAsync();
        return "Remove data successfully";
    }

    public async Task<string> UpdateAsync(T entity)
    {
        _context.Update<T>(entity);
        _context.SaveChangesAsync();
        return "Update data successfully";
    }

    public async Task<string> RemoveAsync(T entity)
    {
        _context.Remove<T>(entity);
        await _context.SaveChangesAsync();
        return "Remove data successfully";

    }
}