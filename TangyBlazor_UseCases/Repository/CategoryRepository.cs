using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangyBlazor_DataAccess.Data;
using TangyBlazor_UseCases.Mapper;
using TangyBlazor_UseCases.Repository.IRepository;

namespace TangyBlazor_UseCases.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDBContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CategoryDTO> Create(CategoryDTO ObjDTO)
        {
            var category = _mapper.Map<CategoryDTO, Category>(ObjDTO);
            category.CreatedDate = DateTime.Now;
            await _db.categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDTO>(category);    

        }

        public async Task<bool> Delete(int id)
        {
            var category = await _db.categories.Where(u => u.Id == id).FirstOrDefaultAsync();
            if(category != null)
            {
                _db.categories.Remove(category);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var category = await _db.categories.Where(u => u.Id == id).FirstOrDefaultAsync();
            if(category != null)
            {
                return _mapper.Map<Category, CategoryDTO>(category);
            }
            return new CategoryDTO();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            try
            {
                return _mapper.Map<IEnumerable<Category>,IEnumerable<CategoryDTO>>(_db.categories);

            }
            catch(Exception ex)
            {
                var x = ex.Message;
                return Enumerable.Empty<CategoryDTO>();
            }
        }

        public async Task<CategoryDTO> Update(CategoryDTO obj)
        {
            var categoryFromDb = await _db.categories.Where(u => u.Id == obj.Id).FirstOrDefaultAsync();
            if(categoryFromDb != null)
            {
                categoryFromDb.Name = obj.Name;
                _db.categories.Update(categoryFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category,CategoryDTO>(categoryFromDb);
            }
            return obj;
        }
    }
}
