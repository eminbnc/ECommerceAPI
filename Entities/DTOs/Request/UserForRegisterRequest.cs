namespace Entities.DTOs.Request
{
    public class UserForRegisterRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
    }
}
