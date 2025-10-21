using ApiProducto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ApiProducto.Database
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Producto> Producto { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dbCreator != null && !dbCreator.CanConnect())
                {
                    dbCreator.Create();
                }
                if (!dbCreator.HasTables())
                {
                    dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
