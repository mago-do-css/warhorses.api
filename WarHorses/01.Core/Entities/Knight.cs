namespace _01.Core.Entities{
    public class Knight{
        public Guid Id { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
        public int? RankPosition { get; set; }  
    }
}