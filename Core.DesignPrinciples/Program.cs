using Core.DesignPrinciples.Contracts;
using Core.DesignPrinciples.Helpers;
using Core.DesignPrinciples.Services;
using Core.DesignPrinciples.Services.Notification;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IInventoryService, InventoryService>();

builder.Services.AddSingleton<IOrderService, OrderService>();

builder.Services.AddSingleton<INotificationSystem, NotificationSystem>();
builder.Services.AddSingleton<EmailNotification>();
builder.Services.AddSingleton<SMSNotification>();
builder.Services.AddSingleton<PushNotification>();
builder.Services.AddSingleton<INotificationSystemFactory, NotificationSystemFactory>();

builder.Services.AddTransient<IOrderHelper, OrderHelper>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", () => "API Running");

app.MapControllers();

app.Run();
