using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Three.Servies;

namespace Three
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            var three = this.configuration["Three:BoldDepartmentEmployeeCountThreshold"];
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //注册服务
            services.AddControllersWithViews();//使用MVC
            //services.AddControllers();//使用API

            services.AddSingleton<IClock, ChinaClock>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            services.Configure<ThreeOptions>(configuration.GetSection("Three"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//管道
        {
            if (env.IsDevelopment())//开发模式
            {
                app.UseDeveloperExceptionPage();//中间件
            }

            app.UseStaticFiles();//获取静态文件中间件

            app.UseHttpsRedirection();//把http转换成https请求

            app.UseAuthentication();//权限中间件

            app.UseRouting();//路由中间件

            app.UseEndpoints(endpoints =>//端点中间件
            {
                endpoints.MapControllerRoute("default", "{controller=Department}/{action=Index}/{id?}");//默认路由
            });
        }
    }
}
