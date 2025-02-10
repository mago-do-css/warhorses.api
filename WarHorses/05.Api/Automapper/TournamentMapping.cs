using _01.Core.Entities;
using _04.Services.Dto;
using AutoMapper;
namespace _05.Api.Automapper
{
    public class TournamentMapping : Profile
    {
        public TournamentMapping()
        {
            CreateMap<Tournament, TournamentDto>();
            CreateMap<TournamentDto, Tournament>();
        }
    }
}