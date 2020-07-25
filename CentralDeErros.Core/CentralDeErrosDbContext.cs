using CentralDeErros.API.Models;
using CentralDeErros.Core.Models;
using CentralDeErros.Core.Models.Maps;
using CentralDeErros.Data.Maps;
using Microsoft.EntityFrameworkCore;


namespace CentralDeErros.Data
{
    public class CentralDeErrosDbContext : DbContext
    {
        public DbSet<Microsservice> Microsservices { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> profiles{ get; set; }
        public DbSet<Environment> Environments { get; set; }


        public CentralDeErrosDbContext(DbContextOptions<CentralDeErrosDbContext> options)
           : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new MicrosserviceMap());

            builder
                .ApplyConfiguration(new OccurrenceMap());

            builder
                .ApplyConfiguration(new ErrorMap());

            builder
                .ApplyConfiguration(new LevelMap());
            
            builder
                .ApplyConfiguration(new UserMap());
            
            builder
                .ApplyConfiguration(new ProfileMap());
            
            builder
                .ApplyConfiguration(new EnvironmentMap());

        }
    }
}
