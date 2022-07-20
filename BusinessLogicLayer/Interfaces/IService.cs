using BusinessLogicLayer.DataTransferObject.Entitys;

namespace BusinessLogicLayer.Interfaces
{
    public interface IService<T>
        where T : BaseEntityDTO
    {
        List<T> Get();
        List<T> Get(string email);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Crear();
    }
}
