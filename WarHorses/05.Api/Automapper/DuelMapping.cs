using _01.Core.Entities;
using _04.Services.Dto;
using AutoMapper;
namespace _05.Api.Automapper
{
    public class DuelMapping : Profile
    {
        public DuelMapping()
        {
            CreateMap<Duel, DuelDto>();
            CreateMap<DuelDto, Duel>();
        }
    }
}