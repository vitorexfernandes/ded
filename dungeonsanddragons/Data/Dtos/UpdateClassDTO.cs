﻿using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Data.Dtos;

public class UpdateClassDTO
{
    [Required(ErrorMessage = "Class Name is required")]
    public string Name{ get; set; }

    public string Description{ get; set; }

}
