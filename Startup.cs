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
            //ע�����
            services.AddControllersWithViews();//ʹ��MVC
            //services.AddControllers();//ʹ��API

            services.AddSingleton<IClock, ChinaClock>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            services.Configure<ThreeOptions>(configuration.GetSection("Three"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//�ܵ�
        {
            if (env.IsDevelopment())//����ģʽ
            {
                app.UseDeveloperExceptionPage();//�м��
            }

            app.UseStaticFiles();//��ȡ��̬�ļ��м��

            app.UseHttpsRedirection();//��httpת����https����

            app.UseAuthentication();//Ȩ���м��

            app.UseRouting();//·���м��

            app.UseEndpoints(endpoints =>//�˵��м��
            {
                endpoints.MapControllerRoute("default", "{controller=Department}/{action=Index}/{id?}");//Ĭ��·��
            });
        }
    }
}
