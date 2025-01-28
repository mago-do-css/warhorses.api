using _01.Core.Enums;

namespace _01.Core.Entities
{
    public class TournamentNotifcication{
        public Guid Id { get; set; } 
        public Guid TournamentId { get; set; } 
        public UserTypeEnum UserType { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}