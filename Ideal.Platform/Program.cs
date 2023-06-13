using Ideal.Platform.Authorization;
using Ideal.Platform.Common.Config;
using Ideal.Platform.Job;

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
    app.UseExceptionHandler("/Home/Error");
}
ConfigClass.Inti();
//TimerJob.StarJob(); 
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
