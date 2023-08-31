namespace DotNetCoreBoilerplate.Data.DbInitializer
{
    using DotNetCoreBoilerplate.Data;

    public class DatabaseUpdates
    {
        private readonly ApplicationDbContext context;
        public DatabaseUpdates(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Initialize()
        {
            //if (!context.Users.Any())
            //{
            //    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            //    if (true)
            //    {
            //        var MvcControllerInfo = _mvcControllerDiscovery.GetControllers();
            //        var role = new ApplicationRole { Name = "Super Administrator" };

            //        foreach (var controller in MvcControllerInfo)
            //            foreach (var action in controller.Actions)
            //                action.ControllerId = controller.Id;
            //        var accessJson = JsonConvert.SerializeObject(MvcControllerInfo);
            //        role.Access = accessJson;
            //        roleManager.CreateAsync(role);
            //        var adminRole = roleManager.FindByNameAsync("Super Administrator");
            //    }
            //    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            //    var adminUser = new ApplicationUser
            //    {
            //        UserName = "superadmin",
            //        Email = "superadmin",
            //        FirstName = "Super",
            //        LastName = "Admin",
            //        IsActive = true
            //    };

            //    var password = "Admin123!";
            //    var success = userManager.CreateAsync(adminUser, password);
            //    if (success.IsCompleted)
            //    {
            //        userManager.AddToRoleAsync(adminUser, "Super Administrator");
            //        context.SaveChanges();
            //        var user = context.Users.FirstOrDefault(x => x.Email == "superadmin").Id;
            //        context.SaveChanges();
            //    }
            //}
        }
    }
}