using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Logic.Services
{
    public class AdminService : IAdminService
    {
        private readonly ShoppingCartDBContext _dbContext = null;
        public AdminService(ShoppingCartDBContext appDbContext)
        {
            this._dbContext = appDbContext;
        }
        public ResponseModel AdminLogin(LoginModel loginModel)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                var userData = _dbContext.AdminInfos.Where(x => x.Email == loginModel.EmailId).FirstOrDefault();
                if (userData != null)
                {
                    if (userData.Password == loginModel.Password)
                    {
                        response.Status = true;
                        response.Message = Convert.ToString(userData.Id) + "|" + userData.Name + "|" + userData.Email;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Your Password is Incorrect";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "Email not registered. Please check your Email Id";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "An Error has occurred. Please try again !";

                return response;
            }
        }
        public CategoryModel SaveCategory(CategoryModel newCategory)
        {
            try
            {
                Category _category = new Category();
                _category.Name = newCategory.Name;
                _dbContext.Add(_category);
                _dbContext.SaveChanges();
                return newCategory;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<CategoryModel> GetCategories()
        {
            var data = _dbContext.Categories.ToList();
            List<CategoryModel> _categoryList = new List<CategoryModel>();
            foreach (var c in data)
            {
                CategoryModel _categoryModel = new CategoryModel();
                _categoryModel.Id = c.Id;
                _categoryModel.Name = c.Name;
                _categoryList.Add(_categoryModel);
            }
            return _categoryList;
        }
        public bool UpdateCategory(CategoryModel categoryToUpdate)
        {
            bool flag = false;
            var _category = _dbContext.Categories.Where(x => x.Id == categoryToUpdate.Id).First();
            if (_category != null)
            {
                _category.Name = categoryToUpdate.Name;
                _dbContext.Categories.Update(_category);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public bool DeleteCategory(CategoryModel categoryToDelete)
        {
            bool flag = false;
            var _category = _dbContext.Categories.Where(x => x.Id == categoryToDelete.Id).First();
            if (_category != null)
            {
                _dbContext.Categories.Remove(_category);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public List<ProductModel> GetProducts()
        {
            List<Category> categoryData = _dbContext.Categories.ToList();
            List<Product> productData = _dbContext.Products.ToList();
            List<ProductModel> _productList = new List<ProductModel>();
            foreach (var p in productData)
            {
                ProductModel _productModel = new ProductModel();
                _productModel.Id = p.Id;
                _productModel.Name = p.Name;
                _productModel.Price = p.Price;
                _productModel.Stock = p.Stock;
                _productModel.ImageUrl = p.ImageUrl;
                _productModel.CategoryId = p.CategoryId;
                _productModel.CategoryName = categoryData.Where(x => x.Id == p.CategoryId).Select(x => x.Name).FirstOrDefault();
                _productList.Add(_productModel);
            }

            return _productList;
        }
        public bool DeleteProduct(ProductModel productToDelete)
        {
            bool flag = false;
            var _product = _dbContext.Products.Where(x => x.Id == productToDelete.Id).First();
            if (_product != null)
            {
                _dbContext.Products.Remove(_product);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public int GetNewProductId()
        {
            try
            {
                int nextProductId = _dbContext.Products.ToList().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
                return nextProductId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ProductModel SaveProduct(ProductModel newProduct)
        {
            try
            {
                Product _product = new Product();
                _product.Name = newProduct.Name;
                _product.Price = newProduct.Price;
                _product.ImageUrl = newProduct.ImageUrl;
                _product.CategoryId = newProduct.CategoryId;
                _product.Stock = newProduct.Stock;
                _dbContext.Add(_product);
                _dbContext.SaveChanges();
                return newProduct;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<StockModel> GetProductStock()
        {
            List<StockModel> productStock = new List<StockModel>();

            List<Category> categoryData = _dbContext.Categories.ToList();
            List<Product> productData = _dbContext.Products.ToList();
            foreach (var p in productData)
            {
                StockModel _productModel = new StockModel();
                _productModel.Id = p.Id;
                _productModel.Name = p.Name;
                _productModel.Stock = p.Stock;
                _productModel.CategoryName = categoryData.Where(x => x.Id == p.CategoryId).Select(x => x.Name).FirstOrDefault();
                productStock.Add(_productModel);
            }

            return productStock;
        }
        public bool UpdateProductStock(StockModel stock)
        {
            bool flag = false;
            var _product = _dbContext.Products.Where(x => x.Id == stock.Id).First();
            if (_product != null)
            {
                _product.Stock = stock.Stock + stock.NewStock;
                _dbContext.Products.Update(_product);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }
    }
}
