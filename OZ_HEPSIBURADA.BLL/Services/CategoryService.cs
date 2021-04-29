using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OZ_HEPSIBURADA.DATA.Model_Entity;
using OZ_HEPSIBURADA.DAL.Repository;
using OZ_HEPSIBURADA.DAL.UnifOfWork;
using OZ_HEPSIBURADA.BLL.Model_DTO;

namespace OZ_HEPSIBURADA.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        // UOW design pattern prevents every action related to the database 
        // from being reflected on the database instantaneously in our software application and
        // accordingly allows all actions to be accumulated and performed over a single connection at a time, 
        // thus minimizing database costs considerably.
        private readonly IUnitOfWork IUOW;
        private readonly IRepository<Category> categoryRepo;

        public CategoryService(IUnitOfWork _iuow)
        {
            // old: categoryRepo = new Repository<Category>();
            IUOW = _iuow;
            categoryRepo = IUOW.GetRepository<Category>();
        }

        public List<CategoryDTO> GetAllCategoryDTO()
        {
            return categoryRepo.GetAllEntity().Select(x => new CategoryDTO()
            {
                DTOId = x.CategoryId,
                DTODesc = x.CategoryDesc,
                DTOName = x.CategoryName
            }).ToList();
        }

        public CategoryDTO GetCategoryDTOById(int id)
        {
            return categoryRepo.GetAllEntity().Where(x => x.CategoryId == id).Select(x =>
                new CategoryDTO()
                {
                    DTOId = x.CategoryId,
                    DTODesc = x.CategoryDesc,
                    DTOName = x.CategoryName
                }).FirstOrDefault();
        }

        public void InsertCategoryDTO(CategoryDTO inserted)
        {
            Category newCategory = new Category()
            {
                CategoryName = inserted.DTOName,
                CategoryDesc = inserted.DTODesc,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                IsActive = true
            };

            categoryRepo.Insert(newCategory);
        }

        public void UpdateCategoryDTO(CategoryDTO updated)
        {
            Category toBeUpdated = categoryRepo.GetEntityById(updated.DTOId);

            toBeUpdated.CategoryName = updated.DTOName;
            toBeUpdated.CategoryDesc = updated.DTODesc;
            toBeUpdated.DateModified = DateTime.Now;

            categoryRepo.Update(toBeUpdated);
        }

        public void SoftDeleteCategoryDTO(int softDeletedId)
        {
            Category toBeSoftDeleted = categoryRepo.GetEntityById(softDeletedId);

            toBeSoftDeleted.IsActive = false;
            toBeSoftDeleted.DateModified = DateTime.Now;

            categoryRepo.Update(toBeSoftDeleted);
        }

        public void HardDeleteCategoryDTO(int hardDeletedId)
        {
            Category toBeHardDeleted = categoryRepo.GetEntityById(hardDeletedId);

            categoryRepo.Delete(toBeHardDeleted);
        }
    }
}
