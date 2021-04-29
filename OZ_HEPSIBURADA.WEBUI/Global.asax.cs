using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using OZ_HEPSIBURADA.IOC;
using OZ_HEPSIBURADA.DAL.Context;
using OZ_HEPSIBURADA.DATA.Model_Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace OZ_HEPSIBURADA.WEBUI
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			Bootstrapper.Initialise();

			ECommerceContext DB = new ECommerceContext();
			DB.Database.CreateIfNotExists();

			// Rol Oluşturma -----------------------------
			RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(DB);
			RoleManager<ApplicationRole> roleManager = new RoleManager<ApplicationRole>(roleStore);

			if (!roleManager.RoleExists("Admin"))
			{
				ApplicationRole adminRole = new ApplicationRole();
				adminRole.Name = "Admin";
				roleManager.Create(adminRole);
			}
			if (!roleManager.RoleExists("User"))
			{
				ApplicationRole userRole = new ApplicationRole();
				userRole.Name = "User";
				roleManager.Create(userRole);
			}

			// Admin Oluşturma -----------------------------
			UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(DB);
			UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

			if (userManager.Users.FirstOrDefault(x => x.Email == "admin@admin.com") == null)
			{
				ApplicationUser admin = new ApplicationUser()
				{
					Email = "admin@admin.com",
					FullName = "Admin Admin",
					UserName = "admin",
					PhoneNumber = "1234567899",
					InvoiceAddress = "none",
					DeliveryAddress = "none"
				};

				userManager.Create(admin, "123456");
				userManager.AddToRole(admin.Id, "Admin");
			}
		}
	}
}