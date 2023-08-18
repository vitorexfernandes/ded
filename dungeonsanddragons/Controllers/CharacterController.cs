using dungeonsanddragons.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace dungeonsanddragons.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private static List<Character> _characterList = new List<Character>();
    private static List<CharacterClass> _classList = new List<CharacterClass>();
    private static List<CharacterSkill> _classskill = new List<CharacterSkill>();

    [HttpPost("CreateCharacter")]
    public void CreateCharacter([FromBody] Character character)
    {
        _characterList.Add(character);
        Console.WriteLine(character.Id);
        Console.WriteLine(character.Name);

    }
    [HttpPost("CreateClass")]
    public void CreateClass([FromBody] CharacterClass Classes)
    {
        _classList.Add(Classes);
        Console.WriteLine(Classes.Id);
        Console.WriteLine(Classes.Name);

    }
    [HttpPost("CreateSkills")]
    public void CreateSkills([FromBody] List<CharacterSkill> skills)
    {
        foreach (var skill in skills)
        {
            _classskill.Add(skill);
            Console.WriteLine(skill.Id);
            Console.WriteLine(skill.Name);
            Console.WriteLine(skill.Value);
        }
    }

}
