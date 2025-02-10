using _01.Core.Entities;
using _01.Core.Enums;
using _02.Data.Infrastructure.FirebaseDto;


public static class TournamentMapper
{
    public static TournamentFirestore ToFirebaseDTO(this Tournament tournament)
    {
        return new TournamentFirestore
        {
            Id = tournament.Id.ToString(),
            Description = tournament.Description,
            Date = tournament.Date,
            Type = (int) tournament.Type
        };
    }

    public static Tournament ToEntity(this TournamentFirestore dto)
    {
        return new Tournament
        {
            Id = Guid.Parse(dto.Id),
            Description = dto.Description,
            Date = dto.Date,
            Type =(TournamentTypeEnum)dto.Type
        };
    }
}
