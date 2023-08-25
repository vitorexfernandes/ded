using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Models
{
    public class CharacterSkill
    {
        //Skill Atributes
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Skill Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }
  


        public CharacterSkill(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
