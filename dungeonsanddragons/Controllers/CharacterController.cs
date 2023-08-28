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
public class CharacterController : ControllerBase
{
    private IMapper _mapper;
    private Context _characterContext;

    public CharacterController(Context context, IMapper mapper)
    {
        _characterContext = context;
        _mapper = mapper;
    }

    //POST METHODS
    //********************************************

    /// <summary>
    /// Adds a character to the database
    /// </summary>
    /// <param name="characterDTO">Object with the fields needed to create a character</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">If successful</response>
    [HttpPost("CreateCharacter")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateCharacter([FromBody] CreateCharacterDTO characterDTO)
    {
        Character _character = _mapper.Map<Character>(characterDTO);
        //var characterclassReturn = _characterContext.CharacterClasses.FirstOrDefault(characterclassReturn => characterclassReturn.Id == _character.CharacterClassId);
        //if (characterclassReturn == null) {
        //    return NotFound("Class not found.");
        //}
        //_character.CharacterClass = characterclassReturn;
        _characterContext.Character.Add(_character);
        _characterContext.SaveChanges();
        return CreatedAtAction(nameof(GetCharacterById), new { id = _character.Id }, _character);

    }

    //PUT METHODS
    //********************************************
    /// <summary>
    /// Modify a character in the database
    /// </summary>
    /// <param name="characterDTO">Object with the fields needed to update a character</param>
    /// <param name="Id">Object with the id of the character to update</param>
    /// <returns>IActionResult</returns>
    [HttpPut("UpdateCharacterById{Id}")]
    public IActionResult UpdateCharacter(int Id, [FromBody] UpdateCharacterDTO characterDTO)
    {
        var characterReturn = _characterContext.Character.FirstOrDefault(_character => _character.Id == Id);
        if (characterReturn == null) return NotFound();
        _mapper.Map(characterDTO, characterReturn);
        _characterContext.SaveChanges();
        return CreatedAtAction(nameof(GetCharacterById), new { id = characterReturn.Id }, characterReturn);
    }


    //Patch METHODS
    //********************************************
    /// <summary>
    /// Modify a character in the database
    /// </summary>
    /// <param name="patch">Object with the fields needed to update a character</param>
    /// <param name="Id">Object with the id of the character to update</param>
    /// <returns>IActionResult</returns>
    [HttpPatch("UpdateCharacterById{Id}")]
    public IActionResult UpdateCharacterPatch(int Id, [FromBody] JsonPatchDocument<UpdateCharacterDTO> patch)
    {
        var characterReturn = _characterContext.Character.FirstOrDefault(_character => _character.Id == Id);
        if (characterReturn == null) return NotFound();
        var characterToUpdate = _mapper.Map<UpdateCharacterDTO>(characterReturn);

        patch.ApplyTo(characterToUpdate, ModelState);

        if (!TryValidateModel(characterToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(characterToUpdate, characterReturn);
        _characterContext.SaveChanges();
        return NoContent();
    }

    //GET METHODS
    //********************************************
    /// <summary>
    /// Gets All character from database
    /// </summary>
    /// <param name="skip">Skip values in the search</param>
    /// <param name="take">Takes the requested amount of values</param>
    /// <returns>IEnumerable</returns>
    [HttpGet("GetAllCharacter")]
    public IEnumerable<ReadCharacterDTO> GetAllCharacter([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadCharacterDTO>>(_characterContext.Character.Skip(skip).Take(take));
    }

    /// <summary>
    /// Get a character by ID from database
    /// </summary>
    /// <param name="Id">Object with the id of the character to get</param>
    /// <returns>IActionResult</returns>
    [HttpGet("GetCaracterById{Id}")]
    public IActionResult GetCharacterById(int Id)
    {
        var characterReturn = _characterContext.Character.FirstOrDefault(_character => _character.Id == Id);
        if (characterReturn == null) return NotFound();
        var characterDTO = _mapper.Map<ReadCharacterDTO>(characterReturn);
        return Ok(characterDTO);
    }

    //DELETE METHODS
    //********************************************
    /// <summary>
    /// Delete a character from database
    /// </summary>
    /// <param name="Id">Object with the id of the character to delete</param>
    /// <returns>IActionResult</returns>
    [HttpDelete("DeleteCharacterById{Id}")]
    public IActionResult DeleteCharacter(int Id)
    {
        var characterReturn = _characterContext.CharacterSkills.FirstOrDefault(_character => _character.Id == Id);
        if (characterReturn == null) return NotFound();
        _characterContext.Remove(characterReturn);
        _characterContext.SaveChanges();
        return NoContent();
    }
}
