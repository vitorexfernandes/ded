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
    public IActionResult CreateSkill([FromBody] CharacterSkill skill)
    {
            skill.Id = SkillId++;
            _classskill.Add(skill);
            return CreatedAtAction(nameof(GetSkillsById),new{id = skill.Id},skill);
    }

    //GET METHODS
    //********************************************
    [HttpGet("GetAllSkills")]
    public IEnumerable<CharacterSkill> GetAllSkills([FromQuery]int skip = 0, [FromQuery] int take = 10)
    {
        return _classskill.Skip(skip).Take(take);
    }

    [HttpGet("GetSkillsById{Id}")]
    public IActionResult GetSkillsById(int Id)
    {
        var skillReturn = _classskill.FirstOrDefault(skill => skill.Id == Id);
        if (skillReturn == null) return NotFound();
        return Ok(skillReturn);
    }
}
