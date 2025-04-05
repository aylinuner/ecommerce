using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class ManagerService
    {
        public static IServiceCollection AddManagerServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));

            //services.AddScoped<INewsManager, NewsManager>();
            //services.AddScoped<ICategoryManager, CategoryManager>();
            //services.AddScoped<IContactManager, ContactManager>();
            //services.AddScoped<ICommentManager, CommentManager>();
            //services.AddScoped<IAdvertManager, AdvertManager>();
            //services.AddScoped<IProfileManager, ProfileManager>();
            services.AddScoped<IAppUserManager, AppUserManager>();

            return services;
        }

    }
}
