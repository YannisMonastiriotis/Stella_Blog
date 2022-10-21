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
        public CategoryDTO Create(CategoryDTO objdto);
        public CategoryDTO Update(CategoryDTO objdto);
        public int Delete(int id);
        public CategoryDTO Get(int id);
        public IEnumerable<CategoryDTO> GetAll();

       
    }
}
