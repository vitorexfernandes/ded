using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Models
{
    public class CharacterClass
    {
        //Class Atributes
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Class Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }



        public CharacterClass(string name)
        {
            Name = name;
        }
    }
}
