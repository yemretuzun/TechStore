

namespace TechStoreWebApp.Services
{
    public class BrandService : BaseService<SharedModels.Brand>
    {
        public BrandService() : base(@"/api/Brand/")
        {
            
        }
    }
}
