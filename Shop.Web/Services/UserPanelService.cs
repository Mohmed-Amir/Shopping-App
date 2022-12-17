using Microsoft.AspNetCore.Components;
using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Shop.Web.Services
{
    public class UserPanelService:IUserPanelService
    {
        private readonly HttpClient httpClient;
        private readonly ProtectedSessionStorage sessionStorage;
        public UserPanelService(HttpClient _httpClient, ProtectedSessionStorage _sessionStorage)
        {
            this.httpClient = _httpClient;
            this.sessionStorage = _sessionStorage;
        }

        public async Task<bool> IsUserLoggedIn()
        {
            bool flag = false;
            var result = await sessionStorage.GetAsync<string>("userKey");
            if (result.Success)
            {
                flag = true;
            }
            return flag;
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            return await httpClient.GetJsonAsync<List<CategoryModel>>("api/user/GetCategories");
        }
        public async Task<List<ProductModel>> GetProductByCategoryId(int categoryId)
        {
            return await httpClient.GetJsonAsync<List<ProductModel>>("api/user/GetProductByCategoryId/?categoryId=" + categoryId);
        }
        public async Task<ResponseModel> RegisterUser(RegisterModel registerModel)
        {
            return await httpClient.PostJsonAsync<ResponseModel>("api/user/RegisterUser", registerModel);
        }
        public async Task<ResponseModel> LoginUser(LoginModel loginModel)
        {
            return await httpClient.PostJsonAsync<ResponseModel>("api/user/LoginUser", loginModel);
        }
        public async Task<ResponseModel> Checkout(List<CartModel> cartItems)
        {
            return await httpClient.PostJsonAsync<ResponseModel>("api/user/Checkout", cartItems);
        }
        public async Task<List<CustomerOrder>> GetOrdersByCustomerId(int customerId)
        {
            return await httpClient.GetJsonAsync<List<CustomerOrder>>("api/user/GetOrdersByCustomerId/?customerId=" + customerId);
        }
        public async Task<List<CartModel>> GetOrderDetailForCustomer(int customerId, string order_number)
        {
            return await httpClient.GetJsonAsync<List<CartModel>>("api/user/GetOrderDetailForCustomer/?customerId=" + customerId + "&order_number=" + order_number);
        }
        public async Task<List<string>> GetShippingStatusForOrder(string order_number)
        {
            return await httpClient.GetJsonAsync<List<string>>("api/user/GetShippingStatusForOrder/?order_number=" + order_number);
        }
        public async Task<ResponseModel> ChangePassword(PasswordModel passwordModel)
        {
            return await httpClient.PostJsonAsync<ResponseModel>("api/user/ChangePassword", passwordModel);
        }
    }
}
