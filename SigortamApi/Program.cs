using DAL;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Service.Companies;
using Service.File;
using Service.PaymentDetails;
using Service.Roles;
using Service.Statuses;
using Service.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IFileDal, FileDal>();
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<ICompanyDal, CompanyDal>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddScoped<IPaymentDetailDal, PaymentDetailDal>();
builder.Services.AddScoped<IPaymentDetailService, PaymentDetailService>();

builder.Services.AddScoped<IFileTypeDal, FileTypeDal>();
builder.Services.AddScoped<IFileTypeService, FileTypeService>();

builder.Services.AddScoped<IRoleDal, RoleDal>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IStatusDal, StatusDal>();
builder.Services.AddScoped<IStatusService, StatusService>();

builder.Services.AddDbContext<ApplicationContext>(conf =>
{
    conf.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));
    //"Data Source=localhost\\SQLEXPRESS;Initial Catalog=Sigortam;Integrated Security=True;"
    conf.EnableSensitiveDataLogging();
});

var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
