using AutoMapper;
using dungeonsanddragons.Data;
using dungeonsanddragons.Data.Dtos;
using dungeonsanddragons.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace dungeonsanddragons.Controllers;

[ApiController]
[Route("[controller]")]
public class SkillController : ControllerBase
{
    private IMapper _mapper;
    private DDContext _skillContext;

    public SkillController(DDContext context, IMapper mapper)
    {
        _skillContext = context;
        _mapper = mapper;
    }

    //POST METHODS
    //********************************************

    /// <summary>
    /// Adds a skill to the database
    /// </summary>
    /// <param name="skillDTO">Object with the fields needed to create a skill</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">If successful</response>
    [HttpPost("CreateSkill")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateSkill([FromBody] CreateSkillDTO skillDTO)
    {
        CharacterSkill skill = _mapper.Map<CharacterSkill>(skillDTO);
        _skillContext.CharacterSkills.Add(skill);
        _skillContext.SaveChanges();
        return CreatedAtAction(nameof(GetSkillById), new { id = skill.Id }, skill);
    }

    //PUT METHODS
    //********************************************
    /// <summary>
    /// Modify a Skill in the database
    /// </summary>
    /// <param name="skillDTO">Object with the fields needed to update a skill</param>
    /// <param name="Id">Object with the id of the skill to update</param>
    /// <returns>IActionResult</returns>
    [HttpPut("UpdateSkillById{Id}")]
    public IActionResult UpdateSkill(int Id, [FromBody] UpdateSkillDTO skillDTO)
    {
        var skillReturn = _skillContext.CharacterSkills.FirstOrDefault(skill => skill.Id == Id);
        if (skillReturn == null) return NotFound();
        _mapper.Map(skillDTO, skillReturn);
        _skillContext.SaveChanges();
        return CreatedAtAction(nameof(GetSkillById), new { id = skillReturn.Id }, skillReturn);
    }

    //Patch METHODS
    //********************************************
    /// <summary>
    /// Modify a Skill in the database
    /// </summary>
    /// <param name="patch">Object with the fields needed to update a skill</param>
    /// <param name="Id">Object with the id of the skill to update</param>
    /// <returns>IActionResult</returns>
    [HttpPatch("UpdateSkillById{Id}")]
    public IActionResult UpdateSkillPatch(int Id, [FromBody] JsonPatchDocument<UpdateSkillDTO> patch)
    {
        var skillReturn = _skillContext.CharacterSkills.FirstOrDefault(skill => skill.Id == Id);
        if (skillReturn == null) return NotFound();
        var skillToUpdate = _mapper.Map<UpdateSkillDTO>(skillReturn);

        patch.ApplyTo(skillToUpdate, ModelState);

        if (!TryValidateModel(skillToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(skillToUpdate, skillReturn);
        _skillContext.SaveChanges();
        return NoContent();
    }

    //GET METHODS
    //********************************************
    /// <summary>
    /// Gets All Skills from database
    /// </summary>
    /// <param name="skip">Skip values in the search</param>
    /// <param name="take">Takes the requested amount of values</param>
    /// <returns>IEnumerable</returns>
    [HttpGet("GetAllSkills")]
    public IEnumerable<ReadSkillDTO> GetAllSkills([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadSkillDTO>>(_skillContext.CharacterSkills.Skip(skip).Take(take));
    }

    /// <summary>
    /// Get a Skill by ID from database
    /// </summary>
    /// <param name="Id">Object with the id of the skill to get</param>
    /// <returns>IActionResult</returns>
    [HttpGet("GetSkillById{Id}")]
    public IActionResult GetSkillById(int Id)
    {
        var skillReturn = _skillContext.CharacterSkills.FirstOrDefault(skill => skill.Id == Id);
        if (skillReturn == null) return NotFound();
        var skillDTO = _mapper.Map<ReadSkillDTO>(skillReturn);
        return Ok(skillDTO);
    }

    //DELETE METHODS
    //********************************************
    /// <summary>
    /// Delete a Skill from database
    /// </summary>
    /// <param name="Id">Object with the id of the skill to delete</param>
    /// <returns>IActionResult</returns>
    [HttpDelete("DeleteSkillById{Id}")]
    public IActionResult DeleteSkill(int Id)
    {
        var skillReturn = _skillContext.CharacterSkills.FirstOrDefault(skill => skill.Id == Id);
        if (skillReturn == null) return NotFound();
        _skillContext.Remove(skillReturn);
        _skillContext.SaveChanges();
        return NoContent();
    }
}
