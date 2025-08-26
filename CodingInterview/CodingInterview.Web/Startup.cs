namespace CodingInterview.Web;

[ExcludeFromCodeCoverage]
public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        _ = services.AddTransient<ICodingInterviewDao, CodingInterviewDao>();
        _ = services.AddTransient<IInvoiceService, InvoiceService>();
        _ = services.AddTransient<IItemService, ItemService>();
        _ = services.AddTransient<ICustomerService, CustomerService>();

        _ = services.AddControllers().AddNewtonsoftJson(x =>
        {
            x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            x.SerializerSettings.Formatting = Formatting.Indented;
            x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            _ = app.UseDeveloperExceptionPage();
        }

        _ = app.UseHttpsRedirection();
        _ = app.UseRouting();
        _ = app.UseAuthorization();

        _ = app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
