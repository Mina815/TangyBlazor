using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangyBlazor_UseCases.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDTO> Create(CategoryDTO category);
        public Task<CategoryDTO> Update(CategoryDTO category);
        public Task<bool> Delete(int id);
        public Task<CategoryDTO> Get(int id);
        public IEnumerable<CategoryDTO> GetAll();
    }
}
