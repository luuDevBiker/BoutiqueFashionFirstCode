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



    public List<T> GetAllDataQuery()
    {
        //var data = _context.Set<T>().Where(p => p.GetType() == typeof(T));
        var data =  _context.Set<T>().AsNoTracking().ToList();
        return data;
    }

    public void AddDataCommand(T entity)
    {
        _context.Add<T>(entity);
        _context.SaveChanges();
    }

    public void UpdateDataCommand(T entity)
    {
        _context.Update<T>(entity);
        _context.SaveChanges();
    }

    public void DeleteDataCommand(T entity)
    {
        _context.Remove<T>(entity);
        _context.SaveChanges();
    }
}