using Autofac;
using Autofac.Extensions.DependencyInjection;
using BPMCase.DataAccess.Context;
using BPMCase.Services.ApprovalServices;
using BPMCase.Services.EvaluationServices;
using BPMCase.Services.NotificationService;
using BPMCase.Services.WorkflowServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterType<EFPersistenceContext>().As<IPersistenceContext>().InstancePerLifetimeScope();

});
IConfiguration configuration = builder.Configuration;


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(
        configuration.GetConnectionString("Default"),
        sqlServerOptions =>
        {
            sqlServerOptions.CommandTimeout(3600);
        });
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

builder.Services.AddScoped<IApprovalService, ApprovalService>();
builder.Services.AddScoped<IEvaluationService, EvaluationService>();
builder.Services.AddScoped<IWorkflowService,WorkflowService>();
builder.Services.AddScoped<INotifService, NotifService>();  

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

app.MapControllers();

app.Run();
