using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OZ_HEPSIBURADA.DAL.Repository;
using OZ_HEPSIBURADA.BLL.Model_DTO;

namespace OZ_HEPSIBURADA.BLL.Services
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetAllCategoryDTO();
        CategoryDTO GetCategoryDTOById(int id);
        void InsertCategoryDTO(CategoryDTO inserted);
        void UpdateCategoryDTO(CategoryDTO updated);
        void SoftDeleteCategoryDTO(int softDeletedId);
        void HardDeleteCategoryDTO(int hardDeletedId);
    }
}
