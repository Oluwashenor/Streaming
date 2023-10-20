using Microsoft.EntityFrameworkCore;
using Streaming.API.Models;

namespace Streaming.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<Transcript>? Transcripts { get; set; }
       
    }
}
