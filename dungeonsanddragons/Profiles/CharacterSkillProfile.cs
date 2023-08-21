﻿using AutoMapper;
using dungeonsanddragons.Data.Dtos;
using dungeonsanddragons.Models;

namespace dungeonsanddragons.Profiles
{
    public class CharacterSkillProfile : Profile
    {
        public CharacterSkillProfile()
        {
            CreateMap<CreateSkillDTO, CharacterSkill>();
        }
    }
}
