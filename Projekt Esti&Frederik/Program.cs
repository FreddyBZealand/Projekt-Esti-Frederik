using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<ExamPlannerDBContext>();

            // True for real services, false for test stubs
            if (true)
            {
                builder.Services.AddTransient<IClassService, ClassService>();
                builder.Services.AddTransient<IExamService, ExamService>();
                builder.Services.AddTransient<IDesignationService, DesignationService>();
                builder.Services.AddTransient<ITeacherService, TeacherService>();
            }
            else
            {
                builder.Services.AddTransient<IClassService, ClassServiceTestStub>();
                builder.Services.AddTransient<IExamService, ExamServiceTestStub>();
                builder.Services.AddTransient<IDesignationService, DesignationServiceTestStub>();
                builder.Services.AddTransient<ITeacherService, TeacherServiceTestStub>();
            }


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
