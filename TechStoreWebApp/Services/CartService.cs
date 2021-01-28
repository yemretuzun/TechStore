

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SharedModels;

namespace TechStoreWebApp.Services
{
    public class CartService : BaseService<SharedModels.Cart>
    {
        public CartService() : base(@"/api/Cart/")
        {
        }

        //http://localhost:8235/api/Cart/AddProduct?cartId=ccc&productId=pp&quantity=1
        public async Task<bool> AddProduct(string cartId, string productId, uint quantity = 1)
        {
            var res = await Client.PatchAsync($"AddProduct?cartId={cartId}&productId={productId}&quantity={quantity}", new StringContent(""));

            return res.StatusCode == HttpStatusCode.OK;
        }


        //http://localhost:8235/api/Cart/RemoveProduct?cartId=1&productId=2&quantity=1
        public async Task<bool> RemoveProduct(string cartId, string productId, uint quantity = 1)
        {
            var res = await Client.PatchAsync($"RemoveProduct?cartId={cartId}&productId={productId}&quantity={quantity}", new StringContent(""));

            return res.StatusCode == HttpStatusCode.OK;
        }

        //http://localhost:8235/api/Cart/GetUserCart?userId=5fcabc82834e02062c0c63f1
        public async Task<Cart> GetUserCart(string userId)
        {
            var result = await Client.Get_Async<Cart>($"GetUserCart?userId={userId}");
            return result;
        }
    }
}
