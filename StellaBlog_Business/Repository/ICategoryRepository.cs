using Stell_Blog_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Stella_Blog_Business.Repository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDTO> Create(CategoryDTO objdto);
        public Task<CategoryDTO> Update(CategoryDTO objdto);
        public Task<int> Delete(int id);
        public Task<CategoryDTO> Get(int id);
        public Task<IEnumerable<CategoryDTO>> GetAll();

       
    }
}
