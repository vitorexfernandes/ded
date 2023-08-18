using dungeonsanddragons.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace dungeonsanddragons.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private static List<Character> _characterList = new List<Character>();
    private static int SkillId = 0;
    private static List<CharacterClass> _classList = new List<CharacterClass>();
    private static List<CharacterSkill> _classskill = new List<CharacterSkill>();

    //POST METHODS
    //********************************************
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
    public void CreateSkills([FromBody] IEnumerable<CharacterSkill> skills)
    {
        foreach (var skill in skills)
        {
            skill.Id = SkillId++;
            _classskill.Add(skill);
            Console.WriteLine("ID=" + skill.Id);
            Console.WriteLine(skill.Name);
            Console.WriteLine("Valor=" + skill.Value);

        }
    }

    //GET METHODS
    //********************************************
    [HttpGet("GetAllSkills")]
    public IEnumerable<CharacterSkill> GetAllSkills([FromQuery]int skip = 0, [FromQuery] int take = 10)
    {
        return _classskill.Skip(skip).Take(take);
    }
    [HttpGet("GetSkillsById{Id}")]
    public CharacterSkill? GetSkillsById(int Id)
    {
        return _classskill.FirstOrDefault(skill => skill.Id == Id);
    }
}
