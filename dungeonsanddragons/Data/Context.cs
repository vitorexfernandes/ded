using dungeonsanddragons.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace dungeonsanddragons.Data
{
    public class Context : DbContext
    {
        public DbSet<CharacterSkill> CharacterSkills{ get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; }
        public DbSet<CharacterClassxSkill> CharacterClassxSkill { get; set; }
        public DbSet<Character> Character { get; set; }

        public Context(DbContextOptions<Context> opts)
            : base(opts)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CharacterClass>()
                .HasMany(characterClass => characterClass.Characters)
                .WithOne(character => character.CharacterClass)
                .HasForeignKey(character => character.CharacterClassId);
        }
    }
}
