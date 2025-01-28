using _01.Core.Enums;

namespace _01.Core.Entities
{
    public class Tournament{
        public Guid Id { get; set; }
        public string? Description  { get; set; }
        public DateTime Date  { get; set; }
        public TournamentTypeEnum  Type  { get; set; } 
    }
}