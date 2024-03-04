using BankApp.Web.Data.Context;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

// BankContext
// IUow -> Uow
// IUserMapper -> UserMapper
// IAccountMapper -> AccountMapper

// create a web aplication builder
var builder = WebApplication.CreateBuilder(args);

// using a context for db processes and adding that services.
// builder take that services and starts before application run
builder.Services.AddDbContext<BankContext>(options =>
{
    options.UseSqlServer("server= (localdb)\\mssqllocaldb; database= BankDb; integrated security= true;");
});

// give us an UserRepository when every time we implement IUserRepository
// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IAccountRepository, AccountRepository>();
// builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// we do not need above with Uow 
// AddScoped, AddTranisent, AddSingleton functions are language based Dependency Injection shorteners
// if sees an interface call than callback it's class
builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IAccountMapper, AccountMapper>();


// setup and use controllers and views (startup.cs/configureservices)
builder.Services.AddControllersWithViews();

// app instance
var app = builder.Build();

// wwwroot publicly available
app.UseStaticFiles();

// use specific directory and files for installing external packages(bootstrap, jquery etc.)
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider= new PhysicalFileProvider(
    Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
    RequestPath= "/node_modules"
});

// matches request to an endpoint
app.UseRouting();

// executes the matched endpoint
// default -> Controller => Home, Action => Index, id? => is nullable
app.UseEndpoints(endpoints =>
{ 
    endpoints.MapDefaultControllerRoute(); 
});

app.Run();
