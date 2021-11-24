using DiAndSignalRApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DiAndSignalRApp.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Guardian> Guardians { get; set; }
        Task<int> SaveChanges();
    }
}
