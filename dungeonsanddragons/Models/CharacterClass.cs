using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Models
{
    public class CharacterClass
    {
        [Key]
        public int Id { get; private set; }
        [Required(ErrorMessage = "Class Name is required")]
        public string Name { get; set; }
        


        public CharacterClass(string name)
        {
            Name = name;
        }
    }
}
