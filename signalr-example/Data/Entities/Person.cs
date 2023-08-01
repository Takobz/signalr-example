namespace signalr_example.Data.Entities 
{
    public class Person : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}