using AutoMapper;
using dungeonsanddragons.Data.Dtos;
using dungeonsanddragons.Models;

namespace dungeonsanddragons.Profiles
{
    public class CharacterClassProfile : Profile
    {
        public CharacterClassProfile()
        {
            CreateMap<CreateClassDTO, CharacterClass>();
            CreateMap<UpdateClassDTO, CharacterClass>();
            CreateMap<CharacterClass, UpdateClassDTO>();
            CreateMap<CharacterClass, ReadClassDTO>();
        }
    }
}
