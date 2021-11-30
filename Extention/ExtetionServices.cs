using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using ApiProductManagment.Repository.RepositoryBase;
using ApiProductManagment.Services;
using ApiProductManagment.Services.InterfaceServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Extention
{
    public static class ExtetionServices
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UsersRepository>();

            services.AddScoped(typeof(IRepositoryBase<CupBoard>), typeof(RepositoryBase<CupBoard>));
            services.AddTransient<IRepositoryCupboard, RepositoryCupBoard>();

            services.AddTransient<IUserXCupBoardRepository, UserXCupBoardRepository>();
            services.AddTransient<IUserXShoppingRepository, UserXShoppingRepository>();

            services.AddScoped(typeof(IRepositoryBase<Category>), typeof(RepositoryBase<Category>));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryXProductRepository, CategoryXProductRepository>();

            services.AddScoped(typeof(IRepositoryBase<Product>), typeof(RepositoryBase<Product>));
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddScoped(typeof(IRepositoryBase<Trademark>), typeof(RepositoryBase<Trademark>));
            services.AddTransient<ITrademarkRepository, TradeMarkRepository>();

            services.AddScoped(typeof(IRepositoryBase<ShoppingList>), typeof(RepositoryBase<ShoppingList>));
            services.AddTransient<IShoppingListRepository, ShoppingListRepository>();
            
            services.AddScoped(typeof(IRepositoryBase<CupBoardDetail>), typeof(RepositoryBase<CupBoardDetail>));
            services.AddTransient<ICupboardDetailRepository, CupboardDetailRepository>();

            services.AddTransient<ICupboardService, CupBoardService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ITrademarkService, TrademarkService>();
            services.AddTransient<IShoppingListService, ShoppingListService>();
            services.AddTransient<ICupboardDetailService, CupboardDetailService>();

            return services;
        }

        public static IServiceCollection AgregarOpsiones(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers(option =>
            {

            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
            return services;
        }



    }
}
