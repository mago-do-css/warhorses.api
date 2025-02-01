using _01.Core.Enums;

namespace _01.Core.Entities
{
    public class Tournament{
        public string? Id { get; set; }  = default!; 
        public string? Description { get; set; } 
        public DateTime Date  { get; set; } = default!; 
        public TournamentTypeEnum  Type  { get; set; } = default!; 
    }
}