﻿using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Data.Dtos;

public class UpdateSkillDTO
{
    [Required(ErrorMessage = "Class Name is required")]
    public string Name{ get; set; }

    public string Description{ get; set; }

}
