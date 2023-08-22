using dungeonsanddragons.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace dungeonsanddragons.Data
{
    public class DDContext : DbContext
    {
        public DbSet<CharacterSkill> CharacterSkills{ get; set; }
        public DbSet<CharacterClass> CharacterClasses{ get; set; }

        public DDContext(DbContextOptions<DDContext> opts)
            : base(opts)
        {
                
        }
    }
}
