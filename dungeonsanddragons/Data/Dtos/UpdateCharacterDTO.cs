using dungeonsanddragons.Models;
using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Data.Dtos;

public class UpdateCharacterDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int CharacterClassId { get; set; }
}
