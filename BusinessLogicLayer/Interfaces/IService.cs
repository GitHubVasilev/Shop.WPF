using BusinessLogicLayer.DataTransferObject.Entitys;

namespace BusinessLogicLayer.Interfaces
{
    public interface IService<T>
        where T : BaseEntityDTO
    {
        Task<List<T>> Get();
        Task<List<T>> Get(string email);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Crear();
    }
}
