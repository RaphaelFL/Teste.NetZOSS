using ZOSS.Domain.DTO;
using ZOSS.Domain.Model;
using ZOSS.Repository.IRepository;
using ZOSS.Services.IService;

namespace ZOSS.Services.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
        {
            try
            {
                var categories = await _categoryRepo.GetAllAsync();

                return categories.Select(c => new CategoryResponseDto
                {
                    Id = c.Id,
                    Name = c.Name
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar categorias.", ex);
            }
        }

        public async Task AddAsync(CategoryDto dto)
        {
            try
            {
                var category = new Category(dto.Name);
                await _categoryRepo.AddAsync(category);
                await _categoryRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar categoria.", ex);
            }
        }
    }
}
