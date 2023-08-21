﻿using System.ComponentModel.DataAnnotations;

namespace dungeonsanddragons.Models
{
    public class CharacterSkill
    {
        //Skill Atributes
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Skill Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Skill Value is required")]
        [Range(0, 10, ErrorMessage = "The skill value must be greater than or equal to 0 and less than or equal to 10")]
        public int Value { get; set; }

        


        public CharacterSkill(string name, string description, int value)
        {
            Name = name;
            Description = description;
            Value = value;
        }
    }
}
