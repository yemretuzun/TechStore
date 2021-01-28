
namespace TechStoreWebApp.Services
{
    public class Services
    {
        public UserService UserService;
        public ProductsService ProductService;
        public CredentialService CredentialService;
        public CredentialTypesService CredentialTypesService;
        public RoleService RoleService;
        public RolePermissionService RolePermissionService;
        public PermissionService PermissionService;
        public UserRoleService UserRoleService;
        public CartService CartService;

        public Services()
        {
            UserService = new UserService();
            ProductService = new ProductsService();
            CredentialService = new CredentialService();
            CredentialTypesService = new CredentialTypesService();
            RoleService = new RoleService();
            RolePermissionService = new RolePermissionService();
            PermissionService = new PermissionService();
            UserRoleService = new UserRoleService();
            CartService = new CartService();
        }
    }
}
