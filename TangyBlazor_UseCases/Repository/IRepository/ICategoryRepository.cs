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
        public CategoryDTO Create(CategoryDTO category);
        public CategoryDTO Update(CategoryDTO category);
        public CategoryDTO Delete(int id);
        public CategoryDTO Get(int id);
        public IEnumerable<CategoryDTO> GetAll();
    }
}
