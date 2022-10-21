
using AutoMapper;
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
        public CategoryDTO Create(CategoryDTO objdto)
        {
            var obj = _mapper.Map <CategoryDTO,Category>(objdto);
           obj.CreatedDate = DateTime.Now;

            var addedObj = _db.Categories.Add(obj);
            _db.SaveChanges();

            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        public int Delete(int id)
        {
            var obj = _db.Categories.FirstOrDefault(u => u.Id == id);
            if(obj!= null)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return obj.Id;
            }
            return 0;
        }

        public CategoryDTO Get(int id)
        {
            var obj = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                var dto = _mapper.Map<Category, CategoryDTO>(obj);
                return dto;
            }
            return new CategoryDTO();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public CategoryDTO Update(CategoryDTO objdto)
        {
            var objFromDb = _db.Categories.FirstOrDefault(u => u.Id == objdto.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = objdto.Name;
                _db.Categories.Update(objFromDb);
                _db.SaveChanges();
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            return objdto;
        }
    }
}
