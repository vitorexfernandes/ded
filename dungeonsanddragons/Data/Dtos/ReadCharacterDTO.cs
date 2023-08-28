using dungeonsanddragons.Models;
using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Data.Dtos;

public class ReadCharacterDTO
{
    public string Name { get; set; }
    public int CharacterClassId { get; set; }
    public DateTime RequestHour { get; set; } = DateTime.Now;

}
