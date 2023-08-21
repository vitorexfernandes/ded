using AutoMapper;
using dungeonsanddragons.Data;
using dungeonsanddragons.Data.Dtos;
using dungeonsanddragons.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace dungeonsanddragons.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    //private static List<Character> _characterList = new List<Character>();
    //private static int SkillId = 0;
    //private static List<CharacterClass> _classList = new List<CharacterClass>();

    private IMapper _mapper;
    private SkillContext _skillContext;

    public CharacterController(SkillContext context, IMapper mapper)
    {
        _skillContext = context;
        _mapper = mapper;
    }

    //POST METHODS
    //********************************************
    [HttpPost("CreateSkill")]
    public IActionResult CreateSkill([FromBody] CreateSkillDTO skillDTO)
    {
        CharacterSkill skill = _mapper.Map<CharacterSkill>(skillDTO);
        _skillContext.CharacterSkills.Add(skill);
        _skillContext.SaveChanges();
        return CreatedAtAction(nameof(GetSkillsById),new{id = skill.Id},skill);
    }

    [HttpPut("UpdateSkill{id}")]
    public IActionResult UpdateSkill(int Id, [FromBody] UpdateSkillDTO skillDTO)
    {
        var skillReturn = _skillContext.CharacterSkills.FirstOrDefault(skill => skill.Id == Id);
        if (skillReturn == null) return NotFound();
        _mapper.Map(skillDTO, skillReturn);
        _skillContext.SaveChanges();
        return CreatedAtAction(nameof(GetSkillsById), new { id = skillReturn.Id }, skillReturn);
    }

    //GET METHODS
    //********************************************
    [HttpGet("GetAllSkills")]
    public IEnumerable<CharacterSkill> GetAllSkills([FromQuery]int skip = 0, [FromQuery] int take = 10)
    {
        return _skillContext.CharacterSkills.Skip(skip).Take(take);
    }

    [HttpGet("GetSkillsById{Id}")]
    public IActionResult GetSkillsById(int Id)
    {
        var skillReturn = _skillContext.CharacterSkills.FirstOrDefault(skill => skill.Id == Id);
        if (skillReturn == null) return NotFound();
        return Ok(skillReturn);
    }


}
