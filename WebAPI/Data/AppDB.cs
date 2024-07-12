using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Entities;

namespace WebAPI.Data
{
    public class AppDB : DbContext
    {
        public AppDB(DbContextOptions<AppDB> options) :base(options)
        { 
        
        }

        public DbSet<Atividade> Atividades { get; set; }
    }
}
