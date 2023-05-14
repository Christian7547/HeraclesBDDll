namespace HeraclesDAO.Models
{
    public class Coach : BaseModel
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string CI { get; set; }
        public string Phone { get; set; }   
    }
}