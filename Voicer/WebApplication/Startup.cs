using AutoMapper;
using BusinessLogicLayer.Abstraction.Repositories;
using BusinessLogicLayer.Abstraction.Services.VotingCommands;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Chat;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
            services.AddControllersWithViews();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddRazorPages();
            services.AddScoped<IVotingRepository, VotingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVotingService, VotingService>();
            services.AddScoped<IVotingOptionRepository, VotingOptionRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();
            services.AddAutoMapper(typeof(VotingMappingProfile));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<VotingDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("SQLite")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //https://voicer.com -> VotingController.Index()
                //https://voicer.com/Home -> HomeController.Index()
                //https://voicer.com/Home/Add -> HomeController.Add()
                //https://voicer.com/Voting/Get -> VotingController.Get()
                //https://voicer.com/Voting/Get/1 -> VotingController.Get(1)
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Voting}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}