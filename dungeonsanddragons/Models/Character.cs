using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CharacterClassId { get; set; }
        public virtual CharacterClass CharacterClass { get; set; }

        public Character()
        {
        }

    }
}
