using BookManagement.Application.Services;
using BookManagement.Core.Interface.Repository;
using BookManagement.Core.Interface.Service;
using BookManagement.Infrastructure.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra as dependências dos Services
builder.Services.AddScoped<IUserService, UserServices>();

// Registra as dependencias dos Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookManagement");
        options.RoutePrefix = string.Empty; // Swagger na raiz
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.Run();
