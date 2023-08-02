namespace signalr_example.Data.Entities
{
    public class Product : Entity
    {        
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
    }
}