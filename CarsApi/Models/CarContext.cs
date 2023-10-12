using Microsoft.EntityFrameworkCore;

namespace CarsApi.Models
{
    //Tools -> Nuget : entityframeworkcore , -||-.tools , pamelo.-||-.mysql
    public class CarContext : DbContext
    {

        public CarContext(DbContextOptions options) : base(options)
        {

        }

        public CarContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=192.168.30.169; database=CarDb; user=root; password=password",
                    ServerVersion.AutoDetect("server=192.168.30.169; database=CarDb; user=root; password=password"));


            }
        }

        public DbSet<Car> Cars { get; set; } = null!;

    }
}
