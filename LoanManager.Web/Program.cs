using LoanManager.Web.Extensions;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);


builder.RegisterServices();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

