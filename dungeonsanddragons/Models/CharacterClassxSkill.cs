using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Models
{
    public class CharacterClassxSkill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CharacterClassId { get; set; }
        public CharacterClass CharacterClass { get; set; }

        [Required]
        public int CharacterSkillId { get; set; }
        public CharacterSkill CharacterSkill { get; set; }

        [Range(0, 10, ErrorMessage = "Skill value must be between 0 and 10")]
        public int Value { get; set; } = 0; 

        public CharacterClassxSkill()
        {

        }
    }
}
