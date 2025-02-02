using _01.Core.Enums;

namespace _04.Services.Dto
{
    public class TournamentDto {
        public Guid Id { get; set; }  = default!; 
        public string? Description { get; set; }
        public DateTime Date { get; set; } 
        public TournamentTypeEnum Type { get; set; }
    } 
}