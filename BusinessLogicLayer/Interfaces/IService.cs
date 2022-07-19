using BusinessLogicLayer.DataTransferObject.Entitys;

namespace BusinessLogicLayer.Interfaces
{
    public interface IService<T>
        where T : BaseEntityDTO
    {
        public List<T> Get();
        public List<T> Get(string email);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
