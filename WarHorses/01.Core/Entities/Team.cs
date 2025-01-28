using System.ComponentModel.DataAnnotations;
using _01.Core.Enums;

namespace _01.Core.Entities
{
    public class Team{
        public Guid Id { get; set; } 
        public string Name { get; set; } = default!; 
        public string? Description { get; set; }
        public Guid DuelId { get; set; }  
        public string? Color { get; set; }
        public List<Guid> Knights { get; set; } = new List<Guid>();
    }
}