
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RopeyDVDs.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RopeyDVDsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RopeyDVDsContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//registering identity services to use identity functionaltiy for handling our database
// to manage the detils of registered user
// to manage user role info
//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<RopeyDVDsContext>();
builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddXmlSerializerFormatters();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//configuring
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NormalUser}/{action=GetActorCopy}/{id?}");

app.Run();
