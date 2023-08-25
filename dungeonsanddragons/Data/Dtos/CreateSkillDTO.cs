using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Data.Dtos;

public class CreateSkillDTO
{
    [Required(ErrorMessage = "Skill Name is required")]
    public string Name{ get; set; }

    public string Description{ get; set; }

}
