
namespace TechStoreWebApp.Services
{
    public class CategoriesService : BaseService<SharedModels.Category>
    {
        public CategoriesService() : base(@"http://localhost:8235/api/Categories/")
        {

        }

    }
}
