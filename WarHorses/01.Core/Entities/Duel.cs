using _01.Core.Enums;

namespace _01.Core.Entities
{
    public class Duel{
        public Guid Id { get; set; } 
        public Guid TournamentId { get; set; } 
        public Guid TeamIdOne { get; set; }
        public Guid TeamIdTwo { get; set; } 
        public StatusDuelEnum  Status  { get; set; } 
        public Guid? WinnerId { get; set; }
    }
}