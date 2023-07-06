using DbContext;
using RpcClientLib;
using UserServices;

namespace RPC_Client
{
    public class Program
    {
        //https://localhost:8081/_explorer/index.html
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "DefaultPolicy",
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });


            builder.Services.AddScoped<ICosmosContext, CosmosContext>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRpcClient, RpcClient>();
            //builder.Services.AddScoped(RpcClient);
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
            app.UseCors("DefaultPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}