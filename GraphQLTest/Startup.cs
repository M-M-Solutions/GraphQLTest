using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQLTest.Data;
using GraphQLTest.GraphQL;
using GraphQLTest.GraphQL.Message;
using GraphQLTest.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GraphQLTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<SWDbContext>(options =>
               options.UseSqlServer(Configuration["ConnectionStrings:SWTest"]));
            services.AddScoped<CharacterRepository>();

            services.AddScoped<CharacterRepository>();
            services.AddScoped<StarshipRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<CharacterSchema>();
            services.AddSingleton<MessageStarshipService>();

            services.AddGraphQL(o => { o.ExposeExceptions = Environment.IsDevelopment(); })
                 .AddGraphTypes(ServiceLifetime.Scoped).AddUserContextBuilder(httpContext => httpContext.User)
                 .AddDataLoader()
                 .AddWebSockets();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SWDbContext dbContext)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseWebSockets();
            app.UseGraphQLWebSockets<CharacterSchema>("/graphql");
            app.UseGraphQL<CharacterSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            dbContext.Seed();
        }
    }
}
