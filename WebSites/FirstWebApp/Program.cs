namespace FirstWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);// builder object that sets up the configuration, services and env needed for web app, it is like preparing the blueprint before building the app

            // Add services to the container.
            builder.Services.AddControllersWithViews();// we are registering the mvc pattern --> Controller :handle logic, Views :display UI

            WebApplication app = builder.Build();// this builds the app using the configuration and services we defined.

            // Configure the HTTP request pipeline.
            // this block runs only in production not in development
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");// redirects to a custom error page if something goes wrong
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();//Enforces HTTPS for security(HTTP STRICT TRANSPORT SECURITY)
            }

            app.UseHttpsRedirection();// redirects all HTTP requests to HTTPS to ensure secure communication
            app.UseRouting();// routing middleware -> enables routing, which is the system that figures out which controller and action to run based on the URL

            app.UseAuthorization();// authorization middleware --> checks whether the user has permission to access certain parts of the app

            app.MapStaticAssets();// static files : this enables serving static files (CSS,JS,images) from the wwwroot folder 

            //specifying what should be valid pattern/url
            // it uses conventional routing ie older routing (mvc default)
            // there is also attribute routing --> webapi by default uses attribure routing
            app.MapControllerRoute(
                name: "default",// name of the route , we can define more than one routes
                pattern: "{controller=Default}/{action=Index}/{id?}")// first part  controller name, second part -> action name, third part -> (?) is optional can be named anything 
                .WithStaticAssets();

            app.Run();// this starts the web application, it begins listening for incoming HTTP requests
        }
    }
}
//localhost:1234/MyCtrl(controller)/MyAction(action)/123(id) <--- this is controller route
//localhost:1234/Employees/Display <--- also valid as id is optional
// if (?) --> not given then it means id becomes compolsary, so if id not given gives 404
// default --> means if we do not write any action then this is the default action it takes
// eg: localhost:1234/Employees --> takes default action as Index

// pattern: "{controller=Default}/{action=Index}/{id?}/{a?}/{b?}/{c?}") very rigid route b/c we cant pass only a single value if we want
// we will use query string then pass in url with named value