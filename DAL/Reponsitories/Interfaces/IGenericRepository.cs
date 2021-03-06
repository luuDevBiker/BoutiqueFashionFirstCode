namespace DAL.Reponsitories.Interfaces;

public interface IGenericRepository<T> where T: class
{
    public List<T> GetAllDataQuery();
    public void AddDataCommand(T entity);
    public void UpdateDataCommand(T entity);
    public void DeleteDataCommand(T entity);
    

}