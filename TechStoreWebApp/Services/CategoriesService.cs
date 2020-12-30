
namespace TechStoreWebApp.Services
{
    /// <summary>
    /// Database ile kategori işlemlerini gerçekleştirir
    /// </summary>
    public class CategoriesService : BaseService<SharedModels.Category>
    {
        public CategoriesService() : base(@"/api/Categories/")
        {

        }

    }
}
