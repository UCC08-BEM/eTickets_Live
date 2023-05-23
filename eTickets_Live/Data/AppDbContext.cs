using Microsoft.EntityFrameworkCore;

namespace eTickets_Live.Data
{
    public class AppDbContext : DbContext 
    {
        // Constructor metodu

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }


    }
}
