using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Data.Dtos;

public class UpdateSkillValueDTO
{
    public string SkillName { get; set; }
    public string ClassName { get; set; }
    public int NewValue { get; set; }

}
