using DPA.Shopping.DOMAIN.Core.Entities;

namespace DPA.Shopping.DOMAIN.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<bool> Insert(Category category);
        Task<bool> Update(Category category);
    }
}