using Microsoft.EntityFrameworkCore;
using Web_API.Domain.Entities;

namespace Web_API.Infraestructure.Database
{
    public class MyDBcontext : DbContext
    {
        public MyDBcontext(DbContextOptions<MyDBcontext> options)
            : base(options)
        {

        }


        // TABLAS A MAPEAR EN LA DB:
        public DbSet<Empleado> Empleados { get; set; }

    }
}
