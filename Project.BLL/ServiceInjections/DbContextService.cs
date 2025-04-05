using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    //DbContextPool'umuz böylece StartUp'da DAL'den bir sınıfı kullanmaktan ziyade sadece BLL'deki bu yaratılmıs olan class'ın kurallarıyla bir Service Entegrasyonu yapacaktır...

    public static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            // biz bu noktada aslında bir Core.MVC platformundaki startup dosyasında degiliz...Dolayısıyla oradaki hazır service elimizde yok...Biz o yapıları ayaga kaldırmak adına bir giriş noktasına ihtiyac duyarız...Ve bu giriş noktasını bana ServiceProvider nesnesi saglar...

            ServiceProvider provider = services.BuildServiceProvider();
            //IConfiguration sayesinde projenizin conf.(ayarlamalarının) bulundugu dosyaya ulasabiliyorsunuz...

            IConfiguration? configuration = provider.GetService<IConfiguration>();

            services.AddDbContextPool<MyContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());

            return services;

        }
    }
}
