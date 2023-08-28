using AutoMapper;
using dungeonsanddragons.Data.Dtos;
using dungeonsanddragons.Models;

namespace dungeonsanddragons.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CreateCharacterDTO, Character>();
            CreateMap<UpdateCharacterDTO, Character>();
            CreateMap<Character, UpdateCharacterDTO>();
            CreateMap<Character, ReadCharacterDTO>();
        }
    }
}
