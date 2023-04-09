using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class VstupContext : DbContext
    {
        public VstupContext(DbContextOptions<VstupContext> options) : base(options) { }

        public DbSet<Vstup> Vstup { get; set; }
    }
}
