

namespace TechStoreWebApp.Services
{
    public class BrandService : BaseService<SharedModels.Brand>
    {
        public BrandService() : base(@"http://localhost:8235/api/Brand/")
        {
            
        }
    }
}
