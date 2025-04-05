using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepServices(this IServiceCollection services)
        {


            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>)); //Burada programa demek istedigimiz şey bir scope icerisinde ilgili Scope'a gelecek parametre generic bir IRepository ise bize generic bir BaseRepository instance'i gönder diyoruz

            //services.AddScoped<INewsRepository, NewsRepository>();
            //services.AddScoped<IContactRepository, ContactRepository>();
            //services.AddScoped<ICommentRepository, CommentRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            //services.AddScoped<IProfileRepository, ProfileRepository>();
            //services.AddScoped<IAdvertRepository, AdvertRepository>();

            return services;



        }



    }
}
