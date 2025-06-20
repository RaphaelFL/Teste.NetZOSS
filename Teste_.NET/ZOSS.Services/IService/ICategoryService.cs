using ZOSS.Domain.DTO;
using ZOSS.Domain.Model;

namespace ZOSS.Services.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetAllAsync();
        Task AddAsync(CategoryDto dto);
    }
}
