namespace HeraclesDAO.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; } 
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
