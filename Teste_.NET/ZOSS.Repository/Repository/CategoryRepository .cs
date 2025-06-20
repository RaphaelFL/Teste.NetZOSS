using System.Collections.Generic;
using System.Threading.Tasks;
using ZOSS.Domain.Model;
using ZOSS.Repository.IRepository;
using ZOSS.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace ZOSS.Repository.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Categorias.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar categoria com ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                return await _context.Categorias.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todas as categorias.", ex);
            }
        }

        public async Task AddAsync(Category category)
        {
            try
            {
                await _context.Categorias.AddAsync(category);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar categoria.", ex);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar alterações no banco de dados.", ex);
            }
        }
    }
}
