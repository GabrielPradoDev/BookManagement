using BookManagement.Application.Services;
using BookManagement.Core.Interface.Repository;
using BookManagement.Core.Interface.Service;
using BookManagement.Infrastructure.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection - Services
builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddScoped<IBookService, BookServices>();
builder.Services.AddScoped<ILoanService, LoanServices>();

// Dependency Injection - Repositories
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<ILoanRepository, LoanRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookManagement");
        options.RoutePrefix = string.Empty; // Swagger na raiz
    });
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
