
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stell_Blog_Models;
using Stella_Blog_DataAccess;
using Stella_Blog_DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stella_Blog_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task <CategoryDTO> Create(CategoryDTO objdto)
        {
            var obj = _mapper.Map <CategoryDTO,Category>(objdto);
           obj.CreatedDate = DateTime.Now;

            var addedObj = _db.Categories.Add(obj);
           await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        public async Task <int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if(obj!= null)
            {
                _db.Categories.Remove(obj);
                await _db.SaveChangesAsync();
                return obj.Id;
            }
            return 0;
        }

        public async Task <CategoryDTO> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                var dto = _mapper.Map<Category, CategoryDTO>(obj);
                return dto;
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO objdto)
        {
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(u => u.Id == objdto.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = objdto.Name;
                _db.Categories.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            return objdto;
        }
    }
}
