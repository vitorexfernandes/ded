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
public class ClassController : ControllerBase
{
    //private static List<Character> _characterList = new List<Character>();
    //private static int ClasslId = 0;
    //private static List<CharacterClass> _classList = new List<CharacterClass>();

    private IMapper _mapper;
    private DDContext _classContext;

    public ClassController(DDContext context, IMapper mapper)
    {
        _classContext = context;
        _mapper = mapper;
    }

    //POST METHODS
    //********************************************

    /// <summary>
    /// Adds a class to the database
    /// </summary>
    /// <param name="classDTO">Object with the fields needed to create a class</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">If successful</response>
    [HttpPost("CreateClass")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateClass([FromBody] CreateClassDTO classDTO)
    {
        CharacterClass characterclass = _mapper.Map<CharacterClass>(classDTO);
        _classContext.CharacterClasses.Add(characterclass);
        _classContext.SaveChanges();
        return CreatedAtAction(nameof(GetClassById), new { id = characterclass.Id }, characterclass);
    }

    //PUT METHODS
    //********************************************
    /// <summary>
    /// Modify a class in the database
    /// </summary>
    /// <param name="classDTO">Object with the fields needed to update a class</param>
    /// <param name="Id">Object with the id of the class to update</param>
    /// <returns>IActionResult</returns>
    [HttpPut("UpdateClassById{Id}")]
    public IActionResult UpdateClass(int Id, [FromBody] UpdateClassDTO classDTO)
    {
        var classReturn = _classContext.CharacterClasses.FirstOrDefault(characterclass => characterclass.Id == Id);
        if (classReturn == null) return NotFound();
        _mapper.Map(classDTO, classReturn);
        _classContext.SaveChanges();
        return CreatedAtAction(nameof(GetClassById), new { id = classReturn.Id }, classReturn);
    }

    //Patch METHODS
    //********************************************
    /// <summary>
    /// Modify a class in the database
    /// </summary>
    /// <param name="patch">Object with the fields needed to update a movie</param>
    /// <param name="Id">Object with the id of the class to update</param>
    /// <returns>IActionResult</returns>
    [HttpPatch("UpdateClassById{Id}")]
    public IActionResult UpdateClassPatch(int Id, [FromBody] JsonPatchDocument<UpdateClassDTO> patch)
    {
        var classReturn = _classContext.CharacterClasses.FirstOrDefault(characterclass => characterclass.Id == Id);
        if (classReturn == null) return NotFound();
        var classToUpdate = _mapper.Map<UpdateClassDTO>(classReturn);

        patch.ApplyTo(classToUpdate, ModelState);

        if (!TryValidateModel(classToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(classToUpdate, classReturn);
        _classContext.SaveChanges();
        return NoContent();
    }

    //GET METHODS
    //********************************************
    /// <summary>
    /// Gets All class from database
    /// </summary>
    /// <param name="skip">Skip values in the search</param>
    /// <param name="take">Takes the requested amount of values</param>
    /// <returns>IEnumerable</returns>
    [HttpGet("GetAllClass")]
    public IEnumerable<ReadClassDTO> GetAllClass([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadClassDTO>>(_classContext.CharacterClasses.Skip(skip).Take(take));
    }

    /// <summary>
    /// Get a Class by ID from database
    /// </summary>
    /// <param name="Id">Object with the id of the Class to get</param>
    /// <returns>IActionResult</returns>
    [HttpGet("GetClassById{Id}")]
    public IActionResult GetClassById(int Id)
    {
        var classReturn = _classContext.CharacterClasses.FirstOrDefault(characterclass => characterclass.Id == Id);
        if (classReturn == null) return NotFound();
        var classDTO = _mapper.Map<ReadClassDTO>(classReturn);
        return Ok(classDTO);
    }

    //DELETE METHODS
    //********************************************
    /// <summary>
    /// Delete a Class from database
    /// </summary>
    /// <param name="Id">Object with the id of the class to delete</param>
    /// <returns>IActionResult</returns>
    [HttpDelete("DeleteClassById{Id}")]
    public IActionResult DeleteClass(int Id)
    {
        var classReturn = _classContext.CharacterClasses.FirstOrDefault(characterclass => characterclass.Id == Id);
        if (classReturn == null) return NotFound();
        _classContext.Remove(classReturn);
        _classContext.SaveChanges();
        return NoContent();
    }
}
