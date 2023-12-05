using Ideal.Ideal.Model;
using Ideal.Platform.Authorization;
using Ideal.Platform.Common.Config;
using Ideal.Platform.Common.Data;
using Ideal.Platform.Job;
using Ideal.Platform.Model;
using Ideal.Platform.Service;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

var policyName = "policyCors";
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: policyName, x =>
    {
        x.AllowAnyHeader();
        x.AllowAnyMethod();
        x.AllowAnyOrigin();
    });
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllers(o =>
{
    o.Filters.Add<ApiAuthoriz>();
    o.Filters.Add<Authentiction>();
});
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".Ideal.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(2000);//����session�Ĺ���ʱ��
    options.Cookie.HttpOnly = true;//���������������ͨ��js��ø�cookie��ֵ 

});
var app = builder.Build();
app.UseCors(policyName);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseExceptionHandler(options =>
    {
        options.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var exception = context.Features.Get<IExceptionHandlerFeature>();
            if (exception != null)
            {
                Ideal_LogService ideal_LogService = new Ideal_LogService();
                Ideal_LogModel model = new Ideal_LogModel();
                model.Type = LogType.Error;
                model.StatusCode = context.Response.StatusCode.ToString();
                model.IP = context.Connection.RemoteIpAddress.ToString();
                model.PostInterface = context.Request.Path;
                model.PostType = context.Request.Method.ToString();
                model.LogName = "系统错误";
                model.Detail = exception.Error.Message;
                //model.Creator = context.Request.Headers["userID"];
                ideal_LogService.InsertLog(model);
            }
        });
    });
}
ConfigClass.Inti();
//TimerJob.StarJob(); 
app.UseFileServer();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseSession();
app.UseRouting();
app.UseCookiePolicy();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
