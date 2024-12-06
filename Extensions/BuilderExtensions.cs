using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Service;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;
using PublishingHouse.DAL.Repository;
using PublishingHouse.WebApi.Auth.Impl;
using PublishingHouse.WebApi.Auth.Interface;
using PublishingHouse.WebApi.Dto.AuthDto;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddDbContextServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<PublishingHouseDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CodeFirstConnectionString"));
                options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            });

            builder.Services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CodeFirstConnectionString"));
                options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            });
        }
        public static void AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBatchPrintService, BatchPrintService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerTypeService, CustomerTypeService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IOrderBookService, OrderBookService>();
            builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
            builder.Services.AddScoped<IPositionService, PositionService>();
            builder.Services.AddScoped<IPrintOrderService, PrintOrderService>();
            builder.Services.AddScoped<IProductionService, ProductionService>();
            builder.Services.AddScoped<IProductionTypeService, ProductionTypeService>();
            builder.Services.AddScoped<IQualityMarkService, QualityMarkService>();
            builder.Services.AddScoped<IRegionService, RegionService>();
            builder.Services.AddScoped<IOrderRequestService, OrderRequestService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
        }

        public static void AddModels(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBatchPrint, BatchPrint>();
            builder.Services.AddScoped<IBook, Book>();
            builder.Services.AddScoped<ICity, City>();
            builder.Services.AddScoped<ICustomer, Customer>();
            builder.Services.AddScoped<ICustomerType, CustomerType>();
            builder.Services.AddScoped<IEmployee, Employee>();
            builder.Services.AddScoped<IOrderBook, OrderBook>();
            builder.Services.AddScoped<IOrderStatus, OrderStatus>();
            builder.Services.AddScoped<IPosition, Position>();
            builder.Services.AddScoped<IPrintOrder, PrintOrder>();
            builder.Services.AddScoped<IProduction, Production>();
            builder.Services.AddScoped<IProductionType, ProductionType>();
            builder.Services.AddScoped<IQualityMark, QualityMark>();
            builder.Services.AddScoped<IRegion, Region>();
            builder.Services.AddScoped<IOrderRequest, OrderRequest>();
        }

        public static void AddAuthServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICustomerRegisterService, CustomerRegisterService>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
        }

        public static void AddMappers(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMapper<ICity, CityRequestDto, CityResponseDto>, CityMapper>();
            builder.Services.AddScoped<IMapper<IBatchPrint, BatchPrintRequestDto, BatchPrintResponseDto>, BatchPrintMapper>();
            builder.Services.AddScoped<IMapper<IBook, BookRequestDto, BookResponseDto>, BookMapper>();
            builder.Services.AddScoped<IMapper<ICustomer, CustomerRequestDto, CustomerResponseDto>, CustomerMapper>();
            builder.Services.AddScoped<IMapper<ICustomerType, CustomerTypeRequestDto, CustomerTypeResponseDto>, CustomerTypeMapper>();
            builder.Services.AddScoped <IMapper<IEmployee, EmployeeRequestDto, EmployeeResponseDto>, EmployeeMapper> ();
            builder.Services.AddScoped<IMapper<IOrderBook, OrderBookRequestDto, OrderBookResponseDto>, OrderBookMapper>();
            builder.Services.AddScoped<IMapper<IOrderStatus, OrderStatusRequestDto, OrderStatusResponseDto>, OrderStatusMapper>();
            builder.Services.AddScoped<IMapper<IPosition, PositionRequestDto, PositionResponseDto>, PositionMapper>();
            builder.Services.AddScoped<IMapper<IPrintOrder, PrintOrderRequestDto, PrintOrderResponseDto>, PrintOrderMapper>();
            builder.Services.AddScoped<IMapper<IProduction, ProductionRequestDto, ProductionResponseDto>, ProductionMapper>();
            builder.Services.AddScoped<IMapper<IProductionType, ProductionTypeRequestDto, ProductionTypeResponseDto>, ProductionTypeMapper>();
            builder.Services.AddScoped<IMapper<IQualityMark, QualityMarkRequestDto, QualityMarkResponseDto>, QualityMarkMapper>();
            builder.Services.AddScoped<IMapper<IRegion, RegionRequestDto, RegionResponseDto>, RegionMapper>();
            builder.Services.AddScoped<IMapper<IOrderRequest, OrderRequestRequestDto, OrderRequestResponseDto>, OrderRequestMapper>();

            builder.Services.AddScoped<IUserMapper<ICustomer, RegisterCustomerRequestDto>, CustomerMapper>();
        }

        public static void AddIdentityServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("PublishingHouse")
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;
                options.User.RequireUniqueEmail = true;
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    AuthenticationType = "Jwt",
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
                };
            });
        }
    }
}
