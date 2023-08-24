using dungeonsanddragons.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace dungeonsanddragons.Data
{
    public class Context : DbContext
    {
        public DbSet<CharacterSkill> CharacterSkills{ get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; }

        public Context(DbContextOptions<Context> opts)
            : base(opts)
        {
                
        }
    }
}
