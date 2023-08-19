using dungeonsanddragons.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace dungeonsanddragons.Data
{
    public class SkillContext : DbContext
    {
        public DbSet<CharacterSkill> Skills{ get; set; }

        public SkillContext(DbContextOptions<SkillContext> opts)
            : base(opts)
        {
                
        }
    }
}
