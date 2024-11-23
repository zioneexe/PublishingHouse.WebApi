using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Service;
using PublishingHouse.DAL;
using PublishingHouse.DAL.Repository;

namespace PublishingHouse.WebApi.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddDbContextServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<PublishingHouseDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CodeFirstConnectionString"));
            });
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IBatchPrintService, BatchPrintService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerTypeService, CustomerTypeService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IOrderBookService, OrderBookService>();
            builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
            builder.Services.AddScoped<IPositionService, PositionService>();
            builder.Services.AddScoped<IPrintOrderService, PrintOrderService>();
            builder.Services.AddScoped<IProductionService, ProductionService>();
            builder.Services.AddScoped<IProductionTypeService, ProductionTypeService>();
            builder.Services.AddScoped<IQualityMarkService, QualityMarkService>();
            builder.Services.AddScoped<IRegionService, RegionService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();
        }

        public static void AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IBatchPrintRepository, BatchPrintRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IOrderBookRepository, OrderBookRepository>();
            builder.Services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            builder.Services.AddScoped<IPositionRepository, PositionRepository>();
            builder.Services.AddScoped<IPrintOrderRepository, PrintOrderRepository>();
            builder.Services.AddScoped<IProductionRepository, ProductionRepository>();
            builder.Services.AddScoped<IProductionTypeRepository, ProductionTypeRepository>();
            builder.Services.AddScoped<IQualityMarkRepository, QualityMarkRepository>();
            builder.Services.AddScoped<IRegionRepository, RegionRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
