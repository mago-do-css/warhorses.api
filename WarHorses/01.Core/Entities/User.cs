namespace _01.Core.Entities{
    public class User{
        public Guid Id;
        public string Name { get; set; } = default!; 
        public string Email { get; set; }  = default!; 
        public string Password { get; set; } = default!; 
        public string Verified { get; set; } = default!; 
    }
}