using _01.Core.Enums; 

namespace _01.Core.Entities
{
    public class Tournament{
        public Guid Id { get; set; } = default!; 
        public string? Description { get; set; } 
        public DateTime Date  { get; set; } = default!; 
        public TournamentTypeEnum  Type  { get; set; } = default!; 
        public bool Active  { get; set; } = default!;
    }
}