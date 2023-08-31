using WebApiCoreBasics;
using WebApiCoreBasics.DataLayer;
using WebApiCoreBasics.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Stateless lightweight services -> Recommended lifetime: Transient
builder.Services.AddTransient<IPasswordService, PasswordService>();
builder.Services.AddTransient<IUserDataLayer, UserDataLayer>();
builder.Services.AddTransient<IAccountDataLayer, AccountDataLayer>();
builder.Services.AddTransient<ITransactionDataLayer, TransactionDataLayer>();

//Statefull, 1 instance per 1 HTTP request  -> Recommended lifetime: Scoped
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionIndexer, TransactionIndexer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
